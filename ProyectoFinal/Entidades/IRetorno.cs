﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public interface IRetorno<T> where T:class
    {
        void Ejecutar(T template);
       
    }
}
