using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public  interface IEntity : IAboutable, ITickable
    {
        int Id { get; }
    }
}
