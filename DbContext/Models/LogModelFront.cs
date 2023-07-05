using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext.Models
{
    public class LogModelFront
    {
        public string UserName { get; set; }
        public double Duration { get; set; }
        public float? Result { get; set; }
        public string Ip { get; set; }
    }
}
