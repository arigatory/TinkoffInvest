using System;
using System.IO;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Network;

namespace TinkoffInvest
{
    class Program
    {
        static async Task Main(string[] args)
        {
           

            // токен аутентификации
            var token = File.ReadAllText("C:\\tokens\\tinkoff_sandbox.txt");   
            // для работы в песочнице используйте GetSandboxConnection
            var connection = ConnectionFactory.GetSandboxConnection(token);
            var context = connection.Context;
            var bonds = await context.MarketBondsAsync();
            foreach (var bond in bonds.Instruments.ToArray())
            {
                Console.WriteLine(bond);
            }
            // вся работа происходит асинхронно через объект контекста
            var portfolio = await context.AccountsAsync();
            
        }
    }
}
