using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLab
{
    public class Build
    {
        public int ID { get; set; }
        public string BuildName { get; set; }
        public string Components { get; set; }
        public decimal Price { get; set; }

        public bool Default { get; set; }

        public override string ToString()
        {
            return BuildName; // para mostrar sempre o nome na combo
        }
    }
}
