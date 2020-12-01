using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Concretas
{
    public class Autenticacao
    {
        public static string TOKEN = "123sfas146sdf46165546dsf";
        public static string FALHA_AUTENTICACAO = "Falha na Autentificação.. O Token informado está inválido!";
        IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string TokenRecebido = contextAccessor.HttpContext.Request.Headers["Token"].ToString();

                if(!string.Equals(TOKEN, TokenRecebido))
                {
                    throw new Exception(FALHA_AUTENTICACAO);
                }
            }
            catch (Exception)
            {
                throw new Exception(FALHA_AUTENTICACAO);
            }
        }

    }
}
