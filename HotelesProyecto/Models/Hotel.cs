using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelesProyecto.Models
{
    public class Hotel
    {
        public int idhotel { get; set; }
        public string nombre { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }

        public int categoria { get; set; }
        public int calificaciones { get; set; }
    }
}
