using AutoMapper;
using FinanceMVC.Dtos;
using FinanceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace FinanceMVC.Controllers.Api
{
    public class BancoController : ApiController
    {

        private FinanceDbContext _context;

        public BancoController()
        {
            _context = new FinanceDbContext();
        }
        // Get Banco
        public IEnumerable<BancosDto> GetBanco()
        {
            return _context.Bancos.ToList().Select(Mapper.Map<Bancos, BancosDto>);
        }

        // Get Banco/1
        public IHttpActionResult GetBancos(int id)
        {
            var banco = _context.Bancos.SingleOrDefault(c => c.BancoId == id);
           if (banco == null)
            {
                return NotFound();
            }

            return Ok( Mapper.Map<Bancos, BancosDto>(banco));

        }

        [HttpPost]
        public IHttpActionResult CreateBanco(BancosDto bancoDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var banco = Mapper.Map<BancosDto,Bancos>(bancoDto);

            _context.Bancos.Add(banco);
            _context.SaveChanges();

            bancoDto.BancoId = banco.BancoId;

            return Created(new Uri(Request.RequestUri + "/" + banco.BancoId), bancoDto);

        }

        [HttpPut]
        public IHttpActionResult UpdateBanco(int id, BancosDto bancoDto)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var bancoInDb = _context.Bancos.SingleOrDefault(c => c.BancoId == id);

            if (bancoInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            Mapper.Map(bancoDto, bancoInDb);
            _context.SaveChanges();

            return Ok();

        }


        [HttpDelete]
        public IHttpActionResult DeleteBanco(int id)
        { 
            var bancoInDb = _context.Bancos.SingleOrDefault(c => c.BancoId == id);

            if (bancoInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Bancos.Remove(bancoInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
