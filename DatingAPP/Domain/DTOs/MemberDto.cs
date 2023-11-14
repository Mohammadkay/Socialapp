using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? DateofBarth { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Lastactive { get; set; }
        public string? Gender { get; set; }
        public string? Introduction { get; set; }
        public string? Lokingfor { get; set; }
        public string? Interests { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? KnwonAs { get; set; }

        public virtual ICollection<PhotoDto> Photos { get; set; }
    }
}
