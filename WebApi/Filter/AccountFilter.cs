using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templete.Identity.Model;

namespace WebApi.Filter
{
    public class AccountFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //VALIDAR OS ERROS DE INSERT DO CLIENTE
            if (context.Exception.Message.Contains("Email"))
            {
                MostrarMensagemErro("EMAIL", "O email que está a tentar inserir já existe.", context);
            }
            else if (context.Exception.Message.Contains("Telefone"))
            {
                MostrarMensagemErro("TELEFONE", "O telefone que está a tentar inserir já existe.", context);
            }
            else if (context.Exception.Message.Contains("Endereco"))
            {
                MostrarMensagemErro("ENDEREÇO", "O Endereço não pode ser null", context);
            }
            else
            {
                MostrarMensagemErro("GENERICO ERRO", context.Exception.Message, context);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        private void MostrarMensagemErro(string message, string messageDetail, ExceptionContext context)
        {
            LoginUser apiResponse = new LoginUser
            {
                Status = "Faild",
                Message = message,
                DetailMessage = messageDetail
            };

            //context.Result = new BadRequestObjectResult(context.ModelState);
            context.Result = new BadRequestObjectResult(apiResponse);
        }
    }

}
