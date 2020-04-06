using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class DatosRecibidos
    {
        public string Path      { get; set; }
        public string Name          { get; set; }
        public int   CesarKey           { get; set; }
        public int   ZigZag_Grade           { get; set; }
        public int    m                 { get; set; }
        public string  Read             {get;set;}
        public string  Write            { get; set; }
    }
}
