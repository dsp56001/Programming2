using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCaveSim.Models
{
    public interface ITickable
    {
        public int LifeTimeTicks { get; }
        public void Tick();
    }
}
