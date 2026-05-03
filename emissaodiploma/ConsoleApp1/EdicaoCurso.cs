using System;

public class EdicaoCurso
{
    public DateTime DataInicio { get; }
    public DateTime DataFim { get; }

    public EdicaoCurso(DateTime dataInicio, DateTime dataFim)
    {
        if (dataFim < dataInicio)
        {
            throw new ArgumentException("A data de fim não pode ser anterior à data de início.");
        }

        DataInicio = dataInicio;
        DataFim = dataFim;
    }
}