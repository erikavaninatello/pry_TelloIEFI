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



    }
}
