using System.Data;
using System.Data.SqlClient;

namespace OmniApiDAL
{
    public class DbConnectionFactory
    {
        public static SqlConnection GetDbConnection(EDbConnectionTypes dbType, string connectionString)
        {
            SqlConnection connection = null;

            switch (dbType)
            {
                case EDbConnectionTypes.Sql:
                    connection = new SqlConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }

            //connection.Open();
            return connection;
        }
    }

    public enum EDbConnectionTypes
    {
        Sql,
        Mongo,
        Xml
    }
}
