using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PruebaTata
{
    public partial class Index : System.Web.UI.Page
    {
        string[] PalFrase = null;
        Clases.clsContaPalabras[] Arreglocontador = new Clases.clsContaPalabras[1];



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonblue_Click(object sender, EventArgs e)
        {
            string texto = txtConte.Text;
            texto = texto.Replace(".", "").Replace(",", "");
            if (String.IsNullOrEmpty(txtConte.Text))
            {
                Response.Write("<script>alert('El campo de texto se encuentra vacío, por favor ingrese texto');</script>");
            }
            else
            {

                if (txtConte.Text.Contains(" "))
                {
                    PalFrase = texto.Split(' ');
                }
                else
                {
                    PalFrase = new string[1];
                    PalFrase[0] = texto;
                }
                foreach (string item in PalFrase)
                {
                    ContarPalabra(item);
                }

                MostrarResultado();

            }
        }

        private void ContarPalabra(string Palabra)
        {
            bool Encontrada = false;
            int PosPalabra = 0;
            if (Arreglocontador[0] == null)
            {
                Arreglocontador[0] = new Clases.clsContaPalabras() { Palabra = Palabra.ToLower(), Cantidad = 1 };
            }
            else
            {
                foreach (Clases.clsContaPalabras item in Arreglocontador)
                {
                    if (Palabra.ToLower().Equals(item.Palabra))
                    {
                        Arreglocontador[PosPalabra].Cantidad++;
                        Encontrada = true;
                        return;
                    }
                    PosPalabra++;
                }
                if (!Encontrada)
                {
                    Array.Resize<Clases.clsContaPalabras>(ref Arreglocontador, Arreglocontador.Length + 1);
                    Arreglocontador[Arreglocontador.Length - 1] = new Clases.clsContaPalabras() { Palabra = Palabra.ToLower(), Cantidad = 1 };
                }
            }

        }

        private void MostrarResultado()
        {
            DataTable Tabla = new DataTable("ContaPalabras");
            Tabla.Columns.Add(new DataColumn("Palabra", typeof(string)));
            Tabla.Columns.Add(new DataColumn("Cantidad", typeof(int)));
            foreach (Clases.clsContaPalabras item in Arreglocontador)
            {
                Tabla.Rows.Add(item.Palabra, item.Cantidad);
            }

            HtmlGenericControl div = new HtmlGenericControl("div") { ID = "CantPalab" };
            DataGrid Grilla = new DataGrid() { DataSource = Tabla, ID = "Grilla" };
            Grilla.DataBind();
            div.Controls.Add(Grilla);
            Form1.Controls.Add(div);

        }
    }
}