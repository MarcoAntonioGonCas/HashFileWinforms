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
        /// <summary>
        /// Llena un comboBox con los nombres de una enumeracion.
        /// al combobox.
        /// </summary>
        /// <typeparam name = "T" > Tipo de la enumeración de la cual se obtendrán los nombres.</typeparam>
        /// <param name="cbx">ComboBox que se llenará con los nombres de la enumeración.</param>
        public static void LLenaCbxDeEnum<T>(this ComboBox cbx)where T : Enum
        {
            string[] nombres = Enum.GetNames(typeof(T));
            cbx.DataSource = nombres;
        }

        /// <summary>
        /// Parsea el elemento seleccionado en un ComboBox a un valor de enumeración.
        /// </summary>
        /// <typeparam name="T">Tipo de enumeración al cual se realizará el parseo.</typeparam>
        /// <param name="cbx">ComboBox que contiene los nombres de la enumeración.</param>
        /// <returns>El valor de enumeración correspondiente al elemento seleccionado en el ComboBox.</returns>
        /// <returns>Regresa la enumeracion parseada</returns>
        public static T DevuelveEnumSeleccionado<T>(this ComboBox cbx) where T : Enum
        {
            T seleccionado = default(T);

            seleccionado= (T) Enum.Parse(typeof(T), cbx.Text);


            return seleccionado;
        }

        /// <summary>
        /// Parsea los elementos seleccionados en un CheckedListBox.
        /// </summary>
        /// <typeparam name="T">Tipo de enumeracion a la cual se reaizara el parseo.</typeparam>
        /// <param name="checkedListBox">CheckedListBox que contiene los nombres de las enumeraciones.</param>
        /// <returns></returns>
        public static T[] ObterEnumsSeleccionados<T>(CheckedListBox checkedListBox) where T : Enum
        {
            T[] tipos = new T[checkedListBox.CheckedItems.Count];

            for (int i = 0; i < checkedListBox.CheckedItems.Count; i++)
            {
                tipos[i] =  (T) Enum.Parse(typeof(T), checkedListBox.CheckedItems[i].ToString());
            }
            return tipos;
        }
    }
}
