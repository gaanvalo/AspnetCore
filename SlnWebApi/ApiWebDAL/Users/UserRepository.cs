using ApiWebDTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ApiWebDAL.Users
{
    public class UserRepository : SqlRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override List<User> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                //var user = conn.QueryAsync
                return  conn.Query<User>("GetUsers", null, commandType: CommandType.StoredProcedure).AsList<User>();
            }
        }

        public override Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override void InsertAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(User entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
