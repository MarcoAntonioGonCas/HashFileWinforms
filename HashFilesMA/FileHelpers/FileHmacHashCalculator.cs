using HashFilesMA.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HashFilesMA.FileHelpers
{
    public class FileHmacHashCalculator : FileHmacHash
    {
        public FileHmacHashCalculator()
        {
            //16MB 
            this.lengthBuffer = 16777216;
        }

        //Helpers
        private string CalculaHashHex(TipoHMACHash tipo, string ruta, string key, CancellationToken? token)
        {
            byte[] bytesHash = CalcularHashAllAux(tipo, ruta, key, token);
            string hexHash = BytesConverter.ConvertBytesToHex(bytesHash);

            return hexHash;

        }
        private byte[] CalcularHashAllAux(TipoHMACHash tipo, string ruta, string key, CancellationToken? token)
        {
            if(!File.Exists(ruta)) {
                throw new FileNotFoundException(ruta);
            }

            byte[] buffer = new byte[this.lengthBuffer];
            byte[] bytesHash = null;

            long contadorBytes = 0;

            using ( FileStream fs = new FileStream( ruta, FileMode.Open, FileAccess.Read))
            using ( HMAC hmac = ObtieneClaseHmac( tipo ))
            {
                long totalBytes = fs.Length;
                int leidos = 0;

                hmac.Key = Encoding.Default.GetBytes(key);

                while ((leidos = fs.Read(buffer, 0, (int)this.lengthBuffer)) > 0 )  { 
                    
                    if(token.HasValue && token.Value.IsCancellationRequested)
                    {
                        throw new OperationCanceledException();
                    }
                    
                    //Calculamos el bloque actual
                    hmac.TransformBlock(buffer, 0, leidos,null,0);

                    //Sumamos los bytes leidos
                    contadorBytes += leidos;

                    

                    //Mostramos el progreso actual
                    OnProgreso(new ProgressHashFileArgs()
                    {
                        Bytes = contadorBytes,
                        TotalBytes = totalBytes,
                        Progreso = (float)contadorBytes / (float)totalBytes
                    });
                
                }
                //Finalizamos el calculo de hash
                hmac.TransformFinalBlock(buffer, 0, 0);


                //Obtenemos el hash
                bytesHash = hmac.Hash;

            }


            OnProgresoCompletado(new EventArgs());
            return bytesHash;
        }


        //Methods

        public override string CalcularHashAll(TipoHMACHash tipo, string ruta, string key, CancellationToken? token)
        {
            try
            {
                string hashHex = CalculaHashHex(tipo, ruta, key, token);

                return hashHex;
            }
            catch
            {
                OnError(new EventArgs());
                return "";
            }
        }

        public override string CalcularHashAll(TipoHMACHash tipo, string ruta, string key)
        {
            return CalculaHashHex(tipo,ruta, key, null);
        }

        public override string CalcularHashText(TipoHMACHash tipo, string text, string key)
        {
            try
            {

                using(HMAC hmac = ObtieneClaseHmac(tipo))
                {
                    hmac.Key = Encoding.Default.GetBytes(key);
                    byte[] bytesText = Encoding.Default.GetBytes(text);
                    byte[] bytesHash = hmac.ComputeHash(bytesText);
                    OnProgreso(new ProgressHashFileArgs()
                    {
                        Bytes = bytesText.Length,
                        TotalBytes = bytesHash.Length,
                        Progreso = 1
                    });

                    string hashHex = BytesConverter.ConvertBytesToHex(bytesHash);

                    OnProgresoCompletado(new EventArgs());
                    return hashHex;
                }


            }catch(Exception ex) {
                OnError(new EventArgs());
                return "";
            }
        }



        //Others
        private HMAC ObtieneClaseHmac(TipoHMACHash tipo)
        {
            HMAC hmac = null;

            if(tipo == TipoHMACHash.HMACMD5)
            {
                hmac = HMACMD5.Create();
            }
            else if(tipo == TipoHMACHash.HMACSHA1)
            {
                hmac = HMACSHA1.Create();
            }
            else if (tipo == TipoHMACHash.HMACSHA256)
            {
                hmac = HMACSHA256.Create();
            }
            else if (tipo == TipoHMACHash.HMACSHA384)
            {
                hmac = HMACSHA384.Create();
            }
            else if (tipo == TipoHMACHash.HMACSHA512)
            {
                hmac = HMACSHA512.Create();
            }
            else
            {
                throw new ArgumentException("No es un tipo valido");
            }

            return hmac;

        }
        
    }
}
