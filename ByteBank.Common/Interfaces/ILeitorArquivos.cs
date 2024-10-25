namespace ByteBank.Common.Interfaces
{
    public interface ILeitorArquivos<T>
    {
        List<T> LerArquivo(string caminhoArquivo);
    }
}