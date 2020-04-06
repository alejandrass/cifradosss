using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CifradosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Lab 5 Cifrados Simetricos";
        }
        [HttpPost("Cifrar/{Tipo}")]
        public void Cifrar([FromBody] object json, string Tipo)
        {

            var datos = JsonConvert.DeserializeObject<DatosRecibidos>(json.ToString());
            var file = new FileStream(datos.Path, FileMode.Open);
            var Text = new StreamReader(file).ReadToEnd();
            file.Close();
            var cifrado = "";
            switch (Tipo.ToLower())
            {
                case "cesar":
                    cifrado = Cesar.Encipher(Text, datos.CesarKey);
                    break;

                case "zigzag":
                    cifrado = new Zigzag().Encipher(datos.ZigZag_Grade, Text);
                    break;


                case "ruta":
                    cifrado = new Ruta().Cipher(datos.Read, datos.Write, Text, datos.m);
                    break;
                default:
                    break;
            }
            var NewFile = new FileStream($"{Path.GetDirectoryName(datos.Path)}\\{datos.Name}.txt", FileMode.Create);
            var writer = new StreamWriter(NewFile);
            foreach (var item in cifrado)
            {
                writer.Write(item);
            }
            NewFile.Close();
        }


        [HttpPost("Decifrar/{Tipo}")]
        public void Decifrar([FromBody] object json, string Tipo)
        {

            var datos = JsonConvert.DeserializeObject<DatosRecibidos>(json.ToString());
            var file = new FileStream(datos.Path, FileMode.Open);
            var Text = new StreamReader(file).ReadToEnd();
            file.Close();
            var cifrado = "";
            switch (Tipo.ToLower())
            {
                case "cesar":
                    cifrado = Cesar.Decipher(Text, datos.CesarKey);
                    break;

                case "zigzag":
                    cifrado = new Zigzag().Decipher(datos.ZigZag_Grade, Text);
                    break;


                case "ruta":
                    cifrado = new Ruta().DeCipher(datos.Read, datos.Write, Text, datos.m);
                    break;
                default:
                    break;
            }
            var NewFile = new FileStream($"{Path.GetDirectoryName(datos.Path)}\\{datos.Name}.txt", FileMode.Create);
            var writer = new StreamWriter(NewFile);
            foreach (var item in cifrado)
            {
                writer.Write(item);
            }
            NewFile.Close();
        }
    }
}

