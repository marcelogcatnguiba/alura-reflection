namespace ByteBank.Common.Entities
{
    public class Boleto
    {
        // Informações do Cedente (Beneficiário)
        public string CedenteNome { get; set; } = string.Empty;
        public string CedenteCpfCnpj { get; set; } = string.Empty;
        public string CedenteAgencia { get; set; } = string.Empty;
        public string CedenteConta { get; set; } = string.Empty;

        // Informações do Sacado (Pagador)
        public string SacadoNome { get; set; } = string.Empty;
        public string SacadoCpfCnpj { get; set; } = string.Empty;
        public string SacadoEndereco { get; set; } = string.Empty;

        // Informações do Boleto
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string NumeroDocumento { get; set; } = string.Empty;
        public string NossoNumero { get; set; } = string.Empty;

        // Outras Informações
        public string CodigoBarras { get; set; } = string.Empty;
        public string LinhaDigitavel { get; set; } = string.Empty;
    }

}
