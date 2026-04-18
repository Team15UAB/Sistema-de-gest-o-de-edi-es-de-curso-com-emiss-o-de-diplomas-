using System;

/// VIEW
/// Responsável apenas pela apresentação.
/// 
/// Neste exemplo:
/// - Apresenta mensagens no console
/// - Em contexto real pode ser UI gráfica ou web
/// 
/// IMPORTANTE:
/// - Não contém lógica de negócio
/// - Não chama diretamente o Model
/// - Apenas reage a eventos
public class View
{
    /// Subscrição aos eventos do Model
    /// Liga a View ao fluxo de notificações
        public void Subscribir(Model model)
    {
        model.OnValidacao += MostrarValidacao;
        model.OnDiplomaEmitido += MostrarDiploma;
    }

    /// Apresenta o resultado da validação
    
    private void MostrarValidacao(object sender, ValidacaoEventArgs e)
    {
        Console.WriteLine("[VIEW] " + e.Mensagem);
    }
    
    /// Apresenta informação sobre o diploma gerado
        private void MostrarDiploma(object sender, DiplomaEmitidoEventArgs e)
    {
        Console.WriteLine("[VIEW] Diploma gerado com sucesso!");
        Console.WriteLine("[VIEW] Tamanho do PDF: " + e.PdfBytes.Length + " bytes");
    }
}