using rest_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace rest_api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }
        public async Task<Product> Create(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int ID)
        {
            var productToDelete = context.Products.Find(ID);
            context.Products.Remove(productToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> Get(int ID)
        {
            return await context.Products.FindAsync(ID);
        }
        public async Task<IEnumerable<Product>> Search(string Type)
        {
            IQueryable<Product> query = context.Products;
            query = query.Where(x => x.Type == Type);
            return await query.ToListAsync();
        }

        public async Task Update(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
