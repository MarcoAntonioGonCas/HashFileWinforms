using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Security.Cryptography;
using System.Threading;
using HashFilesMA.Helpers;
using System.Security.Policy;
using System.Windows.Forms;
using System.Net.Http.Headers;

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

        private HashAlgorithm ObtieneClaseHash(TipoHash tipo)
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
            using (HashAlgorithm algoritmo = ObtieneClaseHash(tipo))
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

        public override string CalcularHashFile(TipoHash tipo, string ruta)
        {
            return CalcularHashFile(tipo, ruta, null);

        }
        public override string CalcularHashFile(TipoHash tipo, string ruta, CancellationToken? token)
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
                using(HashAlgorithm hash = ObtieneClaseHash(tipo))
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



        //Calular multiples hash
        public override HashValue[] CalcularMultipleHashFile(TipoHash[] tipos, string ruta)
        {
           return CalcularMultipleHashFile(tipos, ruta, null);
        }

        public override HashValue[] CalcularMultipleHashFile(TipoHash[] tipos, string ruta, CancellationToken? token)
        {
            try
            {
                //Los hashesh tendran la misma longitud los tipos de hash a calcular
                HashValue[] hashes = new HashValue[tipos.Length];  
                //Obtenemos todos los algoritmos hash a utilizar
                HashAlgorithm[] algoritmos = tipos.Select( tipo => ObtieneClaseHash(tipo) ).ToArray();


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
                            _enProgreso = false;
                            throw new OperationCanceledException();
                        }

                        contadorLeidos += leidos;

                        //Recorremos cada algoritmo
                        foreach(HashAlgorithm algoritmo in algoritmos)
                        {
                            //Calculalamos el bloque en el algoritmo actual
                            algoritmo.TransformBlock(buffer, 0, leidos, null,0);
                            
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
                    for(int i = 0; i < algoritmos.Length; i++)
                    {
                        algoritmos[i].TransformFinalBlock(buffer, 0,0);

                        hashes[i] = new HashValue()
                        {
                            Hash = algoritmos[i].Hash,
                            TipoHash = tipos[i]
                        };
                        hashes[i].HashHex = BytesConverter.ConvertBytesToHex(hashes[i].Hash);

                        algoritmos[i].Dispose();
                    }

                    OnProgresoCompletado(EventArgs.Empty);



                    _enProgreso = false;

                    return hashes;

                }


            }
            catch(Exception ex)
            {
                OnError(new ErrorHashFileArgs { Mensaje = ex.Message });

                return new HashValue[0];
            }
        }

        public override HashValue[] CalcularMultipleHashText(TipoHash[] tipos, string text)
        {
            try
            {
                int len = tipos.Length;
                HashValue[] hashes = new HashValue[len];
                HashAlgorithm[] algoritmos = new HashAlgorithm[len];

                for (int i = 0; i < len; i++)
                {
                    algoritmos[i] = ObtieneClaseHash(tipos[i]);
                }

                for (int i = 0; i < len; i++)
                {
                    HashAlgorithm clase = algoritmos[i];
                    byte[] hash = clase.ComputeHash(Encoding.Default.GetBytes(text));

                    hashes[i] = new HashValue()
                    {
                        Hash = hash,
                        TipoHash = tipos[i],
                        HashHex = BytesConverter.ConvertBytesToHex(hash)
                    };
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
            catch (Exception ex)
            {

                OnError(new ErrorHashFileArgs
                {
                    Mensaje = ex.Message
                });
                return new HashValue[0];
            }
        }
    }
}
