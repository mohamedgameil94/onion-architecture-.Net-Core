using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain
{
  public class Users : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Guid Guid  { get; set; }

    }
}
