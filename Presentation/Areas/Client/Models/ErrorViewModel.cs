using System;

namespace Presentation.Areas.Client.Models

{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } = null;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}