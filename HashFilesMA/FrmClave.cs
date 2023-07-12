using HashFilesMA.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFilesMA
{
    public partial class FrmClave : Form
    {
        public FrmClave()
        {
            InitializeComponent();


            this.txtClave.Text = ObtenerClave();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string clave = txtClave.Text.Trim();

            if(clave.Length == 0)
            {
                MessageBox.Show("La clave esta vacia");
                return;
            }

            GuardarClave(clave);
            this.Close();
            
        }
        //Ruta
        static string nombreRuta = "confi.resx";
        private static void GuardarClave(string clave)
        {
            using (ResourceWriter resXResource = new ResourceWriter(nombreRuta))
            {
                resXResource.AddResource("clave", clave);
            }
        }
        public static string ObtenerClave() {
            if (!File.Exists(nombreRuta))
            {
                return "";
            }


            using(ResourceReader reader = new ResourceReader(nombreRuta))
            {
                IDictionaryEnumerator resourceSet = reader.GetEnumerator();

                if(resourceSet.MoveNext())
                {
                    DictionaryEntry entry = (DictionaryEntry)resourceSet.Current;
                    return entry.Value.ToString();
                }
            }
            return "";
        }


        public static bool EsClaveValida => ObtenerClave().Length > 10;
    }
}
