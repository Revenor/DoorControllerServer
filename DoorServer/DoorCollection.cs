using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace DoorServer
{
    public class DoorOpensCollection
    {
        [Key]
        public int Key { get; set; }
        public DateTime DateTimeOfOpening { get; set; }
        public string Type { get; set; }
        [NotNull] public string NameOfUser { get; set; }
    }
}
