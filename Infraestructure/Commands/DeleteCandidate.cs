using MediatR;

namespace PandaPeAPI.Infraestructure.Commands
{
    public record DeleteCandidate(Guid IdCandidate) :IRequest<bool>;
}
