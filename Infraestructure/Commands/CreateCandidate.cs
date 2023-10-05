using MediatR;
using PandaPeAPI.Domain.DTOs;

namespace PandaPeAPI.Infraestructure.Commands
{
    public record CreateCandidate(RequestCreateCandidateDTO requestCreateCandidateDTO) :IRequest<bool>;
}
