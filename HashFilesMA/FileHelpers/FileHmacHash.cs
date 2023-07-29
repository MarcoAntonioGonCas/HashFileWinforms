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
    public class HmacValue
    {
        public TipoHMACHash TipoHash { get; set; }
        public byte[] Hash { get; set; }
        public string HashHex { get; set; }
    }
    public abstract class FileHmacHash:FileHashEvents
    {

        protected long lengthBuffer { get; set; }

        public abstract string CalcularHashText(TipoHMACHash tipo, string text,string key);
        public abstract HmacValue[] CalcularMultipleHashText(TipoHMACHash[] tipos, string text,string key);
        public abstract string CalcularHashFile(TipoHMACHash tipo, string ruta, string key, CancellationToken? token);
        public abstract string CalcularHashFile(TipoHMACHash tipo, string ruta, string key);
        public abstract HmacValue[] CalcularMultipleHashFile(TipoHMACHash[] tipos, string ruta, string key);
        public abstract HmacValue[] CalcularMultipleHashFile(TipoHMACHash[] tipos, string ruta, string key, CancellationToken? token);

    }
}
