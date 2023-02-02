using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Products.Models;

namespace Shopping_Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShoppingAdminContext _shopcontext;

        public ProductController(ShoppingAdminContext shopcontext)
        {
            _shopcontext = shopcontext;
        }

        [HttpGet]
        [Route("ViewAllProducts")]
        public async Task<List<MobileProduct>> Get()
        {
            return await _shopcontext.MobileProducts.ToListAsync();
        }

        [HttpGet]
        [Route("GetProductByID")]
        public async Task<ActionResult<MobileProduct>> Get(int id)
        {
            var product = await _shopcontext.MobileProducts.FirstOrDefaultAsync(z => z.ProductId == id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<MobileProduct>> Post(MobileProduct prod)
        {
            _shopcontext.Add(prod);
            await _shopcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<MobileProduct>> Put(MobileProduct prodData)
        {
            if (prodData == null || prodData.ProductId == 0)
                return BadRequest();
            
            var prod = await _shopcontext.MobileProducts.FindAsync(prodData.ProductId);
            try 
            {
                if (prod != null)
                    //prod.ProductName = prodData.ProductName;
                    //prod.ProductDesc = prodData.ProductDesc;
                    prod.Quantity = prodData.Quantity;
                    prod.ProductPrice = prodData.ProductPrice;
                await _shopcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
      


        //[HttpDelete("{id}")]
        //public async Task<ActionResult<MobileProduct>> Delete(int id)
        //{
        //    var product = await _shopcontext.MobileProducts.FindAsync(id);
        //    if (product == null) return NotFound();
        //    _shopcontext.MobileProducts.Remove(product);
        //    await _shopcontext.SaveChangesAsync();
        //    return Ok();

        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<MobileProduct>> Delete(int id)
        {
            var product = _shopcontext.MobileProducts.FirstOrDefault(t => t.ProductId == id);
            try
            {
                if (product != null)
                    _shopcontext.MobileProducts.Remove(product);
                await _shopcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            
             
        }
    }
}

