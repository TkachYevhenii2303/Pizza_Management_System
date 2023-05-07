using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Management_System_DAL.Entities
{
    public class Sauce : Entity
    {
        public string? Sauce_title { get; set; }

        public bool Is_vegan { get; set; }
    }
}
