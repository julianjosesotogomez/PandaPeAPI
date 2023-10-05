using MediatR;
using PandaPeAPI.Domain.DTOs;

namespace PandaPeAPI.Infraestructure.Commands
{
    public record UpdateCandidate(RequestUpdateCandidateDTO requestUpdateCandidateDTO) : IRequest<bool>;

}
