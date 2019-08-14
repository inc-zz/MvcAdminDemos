
using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TZ.Infrastructure;
using TZ.Models;
using TZ.Modules.PTS.Extensions;
using TZ.Modules.PTS.Services;
using TZ.Modules.PTS.Models;
using TZ.Modules.PTS.Repositories;
using TZ.Services;
using TZ.Validation;
using System.IO;
using System.Xml.Linq;

using System.Xml;
using TZ.Extensions;
using TZ.ModulesPTS.Models;

namespace TZ.Modules.PTSUI.Services
{
    public partial class WebService : IWebService
    {
        public ICommonService iCommmonService;
        public ICntHeadService iCntHeadService;
        public ICntItemService iCntItemService;
        public ICoInfoService iCoInfoService;

        public IPubCodesService iPubCodesService;
        public IHSService iHSService;
        public IFactGoodsService iFactGoodsService;
        public ICustomerService iCustomerService;
        public IPubCodeClassesService iPubCodeClassesService;
        //      
        public ILAOMasterService iLAOMasterService;
        public ILAODetail1Service iLAODetail1Service;
        public ILAODetail2Service iLAODetail2Service;
        public ILAODetail3Service iLAODetail3Service;
        public ILAODetail4Service iLAODetail4Service;
        //
        public ILEOMasterService iLEOMasterService;
        public ILEODetail1Service iLEODetail1Service;
        public ILEODetail2Service iLEODetail2Service;
        public ILEODetail3Service iLEODetail3Service;
        public ILEODetail4Service iLEODetail4Service;
        //
        public ILDHeadService iLDHeadService;

        //

        public IInvJoinDCService iInvJoinDCService;
        public ILDItemService iLDItemService;
        public IViewNotJoinFactGoodsService iViewNotJoinFactGoodsService;
        public IViewJoinFactGoodsService iViewJoinFactGoodsService;
        public IViewCustomerAndPubService iViewCustomerAndPubService;
        public IViewFactGoodsAndPubService iViewFactGoodsAndPubService;
        public IBomService iBomService;
        public IBomMasterService iBomMasterService;
        public IViewBomJoinFactGoodsService iViewBomJoinFactGoodsService;
        public ITNMasterService iTNMasterService;
        public ITNDetailService iTNDetailService;
        public IFactStoreService iFactStoreService;
        public IFactStore2Service iFactStore2Service;
        public ICntBillMasterService iCntBillMasterService;
        public ICntBillDetailService iCntBillDetailService;
        public IViewCntBillMasterJoinCntBillDetailService iViewCntBillMasterJoinCntBillDetailService;
        public IViewCntBillSummaryService iViewCntBillSummaryService;
        public IViewCntBillSummaryGroupByUnitPriceService iViewCntBillSummaryGroupByUnitPriceService;
        public IDAClassService iDAClassService;
        public IViewUploadInvJoinDCExcelService iViewUploadInvJoinDCExcelService;
        public IViewLDBomJoinLDMItemService iViewLDBomJoinLDMItemService;
        public ILDBomService iLDBomService;
        public ILROMasterService iLROMasterService;
        public IErpBillMasterService iErpBillMasterService;
        public IErpBillDetailService iErpBillDetailService;
        public IBusinessCostService iBusinessCostService;
        public IReceiptLogService iReceiptLogService;
        public ICnBomService iCnBomService;
        public IMODEBILLHEADINPUTService iMODEBILLHEADINPUTService;

        public IMODEBILLCLASSService iMODEBILLCLASSService;

