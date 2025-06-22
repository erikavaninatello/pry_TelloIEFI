 using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_TelloIEFI
{
    internal class clsUsuarioDAO
    {
        private clsConexionBD conexionBD;

        public clsUsuarioDAO()
        {
            conexionBD = new clsConexionBD();
        }

        public bool ValidarUsuario(string nombreUsuario, string clave)
        {
            bool esValido = false;

            try
            {
                using (OleDbConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = ? AND Clave = ?";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", nombreUsuario);
                    cmd.Parameters.AddWithValue("?", clave);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    esValido = count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}");
            }

            return esValido;
        }
        public int ObtenerIdUsuario(string nombreUsuario)
        {
            int idUsuario = 0;

            try
            {
                using (OleDbConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT Id FROM Usuarios WHERE Usuario = ?";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", nombreUsuario);

                    idUsuario = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el ID del usuario: {ex.Message}");
            }

            return idUsuario;
        }

        public List<clsUsuario> ObtenerUsuarios()
        {
            List<clsUsuario> usuarios = new List<clsUsuario>();

            try
            {
                using (OleDbConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "SELECT Id, Usuario, Clave, IdRol, NombreCompleto, Tarea, Fecha, HorarioInicio, HorarioFin FROM Usuarios";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int idUsuario = Convert.ToInt32(reader["Id"]);

                        clsUsuario usuario = new clsUsuario
                        {
                            Id = idUsuario,
                            Usuario = reader["Usuario"].ToString(),
                            Clave = reader["Clave"].ToString(),
                            IdRol = Convert.ToInt32(reader["IdRol"]),
                            NombreCompleto = reader["NombreCompleto"].ToString(),
                            Tarea = reader["Tarea"].ToString(),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            HorarioInicio = reader["HorarioInicio"] != DBNull.Value
                                ? Convert.ToDateTime(reader["HorarioInicio"]).ToString("HH:mm")
                                : "",
                            HorarioFin = reader["HorarioFin"] != DBNull.Value
                                ? Convert.ToDateTime(reader["HorarioFin"]).ToString("HH:mm")
                                : ""
                        };


                        var auditorias = ObtenerAuditoriasPorUsuario(idUsuario);
                        if (auditorias.Any())
                        {
                            var ultima = auditorias.First();
                            usuario.HoraIngreso = ultima.HoraIngreso?.ToString(@"hh\:mm") ?? "";
                            usuario.HoraSalida = ultima.HoraSalida?.ToString(@"hh\:mm") ?? "";
                        }

                        usuarios.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los usuarios: {ex.Message}");
            }

            return usuarios;
        }
        public int RegistrarInicioSesion(clsAuditoria auditoria)
        {
            int idGenerado = 0;

            try
            {
                using (OleDbConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "INSERT INTO Auditoria (IdUsuario, FechaIngreso, HoraIngreso, HoraSalida) VALUES (?, ?, ?, ?)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", auditoria.IdUsuario);
                    cmd.Parameters.AddWithValue("?", auditoria.FechaIngreso);
                    cmd.Parameters.AddWithValue("?", auditoria.HoraIngreso);
                    cmd.Parameters.AddWithValue("?", (object)auditoria.HoraSalida ?? DBNull.Value);
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = "SELECT @@IDENTITY";
                    idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el inicio de sesión: {ex.Message}");
            }

            return idGenerado;
        }
        public void RegistrarSalidaSesion(clsAuditoria auditoria)
        {
            try
            {
                using (OleDbConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "UPDATE Auditoria SET HoraSalida = ? WHERE IdUsuario = ? AND FechaIngreso = ?";
                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    cmd.Parameters.AddWithValue("?", auditoria.HoraSalida);
                    cmd.Parameters.AddWithValue("?", auditoria.IdUsuario);
                    cmd.Parameters.AddWithValue("?", auditoria.FechaIngreso);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar hora de salida: " + ex.Message);
            }
        }
        public void AgregarUsuario(clsUsuario usuario)
        {
            using (OleDbConnection conexion = conexionBD.AbrirConexion())
            {
                string query = "INSERT INTO Usuarios (Usuario, Clave, NombreCompleto, IdRol, Tarea, Fecha, HorarioInicio, HorarioFin) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                using (OleDbCommand comando = new OleDbCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("?", usuario.Usuario);
                    comando.Parameters.AddWithValue("?", usuario.Clave);
                    comando.Parameters.AddWithValue("?", usuario.NombreCompleto);
                    comando.Parameters.AddWithValue("?", usuario.IdRol);
                    comando.Parameters.AddWithValue("?", usuario.Tarea);
                    comando.Parameters.AddWithValue("?", usuario.Fecha);
                    comando.Parameters.AddWithValue("?", usuario.HorarioInicio); // debe estar en formato HH:mm
                    comando.Parameters.AddWithValue("?", usuario.HorarioFin);    // igual que arriba
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void ModificarUsuario(clsUsuario usuario)
        {
            using (OleDbConnection conexion = conexionBD.AbrirConexion())
            {
                string query = "UPDATE Usuarios SET Usuario=?, Clave=?, NombreCompleto=?, IdRol=?, Tarea=?, Fecha=?, HorarioInicio=?, HorarioFin=? WHERE Id=?";
                using (OleDbCommand comando = new OleDbCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("?", usuario.Usuario);
                    comando.Parameters.AddWithValue("?", usuario.Clave);
                    comando.Parameters.AddWithValue("?", usuario.NombreCompleto);
                    comando.Parameters.AddWithValue("?", usuario.IdRol);
                    comando.Parameters.AddWithValue("?", usuario.Tarea);
                    comando.Parameters.AddWithValue("?", usuario.Fecha);
                    comando.Parameters.AddWithValue("?", usuario.HorarioInicio); // formato HH:mm
                    comando.Parameters.AddWithValue("?", usuario.HorarioFin);    // formato HH:mm
                    comando.Parameters.AddWithValue("?", usuario.Id);
                    comando.ExecuteNonQuery();
                }
            }
        }
        public void EliminarUsuario(int id)
        {
            try
            {
                using (OleDbConnection conn = conexionBD.AbrirConexion())
                {
                    string query = "DELETE FROM Usuarios WHERE Id = ?";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}");
            }
        }
        public List<clsAuditoria> ObtenerAuditoriasPorUsuario(int idUsuario)
        {
            List<clsAuditoria> lista = new List<clsAuditoria>();

            using (OleDbConnection con = new clsConexionBD().AbrirConexion())
            {
                string query = "SELECT FechaIngreso, HoraIngreso, HoraSalida FROM Auditoria WHERE IdUsuario = @IdUsuario ORDER BY FechaIngreso DESC";

                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clsAuditoria auditoria = new clsAuditoria();


                            auditoria.FechaIngreso = reader["FechaIngreso"] != DBNull.Value
                                ? Convert.ToDateTime(reader["FechaIngreso"])
                                : DateTime.MinValue;
                            if (reader["HoraIngreso"] != DBNull.Value)
                            {
                                if (DateTime.TryParse(reader["HoraIngreso"].ToString(), out DateTime horaIngresoParsed))
                                {
                                    auditoria.HoraIngreso = horaIngresoParsed.TimeOfDay;
                                }
                                else
                                {
                                    auditoria.HoraIngreso = null;
                                }
                            }

                            if (reader["HoraSalida"] != DBNull.Value)
                            {
                                if (DateTime.TryParse(reader["HoraSalida"].ToString(), out DateTime horaSalidaParsed))
                                {
                                    auditoria.HoraSalida = horaSalidaParsed.TimeOfDay;
                                }
                                else
                                {
                                    auditoria.HoraSalida = null;
                                }
                            }


                            lista.Add(auditoria);
                        }
                    }
                }
            }

            return lista;
        }
        public void RegistrarSalidaSesionPorId(int idAuditoria, TimeSpan horaSalida)
        {
            using (OleDbConnection conn = conexionBD.AbrirConexion())
            {
                string query = "UPDATE Auditoria SET HoraSalida = ? WHERE Id = ?";
                OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("?", horaSalida);
                cmd.Parameters.AddWithValue("?", idAuditoria);

                cmd.ExecuteNonQuery();
            }
        }
        public List<clsTarea> ObtenerTareasPorUsuario(string usuario)
        {
            List<clsTarea> lista = new List<clsTarea>();

            using (OleDbConnection conexion = clsConexionBD.ObtenerConexion())
            {
                string consulta = @"
            SELECT Descripcion, Lugar, Comentario, Fecha, Hora, 
                   Insumo, Estudio, Vacacion, Recibo, Salario
            FROM RegistroTareas
            INNER JOIN Usuarios ON RegistroTareas.IdUsuario = Usuarios.Id
            WHERE Usuarios.Usuario = ?";

                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                comando.Parameters.AddWithValue("?", usuario);

                OleDbDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    clsTarea t = new clsTarea
                    {
                        Descripcion = lector["Descripcion"]?.ToString(),
                        Lugar = lector["Lugar"]?.ToString(),
                        Comentario = lector["Comentario"]?.ToString(),
                        Fecha = lector["Fecha"] != DBNull.Value ? Convert.ToDateTime(lector["Fecha"]) : DateTime.MinValue,
                        Hora = lector["Hora"]?.ToString(),

                      
                        Insumo = lector["Insumo"] != DBNull.Value && Convert.ToBoolean(lector["Insumo"]),
                        Estudio = lector["Estudio"] != DBNull.Value && Convert.ToBoolean(lector["Estudio"]),
                        Vacacion = lector["Vacacion"] != DBNull.Value && Convert.ToBoolean(lector["Vacacion"]),
                        Recibo = lector["Recibo"] != DBNull.Value && Convert.ToBoolean(lector["Recibo"]),
                        Salario = lector["Salario"] != DBNull.Value && Convert.ToBoolean(lector["Salario"])
                    };

                    lista.Add(t);
                }
                lector.Close();
            }

            return lista;
        }
        public List<clsReporteDTO> ObtenerReporteCompleto()
        {
            List<clsReporteDTO> lista = new List<clsReporteDTO>();

            using (OleDbConnection conexion = clsConexionBD.ObtenerConexion())
            {
                string consulta = @"
        SELECT 
            u.Usuario, 
            u.NombreCompleto, 
            u.HorarioInicio, 
            u.HorarioFin,
            a.FechaIngreso, 
            a.HoraIngreso, 
            a.HoraSalida,
            rt.Fecha AS FechaTarea, 
            rt.Tarea, 
            rt.Lugar,
            rt.Comentario, 
            rt.Insumo, 
            rt.Estudio, 
            rt.Vacacion,
            rt.Recibo,
            rt.Salario
        FROM 
            ((Usuarios AS u
        LEFT JOIN Auditoria AS a ON u.Id = a.IdUsuario)
        LEFT JOIN RegistroTareas AS rt ON u.Id = rt.IdUsuario);";

                OleDbCommand comando = new OleDbCommand(consulta, conexion);

                try
                {
                    OleDbDataReader lector = comando.ExecuteReader();
                    int count = 0;

                    while (lector.Read())
                    {
                        var reporte = new clsReporteDTO
                        {
                            Usuario = lector["Usuario"]?.ToString(),
                            NombreCompleto = lector["NombreCompleto"]?.ToString(),

                            HorarioInicio = lector["HorarioInicio"] != DBNull.Value
                                ? Convert.ToDateTime(lector["HorarioInicio"]).ToString("HH:mm")
                                : "",

                            HorarioFin = lector["HorarioFin"] != DBNull.Value
                                ? Convert.ToDateTime(lector["HorarioFin"]).ToString("HH:mm")
                                : "",

                            FechaIngreso = lector["FechaIngreso"] != DBNull.Value
                                ? Convert.ToDateTime(lector["FechaIngreso"])
                                : (DateTime?)null,

                            HoraIngreso = lector["HoraIngreso"] != DBNull.Value
                                ? Convert.ToDateTime(lector["HoraIngreso"]).TimeOfDay
                                : (TimeSpan?)null,

                            HoraSalida = lector["HoraSalida"] != DBNull.Value
                                ? Convert.ToDateTime(lector["HoraSalida"]).TimeOfDay
                                : (TimeSpan?)null,

                            FechaTarea = lector["FechaTarea"] != DBNull.Value
                                ? Convert.ToDateTime(lector["FechaTarea"])
                                : (DateTime?)null,

                            Tarea = lector["Tarea"]?.ToString(),
                            Lugar = lector["Lugar"]?.ToString(),
                            Comentario = lector["Comentario"]?.ToString(),

                            Insumo = lector["Insumo"] != DBNull.Value && Convert.ToBoolean(lector["Insumo"]),
                            Estudio = lector["Estudio"] != DBNull.Value && Convert.ToBoolean(lector["Estudio"]),
                            Vacacion = lector["Vacacion"] != DBNull.Value && Convert.ToBoolean(lector["Vacacion"]),
                            Recibo = lector["Recibo"] != DBNull.Value && Convert.ToBoolean(lector["Recibo"]),
                            Salario = lector["Salario"] != DBNull.Value && Convert.ToBoolean(lector["Salario"])
                        };

                        lista.Add(reporte);  
                        count++;
                    }

                    lector.Close();

                    MessageBox.Show("Se recuperaron " + count + " registros de la base de datos.", "Depuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                }
            }

            return lista;
        }





    }

}













