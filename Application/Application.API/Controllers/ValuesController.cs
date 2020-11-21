using Application.API.ViewModel;
using Application.Models.Concretas;
using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private UsuarioRepository repository;

        public ValuesController()
        {
            repository = new UsuarioRepository();
        }

        //GET api/values
        [HttpGet]
        public string Get()
        {
            string json = string.Empty;
            var listagem = repository.Read();

            json = JsonSerializer.Serialize(listagem);

            return json;
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var pesquisa = repository.Read(id);

            string json = JsonSerializer.Serialize(pesquisa);

            return json;
        }

        //POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        //PUT api/values
        [HttpPut]
        public void Put([FromBody]string value)
        {
        }
    }
}
