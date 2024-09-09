using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Datos.Configuracion;
using Demo.Entidades.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Demo.Entidades.Dicionarios;

namespace Demo.Datos
{
    public class DemoDatos : IDemoDatos
    {
        private readonly ConfiguracionConexion _Server;
        public DemoDatos(IOptions<ConfiguracionConexion> options)
        {
            _Server = options.Value;
        }

        public int Nuevo(DemoEntidad producto)
        {
            using (var sqlServer = new SqlConnection(_Server.SQlServer))
            {
                sqlServer.Open();
                SqlCommand cmd = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Demo_Ins, sqlServer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(nameof(DemoEntidad.nombre), producto.nombre);
                cmd.Parameters.AddWithValue(nameof(DemoEntidad.precio), producto.precio);


                var dr = cmd.ExecuteNonQuery();
                return Convert.ToInt32(dr);
            };
        }

        public int Eliminar(int Id)
        {
            using (var sqlServer = new SqlConnection(_Server.SQlServer))
            {
                sqlServer.Open();
                SqlCommand cmd = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Demo_Ins, sqlServer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(nameof(DemoEntidad.id), Id);

                var dr = cmd.ExecuteNonQuery();
                return Convert.ToInt32(dr);
            };
        }

        public List<DemoEntidad> Obtener()
        {
            List<DemoEntidad> demo = new List<DemoEntidad>();

            using (var sqlServer = new SqlConnection(_Server.SQlServer))
            {
                sqlServer.Open();
                SqlCommand command = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Demo_Obt, sqlServer);
                command.CommandType = CommandType.StoredProcedure;

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        demo.Add(new DemoEntidad()
                        {
                            id = Convert.ToInt32(dr[nameof(DemoEntidad.id)])
                            , nombre = dr[nameof(DemoEntidad.nombre)].ToString()
                            , estatus = Convert.ToInt32(dr[nameof(DemoEntidad.estatus)])
                            , precio = Convert.ToDecimal(dr[nameof(DemoEntidad.precio)])
                            
                        });
                    }

                }
            }


            return demo;
        }
    }
}
