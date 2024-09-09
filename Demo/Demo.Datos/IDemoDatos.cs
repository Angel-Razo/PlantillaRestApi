using Demo.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Datos
{
    public interface IDemoDatos
    {
        int Nuevo(DemoEntidad producto);

        List<DemoEntidad> Obtener();
        int Eliminar(int Id);
    }
}
