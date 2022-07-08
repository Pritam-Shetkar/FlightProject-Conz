using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SearchAPIService.Models
{
    public partial class FlightProjectDBContext : DbContext
    {
        public FlightProjectDBContext()
        {
        }

        public FlightProjectDBContext(DbContextOptions<FlightProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirlineList> AirlineLists { get; set; }
        public virtual DbSet<BookingFlight> BookingFlights { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LoginTb> LoginTbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET390;Initial Catalog=FlightProjectDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirlineList>(entity =>
            {
                entity.HasKey(e => e.AirlineId)
                    .HasName("PK__Airline___DC45821357B02F81");

                entity.ToTable("Airline_List");

                entity.Property(e => e.AirlinesNames)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ContactAddress).HasMaxLength(150);

                entity.Property(e => e.ContactNumber).HasMaxLength(150);

                entity.Property(e => e.LogoPath)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("Logo_Path");
            });

            modelBuilder.Entity<BookingFlight>(entity =>
            {
                entity.HasKey(e => e.BookFlightId)
                    .HasName("PK__Booking___1C0F2229BE851F28");

                entity.ToTable("Booking_Flight");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.AirlineId).HasColumnName("Airline_Id");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Meal).HasMaxLength(150);

                entity.Property(e => e.PassGender)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PassName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Pnr)
                    .HasMaxLength(150)
                    .HasColumnName("pnr");

                entity.Property(e => e.SeatNumber)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.BookingFlights)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("FK__Booking_F__Airli__286302EC");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FromPlace)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentUsed)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Meal)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleDay)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.TbussinessClassSeat).HasColumnName("TBussinessClassSeat");

                entity.Property(e => e.TnobussinessClassSeat).HasColumnName("TNOBussinessClassSeat");

                entity.Property(e => e.ToPlace)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginTb>(entity =>
            {
                entity.ToTable("LoginTB");

                entity.Property(e => e.Password).HasMaxLength(150);

                entity.Property(e => e.UserName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
