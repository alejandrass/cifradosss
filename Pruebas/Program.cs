using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cifradoss.Cifrados;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            var lol = Cesar.Encipher("Hola Mundo, ESTE ES MI PRIMER CIFRADO; FUNCIONAAAAAAAAAAAAAAAAAAAAAAAAAAA", 5);
            var lal = Cesar.Decipher(lol, 5);
            var wow = new Ruta().Cipher("d", "r", lal, 3);
            var waw = new Ruta().Cipher("r", "d", wow, 3);
            var asd= new Zigzag().Encipher(5,lal);
            var asdasd = new Zigzag().Uncipher(5,asd);

        }
    }
}
