using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;


namespace Program.Models.Tables
{
    public class TableReader {
        public static List<T> AccessTable<T>(string tableName){
            List<T> readData;

            #region read
            try { readData = JsonSerializer.Deserialize<List<T>>(File.ReadAllText($@"./Data/{tableName}.json")); }
            catch { throw new System.IO.FileNotFoundException($"Table \"./Data/{tableName}.json\" not found"); }
            #endregion

            return readData;
        }
    }
}