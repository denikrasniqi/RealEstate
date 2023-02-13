using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Data.Entities
{
    public partial class Entry
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; } = null!;
        public bool IsEntry { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
    }
}
