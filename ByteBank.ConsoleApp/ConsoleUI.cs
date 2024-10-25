using ByteBank.Common.Entities;
using ByteBank.Common.Leitores;

namespace ByteBank.ConsoleApp
{
    public class ConsoleUI
    {
        public static void MostrarBoletos(string caminhoArquivo)
        {
            Console.WriteLine("Lendo arquivo de boletos...");
    
            var leitor = new LeitorBoleto();
            List<Boleto> boletos = leitor.LerArquivo("Boletos.csv");

            boletos.ForEach(Console.WriteLine);
        }
    }
}