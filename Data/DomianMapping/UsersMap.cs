using Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DomianMapping
{
   public class UsersMap
    {
        public UsersMap(EntityTypeBuilder<Users> entityBuilder)
        {

            entityBuilder.HasKey(u => u.Id);
            entityBuilder.HasIndex(u => u.Email).IsUnique();
            entityBuilder.Property(u => u.Password).IsRequired();
            entityBuilder.Property(u => u.PasswordSalt).IsRequired();

        }
    }
}
