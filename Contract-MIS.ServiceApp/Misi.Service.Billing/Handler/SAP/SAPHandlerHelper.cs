using System.Collections.Generic;
using System.Linq;
using Misi.DAL.Billing.Model.SAP;
using Misi.Service.Billing.Object;

namespace Misi.Service.Billing.Handler.SAP
{
    public class SAPHandlerHelper
    {
        private static volatile SAPHandlerHelper _sapHandlerHelper;
        private static readonly object SyncRoot23 = new object();

        public static SAPHandlerHelper Instance
        {
            get
            {
                if (_sapHandlerHelper != null) return _sapHandlerHelper;
                lock (SyncRoot23)
                {
                    if (_sapHandlerHelper == null)
                    {
                        _sapHandlerHelper = new SAPHandlerHelper();
                    }
                }
                return _sapHandlerHelper;
            }
        }

        public InvoiceProformaBilling FromBillingDTO2Model(InvoiceProformaItemDTO dto)
        {
            var nbi = new InvoiceProformaBilling
            {
                VBELN = dto.VBELN,
                POSNR = dto.POSNR,
                AUBEL = dto.AUBEL,
                AUPOS = dto.AUPOS,
                MATKL = dto.MATKL,
                ITEM_TYPE = dto.ITEM_TYPE,
                CATEGORY = dto.CATEGORY,
                SUBCATEGORY = dto.SUBCATEGORY,
                WGBEZ = dto.WGBEZ,
                MATNR = dto.MATNR,
                ARKTX = dto.ARKTX,
                FKIMG = dto.FKIMG,
                VRKME = dto.VRKME,
                TOTAL1 = dto.TOTAL1,
                TOTAL2 = dto.TOTAL2,
                TOTAL3 = dto.TOTAL3,
                TOTAL4 = dto.TOTAL4,
                TOTAL5 = dto.TOTAL5,
                VBAK_VBELN = dto.VBAK_VBELN,
                VBAK_POSNR = dto.VBAK_POSNR,
                VBAK_ZMENG = dto.VBAK_ZMENG,
                VBAK_ZIEME = dto.VBAK_ZIEME,
                VBAK_KONDM = dto.VBAK_KONDM,
                VBAK_VTEXT1 = dto.VBAK_VTEXT1,
                VBAK_BSTKD_E = dto.VBAK_BSTKD_E,
                VBAK_EQUNR = dto.VBAK_EQUNR,
                VBAK_TYPBZ = dto.VBAK_TYPBZ,
                VBAK_MAPAR = dto.VBAK_MAPAR,
                VBAK_SERGE = dto.VBAK_SERGE,
                VBAK_LOCATION = dto.VBAK_LOCATION,
                VBAK_PERNR1 = dto.VBAK_PERNR1,
                VBAK_PERNR2 = dto.VBAK_PERNR2,
                VBAK_EMPNAME = dto.VBAK_EMPNAME,
                VBAK_PERSAREA = dto.VBAK_PERSAREA,
                VBAK_PERSAREA_T = dto.VBAK_PERSAREA_T,
                VBAK_SUBAREA = dto.VBAK_SUBAREA,
                VBAK_SUBAREA_T = dto.VBAK_SUBAREA_T,
                VBAK_ORGUNIT = dto.VBAK_ORGUNIT,
                VBAK_ORGUNIT_T = dto.VBAK_ORGUNIT_T,
                VBAK_OUCODE = dto.VBAK_OUCODE,
                VBAK_KOSTL = dto.VBAK_KOSTL,
                VBAK_WAERK = dto.VBAK_WAERK,
                VBAK_NETWR = dto.VBAK_NETWR,
                VBAK_BEDAT = dto.VBAK_BEDAT,
                VBAK_ENDAT = dto.VBAK_ENDAT,
                VBAK_ABGRU_T = dto.VBAK_ABGRU_T,
                VBAK_PS_PSP_PNR = dto.VBAK_PS_PSP_PNR,
                VBAK_PSTYV = dto.VBAK_PSTYV,
                VBAK_KONDA = dto.VBAK_KONDA,
                VBAK_VTEXT2 = dto.VBAK_VTEXT2,
                VBAK_BSTKD = dto.VBAK_BSTKD,
                VBAK_BSTDK = dto.VBAK_BSTDK,
                VBAK_NAME = dto.VBAK_NAME,
                VBAK_APPROVAL = dto.VBAK_APPROVAL,
                VBAK_NOTE = dto.VBAK_NOTE,
                VBAK_ADDRESS = dto.VBAK_ADDRESS,
                VBAK_FAKSK_T = dto.VBAK_FAKSK_T,
                VBAK_EQ_YEAR = dto.VBAK_EQ_YEAR,
                LogMessage = dto.LogMessage, //NOTO
                Remarks = dto.Remarks
            };
            return nbi;
        }