        public WebService(
            ICommonService iCommmonService,
            ICntHeadService iCntHeadService,
            ICntItemService iCntItemService,
            ICoInfoService iCoInfoService,
            IPubCodesService iPubCodesService,
            IHSService iHSService,
            IFactGoodsService iFactGoodsService,
            ICustomerService iCustomerService,
            IPubCodeClassesService iPubCodeClassesService,
            ILAOMasterService iLAOMasterService,
            ILAODetail1Service iLAODetail1Service,
            ILAODetail2Service iLAODetail2Service,
            ILAODetail3Service iLAODetail3Service,
            ILAODetail4Service iLAODetail4Service,
            ILEOMasterService iLEOMasterService,
            ILEODetail1Service iLEODetail1Service,
            ILEODetail2Service iLEODetail2Service,
            ILEODetail3Service iLEODetail3Service,
            ILEODetail4Service iLEODetail4Service,
            ILDHeadService iLDHeadService,
            ILDItemService iLDItemService,
            IViewNotJoinFactGoodsService iViewNotJoinFactGoodsService,
            IViewJoinFactGoodsService iViewJoinFactGoodsService,
            IInvJoinDCService iInvJoinDCService,
            IViewCustomerAndPubService iViewCustomerAndPubService,
            IViewFactGoodsAndPubService iViewFactGoodsAndPubService,
            IBomService iBomService,
            IBomMasterService iBomMasterService,
            IViewBomJoinFactGoodsService iViewBomJoinFactGoodsService,
            ITNMasterService iTNMasterService,
            ITNDetailService iTNDetailService,
            IFactStoreService iFactStoreService,
            IFactStore2Service iFactStore2Service,
            ICntBillMasterService iCntBillMasterService,
            IViewCntBillMasterJoinCntBillDetailService iViewCntBillMasterJoinCntBillDetailService,
            IViewCntBillSummaryService iViewCntBillSummaryService,
            IViewCntBillSummaryGroupByUnitPriceService iViewCntBillSummaryGroupByUnitPriceService,
            IDAClassService iDAClassService,
            ICntBillDetailService iCntBillDetailService,
            IViewUploadInvJoinDCExcelService iViewUploadInvJoinDCExcelService,
            IViewLDBomJoinLDMItemService iViewLDBomJoinLDMItemService,
            ILDBomService iLDBomService,
            ILROMasterService iLROMasterService,
            IErpBillMasterService iErpBillMasterService,
            IErpBillDetailService iErpBillDetailService,
            IBusinessCostService iBusinessCostService,
            IReceiptLogService iReceiptLogService,
            ICnBomService iCnBomService,
            IMODEBILLHEADINPUTService iMODEBILLHEADINPUTService,
            IMODEBILLCLASSService iMODEBILLCLASSService
            )
        {
            this.iCommmonService = iCommmonService;
            this.iCntHeadService = iCntHeadService;
            this.iCntItemService = iCntItemService;
            this.iCoInfoService = iCoInfoService;

            this.iFactGoodsService = iFactGoodsService;
            this.iCustomerService = iCustomerService;
            this.iPubCodeClassesService = iPubCodeClassesService;

            this.iPubCodesService = iPubCodesService;
            this.iHSService = iHSService;
            //
            this.iLAOMasterService = iLAOMasterService;
            this.iLAODetail1Service = iLAODetail1Service;
            this.iLAODetail2Service = iLAODetail2Service;
            this.iLAODetail3Service = iLAODetail3Service;
            this.iLAODetail4Service = iLAODetail4Service;
            //
            this.iLEOMasterService = iLEOMasterService;
            this.iLEODetail1Service = iLEODetail1Service;
            this.iLEODetail2Service = iLEODetail2Service;
            this.iLEODetail3Service = iLEODetail3Service;
            this.iLEODetail4Service = iLEODetail4Service;
            //
            this.iLDHeadService = iLDHeadService;
            this.iLDItemService = iLDItemService;
            this.iViewNotJoinFactGoodsService = iViewNotJoinFactGoodsService;
            this.iViewJoinFactGoodsService = iViewJoinFactGoodsService;
            this.iInvJoinDCService = iInvJoinDCService;
            this.iViewCustomerAndPubService = iViewCustomerAndPubService;
            this.iViewFactGoodsAndPubService = iViewFactGoodsAndPubService;
            this.iBomService = iBomService;
            this.iBomMasterService = iBomMasterService;
            this.iViewBomJoinFactGoodsService = iViewBomJoinFactGoodsService;
            this.iTNMasterService = iTNMasterService;
            this.iTNDetailService = iTNDetailService;
            this.iFactStoreService = iFactStoreService;
            this.iFactStore2Service = iFactStore2Service;
            this.iCntBillMasterService = iCntBillMasterService;
            this.iViewCntBillMasterJoinCntBillDetailService = iViewCntBillMasterJoinCntBillDetailService;
            this.iViewCntBillSummaryService = iViewCntBillSummaryService;
            this.iViewCntBillSummaryGroupByUnitPriceService = iViewCntBillSummaryGroupByUnitPriceService;
            this.iDAClassService = iDAClassService;
            this.iCntBillDetailService = iCntBillDetailService;
            this.iViewUploadInvJoinDCExcelService = iViewUploadInvJoinDCExcelService;
            this.iViewLDBomJoinLDMItemService = iViewLDBomJoinLDMItemService;
            this.iLDBomService = iLDBomService;
            this.iLROMasterService = iLROMasterService;
            this.iErpBillMasterService = iErpBillMasterService;
            this.iErpBillDetailService = iErpBillDetailService;
            this.iBusinessCostService = iBusinessCostService;
            this.iReceiptLogService = iReceiptLogService;
            this.iCnBomService = iCnBomService;
            this.iMODEBILLHEADINPUTService = iMODEBILLHEADINPUTService;
            this.iMODEBILLCLASSService = iMODEBILLCLASSService;
        }

        #region Common Service
        public ResponseData ProcessData(RequestData requestData)
        {
            return iCommmonService.ProcessData(requestData);
        }

        #endregion

        #region 公司信息

        public CoInfo GetCoInfo(Guid Cid)
        {
            return iCoInfoService.GetCoInfo(Cid);
        }

        public ModelResult<CoInfo> SaveCoInfo(CoInfo model)
        {
            return iCoInfoService.SaveCoInfo(model);

        }
        public ModelResult<CoInfo> AddCoInfo(CoInfo model)
        {


            return iCoInfoService.AddCoInfo(model);

        }
        public IPageOfItems<CoInfo> GetCoInfosList(PagingInfo pagingInfo)
        {

            return iCoInfoService.GetCoInfosList(pagingInfo);
        }


