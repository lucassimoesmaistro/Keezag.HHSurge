using Keezag.HHSurge.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keezag.HHSurge.Repository.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Profiles)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            builder.ToTable("User");
        }
    }
}
