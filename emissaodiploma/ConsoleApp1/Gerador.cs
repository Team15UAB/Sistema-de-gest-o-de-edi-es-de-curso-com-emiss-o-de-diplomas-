using System.Text;

/// Interface que define o contrato de geração de diplomas.
/// 
/// Permite:
/// - Trocar a implementação (ex: PDFsharp, outro motor)
/// - Reduzir acoplamento com o Model
public interface IGeradorDiploma
{
    byte[] Gerar(string nomeAluno, string curso);
}

/// Implementação concreta do gerador de diplomas.
/// 
/// Neste exemplo:
/// - Simulação simples
/// 
/// No projeto real:
/// - Deve usar PDFsharp
public class Gerador : IGeradorDiploma
{
    public byte[] Gerar(string nomeAluno, string curso)
    {
        // Simulação de conteúdo do diploma
        string conteudo = $"Diploma de {nomeAluno} - {curso}";

        // Conversão para bytes (simula um PDF)
        return Encoding.UTF8.GetBytes(conteudo);
    }
}
