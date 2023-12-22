using FluentValidation.Results;
using IPS.Feed.Domain.Models;

namespace IPS.Feed.Domain.Interfaces
{
    public interface IEventoService
    {
        Task<ValidationResult> Adicionar(Evento evento);
    }
}
