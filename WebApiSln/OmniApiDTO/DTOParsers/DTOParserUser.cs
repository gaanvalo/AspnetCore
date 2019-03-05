using Newtonsoft.Json;
using OmniApiDTO.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace OmniApiDTO.DTOParsers
{
    public class DTOParserUser : DTOParser
    {
        #region Campos
        private int ord_Usuarios;
        #endregion
        public override CommonBase PopulateDTO(SqlDataReader reader)
        {
            var resp = new Usuarios();
            var jsonCal = string.Empty;

            if (!reader.IsDBNull(ord_Usuarios))
            {
                jsonCal = reader.GetString(ord_Usuarios);
                resp = JsonConvert.DeserializeObject<Usuarios[]>(jsonCal)[0];
            }

            return resp;
        }

        public override CommonBase PopulateDTO(SqlParameterCollection parameters)
        {
            throw new NotImplementedException();
        }

        public override List<Usuarios> PopulateDTOList<Usuarios>(SqlDataReader reader)
        {
            var res = new List<Usuarios>();
            var jsonCal = string.Empty;

            if (!reader.IsDBNull(ord_Usuarios))
            {
                jsonCal = reader.GetString(ord_Usuarios);
                return JsonConvert.DeserializeObject<List<Usuarios>>(jsonCal);
            }

            return res;
        }

        public override void PopulateOrdinals(SqlDataReader reader)
        {
            ord_Usuarios = reader.GetOrdinal("Usuarios");
        }
    }
}
