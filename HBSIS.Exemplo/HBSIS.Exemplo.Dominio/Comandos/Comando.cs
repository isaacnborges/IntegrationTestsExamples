using FluentValidation.Results;

namespace HBSIS.Exemplo.Dominio.Comandos
{
    public abstract class Comando
    {
        public abstract bool Valido();
        public ValidationResult ValidationResult { get; set; }
    }
}
