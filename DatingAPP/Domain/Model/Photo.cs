using System;
using System.Collections.Generic;

namespace DatingAPP
{
    public partial class Photo
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public bool? Ismain { get; set; }
        public string? PublicId { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
