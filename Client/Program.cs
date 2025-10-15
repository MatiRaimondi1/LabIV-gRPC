using Grpc.Net.Client;
using API.Protos;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7208");
            var client = new Calculadora.CalculadoraClient(channel);

            var sumarResponse = client.Sumar(new Request { Number1 = 10, Number2 = 5 });
            Console.WriteLine($"Suma: {sumarResponse.Result}");
            var restarResponse = client.Restar(new Request { Number1 = 10, Number2 = 5 });
            Console.WriteLine($"Resta: {restarResponse.Result}");
            var multiplicarResponse = client.Multiplicar(new Request { Number1 = 10, Number2 = 5 });
            Console.WriteLine($"Multiplicación: {multiplicarResponse.Result}");
            var dividirResponse = client.Dividir(new Request { Number1 = 10, Number2 = 5 });
            Console.WriteLine($"División: {dividirResponse.Result}");

            Console.ReadKey();
        }
    }
}
