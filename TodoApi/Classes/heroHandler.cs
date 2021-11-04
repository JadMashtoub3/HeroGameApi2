using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using HeroGameApi;

namespace HeroGameApi {
    public class heroHandler:DbHandler {

        public static List<Hero> GetHeroes(){ //returns all created heroes /hero

            List<Hero> heroes = new List<Hero>();
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){

                conn.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM HERO", conn)) {

                    using(SqlDataReader reader = command.ExecuteReader()){
                        while(reader.Read()){
                            heroes.Add(new Hero(){HeroId = reader.GetInt32(0),
                                                  HName = reader.GetString(1),
                                                  MinHit = reader.GetInt32(2),
                                                  MaxHit = reader.GetInt32(3)});
                                                 
                        }
                    }
                }
                conn.Close();
            }
            return heroes;   
        }
// /hero (id) -- retrieves hero by id and returns stats
// /hero -- returns all heros in order of id and returns stats
        public static Hero GetHero(int id) { //gets hero by id /hero/(x)
            Hero hero = new Hero();

            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();

                using(SqlCommand command = new SqlCommand(string.Format("SELECT * FROM HERO WHERE HEROID = \'{0}\'", id), conn)){
                    using(SqlDataReader reader = command.ExecuteReader()){
                        while(reader.Read()){
                            hero.HeroId = reader.GetInt32(0);
                            hero.HName = reader.GetString(1);
                            hero.MinHit = reader.GetInt32(2);
                            hero.MaxHit = reader.GetInt32(3);
                            
                        }
                    }
                }
                conn.Close();
            }
            return hero;
        }

        public static string AddHeros(Hero newHero) { // creates new hero
            using(SqlConnection conn = new SqlConnection(GetConnectionString())){
                conn.Open();

                using(SqlCommand command = new SqlCommand("ADD_HERO", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pHEROID", newHero.HeroId);
                    command.Parameters.AddWithValue("@pNAME", newHero.HName);
                    command.Parameters.AddWithValue("@pMINDICE", newHero.MinHit);
                    command.Parameters.AddWithValue("@pMAXDICE", newHero.MaxHit);
                    
                   
                    command.ExecuteNonQuery();
                    
                    conn.Close();                 
                    
                }
            }
            return "New hero created";
        }

        public static string UpdateHero(Hero hero) { //updates hero
            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();

                using(SqlCommand command = new SqlCommand("UPDATE_HERO", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pHEROID", hero.HeroId);
                    command.Parameters.AddWithValue("@pNAME", hero.HName);
                    command.Parameters.AddWithValue("@pMINDICE", hero.MinHit);
                    command.Parameters.AddWithValue("@pMAXDICE", hero.MaxHit);
                    
                    command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            return "Hero has been updated";
        }

        public static string DeleteHero(Hero hero) { //deletes hero by id
            using(SqlConnection conn = new SqlConnection(GetConnectionString())) {
                conn.Open();

                using(SqlCommand command = new SqlCommand("DELETE_HERO", conn)) {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pHEROID", hero.HeroId);
                    command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            return "Hero has been deleted";
        }
    }
}