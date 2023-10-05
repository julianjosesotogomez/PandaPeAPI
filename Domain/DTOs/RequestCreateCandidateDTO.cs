using System.ComponentModel.DataAnnotations;

namespace PandaPeAPI.Domain.DTOs
{
    public class RequestCreateCandidateDTO
    {
        /// <summary>
        /// Nombre
        /// </summary>
        [Required]
        public string? Name { get; set; }
        /// <summary>
        /// Apellidos
        /// </summary>
        [Required]
        public string? Surname { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [Required]
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// Correo electrónico
        /// </summary>
        [Required]
        public string? Email { get; set; }
        /// <summary>
        /// Listado de experiencias
        /// </summary>
        public List<Expiriences> Expiriences { get; set; }
    }
    public class Expiriences
    {
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
        /// Inicio del contrato
        /// </summary>
        public DateTime? BeginDate { get; set; }
        /// <summary>
        /// Finalizacion del contrato
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