        #endregion

        #region 手册商品


        public CntItem GetCntItem(Guid Cid)
        {
            return iCntItemService.GetCntItem(Cid);
        }

        public ModelResult<CntItem> SaveCntProduct(CntItem model)
        {
            return iCntItemService.SaveCntItem(model);

        }
        public ModelResult<CntItem> AddCntProduct(CntItem model)
        {


            return iCntItemService.AddCntItem(model);

        }
        public IPageOfItems<CntItem> GetCntItemsList(PagingInfo pagingInfo)
        {

            return iCntItemService.GetCntItemsList(pagingInfo);
        }



        #endregion

        #region 备案资料库

        public IPageOfItems<LDHead> GetLDHeadList(PagingInfo pagingInfo)
        {
            return iLDHeadService.GetLDHeadsList(pagingInfo);
        }

        public LDHead GetLDHead()
        {
            return iLDHeadService.GetLDHead();
        }

        public IPageOfItems<LAOMaster> GetLAOMastersList(PagingInfo pagingInfo)
        {
            return iLAOMasterService.GetLAOMastersList(pagingInfo);
        }

        public IPageOfItems<LAODetail1> GetLAODetail1sList(PagingInfo pagingInfo)
        {
            return iLAODetail1Service.GetLAODetail1sList(pagingInfo);
        }
        public IPageOfItems<LAODetail2> GetLAODetail2sList(PagingInfo pagingInfo)
        {
            return iLAODetail2Service.GetLAODetail2sList(pagingInfo);
        }
        #endregion

        #region 手册
        public CntHead GetCntHead(Guid Lid)
        {
            return iCntHeadService.GetCntHead(Lid);
        }

        public ModelResult<CntHead> SaveCntHead(CntHead model)
        {
            return iCntHeadService.SaveCntHead(model);
        }

        public ModelResult<CntHead> AddCntHead(CntHead model)
        {


            return iCntHeadService.AddCntHead(model);

        }


        public IPageOfItems<CntHead> GetCntHeadsList(PagingInfo pagingInfo)
        {

            return iCntHeadService.GetCntHeadsList(pagingInfo);
        }
        #endregion
        public LAO GetLAO(string DocType, string DocNo)
        {
            return iLAOMasterService.GetLAO(DocType, DocNo);
        }

        public LEO GetLEO(string DocNo)
        {
            return iLEOMasterService.GetLEO(DocNo);
        }


        public IPageOfItems<PubCodes> GetPubCodessList(PagingInfo pagingInfo)
        {
            return iPubCodesService.GetPubCodessList(pagingInfo);
        }

        public IPageOfItems<MODEBILLCLASS> GetMODEBILLCLASSsList(PagingInfo pagingInfo)
        {
            return iMODEBILLCLASSService.GetMODEBILLCLASSsList(pagingInfo);
        }
        public IPageOfItems<HS> GetHSsList(PagingInfo pagingInfo)
        {
            return iHSService.GetHSsList(pagingInfo);
        }

        public ModelResult<FactGoods> AddFactGoods(FactGoods model)
        {
            return iFactGoodsService.AddFactGoods(model);
        }
        public ModelResult<FactGoods> SaveFactGoods(FactGoods model)
        {
            return iFactGoodsService.SaveFactGoods(model);
        }
        public IPageOfItems<FactGoods> GetFactGoodssList(PagingInfo pagingInfo)
        {
            return iFactGoodsService.GetFactGoodssList(pagingInfo);
        }

        public IPageOfItems<Customer> GetCustomersList(PagingInfo pagingInfo)
        {
            return iCustomerService.GetCustomersList(pagingInfo);
        }
        public ModelResult<Customer> AddCustomer(Customer model)
        {
            return iCustomerService.AddCustomer(model);
        }
        public ModelResult<Customer> SaveCustomer(Customer model)
        {
            return iCustomerService.SaveCustomer(model);
        }

        public Customer GetCustomer(Guid CID)
        {
            return iCustomerService.GetCustomer(CID);
        }

        public bool RemoveCustomer(Customer model)
        {
            return iCustomerService.RemoveCustomer(model);
        }

        public IPageOfItems<PubCodeClasses> GetPubCodeClassessList(PagingInfo pagingInfo)
        {
            return iPubCodeClassesService.GetPubCodeClassessList(pagingInfo);
        }


        public FactGoods GetFactGoods(Guid FID)
        {
            return iFactGoodsService.GetFactGoods(FID);
        }

        public bool RemoveFactGoods(FactGoods model)
        {
            return iFactGoodsService.RemoveFactGoods(model);
        }





        public IPageOfItems<CntItem> GetCntItemList(PagingInfo pagingInfo)
        {
            return iCntItemService.GetCntItemsList(pagingInfo);
        }

