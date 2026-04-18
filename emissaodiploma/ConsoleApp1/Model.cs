using System;
 
/// Classe que transporta o resultado da validação.
/// Usada para comunicar informação do Model para a View.
public class ValidacaoEventArgs
{
    public bool Sucesso { get; }
    public string Mensagem { get; }

    public ValidacaoEventArgs(bool sucesso, string mensagem)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
    }
}

/// Classe que transporta o diploma gerado (em bytes).
public class DiplomaEmitidoEventArgs
{
    public byte[] PdfBytes { get; }

    public DiplomaEmitidoEventArgs(byte[] pdfBytes)
    {
        PdfBytes = pdfBytes;
    }
}
 
/// MODEL (núcleo da aplicação)
/// Responsável por:
/// - Regras de negócio
/// - Validação de dados
/// - Coordenação da emissão do diploma
/// - Notificação da View (via eventos)
/// 
/// NOTA: Não conhece detalhes de PDFsharp → baixo acoplamento
 public class Model
{
    // Dependência abstraída (injeção via interface)
    private readonly IGeradorDiploma _gerador;

    // Eventos que notificam a View
    public event EventHandler<ValidacaoEventArgs> OnValidacao;
    public event EventHandler<DiplomaEmitidoEventArgs> OnDiplomaEmitido;

    public Model(IGeradorDiploma gerador)
    {
        _gerador = gerador;
    }

 
    /// Método principal do Model
    /// Executa o fluxo completo:
    /// 1. Validação
    /// 2. Geração do diploma
    /// 3. Notificação da View
    public void EmitirDiploma(string nomeAluno, string curso)
    {
        // 1. Validação
        if (string.IsNullOrWhiteSpace(nomeAluno))
        {
            OnValidacao?.Invoke(this,
                new ValidacaoEventArgs(false, "Erro: Nome do aluno inválido."));
            return;
        }

        OnValidacao?.Invoke(this,
            new ValidacaoEventArgs(true, "Validação concluída com sucesso."));

        // 2. Geração do diploma (delegada ao serviço)
        byte[] pdf = _gerador.Gerar(nomeAluno, curso);

        // 3. Notificar a View
        OnDiplomaEmitido?.Invoke(this,
            new DiplomaEmitidoEventArgs(pdf));
    }
}