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
    public class FuncionarioController : ControllerBase
    {
        private readonly ITContext _context;

        public FuncionarioController(ITContext context)
        {
            _context = context;
        }
        // GET:api/Funcionario
        [HttpGet]
        public ActionResult Get()
        {
            //usando try catch para simplificar
            try
            {
                return Ok(new Funcionario());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }

        // GET: api/Funcionario/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST: api/Funcionario
        [HttpPost]
        public ActionResult Post(Funcionario model)
        {
            try
            {


                //    var funcionario = new Funcionario
                //    {
                //        Nome = "Fernando",
                //        coloquei o objeto Equipamentos dentro do Objeto Funcionarios, como se tivesse fazendo um JSON
                //        Equipamentos = new List<Equipamento>
                //        {
                //            new Equipamento{ Nome = "Notebook"},
                //            new Equipamento{ Nome = "Smartphone"}
                //        }
                //    };
                //dado meus funcionarios, adicionar os equipamentos e salvar


                _context.Funcionarios.Add(model);
                _context.SaveChanges();

                return Ok("Adicionado com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }

        // PUT: api/Funcionario/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Funcionario model)
        {
            try
            {
                // Utilizando o Funcionarios eu utilizo o AsNoTracking, ele não deixa travar ou ficar atracado
                //o FirstOrDefault e dentro voce faz a sua clausula de Where.
                if (_context.Funcionarios.AsNoTracking().FirstOrDefault(f => f.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();

                    return Ok("Adicionado com Sucesso!");
                }

                //var funcionario = new Funcionario
                //{


                //    //Quando um ID é atribuido a um objeto nós estamos vinculando aquele objeto ao que existe no banco de dados
                //    //Posso passar o _context.Funcionario.Update ou somente _context.Update porque o objeto/entidade está definido no contexto

                //    Id = id,
                //    Nome = "Fernando",
                //    Equipamentos = new List<Equipamento>
                //    {
                //        new Equipamento { Id = 1, Nome = "Notebook Dell 1"},
                //        new Equipamento { Id = 2, Nome = "Smartphone Samsung 1"}


                //    }
                //};


                return Ok("Não encontrado!");

            }

            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }


        //// GET: FuncionarioController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return Ok();
        //}

        //// POST: FuncionarioController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return Ok();
        //    }
        //}

        //// GET: FuncionarioController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return Ok();
        //}

        //// POST: FuncionarioController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return Ok();
        //    }
    }
}