        public IPageOfItems<LDItem> GetLDItemsList(PagingInfo pagingInfo)
        {
            return iLDItemService.GetLDItemsList(pagingInfo);
        }


        public IPageOfItems<ViewNotJoinFactGoods> GetViewNotJoinFactGoodssList(PagingInfo pagingInfo)
        {
            return iViewNotJoinFactGoodsService.GetViewNotJoinFactGoodssList(pagingInfo);
        }


        public IPageOfItems<ViewJoinFactGoods> GetViewJoinFactGoodssList(PagingInfo pagingInfo)
        {
            return iViewJoinFactGoodsService.GetViewJoinFactGoodssList(pagingInfo);
        }
        public bool RemoveInvJoinDC(InvJoinDC model)
        {
            return iInvJoinDCService.RemoveInvJoinDC(model);
        }
        public IPageOfItems<InvJoinDC> GetInvJoinDCsList(PagingInfo pagingInfo)
        {
            return iInvJoinDCService.GetInvJoinDCsList(pagingInfo);
        }

        public bool AddInvJoinDCList(List<InvJoinDC> models)
        {
            return iInvJoinDCService.AddInvJoinDCList(models);
        }
        public ModelResult<InvJoinDC> SaveInvJoinDC(InvJoinDC model)
        {
            return iInvJoinDCService.SaveInvJoinDC(model);
        }



        public IPageOfItems<ViewCustomerAndPub> GetViewCustomerAndPubsList(PagingInfo pagingInfo)
        {
            return iViewCustomerAndPubService.GetViewCustomerAndPubsList(pagingInfo);
        }


        public IPageOfItems<ViewFactGoodsAndPub> GetViewFactGoodsAndPubsList(PagingInfo pagingInfo)
        {
            return iViewFactGoodsAndPubService.GetViewFactGoodsAndPubsList(pagingInfo);
        }



        public int GetMaxDocItemNoByBom(string FieldName, string TableName)
        {
            return iBomService.GetMaxDocItemNoByBom(FieldName, TableName);
        }


        public IPageOfItems<BomMaster> GetBomMastersList(PagingInfo pagingInfo)
        {
            return iBomMasterService.GetBomMastersList(pagingInfo);
        }


        public BomMaster GetBomMaster(Guid TID)
        {
            return iBomMasterService.GetBomMaster(TID);
        }


        public ModelResult<BomMaster> SaveBomMaster(BomMaster model)
        {
            return iBomMasterService.SaveBomMaster(model);
        }


        public ModelResult<BomMaster> AddBomMaster(BomMaster model)
        {
            return iBomMasterService.AddBomMaster(model);
        }


        public ModelResult<Bom> AddBom(Bom model)
        {
            return iBomService.AddBom(model);
        }


        public IPageOfItems<ViewBomJoinFactGoods> GetViewBomJoinFactGoodssList(PagingInfo pagingInfo)
        {
            return iViewBomJoinFactGoodsService.GetViewBomJoinFactGoodssList(pagingInfo);
        }


        public bool RemoveBom(Bom model)
        {
            return iBomService.RemoveBom(model);
        }





        public IPageOfItems<Bom> GetBomsList(PagingInfo pagingInfo)
        {
            return iBomService.GetBomsList(pagingInfo);
        }


        public ModelResult<Bom> SaveBom(Bom model)
        {
            return iBomService.SaveBom(model);
        }


        public bool RemoveBomMaster(string ParentPartNo)
        {
            return iBomMasterService.RemoveBomMaster(ParentPartNo);
        }


        public List<TreeBom> GetTreeBomsList(string ParentPartNo)
        {
            return iBomMasterService.GetTreeBomsList(ParentPartNo);
        }


        public IPageOfItems<BomMaster> GeBomMastersList(PagingInfo pagingInfo)
        {
            return iBomMasterService.GetBomMastersList(pagingInfo);
        }

        public BomMaster GeBomMaster(Guid TID)
        {
            return iBomMasterService.GetBomMaster(TID);
        }


        public LAOMaster GetLAOMaster(Guid LID)
        {
            return iLAOMasterService.GetLAOMaster(LID);
        }


        public LAODetail1 GetLAODetail1(Guid LID)
        {
            return iLAODetail1Service.GetLAODetail1(LID);
        }


        public LAODetail2 GetLAODetail2(Guid LID)
        {
            return iLAODetail2Service.GetLAODetail2(LID);
        }


        public ModelResult<LAOMaster> SaveLAOMaster(LAOMaster model)
        {
            return iLAOMasterService.SaveLAOMaster(model);
        }

        public ModelResult<LAOMaster> AddLAOMaster(LAOMaster model)
        {
            return iLAOMasterService.AddLAOMaster(model);
        }


        public ModelResult<LAODetail1> SaveLAODetail1(LAODetail1 model)
        {
            return iLAODetail1Service.SaveLAODetail1(model);
        }

        public ModelResult<LAODetail1> AddLAODetail1(LAODetail1 model)
        {
            return iLAODetail1Service.AddLAODetail1(model);
        }


