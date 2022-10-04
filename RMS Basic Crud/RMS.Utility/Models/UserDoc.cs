using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Utility.Models
{
    public class UserDoc
    {
        [Key]
        public Guid UserDocId { get; set; }
        public Guid UserId { get; set; }
        public byte[]? File { get; set; }
        public string? FileType { get; set; }
        public string? FileName { get; set; }
    }
}
