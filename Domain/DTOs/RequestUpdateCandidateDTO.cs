using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PandaPeAPI.Domain.DTOs
{
    public class RequestUpdateCandidateDTO
    {
        /// <summary>
        /// Id del candidato regitrado
        /// </summary>
        [Required]
        public Guid IdCandidate { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Apellidos 
        /// </summary>
        public string? Surname { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Listado de las experiencias
        /// </summary>
        public List<ExperiencesUpdate> CandidateExperiences { get; set; }
    }
    public class ExperiencesUpdate
    {
        /// <summary>
        /// Id de la experiencia
        /// </summary>
        public Guid? IdCandidateExperience { get; set; }
        /// <summary>
        /// Nombre de la compañia
        /// </summary>
        public string? Company { get; set; }
        /// <summary>
        /// Nombre del trabajo
        /// </summary>
        public string? Job { get; set; }
        /// <summary>
        /// Descripcion del trabajo
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Salario
        /// </summary>
        public decimal? Salary { get; set; }
        /// <summary>
        /// Inicio del contraro
        /// </summary>
        public DateTime? BeginDate { get; set; }
        /// <summary>
        /// Final del contrato
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
