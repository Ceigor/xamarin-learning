using QuotesApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuotesApp.Data
{
    public class Database
    {
        public const string DATABASE_NAME = "Database.db";
        private readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Quote>().Wait();
        }

        public Task<List<Quote>> GetQuotesAsync()
        {
            return database.Table<Quote>().ToListAsync();
        }

        public Task<int> InsertQuotesAsync(List<Quote> quotes)
        {
            return database.InsertAllAsync(quotes);
        }

        public Task<int> SaveQuoteAsync(Quote quote)
        {
            if (quote.Id > 0)
                return database.UpdateAsync(quote);
            return database.InsertAsync(quote);
        }

        public Task<Quote> GetQuoteAsync(int id)
        {
            return database.GetAsync<Quote>(id);
        }
    }
}
