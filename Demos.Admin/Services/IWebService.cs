
using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TZ.Infrastructure;
using TZ.Models;
using TZ.Modules.PTS.Extensions;
using TZ.Modules.PTS.Models;
using TZ.Modules.PTS.Repositories;
using TZ.Services;
using TZ.ModulesPTS.Models;
using TZ.ModulesPTS.Core;

namespace TZ.Modules.PTSUI.Services
{

    public partial interface IWebService
    {

        #region 通用信息
        ResponseData ProcessData(RequestData requestData);

        #endregion

        #region 公司信息

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Lid"></param>
        /// <returns></returns>
        CoInfo GetCoInfo(Guid Lid);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ModelResult<CoInfo> SaveCoInfo(CoInfo model);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ModelResult<CoInfo> AddCoInfo(CoInfo model);
        /// <summary>
        ///  获取分页信息
        /// </summary>
        /// <param name="pagingInfo"></param>
        /// <returns></returns>
        IPageOfItems<CoInfo> GetCoInfosList(PagingInfo pagingInfo);


        #endregion

        #region  商品

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Lid"></param>
        /// <returns></returns>
        CntItem GetCntItem(Guid Lid);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ModelResult<CntItem> SaveCntProduct(CntItem model);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ModelResult<CntItem> AddCntProduct(CntItem model);
        /// <summary>
        ///  获取分页信息
        /// </summary>
        /// <param name="pagingInfo"></param>
        /// <returns></returns>
        IPageOfItems<CntItem> GetCntItemList(PagingInfo pagingInfo);


        #endregion

        #region 通用
        /// <summary>
        /// 取得要申报的资料(备案资料库申请与变更，手册申请与变更)
        /// </summary>
        /// <returns></returns>
        LAO GetLAO(string DocType, string DocNo);

        /// <summary>
        /// 取得要申报的资料(手册核销的申请)
        /// </summary>
        /// <param name="DocNo"></param>
        /// <returns></returns>
        LEO GetLEO(string DocNo);

        #endregion

        #region 备案资料库


        IPageOfItems<LAOMaster> GetLAOMastersList(PagingInfo pagingInfo);
        LAOMaster GetLAOMaster(Guid LID);

        IPageOfItems<LAODetail1> GetLAODetail1sList(PagingInfo pagingInfo);
        IPageOfItems<LAODetail2> GetLAODetail2sList(PagingInfo pagingInfo);
        LAODetail1 GetLAODetail1(Guid LID);
        LAODetail2 GetLAODetail2(Guid LID);
        ModelResult<LAOMaster> SaveLAOMaster(LAOMaster model);
        ModelResult<LAOMaster> AddLAOMaster(LAOMaster model);
        ModelResult<LAODetail1> SaveLAODetail1(LAODetail1 model);
        ModelResult<LAODetail1> AddLAODetail1(LAODetail1 model);
        ModelResult<LAODetail2> SaveLAODetail2(LAODetail2 model);
        ModelResult<LAODetail2> AddLAODetail2(LAODetail2 model);
        #endregion

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="Lid"></param>
        /// <returns></returns>
        CntHead GetCntHead(Guid Lid);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ModelResult<CntHead> SaveCntHead(CntHead model);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ModelResult<CntHead> AddCntHead(CntHead model);
        /// <summary>
        ///  获取分页信息
        /// </summary>
        /// <param name="pagingInfo"></param>
        /// <returns></returns>
        IPageOfItems<CntHead> GetCntHeadsList(PagingInfo pagingInfo);

        string AutoGenLAONo();
        bool RemoveLAODetail1(LAODetail1 model);
        bool RemoveLAODetail2(LAODetail2 model);
        bool IsExists();
        bool IsExistsByLAODetail1(string DocNo);

        bool IsExistsByLAODetail2(string DocNo);
        IPageOfItems<LDHead> GetLDHeadsList(PagingInfo pagingInfo);

        LDHead GetLDHead();

        #region 公用代码
        IPageOfItems<PubCodes> GetPubCodessList(PagingInfo pagingInfo);

        IPageOfItems<PubCodeClasses> GetPubCodeClassessList(PagingInfo pagingInfo);

        #endregion