        public IEnumerable<InvoiceProformaItemDTO> FromListOfBillingModels2DTOs(IEnumerable<InvoiceProformaBilling> list, long cachedVersion)
        {
            var list1 = list.Select(e => new InvoiceProformaItemDTO
            {
                VBELN = e.VBELN,
                POSNR = e.POSNR,
                AUBEL = e.AUBEL,
                AUPOS = e.AUPOS,
                MATKL = e.MATKL,
                ITEM_TYPE = e.ITEM_TYPE,
                CATEGORY = e.CATEGORY,
                SUBCATEGORY = e.SUBCATEGORY,
                WGBEZ = e.WGBEZ,
                MATNR = e.MATNR,
                ARKTX = e.ARKTX,
                FKIMG = e.FKIMG,
                VRKME = e.VRKME,
                TOTAL1 = e.TOTAL1,
                TOTAL2 = e.TOTAL2,
                TOTAL3 = e.TOTAL3,
                TOTAL4 = e.TOTAL4,
                TOTAL5 = e.TOTAL5,
                VBAK_VBELN = e.VBAK_VBELN,
                VBAK_POSNR = e.VBAK_POSNR,
                VBAK_ZMENG = e.VBAK_ZMENG,
                VBAK_ZIEME = e.VBAK_ZIEME,
                VBAK_KONDM = e.VBAK_KONDM,
                VBAK_VTEXT1 = e.VBAK_VTEXT1,
                VBAK_BSTKD_E = e.VBAK_BSTKD_E,
                VBAK_EQUNR = e.VBAK_EQUNR,
                VBAK_TYPBZ = e.VBAK_TYPBZ,
                VBAK_MAPAR = e.VBAK_MAPAR,
                VBAK_SERGE = e.VBAK_SERGE,
                VBAK_LOCATION = e.VBAK_LOCATION,
                VBAK_PERNR1 = e.VBAK_PERNR1,
                VBAK_PERNR2 = e.VBAK_PERNR2,
                VBAK_EMPNAME = e.VBAK_EMPNAME,
                VBAK_PERSAREA = e.VBAK_PERSAREA,
                VBAK_PERSAREA_T = e.VBAK_PERSAREA_T,
                VBAK_SUBAREA = e.VBAK_SUBAREA,
                VBAK_SUBAREA_T = e.VBAK_SUBAREA_T,
                VBAK_ORGUNIT = e.VBAK_ORGUNIT,
                VBAK_ORGUNIT_T = e.VBAK_ORGUNIT_T,
                VBAK_OUCODE = e.VBAK_OUCODE,
                VBAK_KOSTL = e.VBAK_KOSTL,
                VBAK_WAERK = e.VBAK_WAERK,
                VBAK_NETWR = e.VBAK_NETWR,
                VBAK_BEDAT = e.VBAK_BEDAT,
                VBAK_ENDAT = e.VBAK_ENDAT,
                VBAK_ABGRU_T = e.VBAK_ABGRU_T,
                VBAK_PS_PSP_PNR = e.VBAK_PS_PSP_PNR,
                VBAK_PSTYV = e.VBAK_PSTYV,
                VBAK_KONDA = e.VBAK_KONDA,
                VBAK_VTEXT2 = e.VBAK_VTEXT2,
                VBAK_BSTKD = e.VBAK_BSTKD,
                VBAK_BSTDK = e.VBAK_BSTDK,
                VBAK_NAME = e.VBAK_NAME,
                VBAK_APPROVAL = e.VBAK_APPROVAL,
                VBAK_NOTE = e.VBAK_NOTE,
                VBAK_ADDRESS = e.VBAK_ADDRESS,
                VBAK_FAKSK_T = e.VBAK_FAKSK_T,
                VBAK_EQ_YEAR = e.VBAK_EQ_YEAR,
                LogMessage = e.LogMessage, //NOTO ini dari tabel performa billing
                CachedVersion = cachedVersion,
                NO = e.VBAK_VBELN + "#" + e.VBAK_POSNR,
                Remarks = e.Remarks
            });
            return list1;
        }

