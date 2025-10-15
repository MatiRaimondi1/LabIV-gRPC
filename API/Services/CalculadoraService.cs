using API.Protos;
using Grpc.Core;

namespace API.Services
{
    public class CalculadoraService : Calculadora.CalculadoraBase
    {
        public override Task<Response> Sumar(Request request, ServerCallContext context)
        {
            var result = request.Number1 + request.Number2;
            return Task.FromResult(new Response { Result = result });
        }

        public override Task<Response> Restar(Request request, ServerCallContext context)
        {
            var result = request.Number1 - request.Number2;
            return Task.FromResult(new Response { Result = result });
        }

        public override Task<Response> Multiplicar(Request request, ServerCallContext context)
        {
            var result = request.Number1 * request.Number2;
            return Task.FromResult(new Response { Result = result });
        }

        public override Task<Response> Dividir(Request request, ServerCallContext context)
        {
            if (request.Number2 == 0)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "No se puede dividir por cero"));

            var result = request.Number1 / request.Number2;
            return Task.FromResult(new Response { Result = result });
        }
    }
}
