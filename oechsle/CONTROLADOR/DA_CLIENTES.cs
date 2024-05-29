using oechsle.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace oechsle.CONTROLADOR
{
    public class DA_CLIENTNES
    {
    string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DbConn"]].ConnectionString;
    public List<Model_Clientes> ListarClientes(Int id, int operacion)
        {
            SqlConnection conexion = null;
            List<Model_Clientes> listaResultado = new List<Model_Clientes>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[2];
                    Parametro[0] = new SqlParameter("@id", SqlDbType.int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = id;
                    
                    Parametro[1] = new SqlParameter("@operation", SqlDbType.int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = operacion;


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "BD_LISTAR", Parametro))
                    {
                        while (reader.Read())
                        {
                            Model_Clientes datos = new Model_Clientes();.
                            datos.Id = DataUtil.ObjectToInt32(reader["ID"]);
                            datos.Nombre = DataUtil.ObjectToString(reader["Nombre"]);
                            datos.Apellidos = DataUtil.ObjectToString(reader["Apellidos"]);
                            datos.Fecha_nacimiento = DataUtil.ObjectToString(reader["Fecha_Nac"]);
                            datos.Edad = DataUtil.ObjectToInt32(reader["Edad"]);
                            datos.datos = datos;
                            listaResultado.Add(datos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
            }

            return listaResultado;
        }

        public string RegistrarClientes(int id, string nombre,string apellidos, date fecha_nac)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];
                    Parametro[0] = new SqlParameter("@Id", SqlDbType.int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = id;

                    Parametro[1] = new SqlParameter("@Nombre", SqlDbType.string);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = nombre;

                    Parametro[2] = new SqlParameter("@Apellidos", SqlDbType.string);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = apellidos;

                    Parametro[3] = new SqlParameter("@Fecha_Nac", SqlDbType.date);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = fecha_nac;



                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "BD_INSERT", Parametro))
                    {
                        while (reader.Read())

                        {
                            resultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
      
    }
}