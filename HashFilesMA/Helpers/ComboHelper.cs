using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFilesMA.Helpers
{
    public static class ComboHelper
    {
        public static void LLenaCbxDeEnum<T>(this ComboBox cbx)where T : Enum
        {
            string[] nombres = Enum.GetNames(typeof(T));
            cbx.DataSource = nombres;
        }

        public static T DevuelveEnumSeleccionado<T>(this ComboBox cbx) where T : Enum
        {
            T seleccionado = default(T);

            seleccionado=(T)Enum.Parse(typeof(T), cbx.Text);


            return seleccionado;
        }
        public static T[] ObtenerHashSeleccionados<T>(CheckedListBox checkedListBox) where T : Enum
        {
            T[] tipos = new T[checkedListBox.CheckedItems.Count];
            for (int i = 0; i < checkedListBox.CheckedItems.Count; i++)
            {
                tipos[i] = (T)Enum.Parse(typeof(T), checkedListBox.CheckedItems[i].ToString());
            }
            return tipos;
        }
    }
}
