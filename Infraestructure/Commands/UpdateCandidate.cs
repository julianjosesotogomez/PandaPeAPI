using MediatR;
using PandaPeAPI.Domain.DTOs;
using PandaPeAPI.DTOs;

namespace PandaPeAPI.Infraestructure.Commands
{
    public record UpdateCandidate(RequestUpdateCandidateDTO requestUpdateCandidateDTO) : IRequest<ResponseEndPointDTO<bool>>;

}
