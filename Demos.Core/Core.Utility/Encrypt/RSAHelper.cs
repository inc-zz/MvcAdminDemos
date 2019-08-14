using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Utility
{
    public class RSAHelper
    {
        private RSACryptoServiceProvider _privateKeyRsaProvider;
        private RSACryptoServiceProvider _publicKeyRsaProvider;

        private const string privateKey = @"";
        private const string publicKey = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDAl4nvk8OA0HW+O+GOQCGRJv7AvZatQczZl1TVuAADd8qR7i0ithpReIk+JDo6xlt+GsDKmaYCLcNunkv/CFD3E3D3cT6iVcfnQvnGvp2oCpP1AmYZHfJBbfjlQ3R9vnIdNLnDoFQAcw1o5oWZ7BiL4iZPSNnwapMthuV/X1M73QIDAQAB";

        public RSAHelper()
        {
            _privateKeyRsaProvider = CreateRsaProviderFromPrivateKey(privateKey);
        }

        public RSAHelper(string privateKey)
        {
            _publicKeyRsaProvider = CreateRsaProviderFromPublicKey(publicKey);
        }

        public string Decrypt(string cipherText)
        {
            if (_privateKeyRsaProvider == null)
            {
                throw new Exception("_privateKeyRsaProvider is null");
            }
            return Encoding.UTF8.GetString(_privateKeyRsaProvider.Decrypt(System.Convert.FromBase64String(cipherText), false));
        }

        public string Encrypt(string text)
        {
            if (_publicKeyRsaProvider == null)
            {
                throw new Exception("_publicKeyRsaProvider is null");
            }
            return Convert.ToBase64String(_publicKeyRsaProvider.Encrypt(Encoding.UTF8.GetBytes(text), false));
        }

        private RSACryptoServiceProvider CreateRsaProviderFromPrivateKey(string privateKey)
        {
            var privateKeyBits = System.Convert.FromBase64String(privateKey);

            var RSA = new RSACryptoServiceProvider();
            var RSAparams = new RSAParameters();

            using (BinaryReader binr = new BinaryReader(new MemoryStream(privateKeyBits)))
            {
                byte bt = 0;
                ushort twobytes = 0;
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)
                    binr.ReadByte();
                else if (twobytes == 0x8230)
                    binr.ReadInt16();
                else
                    throw new Exception("Unexpected value read binr.ReadUInt16()");

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102)
                    throw new Exception("Unexpected version");

                bt = binr.ReadByte();
                if (bt != 0x00)
                    throw new Exception("Unexpected value read binr.ReadByte()");

                RSAparams.Modulus = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.Exponent = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.D = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.P = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.Q = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.DP = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.DQ = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.InverseQ = binr.ReadBytes(GetIntegerSize(binr));
            }

            RSA.ImportParameters(RSAparams);
            return RSA;
        }

        private int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();
            else
                if (bt == 0x82)
            {
                highbyte = binr.ReadByte();
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }

        private RSACryptoServiceProvider CreateRsaProviderFromPublicKey(string publicKeyString)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] x509key;
            byte[] seq = new byte[15];
            int x509size;

            x509key = Convert.FromBase64String(publicKeyString);
            x509size = x509key.Length;

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            using (MemoryStream mem = new MemoryStream(x509key))
            {
                using (BinaryReader binr = new BinaryReader(mem))  //wrap Memory Stream with BinaryReader for easy reading
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    seq = binr.ReadBytes(15);       //read the Sequence OID
                    if (!CompareBytearrays(seq, SeqOID))    //make sure Sequence for OID is correct
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8203)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    bt = binr.ReadByte();
                    if (bt != 0x00)     //expect null byte next
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    twobytes = binr.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;

                    if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                        lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                    else if (twobytes == 0x8202)
                    {
                        highbyte = binr.ReadByte(); //advance 2 bytes
                        lowbyte = binr.ReadByte();
                    }
                    else
                        return null;
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                    int modsize = BitConverter.ToInt32(modint, 0);

                    int firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {   //if first byte (highest order) of modulus is zero, don't include it
                        binr.ReadByte();    //skip this null byte
                        modsize -= 1;   //reduce modulus buffer size by 1
                    }

                    byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes

                    if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
                        return null;
                    int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                    byte[] exponent = binr.ReadBytes(expbytes);

                    // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                    RSAParameters RSAKeyInfo = new RSAParameters();
                    RSAKeyInfo.Modulus = modulus;
                    RSAKeyInfo.Exponent = exponent;
                    RSA.ImportParameters(RSAKeyInfo);

                    return RSA;
                }

            }
        }

        private bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }
    }

    public class RSA
    {
        public const string privateKey = "<RSAKeyValue><Modulus>mE8PFoNc6IoMFam4zCquflCkquFB823eNc6lob2yRqSHx8LFMCpttcF2zEZ5I3uSiOGBP8aijTjD8JSk7TvU+EtZfP04hL+nARAGyQM1u+FiabsBOQlkDbOq59dkThmjSPdHw0x/igRdFHe1Uwru4nRbKs1OWczzUsJWWDLV6+0=</Modulus><Exponent>AQAB</Exponent><P>1wBBFlOVkA8O8txRISj9ql8wiuAz3jGTKCaGWnojWqjIhw9W84mPbosrzDS59ZaboVJ2198zRl6jwThR0imR8Q==</P><Q>tVpZRyb1MfLPZsRG0eSV9J05+28DX2FcZWHUCzsVBgJXlBiBaRfgi2eR32a9yNbSZXpqUIr5nbdhXuEP2Yr9vQ==</Q><DP>HvtmZbU9xDinSs/80O57P2XgNOMCFm7Gae7DRZ58IcBYxT2spgOYq7Faal7evUkqvCCKB6meVfGlX16iS8q5wQ==</DP><DQ>FhlGW8dBha6i21D7mEQUidRG5n6mmI7SpYAASMYQT8UlSuSZkGbac+JRAjoQ0lJrHPaH0fy9YhygfuFJ/yZSuQ==</DQ><InverseQ>t9Wr+33I+/wMUuEwzF1MjBZ+LfCIK7HqSxR3kv1oxr1sjq3uQXn+feJQQISNyKM44sNJxWa8TodVbtjwidsmRg==</InverseQ><D>HuqVXnWFy3ISJ+eOqmrThrJp6oHU+EvJ+lQbDOzLnklRgnwHuNIz+NvveGGpv0kbIovbx41Te6UVKOWTYNBvVzLH3EqernsNJTGvJrBn5lwsBhS1OWYc6ajGBL4Z0yf7v5eHJxJPnCuXEE1XxksOUArZAhvlcTRHj7Wp+ETPwcE=</D></RSAKeyValue>";

        public const string publicKey = "<RSAKeyValue><Modulus>mE8PFoNc6IoMFam4zCquflCkquFB823eNc6lob2yRqSHx8LFMCpttcF2zEZ5I3uSiOGBP8aijTjD8JSk7TvU+EtZfP04hL+nARAGyQM1u+FiabsBOQlkDbOq59dkThmjSPdHw0x/igRdFHe1Uwru4nRbKs1OWczzUsJWWDLV6+0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        #region MyRegion

        // RSA 加密(不限长度)
        public static string Crypt(string s, string publicKey)
        {
            if (s == null || s == string.Empty)
                return "";

            byte[] DataToEncrypt;
            byte[] EncryptedData;

            try
            {
                DataToEncrypt = System.Text.Encoding.UTF8.GetBytes(s);

                System.Security.Cryptography.RSACryptoServiceProvider.UseMachineKeyStore = true;
                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
                RSA.FromXmlString(publicKey);


                int keySize = RSA.KeySize / 8;

                int bufferSize = keySize - 11;

                byte[] buffer = new byte[bufferSize - 1];

                System.IO.MemoryStream msInput = new System.IO.MemoryStream(DataToEncrypt);

                System.IO.MemoryStream msOutput = new System.IO.MemoryStream();

                int readLen = msInput.Read(buffer, 0, bufferSize);

                while ((readLen > 0))
                {
                    byte[] dataToEnc = new byte[readLen - 1];
                    Array.Copy(buffer, 0, dataToEnc, 0, readLen);

                    byte[] encData = RSA.Encrypt(dataToEnc, false);
                    msOutput.Write(encData, 0, encData.Length);
                    readLen = msInput.Read(buffer, 0, bufferSize);
                }

                msInput.Close();
                EncryptedData = msOutput.ToArray();
                //得到加密结果
                msOutput.Close();

                RSA.Clear();
            }
            catch
            {
                return "";
            }

            return Convert.ToBase64String(EncryptedData);
        }

        // RSA解密(不限长度)
        public static string Decrypt(string s, string privateKey)
        {
            if (s == null || s == string.Empty)
                return "";

            byte[] DataToDecrypt;
            byte[] DecryptedData;

            try
            {
                DataToDecrypt = Convert.FromBase64String(s);

                System.Security.Cryptography.RSACryptoServiceProvider.UseMachineKeyStore = true;
                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
                RSA.FromXmlString(privateKey);

                int keySize = RSA.KeySize / 8;
                byte[] buffer = new byte[keySize - 1];

                System.IO.MemoryStream msInput = new System.IO.MemoryStream(DataToDecrypt);
                System.IO.MemoryStream msOutput = new System.IO.MemoryStream();
                int readLen = msInput.Read(buffer, 0, keySize);

                while ((readLen > 0))
                {
                    byte[] dataToDec = new byte[readLen - 1];
                    Array.Copy(buffer, 0, dataToDec, 0, readLen);

                    byte[] decData = RSA.Decrypt(dataToDec, false);
                    msOutput.Write(decData, 0, decData.Length);
                    readLen = msInput.Read(buffer, 0, keySize);
                }

                msInput.Close();

                DecryptedData = msOutput.ToArray();
                //得到解密结果

                msOutput.Close();

                RSA.Clear();
            }
            catch
            {
                return "";
            }

            return System.Text.Encoding.UTF8.GetString(DecryptedData);
        }

        //RSA 加密
        public static string Crypt(string s)
        {
            if (s == null || s.Length == 0)
                return "";

            byte[] b;
            RSACryptoServiceProvider.UseMachineKeyStore = true;
            RSACryptoServiceProvider rsaEnc = new RSACryptoServiceProvider();

            rsaEnc.FromXmlString(publicKey);

            try
            {
                b = rsaEnc.Encrypt(Encoding.UTF8.GetBytes(s), false);
            }
            catch
            {
                return "";
            }

            return Convert.ToBase64String(b);
        }

        //RSA 解密
        public static string Decrypt(string s)
        {
            if (s == null || s.Length == 0)
                return "";

            byte[] b;
            b = Convert.FromBase64String(s);

            RSACryptoServiceProvider.UseMachineKeyStore = true;
            RSACryptoServiceProvider rsaDec = new RSACryptoServiceProvider();
            rsaDec.FromXmlString(privateKey);

            try
            {
                b = rsaDec.Decrypt(b, false);
            }
            catch
            {
                return "";
            }

            return Encoding.UTF8.GetString(b);
        }

        #endregion

        //获取RSA密钥对，isCreateNew为true表示创建新密钥，为false时，只提供公钥
        public static IDictionary GetRSAKey(bool isCreateNew)
        {
            Hashtable Rtn = new Hashtable();
            if (isCreateNew)
            {
                RSACryptoServiceProvider.UseMachineKeyStore = true;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
                Rtn.Add("PublicKey", rsa.ToXmlString(false));
                Rtn.Add("PrivateKey", rsa.ToXmlString(true));
            }
            else
            {
                Rtn.Add("PublicKey", publicKey);
                Rtn.Add("PrivateKey", privateKey);
            }
            return Rtn;
        }

        public static void RebuildRSAKey()
        {
            HttpContext.Current.Application.Set("RSAKey", GetRSAKey(true));
        }

        public static string GetApplicationPrivateKey()
        {
            Hashtable Rtn = (Hashtable)HttpContext.Current.Application.Get("RSAKey");
            if (Rtn != null)
            {
                return Rtn["PrivateKey"].ToString();
            }
            return privateKey;
        }

        public static string GetApplicationPublicKey()
        {
            Hashtable Rtn = (Hashtable)HttpContext.Current.Application.Get("RSAKey");
            if (Rtn != null)
            {
                return Rtn["PublicKey"].ToString();
            }
            return publicKey;
        }
    }
}