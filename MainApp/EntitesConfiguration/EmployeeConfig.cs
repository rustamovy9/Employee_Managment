using MainApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainApp.EntitesConfiguration;

public class EmployeeConfig:IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(x=>x.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(x=>x.LastName).HasMaxLength(100).IsRequired();
        builder.Property(x=>x.Email).HasMaxLength(255).IsRequired().IsUnicode(false);
        builder.HasIndex(x=>x.Email).IsUnique();
        builder.Property(x=>x.Phone).HasMaxLength(20).IsRequired();
        builder.HasCheckConstraint("CHK_Phone_Length", "LENGTH(\"Phone\") >= 10");
        builder.Property(x => x.DateOfBirth).IsRequired();
        builder.HasCheckConstraint("CHK_DateOfBirth", "\"DateOfBirth\" < CURRENT_DATE");
        builder.Property(x => x.HireDate).IsRequired();
        builder.Property(x => x.Position).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Salary).HasColumnType("decimal(18,2)").HasDefaultValue(0);
        builder.HasCheckConstraint("CHK_Salary_Positive", "\"Salary\" >= 0");
        builder.Property(x => x.DepartmentName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.ManagerName).HasMaxLength(100).IsRequired();
        builder.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
        builder.Property(x=>x.Address).HasMaxLength(255).IsRequired();
        builder.Property(x => x.City).HasMaxLength(100).IsRequired();
        builder.Property(x=>x.Country).HasMaxLength(100).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP"); 
        builder.Property(x => x.UpdatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
    }
}