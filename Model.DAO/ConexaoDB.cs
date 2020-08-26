using System.Data.SqlClient;

namespace Model.Dao
{
    public class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;

        private ConexaoDB()
        {
            con = new SqlConnection("Data Source=Zeus; Initial Catalog=Financial; Integrated Security= True");
        }

        public static ConexaoDB knowState()
        {
            if (objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }
            return objConexaoDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void CloseDB()
        {
            objConexaoDB = null;
        }
    }
}
