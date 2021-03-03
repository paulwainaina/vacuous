using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vacuous
{
    class Program
    {
        static byte[] getBytes(string filename)
        {
            return File.ReadAllBytes(filename);
        }
        static void writeFile(byte[] filebytes,string filename)
        {
            File.WriteAllBytes(filename, filebytes);
        }
        static string convertTobase64(byte[] fileBytes)
        {
            return Convert.ToBase64String(fileBytes);
        }
        static byte[] convertFrombase64(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }
        static void help()
        {
            System.Console.WriteLine("Usage: vacuous.exe  <path to exe/shellcode>  ");
        }
        static string  convertToHex(string filename)
        {
            return BitConverter.ToString(getBytes(filename)).Replace("-", "/");
        }

        static byte[] convertFromHex(string filehex)
        {
            byte[] data = new byte[filehex.Length / 2];
            for(int i = 0; i < data.Length; i++)
            {
                string bvalue = filehex.Substring(i * 2, 2);
                data[i] = byte.Parse(bvalue, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            return data;
        }
        static void Main(string[] args)
        {
            if (args.Length <2)
            {
                System.Console.WriteLine("No arguments found");
                help();
                return ;
            }
            string xstring = convertToHex(args[0]);
            File.WriteAllText(args[1], xstring);
           
        }
    }
}
