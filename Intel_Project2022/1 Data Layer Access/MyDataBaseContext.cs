using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IntelPro
{
    public partial  class MyDataBaseContext : DbContext
    {
        public MyDataBaseContext()
        {
        }

        public MyDataBaseContext(DbContextOptions<MyDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GlUpdatedPassdown> GlUpdatedPassdowns { get; set; }
        public virtual DbSet<ModuleGasLimit> ModuleGasLimits { get; set; }
        public virtual DbSet<Resume> Resume { get; set; }
        public virtual DbSet<Access_Permission> Access_Permission { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<chat> chat { get; set; }
        public virtual DbSet<Contacts_Online> Contacts_Online { get; set; }
        public virtual DbSet<Torque_List> Torque_List { get; set; }
        public virtual DbSet<All_Images> All_Images { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning: 'To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.'
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-A6NL43V\\SQLEXPRESS;Database=MyDataBase;Trusted_Connection=True");
#pragma warning restore CS1030 // #warning: 'To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.'
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<GlUpdatedPassdown>(entity =>
            {
                entity.ToTable("GL_Updated_Passdown");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Buddy)
                    .HasMaxLength(50)
                    .HasColumnName("buddy");

                entity.Property(e => e.Shift)
                    .HasMaxLength(50)
                    .HasColumnName("shift");

                entity.Property(e => e.Task)
                    .HasMaxLength(50)
                    .HasColumnName("task");

                entity.Property(e => e.Techname)
                .HasMaxLength(50);

                entity.Property(e => e.Time)
                    .HasMaxLength(50)
                    .HasColumnName("time");
            });


            modelBuilder.Entity<Torque_List>(entity =>
            {
                entity.ToTable("Torque List");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.Module).HasColumnName("module").HasMaxLength(50);

                entity.Property(e => e.Part).HasColumnName("part").HasMaxLength(50);

                entity.Property(e => e.Torque).HasColumnName("torque").HasMaxLength(int.MaxValue);

                entity.Property(e => e.Route).HasColumnName("route").HasMaxLength(int.MaxValue);

                entity.Property(e => e.Chambar).HasColumnName("chambar").HasMaxLength(50);

                entity.Property(e => e.pm).HasColumnName("PM").HasMaxLength(50);

            });

            modelBuilder.Entity<All_Images>(entity =>
            {
                entity.ToTable("All_Images");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.Module).HasColumnName("Module").HasMaxLength(50);

                entity.Property(e => e.Task).HasColumnName("Task").HasMaxLength(50);

                entity.Property(e => e.PM_Step).HasColumnName("PM_Step").HasMaxLength(50);

                entity.Property(e => e.ImageLocation).HasColumnName("ImageLocation");

                entity.Property(e => e.description).HasColumnName("description").HasMaxLength(int.MaxValue);

                entity.Property(e => e.part).HasColumnName("Part").HasMaxLength(50);


                entity.Property(e => e.Torque).HasColumnName("Torque").HasMaxLength(int.MaxValue);


            });

            modelBuilder.Entity<Contacts_Online>(entity =>
            {
                entity.ToTable("Contact_Online");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserOnline)
                    .HasMaxLength(50)
                    .HasColumnName("Username");

                entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("Istype");

                entity.Property(e => e.date)
                .HasColumnName("date");
            });


            modelBuilder.Entity<ModuleGasLimit>(entity =>
            {
                entity.ToTable("module_gas_limits");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GasLine).HasColumnName("gas_line");

                entity.Property(e => e.GasName)
                    .IsUnicode(false)
                    .HasColumnName("gas_name");

                entity.Property(e => e.LowerLimit).HasColumnName("lower_limit");

                entity.Property(e => e.Module)
                    .IsUnicode(false)
                    .HasColumnName("module");

                entity.Property(e => e.Target).HasColumnName("target");

                entity.Property(e => e.Tool)
                    .IsUnicode(false)
                    .HasColumnName("tool");

                entity.Property(e => e.UpperLimit).HasColumnName("upper_limit");
            });

            modelBuilder.Entity<chat>(entity =>
            {
                entity.ToTable("chat");

                entity.Property(e => e.id).HasColumnName("id");


                entity.Property(e => e.message)
                .HasMaxLength(int.MaxValue)
                .HasColumnName("message");

                entity.Property(e => e.Name)
               .HasMaxLength(50)
               .HasColumnName("name");

                entity.Property(e => e.date)
            .HasMaxLength(50)
            .HasColumnName("date");

                entity.Property(e => e.Shift)
                   .HasMaxLength(50)
                .HasColumnName("shift");

                entity.Property(e => e.activedate)
                .HasMaxLength(int.MaxValue)
                .HasColumnName("ActiveSendMessagedate");

                entity.Property(e => e.day)
                .HasColumnName("day");              
               
            });
                


            modelBuilder.Entity<Resume>(entity =>
            {
                entity.ToTable("Resume_TaskList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

                entity.Property(e => e.Task)
                .HasMaxLength(50)
                .HasColumnName("task");


                entity.Property(e => e.Router)
               .HasMaxLength(50)
               .HasColumnName("router");

                entity.Property(e => e.Date)
                .HasMaxLength(50)
                .HasColumnName("date");

            });


            modelBuilder.Entity<Access_Permission>(entity =>
            {
                entity.ToTable("Allowing Access");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.First_Name)
                .HasMaxLength(50)
                .HasColumnName("FirstName");

                entity.Property(e => e.Last_Name)
                .HasMaxLength(50)
                .HasColumnName("LastName");

                entity.Property(e => e.User_Name)
                .HasMaxLength(50)
                .HasColumnName("UserName");

                entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("Password");

                entity.Property(e => e.role)
               .HasMaxLength(50)
               .HasColumnName("Role");


                entity.Property(e => e.Jwt_Token)
               .HasMaxLength(50)
               .HasColumnName("JwtToken");

                entity.Property(e => e.command)
                .HasMaxLength(50)
                .HasColumnName("Command");


            });


            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("Comments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("Name");

                entity.Property(e => e.WWid)
                .HasMaxLength(50)
                .HasColumnName("WWid");


                entity.Property(e => e.Subject)
               .HasMaxLength(50)
               .HasColumnName("Subject");

                entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .HasColumnName("Comment");

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
