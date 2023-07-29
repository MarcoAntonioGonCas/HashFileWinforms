using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFilesMA.Helpers
{
    /// <summary>
    /// Clase la cual indica si un archivo fue seleccionado.
    /// </summary>
    public class FileSelect
    {
        
        /// <summary>
        /// Evento el cual es invocado cuando la ruta del archivo
        /// cambia.
        /// </summary>
        public event EventHandler CambioArchivo; 
        private string _rutaArchivo;
        /// <summary>
        /// Indica si actualmente esta seleccionado un archivo.
        /// </summary>
        public bool Seleccionado
        {
            get
            {
                return this.RutaArchivo != "";
            }
        }
        /// <summary>
        /// Ruta del archivo.
        /// </summary>
        public string RutaArchivo
        {
            get => _rutaArchivo; 
            set{

                try
                {

                    if (File.Exists(value))
                    {
                        _rutaArchivo = value;
                        CambioArchivo?.Invoke(this, EventArgs.Empty);
                    }

                }catch
                {
                    _rutaArchivo = string.Empty;
                }

            }
        }
        /// <summary>
        /// Devuelve solo el nombre del archivo si no esta seleccionado
        /// ningun archivo devuelve un string vacio.
        /// </summary>
        public string Nombre
        {
            get
            {
                if (RutaArchivo == string.Empty) return "";
                try
                {
                    string nombre = Path.GetFileName(RutaArchivo);
                    return nombre;
                }catch
                {
                    return "";
                }
            }


        }

        /// <summary>
        /// Quita el archivo seleccionado.
        /// </summary>
        public void Clear()
        {
            _rutaArchivo = "";
            CambioArchivo?.Invoke(this, new EventArgs());
        }
        public FileSelect()
        {
            this._rutaArchivo = "";
        }
    }
}
