using CVA.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVA.Repository.Map
{
    internal class AppoinntmentMap: IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("tb_agendamento", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id_agendamento")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Id)
                .HasColumnName("id_paciente")
                .IsRequired();

            builder.Property(e => e.AppointmentDate)
                .HasColumnName("dat_agendamento")
                .IsRequired();

            builder.Property(e => e.AppointmentTime)
                .HasColumnName("hor_agendamento")
                .IsRequired();

            builder.Property(e => e.StatusDescription)
                .HasColumnName("dsc_status")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.CreationDate)
                .HasColumnName("dat_criacao")
                .IsRequired();

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
