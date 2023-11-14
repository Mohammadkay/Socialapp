using System;
using System.Collections.Generic;

namespace DatingAPP
{
    public partial class User
    {
        public User()
        {
            Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public byte[]? HashPassword { get; set; }
        public byte[]? Saltpassword { get; set; }
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

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
