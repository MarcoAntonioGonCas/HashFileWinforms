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
    public partial class FileHashSelectorControl : UserControl
    {

        private Button btnSeleccionado = null;
        public FileHashSelectorControl()
        {
            InitializeComponent();
            SeleccionarTodos(checkedListBox1);

            VinculaBotones();
        }
        /// <summary>
        /// Vincula los buttons con los textbox que le corresponde.
        /// </summary>
        private void VinculaBotones()
        {
            btnMD5.Tag = txtMD5;
            btnSHA1.Tag = txtSHA1;
            btnSHA256.Tag = txtSHA256;
            btnSHA384.Tag = txtSHA384;
            btnSHA512.Tag = txtSHA512;
        }
        /// <summary>
        /// Marca como seleccionado todos los elementos de un CheckedListBox.
        /// </summary>
        /// <param name="list">CheckedListBox el cual todos los elementos sera marcados.</param>
        private void SeleccionarTodos(CheckedListBox list)
        {
            for(int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, true);
            }
        }


        /// <summary>
        /// Obtiene los tipos de hashes seleccionados en el checkedListBox.
        /// </summary>
        /// <returns>Arreglo de los tipos de hashes seleccionados por el usuario.</returns>
        public TipoHash[] ObtieneTiposSeleccionados()
        {
            return ComboHelper.ObterEnumsSeleccionados<TipoHash>(checkedListBox1);
        }


        /// <summary>
        /// Limpia todos los textbox
        /// </summary>
        public void LimpiaCampos()
        {
            txtMD5.Clear();
            txtSHA1.Clear();
            txtSHA256.Clear();
            txtSHA384.Clear();
            txtSHA512.Clear();
        }

        /// <summary>
        /// Llena los campos de texto correspondientes con los valores de hash calculados.
        /// </summary>
        /// <param name="hashesCalulados">Un arreglo de objetos HashValue que contiene los valores de hash calculados.</param>
        public void LLenaTextbox(HashValue[] hashesCalulados)
        {
            
            foreach(HashValue hashValue in hashesCalulados)
            {

                if(hashValue.TipoHash == TipoHash.MD5)
                {
                    txtMD5.Text = hashValue.HashHex;
                }
                else if(hashValue.TipoHash == TipoHash.SHA1)
                {
                    txtSHA1.Text = hashValue.HashHex;
                }
                else if (hashValue.TipoHash == TipoHash.SHA256)
                {
                    txtSHA256.Text = hashValue.HashHex;
                }
                else if (hashValue.TipoHash == TipoHash.SHA384)
                {
                    txtSHA384.Text = hashValue.HashHex;
                }
                else if (hashValue.TipoHash == TipoHash.SHA512)
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

        #region Eventos en botones 
        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            if (!(sender is Button)) return;

            Button btnHash = sender as Button;

            if (!(btnHash.Tag is TextBox)) return;

            TextBox txtVinculado = btnHash.Tag as TextBox;

            CopiarHashPortapapeles(txtVinculado, btnHash);

        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            timer1.Stop();
            //Regresamos la imagen original al boton presionado al momento de copiar al portapapeles
            this.btnSeleccionado.Image = global::HashFilesMA.Properties.Resources.copiar16;
        }
    }
}
