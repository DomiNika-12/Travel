using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace Travel
{
    public class DataBaseService
    {
        public SQLiteAsyncConnection connection { get; set; }

        public async Task Init()
        {
            if (connection != null)
                return;

            string _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyDatabase.db");
            connection = new SQLiteAsyncConnection(_databasePath);
            await connection.CreateTableAsync<City>();

        }

        public async void AddEntry(City city)
        {
            await Init();
            int id = await connection.InsertAsync(city);
        }

        public async void DeleteEntry(int id)
        {
            await Init();
            await connection.DeleteAsync<City>(id);
        }

    }
}
