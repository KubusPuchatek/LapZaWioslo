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
        public string Name { get; set; }
        public string AdditionalQuestion { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}
