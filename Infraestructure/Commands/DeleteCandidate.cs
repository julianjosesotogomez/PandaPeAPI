using MediatR;
using PandaPeAPI.DTOs;

namespace PandaPeAPI.Infraestructure.Commands
{
    public record DeleteCandidate(Guid IdCandidate) :IRequest<ResponseEndPointDTO<bool>>;
}
