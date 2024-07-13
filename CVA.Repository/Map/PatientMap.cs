using CVA.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVA.Repository.Map
{
    public class PatientMap: IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("tb_paciente", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id_paciente")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("dsc_nome")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.BirthDate)
                .HasColumnName("dat_nascimento")
                .IsRequired();

            builder.Property(e => e.CreationDate)
                .HasColumnName("dat_criacao")
                .IsRequired();

            builder.HasMany(e => e.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
