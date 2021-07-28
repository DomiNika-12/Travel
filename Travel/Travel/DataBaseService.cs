using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace Travel
{
    public class DataBaseService
    {
        public SQLiteAsyncConnection connection { get; set; }

        public async Task Init()
        {
            if (connection != null)
                return;
            var documentsPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            //string _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyDatabase.db");
            connection = new SQLiteAsyncConnection(path);
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
