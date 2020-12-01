using System;
using System.Text.Json;
using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Application.API.ViewModel;
using Application.Models.Concretas;

namespace Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private UsuarioRepository repository;
        private Autenticacao autenticacao;

        public ClientesController(IHttpContextAccessor context)
        {
            repository = new UsuarioRepository();

            autenticacao = new Autenticacao(context);
        }

        //GET api/values
        [HttpGet]
        [Route("listar")]
        public string Get()
        {
            string json = string.Empty;

            try
            {
                autenticacao.Autenticar();

                var listagem = repository.Read();

                json = JsonSerializer.Serialize(listagem);
            }
            catch (Exception ex)
            {
                json = ex.Message;
            }

            return json;
        }

        //GET api/values/5
        [HttpGet("{id}")]
        [Route("buscar/{id}")]
        public string Get(int id)
        {
            string json = string.Empty;

            try
            {
                autenticacao.Autenticar();

                var pesquisa = repository.Read(id);

                json = JsonSerializer.Serialize(pesquisa);

            }
            catch (Exception ex)
            {
                json = ex.Message;
            }

            return json;
        }

        //POST api/values
        [HttpPost]
        [Route("cadastrar")]
        public ReturnAllServices Post([FromBody]UsuarioViewModel model)
        {
            Usuario usuario;
            ReturnAllServices returnServices = new ReturnAllServices();
            try
            {
                autenticacao.Autenticar();

                usuario = new Usuario(model.NOME,       Convert.ToDateTime(model.DATA_CADASTRO), 
                                      model.CPF_CNPJ,   Convert.ToDateTime(model.DATA_NASCIMENTO), 
                                      model.TIPO,       model.TELEFONE, 
                                      model.EMAIL,      model.CEP, 
                                      model.LOGRADOURO, model.NUMERO, 
                                      model.BAIRRO,     model.COMPLEMENTO, 
                                      model.CIDADE,     model.UF);
                
                returnServices.Message = repository.Create(usuario);
                returnServices.Result = true;

                return returnServices;
            }
            catch (Exception ex)
            {
                returnServices.Message = "Erro ao tentar cadastrar um cliente: " + ex.Message;
                returnServices.Result = false;

                return returnServices;
            }
        }

        //PUT api/values
        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Put(int id, [FromBody]UsuarioViewModel model)
        {
            ReturnAllServices returnServices = new ReturnAllServices();

            try
            {
                autenticacao.Autenticar();

                var usuario = repository.Read(id);

                if (usuario != null)
                {
                    Usuario cliente =
                        new Usuario(
                            id,
                            string.IsNullOrEmpty(model.NOME)            ? usuario.NOME            : model.NOME,
                            string.IsNullOrEmpty(model.DATA_CADASTRO)   ? usuario.DATA_CADASTRO   : Convert.ToDateTime(model.DATA_CADASTRO),
                            string.IsNullOrEmpty(model.CPF_CNPJ)        ? usuario.CPF_CNPJ        : model.CPF_CNPJ,
                            string.IsNullOrEmpty(model.DATA_NASCIMENTO) ? usuario.DATA_NASCIMENTO : Convert.ToDateTime(model.DATA_NASCIMENTO),
                            string.IsNullOrEmpty(model.TIPO.ToString()) ? usuario.TIPO            : model.TIPO,
                            string.IsNullOrEmpty(model.TELEFONE)        ? usuario.TELEFONE        : model.TELEFONE,
                            string.IsNullOrEmpty(model.EMAIL)           ? usuario.EMAIL           : model.EMAIL,
                            string.IsNullOrEmpty(model.CEP)             ? usuario.CEP             : model.CEP,
                            string.IsNullOrEmpty(model.LOGRADOURO)      ? usuario.LOGRADOURO      : model.LOGRADOURO,
                            string.IsNullOrEmpty(model.NUMERO)          ? usuario.NUMERO          : model.NUMERO,
                            string.IsNullOrEmpty(model.BAIRRO)          ? usuario.BAIRRO          : model.BAIRRO,
                            string.IsNullOrEmpty(model.COMPLEMENTO)     ? usuario.COMPLEMENTO     : model.COMPLEMENTO,
                            string.IsNullOrEmpty(model.CIDADE)          ? usuario.CIDADE          : model.CIDADE,
                            string.IsNullOrEmpty(model.UF)              ? usuario.UF              : model.UF
                        );
                    returnServices.Message = repository.Update(cliente);
                    returnServices.Result = true;
                }
                else
                {
                    returnServices.Message = "ERROR 404 NOT FOUND";
                    returnServices.Result = false;
                }
            }
            catch (Exception ex)
            {
                returnServices.Message = "Erro ao tentar cadastrar um cliente: " + ex.Message;
                returnServices.Result = false;
            }
            return returnServices;
        }

        //DELETE api/values
        [HttpDelete]
        [Route("apagar/{id}")]
        public ReturnAllServices Delete(int id)
        {
            ReturnAllServices returnServices = new ReturnAllServices();

            try
            {
                autenticacao.Autenticar();

                var usuario = repository.Read(id);

                if (usuario != null)
                {
                    returnServices.Message = repository.Delete(usuario.ID);
                    returnServices.Result = true;
                }
                else
                {
                    returnServices.Message = "ERROR 404 NOT FOUND";
                    returnServices.Result = false;
                }
            }
            catch (Exception ex)
            {
                returnServices.Result = false;
                returnServices.Message = ex.Message;
            }

            return returnServices;
        }

    }
}
