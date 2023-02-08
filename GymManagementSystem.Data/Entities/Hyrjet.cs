using System;
using System.Collections.Generic;

namespace GymManagementSystem.Data.Entities
{
    public partial class Hyrjet
    {
        public int Id { get; set; }
        public int AntariId { get; set; }
        public string NrHyrjeve { get; set; } = null!;
        public DateTime KohaHyrjes { get; set; }

        public virtual Antaresimi Antari { get; set; } = null!;
    }
}
