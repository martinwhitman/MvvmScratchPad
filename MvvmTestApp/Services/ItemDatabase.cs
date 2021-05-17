using MvvmTestApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTestApp.Services
{
    public class ItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ItemDatabase> Instance = new AsyncLazy<ItemDatabase>(async () =>
        {
            var instance = new ItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Item>();
            return instance;
        });

        public ItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }
        public Task<List<Item>> GetItemsAsync()
        {
            return Database.Table<Item>().ToListAsync();
        }

        public Task<List<Item>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Item>("SELECT * FROM [Item] WHERE [Done] = 0");
        }

        public Task<Item> GetItemAsync(int id)
        {
            return Database.Table<Item>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.Id!=0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
