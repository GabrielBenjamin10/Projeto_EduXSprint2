﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EduXSprint2.Domains;
using Projeto_EduXSprint2.Repositories;

namespace Projeto_EduXSprint2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly CurtidaRepository _curtidaRepository;

        public CurtidaController()
        {
            _curtidaRepository = new CurtidaRepository();
        }
        /// <summary>
        /// Lista todos os cursos cadastrados
        /// </summary>
        /// <returns>Retorna a lista de cursos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var curtidas = _curtidaRepository.LerTodos();

                if (curtidas.Count == 0)
                    return NoContent();

                return Ok(curtidas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                // Busca o id da curtida pelo id lá no repositorio
                var curtida = _curtidaRepository.BuscarPorId(id);

                // Aqui nós fazemos uma verificação para saber se esse curso buscado existe. Caso n exista retorna
                // Retorna Notfound- Produto n encontrado
                if (curtida == null)

                    return NotFound();

                return Ok(curtida);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromForm] Curtida curtida)// passou como parametro um formulario
        {
            try
            {

                // Adiciona uma curtida
                _curtidaRepository.Adicionar(curtida);

                // retorna ok com os dados do curtida cadastrado
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Curtida curtida)
        {
            try
            {
                //certamente se ele passou pelo buscar Id ele existe
                var curtidaTemp = _curtidaRepository.BuscarPorId(id);

                // fAZ A verificação do produto
                if (curtidaTemp == null)
                    return NotFound();

                // retorna ok com os dados do curtida alterado
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                // Remove o produto pelo id
                _curtidaRepository.Remover(id);

                // em caso de sucesso de sua remoção
                // em caso de sucesso de sua remoção
                //retorna um ok e mostra o Id 
                return Ok(id);


            }
            catch (Exception ex)
            {

                // Caso ocorra algum erro retorna BadRequest e a msg de erro
                return BadRequest(ex.Message);
            }
        }

    }
}

