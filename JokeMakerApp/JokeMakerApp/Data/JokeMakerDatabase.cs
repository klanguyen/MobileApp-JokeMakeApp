using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;

namespace JokeMakerApp
{
    public class JokeMakerDatabase
    {
        readonly SQLiteAsyncConnection database;

        public JokeMakerDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<JokeMakerItem>().Wait();
        }

        public Task<List<JokeMakerItem>> GetItemsAsync()
        {
            return database.Table<JokeMakerItem>().ToListAsync();
        }

        public Task<JokeMakerItem> GetItemAsync(int id)
        {
            return database.Table<JokeMakerItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(JokeMakerItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(JokeMakerItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}

