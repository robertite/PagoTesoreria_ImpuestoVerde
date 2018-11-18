using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace CargaTesoreria
{
   public class globalClass
    {
        public string validateUser(string usuario, string contraseña)
        {
            Company spCompany = new Company();
            companyClass.paramSPCompany(spCompany,usuario,contraseña);
            spCompany.Connect();
            spCompany.StartTransaction();

            return "";
        }
    }
}
