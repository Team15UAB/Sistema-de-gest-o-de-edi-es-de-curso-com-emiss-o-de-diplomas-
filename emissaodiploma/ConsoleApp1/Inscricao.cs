using System;

public class Inscricao
{
    private int _nota;

    public int Nota
    {
        get => _nota;
        set
        {
            if (value < 0 || value > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "A nota deve estar entre 0 e 20.");
            }
            _nota = value;
        }
    }
}