using FinanceMVC.Models;
using System;
using System.Linq;
using System.Data.Entity;
using FinanceMVC.Dtos;
using AutoMapper;
using System.Web.Http;

namespace FinanceMVC.Controllers.Api
{
    public class ProductoController : ApiController
    {

        private FinanceDbContext _context;

        public ProductoController()
        {
            _context = new FinanceDbContext();
        }

        // Get Producto
        public IHttpActionResult GetProducto()
        {
            var productosList = _context.Productos
                .Include(a => a.Bancos)
                .Include(b => b.CompanyTarjetaCreditos)
                .ToList().Select(Mapper.Map<Productos, ProductosDto>);

            return Ok(productosList);
        }

        // Get Producto/1
        public IHttpActionResult GetProducto(int id)
        {
            var producto = _context.Productos.SingleOrDefault(c => c.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Productos, ProductosDto>(producto));

        }

        [HttpPost]
        public IHttpActionResult CreateProducto(ProductosDto productoDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var producto = Mapper.Map<ProductosDto, Productos>(productoDto);

            _context.Productos.Add(producto);
            _context.SaveChanges();

            productoDto.ProductoId = productoDto.ProductoId;

            return Created(new Uri(Request.RequestUri + "/" + productoDto.ProductoId), productoDto);

        }

        [HttpPut]
        public IHttpActionResult UpdateProducto(int id, ProductosDto productoDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productoInDb = _context.Bancos.SingleOrDefault(c => c.BancoId == id);

            if (productoInDb == null)
            {
                return NotFound();

            }

            Mapper.Map(productoDto, productoInDb);
            _context.SaveChanges();

            return Ok();

        }


        [HttpDelete]
        public IHttpActionResult DeleteProducto(int id)
        {
            var productoInDb = _context.Productos.SingleOrDefault(c => c.ProductoId == id);

            if (productoInDb == null)
            {
                NotFound();

            }

            _context.Productos.Remove(productoInDb);
            _context.SaveChanges();

            return Ok();
        }



    }
}