        #region 核注方式
        IPageOfItems<MODEBILLCLASS> GetMODEBILLCLASSsList(PagingInfo pagingInfo);
        #endregion

        #region 海关商品
        IPageOfItems<HS> GetHSsList(PagingInfo pagingInfo);
        #endregion

        #region 工厂商品
        ModelResult<FactGoods> AddFactGoods(FactGoods model);
        ModelResult<FactGoods> SaveFactGoods(FactGoods model);
        IPageOfItems<FactGoods> GetFactGoodssList(PagingInfo pagingInfo);
        bool RemoveFactGoods(FactGoods model);


        FactGoods GetFactGoods(Guid FID);

        #endregion

        #region 客户和供应商
        IPageOfItems<Customer> GetCustomersList(PagingInfo pagingInfo);
        ModelResult<Customer> SaveCustomer(Customer model);
        ModelResult<Customer> AddCustomer(Customer model);
        Customer GetCustomer(Guid CID);
        bool RemoveCustomer(Customer model);

        IPageOfItems<ViewCustomerAndPub> GetViewCustomerAndPubsList(PagingInfo pagingInfo);
        IPageOfItems<ViewFactGoodsAndPub> GetViewFactGoodsAndPubsList(PagingInfo pagingInfo);
        #endregion


        #region 归并关系模块依赖
        IPageOfItems<LDItem> GetLDItemsList(PagingInfo pagingInfo);
        IPageOfItems<ViewNotJoinFactGoods> GetViewNotJoinFactGoodssList(PagingInfo pagingInfo);
        IPageOfItems<ViewJoinFactGoods> GetViewJoinFactGoodssList(PagingInfo pagingInfo);
        bool RemoveInvJoinDC(InvJoinDC model);
        IPageOfItems<InvJoinDC> GetInvJoinDCsList(PagingInfo pagingInfo);

        IPageOfItems<ViewUploadInvJoinDCExcel> GetViewUploadInvJoinDCExcelsList(PagingInfo pagingInfo);
        #endregion
        bool AddInvJoinDCList(List<InvJoinDC> models);
        ModelResult<InvJoinDC> SaveInvJoinDC(InvJoinDC model);


        #region 工厂Bom模块
        int GetMaxDocItemNoByBom(string FieldName, string TableName);

        IPageOfItems<BomMaster> GeBomMastersList(PagingInfo pagingInfo);
        BomMaster GeBomMaster(Guid TID);
        ModelResult<BomMaster> SaveBomMaster(BomMaster model);
        ModelResult<BomMaster> AddBomMaster(BomMaster model);
        ModelResult<Bom> AddBom(Bom model);
        IPageOfItems<ViewBomJoinFactGoods> GetViewBomJoinFactGoodssList(PagingInfo pagingInfo);
        bool RemoveBom(Bom model);
        IPageOfItems<Bom> GetBomsList(PagingInfo pagingInfo);
        ModelResult<Bom> SaveBom(Bom model);
        IPageOfItems<BomMaster> GetBomMastersList(PagingInfo pagingInfo);

        bool RemoveBomMaster(string ParentPartNo);
        List<TreeBom> GetTreeBomsList(string ParentPartNo);
        #endregion

        #region 进出口通知单
        IPageOfItems<TNMaster> GetTNMastersList(PagingInfo pagingInfo);

        bool RemoveTNMaster(TNMaster model);
        TNMaster GetTNMaster(Guid TID);

        bool RemoveTNDetail(TNDetail model);
        TNDetail GetTNDetail(Guid TID);
        ModelResult<TNMaster> SaveTNMaster(TNMaster model);

        ModelResult<TNMaster> AddTNMaster(TNMaster model);

        IPageOfItems<TNDetail> GetTNDetailsList(PagingInfo pagingInfo);
        #endregion
        string AutoGenTNNo();

        Decimal GetSumTNMaster(string fieldName, string DocNo);
        ModelResult<TNDetail> SaveTNDetail(TNDetail model);
        ModelResult<TNDetail> AddTNDetail(TNDetail model);

        IPageOfItems<TreeBom> GetTreeBomsList(PagingInfo pagingInfo, string ParentPartNo, int ExpandType = 2, int ParentQty = 0, string WithWP = "Y");

