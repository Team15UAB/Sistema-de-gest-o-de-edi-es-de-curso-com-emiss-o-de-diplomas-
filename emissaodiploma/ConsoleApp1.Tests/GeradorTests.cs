using Xunit;
using System.Text;

public class GeradorTests
{
	[Fact]
	public void Gerar_DeveConterNomeDoAlunoNoConteudo()
	{
		// Arrange
		var gerador = new Gerador();
		string nomeEsperado = "Carlos Alberto";

		// Act
		var resultado = gerador.Gerar(nomeEsperado, "C# Advanced");
		string textoFormatado = Encoding.UTF8.GetString(resultado);

		// Assert
		Assert.Contains(nomeEsperado, textoFormatado);
	}
}