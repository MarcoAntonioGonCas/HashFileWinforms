using HashFilesMA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HashFilesMA.FileHelpers
{

    
    public enum TipoHash
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512,
    }

    public class HashValue
    {
        public TipoHash TipoHash { get; set; }
        public byte[] Hash { get; set; }    
        public string HashHex { get; set; }
    }

    //Todo implementarlo 
    public abstract class FileHash:FileHashEvents
    {
        protected long lengthBuffer { get; set; }

        public abstract string CalcularHashText(TipoHash tipo, string text);
        public abstract string CalcularHashAll(TipoHash tipo, string ruta, CancellationToken? token);
        public abstract string CalcularHashAll(TipoHash tipo, string ruta);

        public abstract HashValue[] CalcularMultipleHash(TipoHash[] tipos, string ruta);
        public abstract HashValue[] CalcularMultipleHash(TipoHash[] tipos, string ruta,CancellationToken? token);
    }
}
