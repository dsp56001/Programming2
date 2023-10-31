﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrafting.Models
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }

        string About();
    }
}
