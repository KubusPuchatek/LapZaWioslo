using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapZaWioslo.Models
{
    [Table("Participant")]
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EventInformation")]
        public int EventId { get; set; }

        [Display(Name = "String.Participant.Name.DisplayName")]
        public string Name { get; set; }

        [Display(Name = "String.Participant.Surname.DisplayName")]
        public string Surname { get; set; }


        public virtual EventInformation EventInformation { get; set; }
    }
}
