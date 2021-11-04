using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace HeroGameApi
{
    public class DbHandler
    {
        public static string GetConnectionString() {
            try {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "jaddb.cczgdgxklsc1.us-east-1.rds.amazonaws.com";
                builder.UserID = "admin";
                builder.Password = "testtesttest";
                builder.InitialCatalog = "HeroDB";
                return builder.ConnectionString;
            }
                catch(Exception e) { //returns if unable to connect to database
                    throw new Exception("Unable to retrieve connection string " + e.Message);
            }
        }
    }
}