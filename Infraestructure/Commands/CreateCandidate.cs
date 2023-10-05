using MediatR;
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.DTOs;

namespace PandaPeAPI.Infraestructure.Commands
{
    public record CreateCandidate(RequestCreateCandidateDTO requestCreateCandidateDTO) :IRequest<ResponseEndPointDTO<bool>>;
}
