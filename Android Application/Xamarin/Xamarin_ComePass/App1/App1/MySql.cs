using App1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public class MySql
    {
        #region MySql Connection String

        public static string connection_string = "server = tonic.o2switch.net;" +
            "user = lafe6113_fingertracker_admin;" +
            "password = oMdXu525rg;" +
            "database = lafe6113_fingertracker;" +
            "port = 3306";       

        #endregion

        #region MySql Login Querry

        public static string login_querry = "SELECT * FROM Punonjesi WHERE E_Mail = @email AND Kodi = @kodi;";
        //public static string querry = "Select * From Users Where Username = @username and Kodi = @pass";

        #endregion
    }
}
