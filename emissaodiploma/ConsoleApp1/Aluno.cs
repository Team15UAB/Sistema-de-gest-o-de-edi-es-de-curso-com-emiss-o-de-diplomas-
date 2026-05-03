using System;

public class Aluno
{
    private string _email = string.Empty;

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("O email deve conter um '@'.");
            }
            _email = value;
        }
    }
}
