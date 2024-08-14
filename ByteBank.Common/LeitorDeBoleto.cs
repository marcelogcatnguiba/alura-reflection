using System.Reflection;

namespace ByteBank.Common
{
    public class LeitorDeBoleto
    {
        public List<Boleto> LerBoletos(string caminhoArquivo)
        {
            var boletos = new List<Boleto>();

            using (var reader = new StreamReader(caminhoArquivo))
            {
                string linha = reader.ReadLine()!;
                string[] cabecalho = linha.Split(',');

                while (!reader.EndOfStream)
                {
                    linha = reader.ReadLine()!;
                    
                    string[] dados = linha.Split(',');
                    Boleto boleto = MapearTextoParaObjeto<Boleto>(cabecalho, dados);

                    boletos.Add(boleto);
                }
            }

            return boletos;
        }

        private static T MapearTextoParaObjeto<T>(string[] nomesPropriedades, string[] valoresPropriedades)
        {
            T instancia = Activator.CreateInstance<T>();
            
            for (int i = 0; i < nomesPropriedades.Length; i++)
            {
                var propriedade = nomesPropriedades[i];
                PropertyInfo propertyInfo = instancia!.GetType().GetProperty(propriedade)!;

                if(propertyInfo != null)
                {
                    Type propertyType = propertyInfo.PropertyType;

                    string valorPropriedade = valoresPropriedades[i];

                    object valorConvertido = Convert.ChangeType(valorPropriedade, propertyType);

                    propertyInfo.SetValue(instancia, valorConvertido);
                }
            }
            
            return instancia;
        }
    }
}
