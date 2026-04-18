using System;
 
/// Ponto de entrada da aplicação.
/// 
/// Responsável por:
/// - Criar objetos
/// - Ligar os componentes (injeção de dependências)
/// - Iniciar o fluxo
class Program
{
    static void Main()
    {
        // 1. Criar serviço (infraestrutura)
        IGeradorDiploma gerador = new Gerador();

        // 2. Criar Model (núcleo)
        Model model = new Model(gerador);

        // 3. Criar View e subscrever eventos
        View view = new View();
        view.Subscribir(model);

        // 4. Criar Controller
        Controller controller = new Controller(model);

        // 5. Simular input do utilizador
        controller.EmitirDiploma("João Silva", "Engenharia Informática");

        Console.ReadLine();
    }
}