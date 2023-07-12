using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Security.Cryptography;
using System.Threading;
using HashFilesMA.Helpers;

namespace HashFilesMA.FileHelpers
{

    

   
    public class FileHashCalculator : FileHash
    {
        //Buffer de 16MB
        private bool _enProgreso = false;

        public bool EnProgreso => _enProgreso;

        
        public FileHashCalculator()
        {
            //16MB 
            this.lengthBuffer = 16777216;
        }

        private HashAlgorithm ObtieneHash(TipoHash tipo)
        {
            HashAlgorithm hash = null;
            if (tipo == TipoHash.MD5)
            {
                hash = MD5.Create();
            }
            else if (tipo == TipoHash.SHA1)
            {
                hash = SHA1.Create();

            }
            else if (tipo == TipoHash.SHA256)
            {
                hash = SHA256.Create();
            }
            else if (tipo == TipoHash.SHA384)
            {
                hash = SHA384.Create();
            }
            else if (tipo == TipoHash.SHA512)
            {
                hash = SHA512.Create();
            }
            else
            {
                throw new ArgumentException("No existe");
            }
            return hash;

        }
        private byte[] CalcularHashAux(TipoHash tipo,string path, CancellationToken? token)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            _enProgreso = true;
            using (HashAlgorithm algoritmo = ObtieneHash(tipo))
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                long tamanioArchivo = fs.Length;
                long contadorLeidos = 0;

                byte[] buffer = new byte[lengthBuffer];
                int leidos;

                while ((leidos = fs.Read(buffer, 0, buffer.Length)) > 0)
                {

                    if (token.HasValue && token.Value.IsCancellationRequested)
                    {
                        _enProgreso = false;
                        throw new OperationCanceledException();
                    }

                    contadorLeidos += leidos;
                    algoritmo.TransformBlock(buffer, 0, leidos, null, 0);


                    OnProgreso(new ProgressHashFileArgs()
                    {
                        Bytes = contadorLeidos,
                        TotalBytes = tamanioArchivo,
                        Progreso = contadorLeidos / (float)tamanioArchivo
                    });
                }

                algoritmo.TransformFinalBlock(buffer, 0, 0);





                byte[] md5string = algoritmo.Hash;


                _enProgreso = false;

                return md5string;

            }
        }

        public override string CalcularHashAll(TipoHash tipo, string ruta)
        {
            return CalcularHashAll(tipo, ruta, null);

        }
        public override string CalcularHashAll(TipoHash tipo, string ruta, CancellationToken? token)
        {
            try
            {
                string hashHex = "";
                
                byte[] bytesHash = CalcularHashAux(tipo,ruta,token);
                hashHex = BytesConverter.ConvertBytesToHex(bytesHash);

                OnProgresoCompletado(new EventArgs());
                
                return hashHex;
            }
            catch (Exception ex)
            {
                OnError(new ErrorHashFileArgs() { Mensaje = ex.Message});
                return "";
            }

        }
        public override string CalcularHashText(TipoHash tipo, string text)
        {
            try
            {
                using(HashAlgorithm hash = ObtieneHash(tipo))
                {
                    
                    byte[] bytesText = Encoding.Default.GetBytes(text);

                    byte[] hashBytes = hash.ComputeHash(bytesText);

                    OnProgreso(new ProgressHashFileArgs()
                    {
                        Bytes = hashBytes.Length,
                        TotalBytes = hashBytes.Length,
                        Progreso = 1
                    });
                    string hashHEX = BytesConverter.ConvertBytesToHex(hashBytes);

                    OnProgresoCompletado(new EventArgs());


                    return hashHEX;

                }
            } catch (Exception ex)
            {
                OnError(new ErrorHashFileArgs() { Mensaje = ex.Message });
                return "";
            }
        }
    }
}
