using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly ITContext _context;
        public SquadController(ITContext context)
        {
            _context = context;
        }
        // GET: api/Squad
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Squad());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }


        //GET: api/squad/5
        [HttpGet("{id}", Name = "GetSquad")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST: api/Squad
        [HttpPost]
        public ActionResult Post(Squad model)
        {
            try
            {
                _context.Squads.Add(model);
                _context.SaveChanges();
                return Ok("Adicionado com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Squad/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Squad model)
        {
            try
            {
                if (_context.Squads.AsNoTracking().FirstOrDefault(f => f.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return Ok("Atualizado com Sucesso!");
                }
                return Ok("Não encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}


        // POST: SquadController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return Ok();
//            }
//        }

//        // GET: SquadController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return Ok();
//        }

//        // POST: SquadController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return Ok();
//            }
//        }
//    }
//}
