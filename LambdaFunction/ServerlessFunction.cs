using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;

[assembly: LambdaSerializer(typeof(JsonSerializer))]

namespace LambdaFunction
{
    public class ServerlessFunction
    {
        public ServerlessFunction(){}

        private void Handler(LambdaRequest request, ILambdaContext context)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(7);

            if(request != null)
            {
                startDate = request.startDate ?? DateTime.Now;
                endDate = request.endDate ?? DateTime.Now.AddDays(7);
            }

            context.Logger.Log($"Iniciando processamento de dados do dia {startDate.Date} até o dia {endDate.Date}");
            context.Logger.Log("Buscando dados da api externa...");
            context.Logger.Log("Inserindo no banco de dados...");
            context.Logger.Log("Processamento finalizado!");
        }
    }
}