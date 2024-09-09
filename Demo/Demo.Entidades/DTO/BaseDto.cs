using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entidades.DTO
{
    public class BaseDto<T>
    {
        public bool Completado { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }
    }
}
