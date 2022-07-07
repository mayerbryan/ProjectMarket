using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectMarket.Application.Models;

namespace ProjectMarket.Api.Data.Mappings
{
    public class UserClientMap : IEntityTypeConfiguration<UserClientModel>
    {
        public void Configure(EntityTypeBuilder<UserClientModel> builder)
        {
            builder.ToTable("UserClient");

            builder.HasKey(x => x.SystemId);

            builder.Property(x => x.SystemId)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnName("UserClientName")
                .HasColumnType("text")
                .HasMaxLength(50);

            builder.Property(x => x.UserAddress)
                .IsRequired()
                .HasColumnName("UserClientAddress")
                .HasColumnType("text")
                .HasMaxLength(80);

            builder.Property(x => x.UserPhone)
                .IsRequired()
                .HasColumnName("UserClientPhone")
                .HasColumnType("integer")
                .HasMaxLength(15);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserClientId")
                .HasColumnType("integer")
                .HasMaxLength(15);

            builder.Property(x => x.UserEmail)
                .IsRequired()
                .HasColumnName("UserClientEmail")
                .HasColumnType("text")
                .HasMaxLength(30);

            builder.Property(x => x.UserPassword)
                .IsRequired()
                .HasColumnName("UserClientPassword")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);


       
        }
    }
}
