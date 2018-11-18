using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace CargaTesoreria
{
   public class Tesoreria
    {
        public string rut { get; set; }
        public string cod_verificador { get; set; }
        public string direccion { get; set; }
        public string comuna { get; set; }
        public string cod_inf_tec { get; set; }
        public string numero_chasis { get; set; }
        public string tipo_docto { get; set; }
        public string rut_emisor_fac { get; set; }
        public int nro_factura { get; set; }
        public DateTime fecha_emision_docto { get; set; }
        public string tipo_factura { get; set; }
        public int valor_neto { get; set; }
        public int valor_iva { get; set; }
        public int valor_total { get; set; }
       

        public Boolean GetFactura() {

            DataTable dt = new DataTable("Factura");
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSAIS"].ToString());
            SqlCommand cmd = new SqlCommand(" select SUBSTRING(t1.LicTradNum,1,LEN(t1.lictradnum) - 2) 'Rut', " +
                                            " SUBSTRING(t1.LicTradNum, LEN(t1.lictradnum), LEN(t1.lictradnum)) 'Cod_Verificador'," +
                                            " t1.MailAddres 'Direccion'," +
                                            " t1.MailCounty 'Comuna'," +
                                            " t3.U_Cod_Fab 'Cod_Inf_Tec'," +
                                            " t3.u_num_vin 'Chasis'," +
                                            " 'FACTURA' 'Tipo_docto'," +
                                            " '79853470-k' 'Rut_Emisor_Fac'," +
                                            " Convert(nvarchar(10), t0.DocDate, 105) 'fecha_emision'," +
                                            " 'AFECTA A IVA' 'Tipo_Factura'," +
                                            " Convert(numeric(18, 0), t0.GrosProfit) 'Valor_Neto'," +
                                            " Convert(numeric(18, 0), t0.VatSum) 'Valor_Iva'," +
                                            " Convert(numeric(18, 0), t0.DocTotal) 'Valor_Total'"+
                                            " from oinv t0 with(nolock)" +
                                            " inner join OCRD t1 with(nolock) on t0.CardCode = t1.CardCode" +
                                            " inner join[@SCGD_VEHICULO] t3 with(nolock) on t0.U_SCGD_Cod_Unidad = t3.U_Cod_Unid" +
                                            " where FolioNum = @nro_factura ", conn);
            cmd.Parameters.AddWithValue("@nro_factura", SqlDbType.Int).Value = nro_factura;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count == 0) {
                return false;
            }

            foreach (DataRow dr in dt.Rows)
            {
                rut = dr[0].ToString();
                cod_verificador = dr[1].ToString();
                direccion = dr[2].ToString();
                comuna = dr[3].ToString();
                cod_inf_tec = dr[4].ToString();
                numero_chasis = dr[5].ToString();
                tipo_docto = dr[6].ToString();
                rut_emisor_fac = dr[7].ToString();
                fecha_emision_docto = Convert.ToDateTime(dr[8]);
                tipo_factura = dr[9].ToString();
                valor_neto = int.Parse(dr[10].ToString());
                valor_iva = int.Parse(dr[11].ToString());
                valor_total = int.Parse(dr[12].ToString());

            }

            return true;
        }
        
    }
    
}
