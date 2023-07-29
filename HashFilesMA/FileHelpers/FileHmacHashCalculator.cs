using HashFilesMA.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            byte[] bytesHash = CalcularHashFileAux(tipo, ruta, key, token);
            string hexHash = BytesConverter.ConvertBytesToHex(bytesHash);

            return hexHash;

        }
        private byte[] CalcularHashFileAux(TipoHMACHash tipo, string ruta, string key, CancellationToken? token)
        {
            if(!File.Exists(ruta)) {
                throw new FileNotFoundException(ruta);
            }

            byte[] buffer = new byte[this.lengthBuffer];
            byte[] bytesHash = null;

            long contadorBytes = 0;

            using ( FileStream fs = new FileStream( ruta, FileMode.Open, FileAccess.Read))
            using ( HMAC hmac = ObtieneClaseHmac( tipo, Encoding.Default.GetBytes(key)))
            {
                long totalBytes = fs.Length;
                int leidos = 0;

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

        public override string CalcularHashFile(TipoHMACHash tipo, string ruta, string key, CancellationToken? token)
        {
            try
            {
                string hashHex = CalculaHashHex(tipo, ruta, key, token);

                return hashHex;
            }
            catch(Exception ex)
            {
                OnError(new ErrorHashFileArgs() { Mensaje = ex.Message });
                return "";
            }
        }

        public override string CalcularHashFile(TipoHMACHash tipo, string ruta, string key)
        {
            return CalculaHashHex(tipo,ruta, key, null);
        }

        public override string CalcularHashText(TipoHMACHash tipo, string text, string key)
        {
            try
            {

                using(HMAC hmac = ObtieneClaseHmac(tipo, Encoding.Default.GetBytes(key)))
                {
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
                OnError(new ErrorHashFileArgs() { Mensaje = ex.Message });
                return "";
            }
        }



        //Others
        private HMAC ObtieneClaseHmac(TipoHMACHash tipo, byte[] key)
        {
            HMAC hmac = null;

            if(tipo == TipoHMACHash.HMACMD5)
            {
                hmac = new HMACMD5(key);
            }
            else if(tipo == TipoHMACHash.HMACSHA1)
            {
                hmac = new HMACSHA1(key);
            }
            else if (tipo == TipoHMACHash.HMACSHA256)
            {
                hmac = new HMACSHA256(key);
            }
            else if (tipo == TipoHMACHash.HMACSHA384)
            {
                hmac = new HMACSHA384(key);
            }
            else if (tipo == TipoHMACHash.HMACSHA512)
            {
                hmac = new HMACSHA512(key);
            }
            else
            {
                throw new ArgumentException("No es un tipo valido");
            }

            return hmac;

        }

        public override HmacValue[] CalcularMultipleHashFile(TipoHMACHash[] tipos, string ruta, string key)
        {
            return CalcularMultipleHashFile(tipos, ruta, key, null);
        }

        public override HmacValue[] CalcularMultipleHashFile(TipoHMACHash[] tipos, string ruta, string key, CancellationToken? token)
        {
            try
            {
                //Los hashesh tendran la misma longitud los tipos de hash a calcular
                HmacValue[] hashes = new HmacValue[tipos.Length];
                //Obtenemos todos los algoritmos hmac a utilizar
                HMAC[] algoritmos = tipos.Select(tipo => ObtieneClaseHmac(tipo, Encoding.Default.GetBytes(key))).ToArray();

                //Abrimos el archivos en modo lectura 
                using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    //Obtenemos el tamaño del archivo
                    long tamanioArchivo = fs.Length;
                    long contadorLeidos = 0;

                    byte[] buffer = new byte[lengthBuffer];
                    int leidos;

                    //Leeamos en bloques
                    while ((leidos = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        //Si se solicita la concelacion de la operacion la realizamos
                        if (token.HasValue && token.Value.IsCancellationRequested)
                        {
                           
                            throw new OperationCanceledException();
                        }

                        contadorLeidos += leidos;

                        //Recorremos cada algoritmo
                        foreach (HMAC algoritmo in algoritmos)
                        {
                
                            //Calculalamos el bloque en el algoritmo actual
                            algoritmo.TransformBlock(buffer, 0, leidos, null, 0);
                        }

                        //Invocamos el evento de progreso pasando los bytes leidos
                        //El total de bytes
                        OnProgreso(new ProgressHashFileArgs()
                        {
                            Bytes = contadorLeidos,
                            TotalBytes = tamanioArchivo,
                            Progreso = contadorLeidos / (float)tamanioArchivo // Progreso 0.0 - 1.0
                        });
                    }
                    //Finalmente recorremos de  
                    for (int i = 0; i < algoritmos.Length; i++)
                    {
                        algoritmos[i].TransformFinalBlock(buffer, 0, 0);

                        hashes[i] = new HmacValue()
                        {
                            Hash = algoritmos[i].Hash,
                            TipoHash = tipos[i],
                            HashHex = BytesConverter.ConvertBytesToHex(algoritmos[i].Hash)
                        };

                        algoritmos[i].Dispose();
                    }

                    OnProgresoCompletado(EventArgs.Empty);


                    return hashes;

                }


            }
            catch (Exception ex)
            {
                OnError(new ErrorHashFileArgs { Mensaje = ex.Message });

                return new HmacValue[0];
            }
        }

        public override HmacValue[] CalcularMultipleHashText(TipoHMACHash[] tipos, string text, string key)
        {
            try
            {
                int len = tipos.Length;
                HmacValue[] hashes = new HmacValue[len];
                HMAC[] algoritmos = new HMAC[len];

                for (int i = 0; i < len; i++)
                {
                    algoritmos[i] = ObtieneClaseHmac(tipos[i],Encoding.Default.GetBytes(key));
                }

                for (int i = 0; i < len; i++)
                {
                    HMAC clase = algoritmos[i];
                    byte[] hash = clase.ComputeHash(Encoding.Default.GetBytes(text));

                    hashes[i] = new HmacValue()
                    {
                        Hash = hash,
                        TipoHash = tipos[i],
                        HashHex = BytesConverter.ConvertBytesToHex(hash)
                    };
                    clase.Dispose();
                }

                OnProgreso(new ProgressHashFileArgs()
                {
                    Bytes = 1,
                    Progreso = 1,
                    TotalBytes = 1,
                });
                //OnProgresoCompletado(EventArgs.Empty);
                return hashes;

            }
            catch(Exception ex) {

                OnError(new ErrorHashFileArgs
                {
                    Mensaje = ex.Message
                });
                return new HmacValue[0]; 
            }
        }
    }
}