        public ModelResult<LAODetail2> AddLAODetail2(LAODetail2 model)
        {
            return iLAODetail2Service.AddLAODetail2(model);
        }

        public ModelResult<LAODetail2> SaveLAODetail2(LAODetail2 model)
        {
            return iLAODetail2Service.SaveLAODetail2(model);
        }


        public string AutoGenLAONo()
        {
            return iLAOMasterService.AutoGenLAONo();
        }


        public bool RemoveLAODetail1(LAODetail1 model)
        {
            return iLAODetail1Service.RemoveLAODetail1(model);
        }


        public bool RemoveLAODetail2(LAODetail2 model)
        {
            return iLAODetail2Service.RemoveLAODetail2(model);
        }


        public bool IsExists()
        {
            return iLDHeadService.IsExists();
        }


        public bool IsExistsByLAODetail1(string DocNo)
        {
            return iLAODetail1Service.IsExistsByLAODetail1(DocNo);
        }


        public bool IsExistsByLAODetail2(string DocNo)
        {
            return iLAODetail2Service.IsExistsByLAODetail2(DocNo);
        }


        public IPageOfItems<LDHead> GetLDHeadsList(PagingInfo pagingInfo)
        {
            return iLDHeadService.GetLDHeadsList(pagingInfo);
        }


        public IPageOfItems<TNMaster> GetTNMastersList(PagingInfo pagingInfo)
        {
            return iTNMasterService.GetTNMastersList(pagingInfo);
        }

        public TNMaster GetTNMaster(Guid TID)
        {
            return iTNMasterService.GetTNMaster(TID);
        }

        public bool RemoveTNDetail(TNDetail model)
        {
            return iTNDetailService.RemoveTNDetail(model);
        }

        public TNDetail GetTNDetail(Guid TID)
        {
            return iTNDetailService.GetTNDetail(TID);
        }


        public ModelResult<TNMaster> SaveTNMaster(TNMaster model)
        {
            return iTNMasterService.SaveTNMaster(model);
        }


        public ModelResult<TNMaster> AddTNMaster(TNMaster model)
        {
            return iTNMasterService.AddTNMaster(model);
        }


        public IPageOfItems<TNDetail> GetTNDetailsList(PagingInfo pagingInfo)
        {
            return iTNDetailService.GetTNDetailsList(pagingInfo);
        }


        public string AutoGenTNNo()
        {
            return iTNMasterService.AutoGenTNNo();
        }


        public decimal GetSumTNMaster(string fieldName, string DocNo)
        {
            return iTNMasterService.GetSumTNMaster(fieldName, DocNo);
        }



        public ModelResult<TNDetail> SaveTNDetail(TNDetail model)
        {
            return iTNDetailService.SaveTNDetail(model);
        }


        public ModelResult<TNDetail> AddTNDetail(TNDetail model)
        {
            return iTNDetailService.AddTNDetail(model);
        }


        public bool RemoveTNMaster(TNMaster model)
        {
            return iTNMasterService.RemoveTNMaster(model);
        }


        public IPageOfItems<TreeBom> GetTreeBomsList(PagingInfo pagingInfo, string ParentPartNo, int ExpandType = 2, int ParentQty = 0, string WithWP = "Y")
        {
            return iBomMasterService.GetTreeBomsList(pagingInfo, ParentPartNo, ExpandType, ParentQty, WithWP);
        }


        public IPageOfItems<FactStore> GetFactStoresList(PagingInfo pagingInfo)
        {
            return iFactStoreService.GetFactStoresList(pagingInfo);
        }


        public IPageOfItems<FactStore2> GetFactStore2sList(PagingInfo pagingInfo)
        {
            return iFactStore2Service.GetFactStore2sList(pagingInfo);
        }


        public string AutoGenDocNo(string tableName)
        {
            return iFactStoreService.AutoGenDocNo(tableName);
        }


        public ModelResult<FactStore> AddFactStore(FactStore model)
        {
            return iFactStoreService.AddFactStore(model);
        }


        public ModelResult<FactStore2> AddFactStore2(FactStore2 model)
        {
            return iFactStore2Service.AddFactStore2(model);
        }




        public bool RemoveFactStore2(FactStore2 model)
        {
            return iFactStore2Service.RemoveFactStore2(model);
        }

        public bool RemoveFactStore2(PagingInfo pagingInfo)
        {
            return iFactStore2Service.RemoveFactStore2(pagingInfo);
        }


        public bool RemoveFactStore(PagingInfo pagingInfo)
        {
            return iFactStoreService.RemoveFactStore(pagingInfo);
        }


        public bool AddFactGoodsList(List<FactGoods> models)
        {
            return iFactGoodsService.AddFactGoodsList(models);
        }


        public bool AddFactStoreList(FactStore _FactStore, List<FactStore2> models)
        {
            return iFactStoreService.AddFactStoreList(_FactStore, models);
        }


        public bool AddBomList(List<Bom> models)
        {
            return iBomService.AddBomList(models);
        }


