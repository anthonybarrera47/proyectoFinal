﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CallerMemberName
    {
        public string Nombre { get; set; }
        public void UsingCallerMemberName([CallerMemberName]string callerName = "No asignado")
        {     
            Nombre = callerName;
        }
    }
}
