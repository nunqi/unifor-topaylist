using System;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Collections;
using System.Globalization;


class SqliteBroker {
    private SqliteConnection connection;
    private string path = "./teste.db";

    public void CreateConnection() {
        connection = new SqliteConnection("Data Source=" + path);
        connection.Open();
    }

    public void EndConnection() {
        connection.Close();
    }

    public void CreateTable() {
        try {
            NonQuery("CREATE TABLE teste (id INTEGER PRIMARY KEY AUTOINCREMENT, description TEXT NOT NULL, value TEXT NOT NULL, type TEXT NOT NULL)");
        } 
        catch { }
    }

    public ArrayList GetAllItems() {
        ArrayList ids, descriptions, values, types, items;
        ids = Read("SELECT id FROM teste");            
        descriptions = Read("SELECT description FROM teste");            
        values = Read("SELECT value FROM teste"); 
        types = Read("SELECT type FROM teste"); 
        items = new ArrayList();
        for (int i = 0; i < ids.Count; i++) {
            items.Add(new Item(int.Parse((string) ids[i]), (string) descriptions[i], (string) values[i], (string) types[i]));
        }
        return items;           
    }

    public void Add(string description, string value, string type) {
        NonQuery("INSERT INTO teste(description, value, type) VALUES('" + description + "', '" + value + "', '" + type + "')");
    }

    public void Remove(int id) {
        NonQuery("DELETE FROM teste WHERE id = " + id + ")");
    }


    public void NonQuery(string commandStr) {
        using (SqliteTransaction transaction = connection.BeginTransaction())
        {
            SqliteCommand command = connection.CreateCommand();

            command.CommandText = commandStr;
            command.ExecuteNonQuery();

            transaction.Commit();
        }
    }

    public ArrayList Read(string commandStr) {
        var selectCmd = connection.CreateCommand();
        selectCmd.CommandText = commandStr;

        using (SqliteDataReader reader = selectCmd.ExecuteReader())
        {
            ArrayList list = new ArrayList();
            while (reader.Read())
            {
                var message = reader.GetString(0);
                list.Add(message);
            }
            return list;
        }
    }

}