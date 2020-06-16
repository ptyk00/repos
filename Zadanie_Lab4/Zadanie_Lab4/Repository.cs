using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_Lab4
{
    public class Repository
    {
        public async Task AddAsync<T>(IEnumerable<T> data) where T : class
        {
            await using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();

            foreach (var entity in data)
            {
                context.Set<T>().Add(entity);
            }

            var success = await context.SaveChangesAsync() > 0;

            if (success) Console.WriteLine("Success");
        }
    }
}
