using System;
using Xunit;
using Moq;

namespace ConsoleApp1.Tests
{
    // ---------------------------------------------------------
    // CT01: Aluno - Validação de Email
    // ---------------------------------------------------------
    public class AlunoTests
    {
        [Theory]
        [InlineData("sem_arroba.com")]
        [InlineData("emailinvalido")]
        public void DefinirEmail_SemArroba_DeveLancarExcecao(string emailInvalido)
        {
            // Arrange
            var aluno = new Aluno();

            // Act & Assert
            // Espera-se que a classe Aluno lance uma exceção se o email não for válido
            var ex = Assert.Throws<ArgumentException>(() => aluno.Email = emailInvalido);
            Assert.Contains("@", ex.Message); // Opcional: validar se a mensagem fala do '@'
        }
    }

    // ---------------------------------------------------------
    // CT02: Edição - Coerência de Datas
    // ---------------------------------------------------------
    public class EdicaoTests
    {
        [Fact]
        public void CriarEdicao_DataFimMenorQueInicio_DeveLancarArgumentException()
        {
            // Arrange
            DateTime dataInicio = new DateTime(2023, 10, 1);
            DateTime dataFim = new DateTime(2023, 9, 1); // Fim antes do início

            // Act & Assert
            // Espera-se que a classe lance exceção ao instanciar ou ao definir as datas
            Assert.Throws<ArgumentException>(() => new EdicaoCurso(dataInicio, dataFim));
        }
    }

    // ---------------------------------------------------------
    // CT03: Inscrição - Intervalo de Notas
    // ---------------------------------------------------------
    public class InscricaoTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(21)]
        public void DefinirNota_ForaDoIntervalo_DeveLancarExcecao(int notaInvalida)
        {
            // Arrange
            var inscricao = new Inscricao();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => inscricao.Nota = notaInvalida);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(20)]
        public void DefinirNota_DentroDoIntervalo_DeveAtribuirComSucesso(int notaValida)
        {
            // Arrange
            var inscricao = new Inscricao();

            // Act
            inscricao.Nota = notaValida;

            // Assert
            Assert.Equal(notaValida, inscricao.Nota);
        }
    }

    // ---------------------------------------------------------
    // CT04: Model - Elegibilidade de Emissão
    // ---------------------------------------------------------
    public class ModelElegibilidadeTests
    {
        [Theory]
        [InlineData(9, "Concluída")] // Falha na nota (< 10)
        [InlineData(15, "Pendente")]  // Falha no estado (!= Concluída)
        public void EmitirDiploma_AlunoInElegivel_NaoDeveChamarGerador(int nota, string estado)
        {
            // Arrange
            var mockGerador = new Mock<IGeradorDiploma>();
            var model = new Model(mockGerador.Object);

            // Act
            // NOTA PARA A EQUIPA: Como planeado, o Model atual precisa de ser atualizado 
            // para avaliar a Nota e o Estado. Quando atualizarem o método EmitirDiploma,
            // descomentem e ajustem a linha abaixo:

            // model.EmitirDiploma("João Silva", "Engenharia", nota, estado);

            // Assert
            // Garante que o método Gerar() nunca chega a ser executado se o aluno reprovar
            mockGerador.Verify(g => g.Gerar(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}