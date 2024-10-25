namespace ByteBank.Common.Entities
{
    public class BoletosPorCedente
    {
        public string CedenteNome { get; set; } = string.Empty;
        public string CedenteCpfCnpj { get; set; } = string.Empty;
        public string CedenteAgencia { get; set; } = string.Empty;
        public string CedenteConta { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}