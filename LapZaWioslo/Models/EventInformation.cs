using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LapZaWioslo.Models
{
    [Table("EventInformation")]
    public class EventInformation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "String.Event.Name.DisplayName")]
        public string Name { get; set; }

        [Display(Name = "String.Event.AdditionalQuestion.DisplayName")]
        public string AdditionalQuestion { get; set; }

        [Display(Name = "String.Event.StartDate.DisplayName")]
        public DateTime StartDate { get; set; }

        [Display(Name = "String.Event.EndDate.DisplayName")]
        public DateTime EndDate { get; set; }

        [Display(Name = "String.Event.Description.DisplayName")]
        public string Description { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}
