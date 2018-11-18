using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using System.Configuration;

namespace CargaTesoreria
{
    public class companyClass
    {
        public static void paramSPCompany(Company spCompany,string usuario, string contraseña)
        {
            string licenseServer = ConfigurationManager.AppSettings["licserver"].ToString();
            string bddServer = ConfigurationManager.AppSettings["serversap"].ToString();
            string bddSAP = ConfigurationManager.AppSettings["bddsap"].ToString();
            string uSQLSAP = ConfigurationManager.AppSettings["ufull"].ToString();
            string pSQLSAP = ConfigurationManager.AppSettings["pfull"].ToString();
            string uSAP = usuario;
            string pSAP = contraseña;


            spCompany.UseTrusted = false;
            spCompany.Server = bddServer;
            spCompany.LicenseServer = licenseServer;
            spCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008;
            spCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            spCompany.DbUserName = uSQLSAP;
            spCompany.DbPassword = pSQLSAP;

            //Credenciales de Usuario SAP
            spCompany.CompanyDB = bddSAP;
            spCompany.UserName = uSAP;
            spCompany.Password = pSAP;

        } }
}
