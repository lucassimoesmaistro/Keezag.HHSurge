using Keezag.HHSurge.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keezag.HHSurge.Repository.Mappings
{
    public class ProfileMapping : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Address)
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Avatar)
                .HasColumnType("varchar(11)");

            builder.Property(c => c.Document)
                .HasColumnType("varchar(11)");


            builder.HasOne(c => c.User)
                .WithMany(c => c.Profiles);

            builder.ToTable("Profile");
        }
    }
}
