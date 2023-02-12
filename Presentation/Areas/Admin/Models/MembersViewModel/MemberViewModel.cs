﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Areas.Admin.Models.MembersViewModel
{
    public class MemberViewModel
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Statusi { get; set; }
        public int? Qmimi { get; set; }
        public string? Antaresimi { get; set; }

    }
}
