using COmpamelaVacaAPI.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COmpamelaVacaAPI.Data.Repositorios
{
    public class USerRepository : IUserRepository
    {
        private readonly MySQLconfiguration _connectionString;
        public USerRepository(MySQLconfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteUser(User user)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM usuarios WHERE id = @Id";

#pragma warning disable IDE0037 // Usar nombre de miembro inferido
            var result = await db.ExecuteAsync(sql, new { Id = user.Id  });
#pragma warning restore IDE0037 // Usar nombre de miembro inferido

            return result > 0;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var db = dbConnection();

            var sql = @" SELECT id, idRole, nombre, correo, contraseña, telefono
                        FROM usuarios ";
            return await db.QueryAsync<User>(sql, new { });
        }

         public async Task<User> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, idRole, nombre, correo, contraseña, telefono
                        FROM usuarios
                        WHERE id = @Id  ";
            return await db.QueryFirstOrDefaultAsync<User>(sql, new {Id = id });
        }

        public async Task<bool> InsertUser(User user)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO usuarios(idRole, nombre, correo, contraseña, telefono)
                        VALUES(@idRole, @nombre, @correo, @contraseña, @telefono) ";
            var result = await db.ExecuteAsync(sql, new
                 { user.idRole, user.nombre, user.correo, user.contraseña, user.telefono });
            return result > 0;
        }
        public async Task<bool> UpdateUser(User user)
        {
            var db = dbConnection();

            var sql = @" UPDATE  usuarios
                        SET idRole=@idRole, 
                            nombre= @nombre, 
                            correo=  @correo, 
                            contraseña= @contraseña, 
                            telefono = @telefono
                            WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new
            { user.idRole, user.nombre, user.correo, user.contraseña, user.telefono,user.Id });
            return result > 0;
        }


    }
}
