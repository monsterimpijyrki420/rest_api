using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rest_api.Models;
using rest_api.Repositories;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }

        //gets all products
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                return Ok(await repository.Get());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: " + e.ToString());
            }
        }

        //gets product by id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await repository.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(await repository.Get(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: " + e.ToString());
            }
        }

        //gets products by type
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByType(string type)
        {
            try
            {
                var products = await repository.Search(type);
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: " + e.ToString());
            }
        }

        //update a product
        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            try
            {
                await repository.Update(product);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: " + e.ToString());
            }

        }

        //create a product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                var newProduct = await repository.Create(product);
                return CreatedAtAction(nameof(GetProduct), new { id = newProduct.ID }, newProduct);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: " + e.ToString());
            }
        }
        
        //delete product by id
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {

            try
            {
                var product = await repository.Get(id);
                if (product == null)
                {
                    return NotFound();
                }

                await repository.Delete(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error: " + e.ToString());
            }
        }
    }
}
