using System.Data.SqlClient;

namespace Model.Dao
{
    public class ConexaoDB
    {
        private static ConexaoDB conexaoDB = null;
        private SqlConnection con;

        private ConexaoDB()
        {
            con = new SqlConnection("Data Source=Zeus; Initial Catalog=Financial; Integrated Security= True");
        }

        public static ConexaoDB knowState()
        {
            if (conexaoDB == null)
            {
                conexaoDB = new ConexaoDB();
            }
            return conexaoDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void CloseDB()
        {
            conexaoDB = null;
        }
    }
}
