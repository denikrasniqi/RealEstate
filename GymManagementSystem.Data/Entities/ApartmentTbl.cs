using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Data.Entities
{
    [Table("ApartmentTbl")]
    public partial class ApartmentTbl
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Type { get; set; } = null!;
        [StringLength(50)]
        public string Address { get; set; } = null!;
        [StringLength(50)]
        public string City { get; set; } = null!;
        public int Floor { get; set; }
        [StringLength(50)]
        public string Size { get; set; } = null!;
        public int Rooms { get; set; }
        public int Kitchens { get; set; }
        public int Bathrooms { get; set; }
        [StringLength(50)]
        public string Phonenumber { get; set; } = null!;
        public int Price { get; set; }
    }
}
