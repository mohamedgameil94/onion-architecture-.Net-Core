using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
  public class Users : BaseEntity
    {
        public string Email { get; set; }

        public byte[] Password { get; set; }

        public byte[] PasswordSalt { get; set; }
        public Guid Guid  { get; set; }

    }
}
