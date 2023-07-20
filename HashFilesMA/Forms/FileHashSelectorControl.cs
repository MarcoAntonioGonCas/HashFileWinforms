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
        public FileHashSelectorControl()
        {
            InitializeComponent();
            SeleccionarTodos(checkedListBox1);


        }
        private void SeleccionarTodos(CheckedListBox list)
        {
            for(int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, true);
            }
        }

        public TipoHash[] ObtieneTiposSeleccionados()
        {
            return ComboHelper.ObtenerHashSeleccionados<TipoHash>(checkedListBox1);
        }

        public void LimpiaCampos()
        {
            txtMD5.Clear();
            txtSHA1.Clear();
            txtSHA256.Clear();
            txtSHA384.Clear();
            txtSHA512.Clear();
        }
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
    }
}