        public void CopyBillingValues(InvoiceProformaBilling src, InvoiceProformaBilling dest)
        {
            dest.VBELN = src.VBELN;
            dest.POSNR = src.POSNR;
            dest.AUBEL = src.AUBEL;
            dest.AUPOS = src.AUPOS;
            dest.MATKL = src.MATKL;
            dest.ITEM_TYPE = src.ITEM_TYPE;
            dest.CATEGORY = src.CATEGORY;
            dest.SUBCATEGORY = src.SUBCATEGORY;
            dest.WGBEZ = src.WGBEZ;
            dest.MATNR = src.MATNR;
            dest.ARKTX = src.ARKTX;
            dest.FKIMG = src.FKIMG;
            dest.VRKME = src.VRKME;
            dest.TOTAL1 = src.TOTAL1;
            dest.TOTAL2 = src.TOTAL2;
            dest.TOTAL3 = src.TOTAL3;
            dest.TOTAL4 = src.TOTAL4;
            dest.TOTAL5 = src.TOTAL5;
            dest.VBAK_VBELN = src.VBAK_VBELN;
            dest.VBAK_POSNR = src.VBAK_POSNR;
            dest.VBAK_ZMENG = src.VBAK_ZMENG;
            dest.VBAK_ZIEME = src.VBAK_ZIEME;
            dest.VBAK_KONDM = src.VBAK_KONDM;
            dest.VBAK_VTEXT1 = src.VBAK_VTEXT1;
            dest.VBAK_BSTKD_E = src.VBAK_BSTKD_E;
            dest.VBAK_EQUNR = src.VBAK_EQUNR;
            dest.VBAK_TYPBZ = src.VBAK_TYPBZ;
            dest.VBAK_MAPAR = src.VBAK_MAPAR;
            dest.VBAK_SERGE = src.VBAK_SERGE;
            dest.VBAK_LOCATION = src.VBAK_LOCATION;
            dest.VBAK_PERNR1 = src.VBAK_PERNR1;
            dest.VBAK_PERNR2 = src.VBAK_PERNR2;
            dest.VBAK_EMPNAME = src.VBAK_EMPNAME;
            dest.VBAK_PERSAREA = src.VBAK_PERSAREA;
            dest.VBAK_PERSAREA_T = src.VBAK_PERSAREA_T;
            dest.VBAK_SUBAREA = src.VBAK_SUBAREA;
            dest.VBAK_SUBAREA_T = src.VBAK_SUBAREA_T;
            dest.VBAK_ORGUNIT = src.VBAK_ORGUNIT;
            dest.VBAK_ORGUNIT_T = src.VBAK_ORGUNIT_T;
            dest.VBAK_OUCODE = src.VBAK_OUCODE;
            dest.VBAK_KOSTL = src.VBAK_KOSTL;
            dest.VBAK_WAERK = src.VBAK_WAERK;
            dest.VBAK_NETWR = src.VBAK_NETWR;
            dest.VBAK_BEDAT = src.VBAK_BEDAT;
            dest.VBAK_ENDAT = src.VBAK_ENDAT;
            dest.VBAK_ABGRU_T = src.VBAK_ABGRU_T;
            dest.VBAK_PS_PSP_PNR = src.VBAK_PS_PSP_PNR;
            dest.VBAK_PSTYV = src.VBAK_PSTYV;
            dest.VBAK_KONDA = src.VBAK_KONDA;
            dest.VBAK_VTEXT2 = src.VBAK_VTEXT2;
            dest.VBAK_BSTKD = src.VBAK_BSTKD;
            dest.VBAK_BSTDK = src.VBAK_BSTDK;
            dest.VBAK_NAME = src.VBAK_NAME;
            dest.VBAK_APPROVAL = src.VBAK_APPROVAL;
            dest.VBAK_NOTE = src.VBAK_NOTE;
            dest.VBAK_ADDRESS = src.VBAK_ADDRESS;
            dest.VBAK_FAKSK_T = src.VBAK_FAKSK_T;
            dest.VBAK_EQ_YEAR = src.VBAK_EQ_YEAR;
            dest.LogMessage = src.LogMessage; //NOTO
            dest.Remarks = src.Remarks;
        }
    }
}