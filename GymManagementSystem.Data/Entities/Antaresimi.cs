using System;
using System.Collections.Generic;

namespace GymManagementSystem.Data.Entities
{
    public partial class Antaresimi
    {
        public Antaresimi()
        {
            Hyrjets = new HashSet<Hyrjet>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public string Statusi { get; set; } = null!;
        public int Qmimi { get; set; }
        public string _Antaresimi { get; set; } = null!;

        public virtual ICollection<Hyrjet> Hyrjets { get; set; }
    }
}
