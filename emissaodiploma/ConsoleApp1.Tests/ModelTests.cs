using Moq;
using Xunit;

public class ModelTests
{
	[Fact]
	public void EmitirDiploma_NomeVazio_DeveRetornarErroDeValidacao()
	{
		// Arrange
		var mockGerador = new Mock<IGeradorDiploma>();
		var model = new Model(mockGerador.Object);
		bool erroDetectado = false;

		model.OnValidacao += (sender, e) => {
			if (!e.Sucesso) erroDetectado = true;
		};

		// Act
		model.EmitirDiploma("", "Engenharia");

		// Assert
		Assert.True(erroDetectado);
		mockGerador.Verify(g => g.Gerar(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
	}
}