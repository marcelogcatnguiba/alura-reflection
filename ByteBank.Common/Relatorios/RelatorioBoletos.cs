using ByteBank.Common.Entities;
using System.Reflection;

namespace ByteBank.Common
{
    public interface IRelatorioDeBoleto<T>
    {
        void Processar(List<T> boletos);
    }

    public class RelatorioDeBoleto : IRelatorioDeBoleto<Boleto>
    {
        private readonly string _nomeArquivoSaida = string.Empty;
        private readonly DateTime _dataRelatorio = DateTime.Now;

        public RelatorioDeBoleto(string nomeArquivoSaida, DateTime dataRelatorio)
        {
            _nomeArquivoSaida = nomeArquivoSaida;
            _dataRelatorio = dataRelatorio;
        }

        public RelatorioDeBoleto(DateTime dataRelatorio)
        {
            _dataRelatorio = dataRelatorio;
        }

        public RelatorioDeBoleto(string nomeArquivoSaida)
        {
            _nomeArquivoSaida = nomeArquivoSaida;
        }

        public void Processar(List<Boleto> boletos)
        {
            var boletosPorCedente = PegaBoletosAgrupados(boletos);
            GravarArquivo(boletosPorCedente);
        }

        private void GravarArquivo(List<BoletosPorCedente> grupos)
        {
            // Obter tipo da classe
            Type tipo = typeof(BoletosPorCedente);

            // Usar Reflection para obter propriedades
            PropertyInfo[] propriedades = tipo.GetProperties();

            // Escrever os dados no arquivo CSV
            using (var sw = new StreamWriter(_nomeArquivoSaida))
            {
                // Escrever cabeçalho
                var cabecalho = propriedades
                    .Select(p => p.Name);
                    
                sw.WriteLine(string.Join(',', cabecalho));

                // Escrever linhas do relatório
                foreach (var grupo in grupos)
                {
                    var valores = propriedades.Select(p => p.GetValue(grupo));
                    sw.WriteLine(string.Join(',', valores));
                }
            }

            Console.WriteLine($"Arquivo '{_nomeArquivoSaida}' criado com sucesso!");
        }

        private List<BoletosPorCedente> PegaBoletosAgrupados(List<Boleto> boletos)
        {
            // Agrupar boletos por cedente
            var boletosAgrupados = boletos.GroupBy(b => new
            {
                b.CedenteNome,
                b.CedenteCpfCnpj,
                b.CedenteAgencia,
                b.CedenteConta
            });

            // Lista para armazenar instâncias de BoletosPorCedente
            List<BoletosPorCedente> boletosPorCedenteList = new List<BoletosPorCedente>();

            // Iterar sobre os grupos de boletos por cedente
            foreach (var grupo in boletosAgrupados)
            {
                // Criar instância de BoletosPorCedente
                BoletosPorCedente boletosPorCedente = new BoletosPorCedente
                {
                    CedenteNome = grupo.Key.CedenteNome,
                    CedenteCpfCnpj = grupo.Key.CedenteCpfCnpj,
                    CedenteAgencia = grupo.Key.CedenteAgencia,
                    CedenteConta = grupo.Key.CedenteConta,
                    Valor = grupo.Sum(b => b.Valor),
                    Quantidade = grupo.Count()
                };

                // Adicionar à lista
                boletosPorCedenteList.Add(boletosPorCedente);
            }

            return boletosPorCedenteList;
        }
    }
}