        public bool AddTNList(TNMaster _TNMaster, List<TNDetail> models)
        {
            return iTNMasterService.AddTNList(_TNMaster, models);
        }


        public bool AddCustomerList(List<Customer> models)
        {
            return iCustomerService.AddCustomerList(models);
        }


        public bool AddLDItemList(List<LDItem> models)
        {
            return iLDItemService.AddLDItemList(models);
        }


        public IPageOfItems<CntBillMaster> GetCntBillMastersList(PagingInfo pagingInfo)
        {
            return iCntBillMasterService.GetCntBillMastersList(pagingInfo);
        }

        public IPageOfItems<CntBillMaster1> GetCntBillMastersList_SP(string ErpDocNo, PagingInfo pagingInfo)
        {
            return iCntBillMasterService.GetCntBillMastersList_SP(ErpDocNo, pagingInfo);
        }


        public HS GetHS(Guid HID)
        {
            return iHSService.GetHS(HID);
        }


        public ModelResult<HS> SaveHS(HS model)
        {
            return iHSService.SaveHS(model);
        }


        public ModelResult<HS> AddHS(HS model)
        {
            return iHSService.AddHS(model);
        }


        public bool RemoveLAOMaster(PagingInfo pagingInfo)
        {
            return iLAOMasterService.RemoveLAOMaster(pagingInfo);
        }


        public IPageOfItems<ViewCntBillMasterJoinCntBillDetail> GetViewCntBillMasterJoinCntBillDetailsList(PagingInfo pagingInfo)
        {
            return iViewCntBillMasterJoinCntBillDetailService.GetViewCntBillMasterJoinCntBillDetailsList(pagingInfo);
        }


        public IPageOfItems<ViewCntBillSummary> GetViewCntBillSummarysList(PagingInfo pagingInfo, string Summary)
        {
            return iViewCntBillSummaryService.GetViewCntBillSummarysList(pagingInfo, Summary);
        }


        public IPageOfItems<ViewCntBillSummaryGroupByUnitPrice> GetViewCntBillSummaryGroupByUnitPricesList(PagingInfo pagingInfo)
        {
            return iViewCntBillSummaryGroupByUnitPriceService.GetViewCntBillSummaryGroupByUnitPricesList(pagingInfo);
        }


        public decimal GetSumBalanceInvQty(int LDSeq)
        {
            return iCntItemService.GetSumBalanceInvQty(LDSeq);
        }


        public decimal GetERPInventory(string DocNo, int LDSeq)
        {
            return iFactStore2Service.GetERPInventory(DocNo, LDSeq);
        }

        public bool RemoveHS(HS model)
        {
            return iHSService.RemoveHS(model);
        }


        public IPageOfItems<DAClass> GetDAClasssList(PagingInfo pagingInfo)
        {
            return iDAClassService.GetDAClasssList(pagingInfo);
        }


        public ModelResult<LAODetail4> AddLAODetail4(LAODetail4 model)
        {
            return iLAODetail4Service.AddLAODetail4(model);
        }


        public IPageOfItems<LAODetail4> GetLAODetail4sList(PagingInfo pagingInfo)
        {
            return iLAODetail4Service.GetLAODetail4sList(pagingInfo);
        }


        public ModelResult<LAODetail4> SaveLAODetail4(LAODetail4 model)
        {
            return iLAODetail4Service.SaveLAODetail4(model);
        }


        public LAODetail4 GetLAODetail4(Guid LID)
        {
            return iLAODetail4Service.GetLAODetail4(LID);
        }


        public bool RemoveLAODetail4(LAODetail4 model)
        {
            return iLAODetail4Service.RemoveLAODetail4(model);
        }


        public ModelResult<LEODetail4> AddLEODetail4(LEODetail4 model)
        {
            return iLEODetail4Service.AddLEODetail4(model);
        }


        public IPageOfItems<LEODetail4> GetLEODetail4sList(PagingInfo pagingInfo)
        {
            return iLEODetail4Service.GetLEODetail4sList(pagingInfo);
        }


        public ModelResult<LEODetail4> SaveLEODetail4(LEODetail4 model)
        {
            return iLEODetail4Service.SaveLEODetail4(model);
        }


        public LEODetail4 GetLEODetail4(Guid LID)
        {
            return iLEODetail4Service.GetLEODetail4(LID);
        }


        public bool RemoveLEODetail4(LEODetail4 model)
        {
            return iLEODetail4Service.RemoveLEODetail4(model);
        }


        public IPageOfItems<LEOMaster> GetLEOMastersList(PagingInfo pagingInfo)
        {
            return iLEOMasterService.GetLEOMastersList(pagingInfo);
        }


        public ModulesPTS.Core.Result ConvertToDec(string docNo, string strDCType, CntBillMaster objCntBillMaster, UserInfo objUserInfo, int DecType, ref string DecID)
        {
            return iTNMasterService.ConvertToDec(docNo, strDCType, objCntBillMaster, objUserInfo, DecType, ref DecID);
        }

