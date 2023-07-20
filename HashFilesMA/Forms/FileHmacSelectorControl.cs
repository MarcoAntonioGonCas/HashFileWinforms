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
        public FileHmacSelectorControl()
        {
            InitializeComponent();
            SeleccionarTodos(checkedListBox1);
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
            return ComboHelper.ObtenerHashSeleccionados<TipoHMACHash>(checkedListBox1);
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
    }
}