        IPageOfItems<FactStore> GetFactStoresList(PagingInfo pagingInfo);

        IPageOfItems<FactStore2> GetFactStore2sList(PagingInfo pagingInfo);

        string AutoGenDocNo(string tableName);
        ModelResult<FactStore> AddFactStore(FactStore model);

        ModelResult<FactStore2> AddFactStore2(FactStore2 model);
        bool RemoveFactStore(PagingInfo pagingInfo);
        bool RemoveFactStore2(FactStore2 model);
        bool RemoveFactStore2(PagingInfo pagingInfo);

        bool AddFactGoodsList(System.Collections.Generic.List<FactGoods> models);

        bool AddFactStoreList(FactStore _FactStore, List<FactStore2> models);

        bool AddBomList(List<Bom> models);

        bool AddTNList(TNMaster _TNMaster, List<TNDetail> models);

        bool AddCustomerList(List<Customer> models);

        bool AddLDItemList(List<LDItem> models);

        IPageOfItems<CntBillMaster> GetCntBillMastersList(PagingInfo pagingInfo);

        IPageOfItems<CntBillMaster1> GetCntBillMastersList_SP(string ErpDocNo, PagingInfo pagingInfo);

        HS GetHS(Guid HID);

        ModelResult<HS> SaveHS(HS model);

        ModelResult<HS> AddHS(HS model);

        bool RemoveLAOMaster(PagingInfo pagingInfo);

        IPageOfItems<ViewCntBillMasterJoinCntBillDetail> GetViewCntBillMasterJoinCntBillDetailsList(PagingInfo pagingInfo);

        IPageOfItems<ViewCntBillSummary> GetViewCntBillSummarysList(PagingInfo pagingInfo, string Summary);

        IPageOfItems<ViewCntBillSummaryGroupByUnitPrice> GetViewCntBillSummaryGroupByUnitPricesList(PagingInfo pagingInfo);

        decimal GetSumBalanceInvQty(int LDSeq);

        decimal GetERPInventory(string DocNo, int LDSeq);

        bool RemoveHS(HS model);

        IPageOfItems<DAClass> GetDAClasssList(PagingInfo pagingInfo);

        ModelResult<LAODetail4> AddLAODetail4(LAODetail4 model);

        IPageOfItems<LAODetail4> GetLAODetail4sList(PagingInfo pagingInfo);

        ModelResult<LAODetail4> SaveLAODetail4(LAODetail4 model);

        LAODetail4 GetLAODetail4(Guid LID);

        bool RemoveLAODetail4(LAODetail4 model);
        ModelResult<LEODetail4> AddLEODetail4(LEODetail4 model);

        IPageOfItems<LEODetail4> GetLEODetail4sList(PagingInfo pagingInfo);

        ModelResult<LEODetail4> SaveLEODetail4(LEODetail4 model);

        LEODetail4 GetLEODetail4(Guid LID);

        bool RemoveLEODetail4(LEODetail4 model);

        IPageOfItems<LEOMaster> GetLEOMastersList(PagingInfo pagingInfo);

        Result ConvertToDec(string docNo, string strDCType, CntBillMaster objCntBillMaster, UserInfo objUserInfo,int DecType, ref string DecID);

        IPageOfItems<CustomsInventory> GetCustomsInventoryList(PagingInfo pagingInfo, bool UserAdvanced, ref List<CntHead> objCntHeaders);

        /// <summary>
        /// 根据单证号获取报关单信息
        /// </summary>
        /// <param name="arrayDocNo"></param>
        /// <returns></returns>
        CntBillMasterOrCntBillDetail GetCntBillMasterOrCntBillDetailList(string arrayDCBillNo);
        ModelResult<CntBillMaster> AddCntBillMaster(CntBillMaster model);
        ModelResult<CntBillMaster> SaveCntBillMaster(CntBillMaster model);
        ModelResult<CntBillDetail> SaveCntBillDetail(CntBillDetail model);
        ModelResult<CntBillDetail> AddCntBillDetail(CntBillDetail model);

        /// <summary>
        /// 取得系统申报资料。
        /// </summary>
        LAO GetLaoInfo(string DocNo, string dcType);

