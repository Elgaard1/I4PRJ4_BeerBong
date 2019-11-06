﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt4.Model
{
    public class Participant : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("Participant_name")]
        [StringLength(50)]
        public string ParticipantName { get; set; }
        [Column("date_created", TypeName = "TimeStamp")]
        public DateTime TimeStamp { get; set; }
        [Column("Result_from_drinking")]
        public double RestultTime { get; set; }

        //Navigation propertie
        public Queue Queue { get; set; }

    }
}
