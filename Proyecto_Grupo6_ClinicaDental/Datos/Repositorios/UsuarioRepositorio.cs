using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private string CadenaConexion;

        public UsuarioRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE usuario SET Nombre = @Nombre,Clave= @Clave,Correo= @Correo,
                             Rol=@Rol,EstaActivo=@EstaActivo WHERE CodigoUsuario=@CodigoUsuario;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, usuario));
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        public async Task<bool> Eliminar(string codigousuario)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE FROM usuario WHERE CodigoUsuario=@CodigoUsuario;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { codigousuario }));
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        public async Task<IEnumerable<Usuario>> GetLista()
        {
            IEnumerable<Usuario> lista = new List<Usuario>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM usuario;";
                lista = await conexion.QueryAsync<Usuario>(sql);
            }
            catch (Exception ex)
            {

            }
            return lista;
        }

        public async Task<Usuario> GetPorCodigo(string codigousuario)
        {
            Usuario user = new Usuario();

            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM usuario WHERE CodigoUsuario = @CodigoUsuario; ";

                user = await conexion.QueryFirstAsync<Usuario>(sql, new { codigousuario });
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        public async Task<bool> Nuevo(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO usuario (CodigoUsuario,Nombre,Clave,Correo,Rol,EstaActivo) 
                                VALUES (@CodigoUsuario,@Nombre,@Clave,@Correo,@Rol,@EstaActivo);";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, usuario));
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }
    }
}
