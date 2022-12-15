using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopBaseApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }


        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(x => x.Id);
                builder.ToTable("User.Role");
                builder.HasOne(d => d.Role)
                    .WithMany(x=>x.Users)
                    .HasForeignKey(x=>x.RoleId);
            }
        }

    }
}
