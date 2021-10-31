using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System;
using HeroGameApi;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace HeroGameApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class gameController 
    {
        [HttpPost]
        public void logGame([FromBody] JObject jsonBody)
        {
            using (SqlConnection sqlConnection = new SqlConnection("workstation id=MasterDBJad.mssql.somee.com;packet size=4096;user id=jadDb_103596586;pwd=Skylines33;data source=MasterDBJad.mssql.somee.com;persist security info=False;initial catalog=MasterDBJad"))
            {
                SqlCommand sqlCommand = new SqlCommand
                ("INSERT INTO GAME (GAME_ID, DATE_PLAYED, GAME_WINNER) VALUES ((SELECT MAX(GAME_ID) FROM GAME))", 
                sqlConnection);
                
                sqlCommand.Parameters.AddWithValue
                ("@winner", SqlDbType.NVarChar);

                sqlCommand.Parameters
                ["@winner"].Value = jsonBody
                ["MatchWinner"].Value<string>();
                
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            }
        }
    }
}