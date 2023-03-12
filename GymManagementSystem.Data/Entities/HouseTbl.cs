using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Data.Entities
{
    [Table("HouseTbl")]
    public partial class HouseTbl
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Type { get; set; } = null!;
        [StringLength(50)]
        public string Address { get; set; } = null!;
        [StringLength(50)]
        public string City { get; set; } = null!;
        public int Rooms { get; set; }
        public int Kitchens { get; set; }
        public int Bathrooms { get; set; }
        [StringLength(50)]
        public string Phonenumber { get; set; } = null!;
        public int Price { get; set; }
    }
}
