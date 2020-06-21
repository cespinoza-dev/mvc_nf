using DataAccess.Contract;
using DataAccess.Repository;
using Entity_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class daoCliente : OracleConexion, IOperacionCrud<ClienteBO>
    {
        public string Actualizar(ClienteBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("TEST_SP_UPDATE_CLIENTE", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("P_DNI", OracleDbType.Varchar2)).Value = dto.DNI;
                        cmd.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2)).Value = dto.NOMBRE;
                        cmd.Parameters.Add(new OracleParameter("P_APELLIDO", OracleDbType.Varchar2)).Value = dto.APELLIDO;
                        cmd.Parameters.Add(new OracleParameter("P_EMAIL", OracleDbType.Varchar2)).Value = dto.EMAIL;
                        cmd.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = dto.TELEFONO;
                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleDbType.Varchar2,50)).Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        result = Convert.ToString(cmd.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en metodo Actualizar" + ex.Message);
            }
            return result;
        }

        public string Eliminar(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("TEST_SP_DELETE_CLIENTE", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("P_DNI", OracleDbType.Varchar2)).Value = dto;
                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleDbType.Varchar2, 50)).Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        result = Convert.ToString(cmd.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en metodo Eliminar" + ex.Message);
            }
            return result;
        }

        public string Insertar(ClienteBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle)) {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("TEST_SP_INSERT_CLIENTE", cn)) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("P_DNI",OracleDbType.Varchar2)).Value = dto.DNI;
                        cmd.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2)).Value = dto.NOMBRE;
                        cmd.Parameters.Add(new OracleParameter("P_APELLIDO", OracleDbType.Varchar2)).Value = dto.APELLIDO;
                        cmd.Parameters.Add(new OracleParameter("P_EMAIL", OracleDbType.Varchar2)).Value = dto.EMAIL;
                        cmd.Parameters.Add(new OracleParameter("P_TELEFONO", OracleDbType.Int32)).Value = dto.TELEFONO;
                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleDbType.Varchar2, 50)).Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        result = Convert.ToString(cmd.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en metodo Insertar" + ex.Message);
            }
            return result;
        }

        public List<ClienteBO> Listar()
        {
            List<ClienteBO> list = new List<ClienteBO>();
            ClienteBO dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle)) {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("TEST_SP_SELECT_CLIENTE", cn)) {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleDbType.RefCursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)) {
                            while (dr.Read()) {
                                dto = new ClienteBO();
                                dto.DNI = dr["DNI"].ToString();
                                dto.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                                dto.APELLIDO = Convert.ToString(dr["APELLIDO"]);
                                dto.EMAIL = Convert.ToString(dr["EMAIL"]);
                                dto.TELEFONO = Convert.ToInt32(dr["TELEFONO"]);
                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en metodo Listar" + ex.Message);
            }
            return list;
        }
    }
}
