using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Services
{
    public class MockDataStore : IDataStore<Article>
    {
        readonly List<Article> items;

        public MockDataStore()
        {
            items = new List<Article>()
            {
                new Article(reference:1,nom:"Article 1",prix:1.2,qt:1),
                 new Article(reference:2,nom:"Article 2",prix:1.2,qt:1),
                  new Article(reference:3,nom:"Article 3",prix:1.2,qt:1),
                new Article(reference:4,nom:"Article 4",prix:1.2,qt:1)

            };
        }

        public async Task<bool> AddItemAsync(Article item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Article item)
        {
            var oldItem = items.Where((Article arg) => arg.Reference == item.Reference).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Article arg) => arg.Reference == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Article> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Reference == id));
        }

        public async Task<IEnumerable<Article>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<Article> GetItemAsync(string nom)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Nom == nom));
        }

        public async Task<Article> GetItemAsync(double prix)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Prix == prix));
        }
    }
}
