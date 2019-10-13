namespace WebApplication1.App_Start
{
    using Banco.Infrastructure.CrossCutting.ValueObject;
    using Microsoft.Owin;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase para el manejo de excepciones no controladas de OWIN
    /// </summary>
    /// <seealso cref="Microsoft.Owin.OwinMiddleware" />
    public class OwinExceptionHandler : OwinMiddleware
    {
        /// <summary>
        /// Inicializa una instancia de la <see cref="OwinExceptionHandler"/> clase.
        /// </summary>
        /// <param name="next">Intancia de OWIN</param>
        public OwinExceptionHandler(OwinMiddleware next) : base(next)
        {
        }

        /// <summary>
        /// Procesa una solicitud, si esta falla invoca el control de excepciones
        /// </summary>
        /// <param name="context">Contexto de OWIN</param>
        /// <returns>Metodo asincrono</returns>
        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                try
                {
                    this.HandleException(ex, context);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Controla la excepcion y devuelve un JSON con la información del error
        /// </summary>
        /// <param name="ex">Excepcion a controlar</param>
        /// <param name="context">Contexto de OWIN</param>
        private void HandleException(Exception ex, IOwinContext context)
        {
            var request = context.Request;
            var errorResult = new ErrorResult()
            {
                Error = true,
                Message = "Ocurrió un error en la aplicación ",
                Exception = ex.Message,
                Stacktrace = ex.StackTrace
            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ReasonPhrase = "Internal Server Error";
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(errorResult));
        }
    }
}