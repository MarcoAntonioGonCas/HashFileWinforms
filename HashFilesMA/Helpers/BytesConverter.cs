using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFilesMA.Helpers
{
    public static class BytesConverter
    {
        

        //Bytes to hex
        public static string ByteArrayToString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public static string ConvertBytesToHexEvil(byte[] bytes)
        {
            StringBuilder strhex = new StringBuilder();


            foreach (byte b in bytes)
            {

                strhex.Append(b.ToString("X2"));
            }


            return strhex.ToString();

        }
        public static string ConvertBytesToHex(byte[] bytes)
        {
            string hexa = "";

            foreach (byte b in bytes)
            {
                hexa += ConvertToHex(b,2);

            }


            return hexa;

        }
        private static string ConvertToHex(int num, int padding = 0)
        {

            int aux = num;
            int resto;

            string convertido = string.Empty;
            while (aux > 0)
            {
                resto = aux % 16;
                aux /= 16;

                if (resto > 9)
                {
                    resto -= 10;
                    convertido = (char)('A' + resto) + convertido;
                }
                else
                {
                    convertido = (char)(('0') + resto) + convertido;
                }


            }
            if (padding > 0)
            {
                convertido = convertido.PadLeft(padding, '0');
            }

            return convertido;
        }



        //Extra

        public static string BytesToHexEvil(byte[] bytes)
        {
            StringBuilder strhex = new StringBuilder();
            foreach (byte b in bytes)
            {
                strhex.Append(ByteToHexAux(b,2));
            }
            return strhex.ToString();
        }
        private static string ByteToHexAux(byte b,int padding =0)
        {
            //Un byte tiene dos valores haxdecimales
            //Diccionario de valor hexadecimal
            Dictionary<int, char> dic = new Dictionary<int, char>()
            {
                {0,'0' },
                {1,'1' },
                {2,'2' },
                {3,'3' },
                {4,'4' },
                {5,'5' },
                {6,'6' },
                {7,'7' },
                {8,'8' },
                {9,'9'},
                {10,'A'},
                {11,'B'},
                {12,'C'},
                {13,'D'},
                {14,'E'},
                {15,'F'},
            };

            // Obtener los 4 bits más significativos (izquierda) y los 4 bits menos significativos (derecha)
            byte bitsIzq = (byte)((int)b >> 4 & 0xF);
            byte bitsDer = (byte)((int)b & 0xF);
            string numHex = "";

            if(bitsIzq != 0)
            {
                numHex += dic[bitsIzq];
            }

            numHex += dic[bitsDer];

            // Agregar ceros a la izquierda si este esta especificado
            if (padding > 0)
            {
                numHex = numHex.PadLeft(padding,'0');
            }
            return numHex;

        }

        //

        



        //Hex to bytes

        public static byte[] HexToBytes(string hex) {
            Regex regex = new Regex("^[0-9a-fA-F]+");


            if (!regex.IsMatch(hex))
            {
                throw new ArgumentException("No es valor haxecimal valido", nameof(hex));
            }


            byte[] bytes = new byte[hex.Length/2];

            for(int i = 0,j=0; i < hex.Length; i += 2,j++)
            {
                if( i+2 <= hex.Length)
                {
                    int v1 = DevuelveValorChar(hex[i]);
                    int v2 = DevuelveValorChar(hex[i + 1]);
                    int aux = v1 << 4 | v2;

                    bytes[j] = (byte)aux;
                }
                else
                {
                    int v1 = DevuelveValorChar(hex[i]);
                    bytes[j] = (byte)v1;
                }
            }


            return bytes;
            
        }

        private static int DevuelveValorChar(char charHex)
        {
            if( charHex >= 'a' &&charHex <= 'f')
            {
                return (charHex - 'a') + 10;
            }else if( charHex >= 'A' && charHex <= 'F')
            {
                return (charHex - 'a') + 10;
            }else if( charHex >= '0' && charHex <= 'F')
            {
                return (charHex - '0');
            }
            else
            {
                throw new ArgumentException("El char no es valor hexadimal valido");
            }
        }


        public static string IntToBitsEnd(int valor)
        {
            string strBits = "";
            int tamanioInt = sizeof(int) * 8;

            for (int i = tamanioInt - 1; i >= 0; i--)
            {

                int activo = (valor >> i) & 1;
                strBits += ((char)('0' + activo));
            }
            return strBits;
        }
        public static string IntToBitsEndEvil(int valor)
        {
            string strBits = "";
            int bitSignificativo = 1 << ((sizeof(int) * 8) - 1);

            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                int activo = valor & bitSignificativo;

                valor <<= 1;
                strBits += ((char)(activo != 0 ? '1' : '0'));
            }
            return strBits;
        }
        public static string IntToBitsStart(int valor)
        {
            string strBits = "";
            int tamanioInt = sizeof(int) * 8;

            for (int i = 0; i < tamanioInt; i++)
            {

                int activo = (valor) & ( 1 << i);
                strBits = (activo !=0 ? '1' : '0' ) + strBits;
            }
            return strBits;
        }

        public static string IntToBitsStartEvil(int valor)
        {
            string strBits = "";
            int tamanioInt = sizeof(int) * 8;

            for (int i = 0; i < tamanioInt; i++)
            {

                int activo = (valor) & (1);
                valor >>= 1;
                strBits = (char)('0' + activo) + strBits;
            }
            return strBits;
        }

    }
}
