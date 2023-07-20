using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFilesMA.Helpers
{
    public class FileSelect
    {
        

        public event EventHandler CambioArchivo; 
        private string _rutaArchivo;
        public bool Seleccionado
        {
            get
            {
                return this.RutaArchivo != "";
            }
        }
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
