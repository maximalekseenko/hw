using System;
using Microsoft.EntityFrameworkCore;


#define DATABASE_NAME DBfIT;

namespace Program.Tasks
{
    internal class Task_II_2 {
        
        public static void Run(string[] args){
            var PSQL_CONNECTION = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=enter;");

            // make database
            PSQL_CONNECTION.Open();
            new NpgsqlCommand(@"CREATE DATABASE IF NOT EXISTS {DATABASE_NAME}", PSQL_CONNECTION).ExecuteNonQuery();
            PSQL_CONNECTION.Close();

            // connect to database
            PSQL_CONNECTION = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=enter;");
            
        }
    }
}