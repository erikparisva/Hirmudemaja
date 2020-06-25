using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hirmudemja.Models
{
    public class hirmudemaja
    {
        public int id { get; set; }
        public string Eesnimi { get; set; }
        [Range(-1, 10)]
        public int Sisenes { get; set; } = -1;
        public int Lahkus { get; set; } = -1;
    }
}