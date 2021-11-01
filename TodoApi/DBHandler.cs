using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Heroo
{
    public class HeroGameApi
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
                catch(Exception e) {
                    throw new Exception("Incorrect Connection string " + e.Message);
            }
        }
    }
}