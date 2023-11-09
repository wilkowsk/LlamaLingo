using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LlamaLingo.Models;

public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<Microsoft.EntityFrameworkCore.DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Noun> Nouns { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Pod> Pods { get; set; }

    public virtual DbSet<Pype> Pypes { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Verb> Verbs { get; set; }

    public virtual DbSet<ViewPodBase> ViewPodBases { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("\nServer=llamalingo.database.windows.net;Database=LlamaLingoDB;User=LlamaLingoLogin;Password=UMDLlamaLingo4444");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("Location_ID");
            entity.Property(e => e.LocationDescription)
                .IsRequired()
                .HasMaxLength(128)
                .HasDefaultValueSql("('location desc')")
                .HasColumnName("Location_description");
            entity.Property(e => e.LocationLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValueSql("('label 16')")
                .HasColumnName("Location_label");
            entity.Property(e => e.LocationStatus)
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValueSql("('A')")
                .IsFixedLength()
                .HasColumnName("Location_status");
            entity.Property(e => e.LocationType)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("(N'locs')")
                .IsFixedLength()
                .HasColumnName("Location_type");
            entity.Property(e => e.PersonFkAcad)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Person_FK_acad");
            entity.Property(e => e.PersonFkAdmn)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Person_FK_admn");
            entity.Property(e => e.PersonFkEngr)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Person_FK_engr");
            entity.Property(e => e.PersonFkNnai)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Person_FK_nnai");
            entity.Property(e => e.PersonFkXprt)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Person_FK_xprt");
        });

        modelBuilder.Entity<Noun>(entity =>
        {
            entity.ToTable("Noun");

            entity.Property(e => e.NounId).HasColumnName("Noun_ID");
            entity.Property(e => e.NounDescription)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("(N'description of Noun')")
                .HasColumnName("Noun_description");
            entity.Property(e => e.NounLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValueSql("(N'label 16')")
                .IsFixedLength()
                .HasColumnName("Noun_label");
            entity.Property(e => e.NounStatus)
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValueSql("(N'A')")
                .IsFixedLength()
                .HasColumnName("Noun_status");
            entity.Property(e => e.NounType)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("(N'base')")
                .IsFixedLength()
                .HasColumnName("Noun_type");
            entity.Property(e => e.PodIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("POD_ID_FK");
            entity.Property(e => e.UrlIdPk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("URL_ID_PK");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.PersonId).HasColumnName("Person_ID");
            entity.Property(e => e.LocationIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Location_ID_FK");
            entity.Property(e => e.PersonDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Person_datetime");
            entity.Property(e => e.PersonFirst)
                .IsRequired()
                .HasMaxLength(32)
                .HasDefaultValueSql("(N'first')")
                .HasColumnName("Person_first");
            entity.Property(e => e.PersonLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValueSql("(N'label 16')")
                .IsFixedLength()
                .HasColumnName("Person_label");
            entity.Property(e => e.PersonLast)
                .IsRequired()
                .HasMaxLength(32)
                .HasDefaultValueSql("(N'last')")
                .HasColumnName("Person_last");
            entity.Property(e => e.PersonRole)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("(N'role')")
                .IsFixedLength()
                .HasColumnName("Person_role");
            entity.Property(e => e.PersonStatus)
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValueSql("('A')")
                .IsFixedLength()
                .HasColumnName("Person_status");
            entity.Property(e => e.PersonType)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("('hman')")
                .IsFixedLength()
                .HasColumnName("Person_type");
            entity.Property(e => e.PodIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("POD_ID_FK");
        });

        modelBuilder.Entity<Pod>(entity =>
        {
            entity.ToTable("POD");

            entity.Property(e => e.PodId).HasColumnName("POD_ID");
            entity.Property(e => e.LocationIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Location_ID_FK");
            entity.Property(e => e.PersonIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Person_ID_FK");
            entity.Property(e => e.PodChannel)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("(N'chan')")
                .IsFixedLength()
                .HasColumnName("POD_channel");
            entity.Property(e => e.PodDescription)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("(N'POD desc')")
                .HasColumnName("POD_description");
            entity.Property(e => e.PodLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValueSql("(N'POD label')")
                .HasColumnName("POD_label");
            entity.Property(e => e.PodStatus)
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValueSql("(N'A')")
                .IsFixedLength()
                .HasColumnName("POD_status");
            entity.Property(e => e.PodType)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("(N'pods')")
                .IsFixedLength()
                .HasColumnName("POD_type");
            entity.Property(e => e.PodUrlBase)
                .IsRequired()
                .HasMaxLength(128)
                .HasDefaultValueSql("(N'URL pointer to storage')")
                .HasColumnName("POD_URL_base");
        });

        modelBuilder.Entity<Pype>(entity =>
        {
            entity.HasKey(e => new { e.PypeId, e.PypeType });

            entity.ToTable("Pype");

            entity.Property(e => e.PypeId)
                .HasMaxLength(4)
                .HasDefaultValueSql("('NOVA')")
                .IsFixedLength()
                .HasColumnName("Pype_ID");
            entity.Property(e => e.PypeType)
                .HasMaxLength(4)
                .HasDefaultValueSql("('type')")
                .IsFixedLength()
                .HasColumnName("Pype_type");
            entity.Property(e => e.PodIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("POD_ID_FK");
            entity.Property(e => e.PypeDesc)
                .IsRequired()
                .HasMaxLength(64)
                .HasDefaultValueSql("('Domain Expert Definition')")
                .HasColumnName("Pype_desc");
            entity.Property(e => e.PypeLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValueSql("('label 16')")
                .IsFixedLength()
                .HasColumnName("Pype_label");
            entity.Property(e => e.PypeLink)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("('stop')")
                .IsFixedLength()
                .HasColumnName("Pype_link");
            entity.Property(e => e.PypeStatus)
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValueSql("('A')")
                .IsFixedLength()
                .HasColumnName("Pype_status");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK_Task_1");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId).HasColumnName("Task_ID");
            entity.Property(e => e.NovaIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("NOVA_ID_FK");
            entity.Property(e => e.ParentIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Parent_ID_FK");
            entity.Property(e => e.PersonIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Person_ID_FK");
            entity.Property(e => e.TaskDescription)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("('description of goal step')")
                .HasColumnName("Task_description");
            entity.Property(e => e.TaskDuration)
                .IsRequired()
                .HasMaxLength(64)
                .HasDefaultValueSql("((7))")
                .HasColumnName("Task_duration");
            entity.Property(e => e.TaskEntryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Task_entry_date");
            entity.Property(e => e.TaskFinishDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Task_finish_date");
            entity.Property(e => e.TaskLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValueSql("('description of goal step')")
                .IsFixedLength()
                .HasColumnName("Task_label");
            entity.Property(e => e.TaskLevel)
                .HasDefaultValueSql("((1))")
                .HasColumnName("Task_level");
            entity.Property(e => e.TaskProgress).HasColumnName("Task_progress");
            entity.Property(e => e.TaskStartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Task_start_date");
            entity.Property(e => e.TaskStatus)
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValueSql("('A')")
                .IsFixedLength()
                .HasColumnName("Task_status");
            entity.Property(e => e.TaskType)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("(N'task')")
                .IsFixedLength()
                .HasColumnName("Task_type");
        });

        modelBuilder.Entity<Verb>(entity =>
        {
            entity.ToTable("Verb");

            entity.Property(e => e.VerbId).HasColumnName("Verb_ID");
            entity.Property(e => e.PodIdFk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("POD_ID_FK");
            entity.Property(e => e.UrlIdPk)
                .HasDefaultValueSql("((1))")
                .HasColumnName("URL_ID_PK");
            entity.Property(e => e.VerbDescription)
                .IsRequired()
                .HasMaxLength(255)
                .HasDefaultValueSql("(N'Description of Verb')")
                .HasColumnName("Verb_description");
            entity.Property(e => e.VerbLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasDefaultValueSql("(N'label 16')")
                .IsFixedLength()
                .HasColumnName("Verb_label");
            entity.Property(e => e.VerbStatus)
                .IsRequired()
                .HasMaxLength(1)
                .HasDefaultValueSql("(N'A')")
                .IsFixedLength()
                .HasColumnName("Verb_status");
            entity.Property(e => e.VerbType)
                .IsRequired()
                .HasMaxLength(4)
                .HasDefaultValueSql("(N'base')")
                .IsFixedLength()
                .HasColumnName("Verb_type");
        });

        modelBuilder.Entity<ViewPodBase>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_POD_base");

            entity.Property(e => e.LocationDescription)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("Location_description");
            entity.Property(e => e.LocationIdFk).HasColumnName("Location_ID_FK");
            entity.Property(e => e.LocationLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("Location_label");
            entity.Property(e => e.PersonFirst)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnName("Person_first");
            entity.Property(e => e.PersonLast)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnName("Person_last");
            entity.Property(e => e.PodChannel)
                .IsRequired()
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("POD_channel");
            entity.Property(e => e.PodDescription)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("POD_description");
            entity.Property(e => e.PodId).HasColumnName("POD_ID");
            entity.Property(e => e.PodLabel)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("POD_label");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