        /// <summary>
        /// 更新手册申报更新状态
        /// </summary>
        bool UpdateLAOMasterState(string DocNo, string dcType);

        ModelResult<LDHead> AddLDHead(LDHead model);

        CoInfo GetCoInfoInfoOne();

        /// <summary>
        /// 根据编号删除报关单主从表信息
        /// </summary>
        /// <param name="docNo"></param>
        /// <returns></returns>
        string DelCntBillInfo(string docNo);

        /// <summary>
        /// 自动生成系统单号
        /// </summary>
        /// <returns></returns>
        string AutoGenCntBillNo();

        List<PubCodes> GetPubCodes();

        /// <summary>
        /// 根据编号删除报关单从表信息
        /// </summary>
        /// <param name="docNo"></param>
        /// <returns></returns>
        void DelCntBillDetailInfo(string docNo);

        ModelResult<InvJoinDC> AddInvJoinDC(InvJoinDC model);


        /// <summary>
        /// 根据手册号获取手册信息
        /// </summary>
        /// <param name="lcNo"></param>
        /// <returns></returns>
        CntHead GetCntHeadLcNo(string lcNo);


        /// <summary>
        /// 取得要核销手册信息
        /// </summary>
        /// <param name="DocNo">手册号</param>
        /// <returns></returns>
        LEO GetLEOInfo(string DocNo);

        /// <summary>
        /// 更新手册核销申报状态
        /// </summary>
        bool UpdateLEOMasterState(string DocNo);

        int GetMaxId(string FieldName, string TableName, string whereFieldName, string whereValue);

        IPageOfItems<ViewLDBomJoinLDMItem> GetViewLDBomJoinLDMItemsList(PagingInfo pagingInfo);
        ModelResult<LDBom> AddLDBom(LDBom model);
        bool RemoveLDBom(PagingInfo pagingInfo);
        IPageOfItems<LDBom> GetLDBomsList(PagingInfo pagingInfo);
        ModelResult<LDBom> SaveLDBom(LDBom model);

        LRO GetLROInfo(string docNo);

        IPageOfItems<CntBillDetail> GetCntBillDetailsList(PagingInfo pagingInfo);

        bool SqlServerTransactionAddCustomerList(List<Customer> models);

        bool SqlServerTransactionAddFactGoodsList(List<FactGoods> models);

        bool SqlServerTransactionAddFactStoreList(FactStore _FactStore, List<FactStore2> models);

        bool SqlServerTransactionAddErpBillList(ErpBillMaster _ErpBillMaster, List<ErpBillDetail> models);

        IPageOfItems<ErpBillMaster> GetErpBillMastersList(PagingInfo pagingInfo);

        IPageOfItems<ErpBillDetail> GetErpBillDetailsList(PagingInfo pagingInfo);

        IEnumerable<LAODetail4> GetLAODetail4DocNoList(string docNo, string dCType);

        CntBillMaster GetCntBillMaster(Guid TID);

        CntBillDetail GetCntBillDetail(Guid TID);

        bool RemoveCntBillDetail(CntBillDetail model);

        bool RemoveCntBillMaster(PagingInfo pagingInfo);

        ErpBillMaster GetErpBillMaster(Guid EID);

        ModelResult<ErpBillMaster> SaveErpBillMaster(ErpBillMaster model);

        IPageOfItems<BusinessCost> GetBusinessCostsList(PagingInfo pagingInfo);

        BusinessCost GetBusinessCost(Guid BID);

        ModelResult<BusinessCost> SaveBusinessCost(BusinessCost model);

        ModelResult<BusinessCost> AddBusinessCost(BusinessCost model);

        bool RemoveBusinessCost(BusinessCost model);

        IPageOfItems<ErpAndFactGoods> GetErpAndFactGoodsList(PagingInfo pagingInfo);

        ModelResult<ReceiptLog> AddReceiptLog(ReceiptLog model);

        IPageOfItems<CnBom> GetCnBomsList(PagingInfo pagingInfo);
        IPageOfItems<CntBomAndItem> GetCntBomAndItemList(PagingInfo pagingInfo);

        IPageOfItems<MODEBILLHEADINPUT> GetMODEBILLHEADINPUTsList(PagingInfo pagingInfo);
    }

}