        public IPageOfItems<CustomsInventory> GetCustomsInventoryList(PagingInfo pagingInfo, bool UseAdvanced, ref List<CntHead> objCntHeaders)
        {
            return iLDItemService.GetCustomsInventoryList(pagingInfo, UseAdvanced, ref objCntHeaders);
        }

        public CntBillMasterOrCntBillDetail GetCntBillMasterOrCntBillDetailList(string arrayDCBillNo)
        {
            return iCntBillMasterService.GetCntBillMasterOrCntBillDetailList(arrayDCBillNo);
        }

        public ModelResult<CntBillMaster> AddCntBillMaster(CntBillMaster model)
        {
            return iCntBillMasterService.AddCntBillMaster(model);
        }
        public ModelResult<CntBillMaster> SaveCntBillMaster(CntBillMaster model)
        {
            return iCntBillMasterService.SaveCntBillMaster(model);
        }
        public ModelResult<CntBillDetail> SaveCntBillDetail(CntBillDetail model)
        {
            return iCntBillDetailService.SaveCntBillDetail(model);
        }
        public ModelResult<CntBillDetail> AddCntBillDetail(CntBillDetail model)
        {
            return iCntBillDetailService.AddCntBillDetail(model);
        }


        public IPageOfItems<ViewUploadInvJoinDCExcel> GetViewUploadInvJoinDCExcelsList(PagingInfo pagingInfo)
        {
            return iViewUploadInvJoinDCExcelService.GetViewUploadInvJoinDCExcelsList(pagingInfo);
        }

        /// <summary>
        /// 取得系统申报资料。
        /// </summary>
        public LAO GetLaoInfo(string DocNo, string dcType)
        {
            return iLAOMasterService.GetLaoInfo(DocNo, dcType);
        }

        /// <summary>
        /// 更新手册申报更新状态
        /// </summary>
        public bool UpdateLAOMasterState(string DocNo, string dcType)
        {
            return iLAOMasterService.UpdateLAOMasterState(DocNo, dcType);
        }

        public ModelResult<LDHead> AddLDHead(LDHead model)
        {
            return iLDHeadService.AddLDHead(model);
        }

        public CoInfo GetCoInfoInfoOne()
        {
            return iCoInfoService.GetCoInfoInfoOne();
        }

        /// <summary>
        /// 根据编号删除报关单主从表信息
        /// </summary>
        /// <param name="docNo"></param>
        /// <returns></returns>
        public string DelCntBillInfo(string docNo)
        {
            return iCntBillMasterService.DelCntBillInfo(docNo);
        }

        /// <summary>
        /// 自动生成系统单号
        /// </summary>
        /// <returns></returns>
        public string AutoGenCntBillNo()
        {
            return iCntBillMasterService.AutoGenCntBillNo();
        }

        public List<PubCodes> GetPubCodes()
        {
            return iCntBillMasterService.GetPubCodes();
        }

        /// <summary>
        /// 根据编号删除报关单从表信息
        /// </summary>
        /// <param name="docNo"></param>
        /// <returns></returns>
        public void DelCntBillDetailInfo(string docNo)
        {
            iCntBillMasterService.DelCntBillDetailInfo(docNo);
        }


        public ModelResult<InvJoinDC> AddInvJoinDC(InvJoinDC model)
        {
            return iInvJoinDCService.AddInvJoinDC(model);
        }

        /// <summary>
        /// 根据手册号获取手册信息
        /// </summary>
        /// <param name="lcNo"></param>
        /// <returns></returns>
        public CntHead GetCntHeadLcNo(string lcNo)
        {
            return iLEOMasterService.GetCntHeadLcNo(lcNo);
        }


        /// <summary>
        /// 取得要核销手册信息
        /// </summary>
        /// <param name="DocNo">手册号</param>
        /// <returns></returns>
        public LEO GetLEOInfo(string DocNo)
        {
            return iLEOMasterService.GetLEOInfo(DocNo);
        }

        /// <summary>
        /// 更新手册核销申报状态
        /// </summary>
        public bool UpdateLEOMasterState(string DocNo)
        {
            return iLEOMasterService.UpdateLEOMasterState(DocNo);
        }


        public int GetMaxId(string FieldName, string TableName, string whereFieldName, string whereValue)
        {
            return iBomService.GetMaxId(FieldName, TableName, whereFieldName, whereValue);
        }


        public IPageOfItems<ViewLDBomJoinLDMItem> GetViewLDBomJoinLDMItemsList(PagingInfo pagingInfo)
        {
            return iViewLDBomJoinLDMItemService.GetViewLDBomJoinLDMItemsList(pagingInfo);
        }


        public ModelResult<LDBom> AddLDBom(LDBom model)
        {
            return iLDBomService.AddLDBom(model);
        }


        public bool RemoveLDBom(PagingInfo pagingInfo)
        {
            return iLDBomService.RemoveLDBom(pagingInfo);
        }


