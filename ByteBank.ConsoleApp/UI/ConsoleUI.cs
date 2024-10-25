namespace ByteBank.ConsoleApp.UI
{
    public class ConsoleUI
    {
        public static void MostrarBoletos<T>(List<T> boletos)
        {
            Console.WriteLine("Lendo arquivo de boletos...");
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                
                foreach(var b in boletos)
                    System.Console.WriteLine(b);
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: {e.Message}");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}