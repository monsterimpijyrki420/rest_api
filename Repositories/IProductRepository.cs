using rest_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rest_api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get(); //get all products
        Task<Product> Get(int ID); //get product by id
        Task<IEnumerable<Product>> Search(string Type); //gets all products by type
        Task<Product> Create(Product product); 
        Task Update(Product product);
        Task Delete(int ID);
    }
}
