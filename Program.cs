using System;

// =========================
// MODELO
// =========================

public class DiplomaModel
{
    public string NomeAluno { get; set; }
    public string Curso { get; set; }

    // Eventos (delegados)
    public event Action<string> OnValidacao;
    public event Action<byte[]> OnDiplomaEmitido;

    // Método principal (Model ativo)
    public void EmitirDiploma()
    {
        // Validação
        if (string.IsNullOrWhiteSpace(NomeAluno))
        {
            OnValidacao?.Invoke("Erro: Nome do aluno inválido.");
            return;
        }

        OnValidacao?.Invoke("Validação concluída com sucesso.");

        // Simulação de geração de PDF (byte[])
        byte[] pdf = GerarPdf();

        // Notificar emissão
        OnDiplomaEmitido?.Invoke(pdf);
    }

    private byte[] GerarPdf()
    {
        // Aqui ligarias ao teu GeradorDiplomaPdfSharp
        return new byte[] { 1, 2, 3 }; // mock
    }
}

// =========================
// VIEW (observa o Model)
// =========================

public class DiplomaView
{
    public void Subscribir(DiplomaModel model)
    {
        model.OnValidacao += MostrarMensagem;
        model.OnDiplomaEmitido += MostrarDiploma;
    }

    private void MostrarMensagem(string mensagem)
    {
        Console.WriteLine("[VIEW] " + mensagem);
    }

    private void MostrarDiploma(byte[] pdf)
    {
        Console.WriteLine("[VIEW] Diploma gerado com sucesso!");
        Console.WriteLine("[VIEW] Tamanho do PDF: " + pdf.Length + " bytes");
    }
}

// =========================
// CONTROLLER (leve)
// =========================

public class DiplomaController
{
    private DiplomaModel _model;

    public DiplomaController(DiplomaModel model)
    {
        _model = model;
    }

    public void EmitirDiploma()
    {
        _model.EmitirDiploma();
    }
}

// =========================
// PROGRAMA (simulação)
// =========================

class Program
{
    static void Main()
    {
        DiplomaModel model = new DiplomaModel
        {
            NomeAluno = "João Silva",
            Curso = "Engenharia Informática"
        };

        DiplomaView view = new DiplomaView();
        view.Subscribir(model);

        DiplomaController controller = new DiplomaController(model);

        // Iniciar fluxo
        controller.EmitirDiploma();
    }
}
