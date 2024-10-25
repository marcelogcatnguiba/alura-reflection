using System.Reflection;
using ByteBank.Common.Interfaces;

namespace ByteBank.Common.Leitores
{
    public abstract class Leitor<T> : ILeitorArquivos<T>
    {
        public List<T> LerArquivo(string caminhoArquivo)
        {
            var result = new List<T>();

            using (var reader = new StreamReader(caminhoArquivo))
            {
                string linha = reader.ReadLine()!;
                string[] cabecalho = linha.Split(',');

                while (!reader.EndOfStream)
                {
                    linha = reader.ReadLine()!;
                    
                    string[] dados = linha.Split(',');
                    T boleto = MapearTextoParaObjeto(cabecalho, dados);

                    result.Add(boleto);
                }
            }

            return result;
        }

        private static T MapearTextoParaObjeto(string[] nomesPropriedades, string[] valoresPropriedades)
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
