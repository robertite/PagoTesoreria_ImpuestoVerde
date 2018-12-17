using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace CargaTesoreria
{
    public partial class Ingreso : Form 
    {
        ChromiumWebBrowser browser;
        IKeyboardHandler IKey;


        public static Ingreso GetInstance()
        {

                Ingreso ingreso = (Ingreso)Application.OpenForms["ingreso"];
                if (ingreso != null)
                {
                return ingreso;
                }
                else
                {
                    ingreso = new Ingreso();
                return ingreso;
                }
            
        }
        public Ingreso()
        {           
            InitializeComponent();
            InitBrowser();
        }

        public void InitBrowser()
        {
            if (!Cef.IsInitialized) { Cef.Initialize(new CefSettings()); }
            //   browser = new ChromiumWebBrowser("http://www.tesoreria.cl/IntForm88Web/resumen?fin=Vigente|88|2325033|31-10-2018|320267|10281800000518103108817219|76010221|28-10-2018|90008800000002325033||www.tesoreria.cl");
            browser = new ChromiumWebBrowser("http://www.tesoreria.cl/IntForm88Web/form1");
            //this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            panel1.Controls.Add(browser);
            //this.Controls.Add(panel1);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //webBrowser1.ScriptErrorsSuppressed = true;
            //webBrowser1.AllowNavigation = true;
         
     

          //  webBrowser1.Navigate("http://www.tesoreria.cl/IntForm88Web/form1");
           // webBrowser1.Navigate("https://webpay3g.transbank.cl/webpayserver/dist/");
        }

        private void btnCargarRut_Click(object sender, EventArgs e)
        {
            if (txtRut.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Datos", "Error", MessageBoxButtons.OK);
                return;
            }
            if (!IsNumeric(txtRut.Text))
            {
                MessageBox.Show("Ingrese Datos Numéricos", "Error", MessageBoxButtons.OK);
                return;
            }
            Tesoreria factura = new Tesoreria();
            factura.nro_factura = int.Parse(txtRut.Text.Trim());
            if (!factura.GetFactura()) {
                MessageBox.Show("Numero de Factura Inválido","Error", MessageBoxButtons.OK);
                txtRut.Text = "";
                return;
            }

 
            browser.ExecuteScriptAsync("document.getElementById('L03').value = '"+ factura.rut +"';");
            browser.ExecuteScriptAsync("document.getElementById('L003').value = '" + factura.cod_verificador + "';");

            //KeyEvent k = new KeyEvent();
            //k.WindowsKeyCode = 0x0D;
            //k.FocusOnEditableField = true;
            //k.IsSystemKey = false;
            //k.Type = KeyEventType.Char;
            //browser.GetBrowser().GetHost().SendKeyEvent(k);

            browser.ExecuteScriptAsync("document.getElementById('L6').value = '" + factura.direccion + "';");
            browser.ExecuteScriptAsync("document.getElementById('L8').value = '" + factura.comuna + "';");
            browser.ExecuteScriptAsync("document.getElementById('L28').value = '" + factura.cod_inf_tec + "';");
            browser.ExecuteScriptAsync("document.getElementById('L33').value = '" + factura.numero_chasis + "';");
            browser.ExecuteScriptAsync("document.getElementById('L20').value = '" + factura.tipo_docto+ "';");
            browser.ExecuteScriptAsync("document.getElementById('L21').value = '" + factura.rut_emisor_fac + "';");
            browser.ExecuteScriptAsync("document.getElementById('L22').value = '" + factura.nro_factura.ToString() + "';");
            browser.ExecuteScriptAsync("document.getElementById('L23').value = '" + factura.fecha_emision_docto.ToString("dd-MM-yyyy") + "';");
            browser.ExecuteScriptAsync("document.getElementById('L24').value = '" + factura.tipo_factura + "';");
         
            browser.Focused.Equals("L003");
            browser.ExecuteScriptAsync("document.getElementById('L25').value = '" + factura.valor_neto.ToString()+ "';");
            browser.ExecuteScriptAsync("document.getElementById('L26').value = '" + factura.valor_iva.ToString() + "';");
            browser.ExecuteScriptAsync("document.getElementById('L27').value = '" + factura.valor_total + "';");

        

        //     browser.ExecuteScriptAsync("document.getElementById('Sii').click();");



        //webBrowser1.Document.GetElementById("L03").SetAttribute("value", factura.rut);
        //webBrowser1.Document.GetElementById("L003").SetAttribute("value", factura.cod_verificador);
        //webBrowser1.Document.GetElementById("L003").Focus();
        //SendKeys.Send("{TAB}");
        //SendKeys.Flush();
        //webBrowser1.Document.GetElementById("L6").SetAttribute("value", factura.direccion);
        //webBrowser1.Document.GetElementById("L8").SetAttribute("value", factura.comuna);
        //webBrowser1.Document.GetElementById("L28").SetAttribute("value", factura.cod_inf_tec);
        //webBrowser1.Document.GetElementById("L28").Focus();
        //SendKeys.Send("{TAB}");
        //SendKeys.Flush();
        //webBrowser1.Document.GetElementById("L33").SetAttribute("value", factura.numero_chasis);
        //webBrowser1.Document.GetElementById("L20").SetAttribute("value", factura.tipo_docto);
        //webBrowser1.Document.GetElementById("L21").SetAttribute("value", factura.rut_emisor_fac);
        //webBrowser1.Document.GetElementById("L22").SetAttribute("value", factura.nro_factura.ToString ());



        //webBrowser1.Document.GetElementById("L23").SetAttribute("value", factura.fecha_emision_docto.ToString("dd-MM-yyyy"));


        //webBrowser1.Document.GetElementById("L24").SetAttribute("value", factura.tipo_factura);
        //webBrowser1.Document.GetElementById("L25").SetAttribute("value", factura.valor_neto.ToString());
        //webBrowser1.Document.GetElementById("L26").SetAttribute("value", factura.valor_iva.ToString());
        //webBrowser1.Document.GetElementById("L27").SetAttribute("value", factura.valor_total.ToString());
        //webBrowser1.Document.GetElementById("Sii").InvokeMember("click");

    }
        private bool IsNumeric(string Factura) {
            try {
                int x = int.Parse(Factura);
              
            }
            catch (Exception ex) {
                ex.ToString();
                return false;
            }
            return true;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //webBrowser1.Refresh();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //webBrowser1.GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoForward();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("http://www.tesoreria.cl/IntForm88Web/form1");
          //  webBrowser1.Navigate("https://webpay3g.transbank.cl/webpayserver/dist/");
        }

        private void ingresarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

          
        }

    }


}
