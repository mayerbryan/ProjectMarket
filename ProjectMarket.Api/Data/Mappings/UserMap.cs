using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectMarket.Application.Models;

namespace ProjectMarket.Api.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("UserClient");

            builder.Property(x => x.SystemId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("text")
                .HasMaxLength(50);

            builder.Property(x => x.UserAddress)
                .IsRequired()
                .HasColumnName("UserAddress")
                .HasColumnType("text")
                .HasMaxLength(80);

            builder.Property(x => x.UserPhone)
                .IsRequired()
                .HasColumnName("UserPhone")
                .HasColumnType("integer")
                .HasMaxLength(15);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("integer")
                .HasMaxLength(15);

            builder.Property(x => x.UserEmail)
                .IsRequired()
                .HasColumnName("UserEmail")
                .HasColumnType("text")
                .HasMaxLength(30);

            builder.Property(x => x.UserPassword)
                .IsRequired()
                .HasColumnName("UserPassword")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);


       
        }
    }
}
