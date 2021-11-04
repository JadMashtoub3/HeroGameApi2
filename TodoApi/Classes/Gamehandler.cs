using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using HeroGameApi;
namespace HeroGameApi {
    public class GameHandler:DbHandler {

        public static string AddGame(Game newGame){ //adds a name game when parameters are filled
            
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){

                conn.Open();
               
                using (SqlCommand command = new SqlCommand("ADD_GAME", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue
                    ("@pGameid", newGame.GameID);
                    command.Parameters.AddWithValue
                    ("@pWINNER", newGame.Winner);
                    command.Parameters.AddWithValue
                    ("@pDATE", newGame.Date);
                    command.Parameters.AddWithValue
                    ("@pATTACKS", newGame.Rolls);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            return "New game added";
            
        }

        public static List<Game> GetGames(){ //TODO FIX THIS (gets list of games)
                
            List<Game> games = new List<Game>();
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){

                conn.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM GAME", conn)) {

                    using(SqlDataReader reader = command.ExecuteReader()){
                        while(reader.Read()){
                            games.Add(new Game(){ GameID = reader.GetInt32(0),
                                                  Winner = reader.GetString(1),
                                                  Date = reader.GetDateTime(2), 
                                                  //needs to be converted to date, idk how
                                                  Rolls = reader.GetString(3)});
                                                 
                        }
                    }
                }
                conn.Close();
            }
            return games;   
        }
    }
}