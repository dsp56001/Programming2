using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public interface IAboutable
    {
        string Name { get; set; }
        string Description { get; set; }
        string About();
    }
}
