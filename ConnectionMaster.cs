using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Kino.Forms;

namespace Kino
{
    public class ConnectionMaster
    {

        SqlConnectionStringBuilder connString;
        SqlConnection connection;//
        //Initial Catalog=mayorov_db;User ID=mayorov484; Password=1
        private static ConnectionMaster instance;

        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
            private set
            {
                connection = value;
            }
        }

        private ConnectionMaster() 
        {
            //connString.connString = new SqlConnectionStringBuilder("Data Source=MSSQL-2K8;Initial Catalog=mayorov_db;User ID=mayorov484; Password=1");
            connString = new SqlConnectionStringBuilder("Data Source=MSSQL-2K8;Initial Catalog=mayorov_db; User ID=worker; Password=worker");
            Connection = new SqlConnection(connString.ToString());
        }
        //<summary>
        //Авторизует пользователя приложения.
        //</summary
        public string ReLogin(string login, string pass)
        {
           
            string loginInDB;
            string passInDB;
            string nameInDB="";

            DataTable dataTable = DBController.DoStoredProc("CheckPSW", 
                new ParameterStoredProc(SqlDbType.VarChar, "@userLogin", login)
                , new ParameterStoredProc(SqlDbType.VarChar, "@userPass", pass));
            
            if(dataTable.Rows.Count == 0)
            { return ""; }
            nameInDB = dataTable.Rows[0][0].ToString();
            loginInDB = dataTable.Rows[0][1].ToString();
            passInDB = dataTable.Rows[0][2].ToString();

            connString.Add("User ID", loginInDB);
            connString.Add("Password", passInDB);

            Connection = new SqlConnection(connString.ToString());
            return nameInDB;
        }

        public static ConnectionMaster GetInstance()
        {
            if (instance == null)
                instance = new ConnectionMaster();
            return instance;
        }
    }
}
