using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class UserRepository : SqlRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {

            //return SqlHelper.ExtecuteProcedureReturnData<List<User>>(connectionString,
            //   "GetUsers", r => r.TranslateAsUsersList());

            using (var conn = GetOpenConnection())
            {

                //var user = conn.QueryAsync
                return await conn.QueryAsync<User>("GetUsers", null, commandType: CommandType.StoredProcedure);
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
