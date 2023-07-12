using HashFilesMA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFilesMA.FileHelpers
{
    public class ProgressHashFileArgs : EventArgs
    {
        public float Progreso { get; set; }
        public long Bytes { get; set; }
        public long TotalBytes { get; set; }
    }
    public class ErrorHashFileArgs : EventArgs
    {
        public string Mensaje { get; set; }
    }
    public delegate void ProgressHashFileHandler(object sender, ProgressHashFileArgs args);
    public abstract class FileHashEvents
    {
        public event ProgressHashFileHandler Progreso;
        public event EventHandler ProgresoCompletado;
        public event EventHandler<ErrorHashFileArgs> Error;

        protected void OnProgreso(ProgressHashFileArgs args)
        {
            Progreso?.Invoke(this, args);
        }

        protected void OnProgresoCompletado(EventArgs args)
        {
            ProgresoCompletado?.Invoke(this, args);
        }
        protected void OnError(ErrorHashFileArgs args)
        {
            Error?.Invoke(this, args);
        }

    }
}
