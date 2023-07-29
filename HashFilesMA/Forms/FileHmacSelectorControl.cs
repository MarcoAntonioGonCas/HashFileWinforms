using HashFilesMA.FileHelpers;
using HashFilesMA.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFilesMA.Forms
{
    public partial class FileHmacSelectorControl : UserControl
    {
        private Button btnSeleccionado = null;
        public FileHmacSelectorControl()
        {
            InitializeComponent();
            SeleccionarTodos(checkedListBox1);
            VinculaBotones();
        }

        private void VinculaBotones()
        {
            btnMD5.Tag = txtMD5;
            btnSHA1.Tag = txtSHA1;  
            btnSHA256.Tag = txtSHA256;
            btnSHA384.Tag = txtSHA384;
            btnSHA512.Tag = txtSHA512;
        }
        private void btnClave_Click(object sender, EventArgs e)
        {
            new FrmClave().ShowDialog();
        }
        private void SeleccionarTodos(CheckedListBox list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, true);
            }
        }

        public TipoHMACHash[] ObtieneTiposSeleccionados()
        {
            return ComboHelper.ObterEnumsSeleccionados<TipoHMACHash>(checkedListBox1);
        }

        public void LimpiaCampos()
        {
            txtMD5.Clear();
            txtSHA1.Clear();
            txtSHA256.Clear();
            txtSHA384.Clear();
            txtSHA512.Clear();
        }
        public void LLenaTextbox(HmacValue[] hashesCalulados)
        {
           
            foreach (HmacValue hashValue in hashesCalulados)
            {
                
                if (hashValue.TipoHash == TipoHMACHash.HMACMD5)
                {
                    txtMD5.Text = hashValue.HashHex;
                }
                else if (hashValue.TipoHash == TipoHMACHash.HMACSHA1)
                {
                    txtSHA1.Text = hashValue.HashHex;
                }
                else if (hashValue.TipoHash == TipoHMACHash.HMACSHA256)
                {
                    txtSHA256.Text = hashValue.HashHex;
                }
                else if (hashValue.TipoHash == TipoHMACHash.HMACSHA384)
                {
                    txtSHA384.Text = hashValue.HashHex;
                }
                else if (hashValue.TipoHash == TipoHMACHash.HMACSHA512)
                {
                    txtSHA512.Text = hashValue.HashHex;
                }

            }


        }


        /// <summary>
        /// Copia el contenido del textbox al portapapeles y cambia el icono del botton seleccionado.
        /// </summary>
        /// <param name="txt">Textbox del cual obtendremos el texto a copiar.</param>
        /// <param name="button">Button el cual fue presionado.</param>
        private void CopiarHashPortapapeles(TextBox txt, Button button)
        {
            string hashTextbox = "";

            hashTextbox = txt.Text;
            if (hashTextbox == "") return;

            // Copia el texto del texbox al portapeles
            Clipboard.SetText(hashTextbox);

            // Si se preciono un boton anteriormente se le devuelve la imagen original
            if (btnSeleccionado != null)
            {
                this.btnSeleccionado.Image = global::HashFilesMA.Properties.Resources.copiar16;
            }

            // Se cambia la imagen indicando que se copio al portapapeles correctamente
            button.Image = global::HashFilesMA.Properties.Resources.copiado;
            this.btnSeleccionado = button;

            //Iniciamos nuestro timer para regresar la imagen original al boton presionado
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();
            //Regresamos la imagen original al boton presionado al momento de copiar al portapapeles
            this.btnSeleccionado.Image = global::HashFilesMA.Properties.Resources.copiar16;
        }

        private void btnMD5_Click(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;
            Button btnHash = sender as Button;
            if (!(btnHash.Tag is TextBox)) return;

            TextBox txtVinculado = btnHash.Tag as TextBox;

            CopiarHashPortapapeles(txtVinculado,btnHash);

        }
    }
}
