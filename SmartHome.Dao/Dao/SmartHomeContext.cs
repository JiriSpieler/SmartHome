using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SmartHome.Dao.Dao;

public partial class SmartHomeContext : DbContext
{
    public SmartHomeContext()
    {
    }

    public SmartHomeContext(DbContextOptions<SmartHomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Input> Inputs { get; set; }

    public virtual DbSet<Output> Outputs { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomInput> RoomInputs { get; set; }

    public virtual DbSet<RoomOutput> RoomOutputs { get; set; }

    public virtual DbSet<RoomThermoRule> RoomThermoRules { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<ThermoRule> ThermoRules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Input>(entity =>
        {
            entity.ToTable("INPUTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Circuit)
                .HasMaxLength(50)
                .HasColumnName("CIRCUIT");
            entity.Property(e => e.Dev)
                .HasMaxLength(50)
                .HasColumnName("DEV");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("LAST_UPDATE");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("VALUE");
        });

        modelBuilder.Entity<Output>(entity =>
        {
            entity.ToTable("OUTPUTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Circuit)
                .HasMaxLength(50)
                .HasColumnName("CIRCUIT");
            entity.Property(e => e.Dev)
                .HasMaxLength(50)
                .HasColumnName("DEV");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("LAST_UPDATE");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("VALUE");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("ROOMS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DefaultTemp)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("DEFAULT_TEMP");
            entity.Property(e => e.Hystersis)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("HYSTERSIS");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<RoomInput>(entity =>
        {
            entity.ToTable("ROOM_INPUTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.IdInput).HasColumnName("ID_INPUT");
            entity.Property(e => e.IdRoom).HasColumnName("ID_ROOM");
            entity.Property(e => e.IdSecondaryInput)
                .HasColumnType("decimal(12, 0)")
                .HasColumnName("ID_SECONDARY_INPUT");

            entity.HasOne(d => d.IdInputNavigation).WithMany(p => p.RoomInputs)
                .HasForeignKey(d => d.IdInput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_INPUTS_INPUTS");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.RoomInputs)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_INPUTS_ROOMS");
        });

        modelBuilder.Entity<RoomOutput>(entity =>
        {
            entity.ToTable("ROOM_OUTPUTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.IdOutput).HasColumnName("ID_OUTPUT");
            entity.Property(e => e.IdRoom).HasColumnName("ID_ROOM");

            entity.HasOne(d => d.IdOutputNavigation).WithMany(p => p.RoomOutputs)
                .HasForeignKey(d => d.IdOutput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_OUTPUTS_OUTPUTS");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.RoomOutputs)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_OUTPUTS_ROOMS");
        });

        modelBuilder.Entity<RoomThermoRule>(entity =>
        {
            entity.ToTable("ROOM_THERMO_RULES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdRoom).HasColumnName("ID_ROOM");
            entity.Property(e => e.IdThermoRule).HasColumnName("ID_THERMO_RULE");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.RoomThermoRules)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_THERMO_RULES_ROOMS");

            entity.HasOne(d => d.IdThermoRuleNavigation).WithMany(p => p.RoomThermoRules)
                .HasForeignKey(d => d.IdThermoRule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_THERMO_RULES_THERMO_RULES");
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.ToTable("STATISTICS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CaptureDate)
                .HasColumnType("datetime")
                .HasColumnName("CAPTURE_DATE");
            entity.Property(e => e.IdInput).HasColumnName("ID_INPUT");
            entity.Property(e => e.Temp)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TEMP");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.IdInputNavigation).WithMany(p => p.Statistics)
                .HasForeignKey(d => d.IdInput)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STATISTICS_INPUTS");
        });

        modelBuilder.Entity<ThermoRule>(entity =>
        {
            entity.ToTable("THERMO_RULES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Disabled).HasColumnName("DISABLED");
            entity.Property(e => e.End)
                .HasMaxLength(5)
                .HasColumnName("END");
            entity.Property(e => e.IntervalSatus)
                .HasColumnType("decimal(1, 0)")
                .HasColumnName("INTERVAL_SATUS");
            entity.Property(e => e.LastUpdate)
                .HasColumnType("datetime")
                .HasColumnName("LAST_UPDATE");
            entity.Property(e => e.Start)
                .HasMaxLength(5)
                .HasColumnName("START");
            entity.Property(e => e.Temp)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("TEMP");
            entity.Property(e => e.WeekDay)
                .HasColumnType("decimal(12, 0)")
                .HasColumnName("WEEK_DAY");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("LOGIN");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("ROLE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
