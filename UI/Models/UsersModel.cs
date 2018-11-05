using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class UsersModel : BaseModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] PasswordSalt { get; set; }

        public Guid Guid { get; set; }
    }
}
