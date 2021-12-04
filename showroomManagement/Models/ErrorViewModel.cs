using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace showroomManagement.Models
{   
    [NotMapped]
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
