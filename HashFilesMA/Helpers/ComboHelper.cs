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

    }
}
