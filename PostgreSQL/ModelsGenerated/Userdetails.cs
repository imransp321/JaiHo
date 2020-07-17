using System;
using System.Collections.Generic;

namespace PostgreSQL.ModelsGenerated
{
    public partial class Userdetails
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public bool? Isactive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
