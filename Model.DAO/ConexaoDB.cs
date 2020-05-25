using System.Data.SqlClient;

namespace Model.Dao
{
    class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;

        private ConexaoDB()
        {
            con = new SqlConnection("Data Source=Zeus; Initial Catalog=Financeiro; Integrated Security= True");
        }

        public static ConexaoDB saberEstado()
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
