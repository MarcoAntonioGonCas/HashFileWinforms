using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HashFilesMA.FileHelpers
{
    public enum TipoHMACHash
    {
        HMACMD5,
        HMACSHA1,
        HMACSHA256,
        HMACSHA384,
        HMACSHA512,
    }
    public abstract class FileHmacHash:FileHashEvents
    {

        protected long lengthBuffer { get; set; }

        public abstract string CalcularHashText(TipoHMACHash tipo, string text,string key);
        public abstract string CalcularHashAll(TipoHMACHash tipo, string ruta, string key, CancellationToken? token);
        public abstract string CalcularHashAll(TipoHMACHash tipo, string ruta, string key);

    }
}
