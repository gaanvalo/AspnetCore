using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OmniApiDTO.DTOs;

namespace OmniApiDAL.User
{
    public class UserRepository : SqlRepository<Usuarios>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Usuarios> GetAllAsync()
        {
            var resultado = new List<Usuarios>();

            try
            {
                var cmd = GetDbSprocCommand("GetAllUsers");
                resultado = GetDTOListJSON<Usuarios>(ref cmd);
                
            }
            catch (Exception ext)
            {
                throw ext;
            }

            return resultado;
        }

        public override Usuarios GetAsync(int id)
        {
            var resultado = new Usuarios();

            try
            {
                var cmd = GetDbSprocCommand("GetUsersById");
                cmd.Parameters.Add(CreateParameter("@Id", id));
                resultado = GetSingleDTO<Usuarios>(ref cmd);

            }
            catch (Exception ext)
            {
                throw ext;
            }

            return  resultado;
        }

        public override void InsertAsync(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(Usuarios entityToUpdate)
        {
            throw new NotImplementedException();
        }

       
    }
}