        public IPageOfItems<LDBom> GetLDBomsList(PagingInfo pagingInfo)
        {
            return iLDBomService.GetLDBomsList(pagingInfo);
        }


        public ModelResult<LDBom> SaveLDBom(LDBom model)
        {
            return iLDBomService.SaveLDBom(model);
        }


        public LRO GetLROInfo(string docNo)
        {
            return iLROMasterService.GetLROInfo(docNo);
        }

        public IPageOfItems<CntBillDetail> GetCntBillDetailsList(PagingInfo pagingInfo)
        {
            return iCntBillDetailService.GetCntBillDetailsList(pagingInfo);
        }


        public bool SqlServerTransactionAddCustomerList(List<Customer> models)
        {
            return iCustomerService.SqlServerTransactionAddCustomerList(models);
        }


        public bool SqlServerTransactionAddFactGoodsList(List<FactGoods> models)
        {
            return iFactGoodsService.SqlServerTransactionAddFactGoodsList(models);
        }

        public bool SqlServerTransactionAddFactStoreList(FactStore _FactStore, List<FactStore2> models)
        {
            return iFactStoreService.SqlServerTransactionAddFactStoreList(_FactStore, models);
        }


        public bool SqlServerTransactionAddErpBillList(ErpBillMaster _ErpBillMaster, List<ErpBillDetail> models)
        {
            return iErpBillMasterService.SqlServerTransactionAddErpBillList(_ErpBillMaster, models);
        }


        public IPageOfItems<ErpBillMaster> GetErpBillMastersList(PagingInfo pagingInfo)
        {
            return iErpBillMasterService.GetErpBillMastersList(pagingInfo);
        }

        public IPageOfItems<ErpBillDetail> GetErpBillDetailsList(PagingInfo pagingInfo)
        {
            return iErpBillDetailService.GetErpBillDetailsList(pagingInfo);
        }

        /// <summary>
        /// 根据查询条件获取随附单证信息
        /// </summary>
        /// <param name="docNo"></param>
        /// <param name="DCType"></param>
        /// <returns></returns>
        public IEnumerable<LAODetail4> GetLAODetail4DocNoList(string docNo, string dCType)
        {
            return iLAODetail4Service.GetLAODetail4DocNoList(docNo, dCType);
        }


        public CntBillMaster GetCntBillMaster(Guid TID)
        {
            return iCntBillMasterService.GetCntBillMaster(TID);
        }


        public CntBillDetail GetCntBillDetail(Guid TID)
        {
            return iCntBillDetailService.GetCntBillDetail(TID);
        }


        public bool RemoveCntBillDetail(CntBillDetail model)
        {
            return iCntBillDetailService.RemoveCntBillDetail(model);
        }


        public bool RemoveCntBillMaster(PagingInfo pagingInfo)
        {
            return iCntBillMasterService.RemoveCntBillMaster(pagingInfo);
        }


        public ErpBillMaster GetErpBillMaster(Guid EID)
        {
            return iErpBillMasterService.GetErpBillMaster(EID);
        }


        public ModelResult<ErpBillMaster> SaveErpBillMaster(ErpBillMaster model)
        {
            return iErpBillMasterService.SaveErpBillMaster(model);
        }


        public IPageOfItems<BusinessCost> GetBusinessCostsList(PagingInfo pagingInfo)
        {
            return iBusinessCostService.GetBusinessCostsList(pagingInfo);
        }


        public BusinessCost GetBusinessCost(Guid BID)
        {
            return iBusinessCostService.GetBusinessCost(BID);
        }

        public ModelResult<BusinessCost> SaveBusinessCost(BusinessCost model)
        {
            return iBusinessCostService.SaveBusinessCost(model);
        }

        public ModelResult<BusinessCost> AddBusinessCost(BusinessCost model)
        {
            return iBusinessCostService.AddBusinessCost(model);
        }


        public bool RemoveBusinessCost(BusinessCost model)
        {
            return iBusinessCostService.RemoveBusinessCost(model);
        }


        public IPageOfItems<ErpAndFactGoods> GetErpAndFactGoodsList(PagingInfo pagingInfo)
        {
            return iErpBillDetailService.GetErpAndFactGoodsList(pagingInfo);
        }

        public ModelResult<ReceiptLog> AddReceiptLog(ReceiptLog model)
        {
            return iReceiptLogService.AddReceiptLog(model);
        }


        public IPageOfItems<CnBom> GetCnBomsList(PagingInfo pagingInfo)
        {
            return iCnBomService.GetCnBomsList(pagingInfo);
        }


        public IPageOfItems<CntBomAndItem> GetCntBomAndItemList(PagingInfo pagingInfo)
        {
            return iCnBomService.GetCntBomAndItemList(pagingInfo);
        }

        public IPageOfItems<MODEBILLHEADINPUT> GetMODEBILLHEADINPUTsList(PagingInfo pagingInfo)
        {
            return iMODEBILLHEADINPUTService.GetMODEBILLHEADINPUTsList(pagingInfo);
        }
    }
}