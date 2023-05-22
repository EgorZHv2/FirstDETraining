using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviPrilizhenie.Models
{
    public class TarifiOutputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Opisanie { get; set; }
    }
}
