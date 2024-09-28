using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebRole1.Data
{
    public class Connection
    {
        private string connection;
        public Connection ()
        {
            connection = "Server=tcp:josemur.database.windows.net,1433;Initial Catalog=josemur;Persist Security Info=False;User ID=josemur;Password=Qwertyuiop!98;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        
        public string getconnection()
        {
            return connection;
        }
    }
}