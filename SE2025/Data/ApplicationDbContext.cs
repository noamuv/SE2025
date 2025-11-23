using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SE2025.Models;
namespace SE2025.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<SE2025.Models.User> Users { get; set; }
        public DbSet<SE2025.Models.User_Type> User_Types { get; set; }
        public DbSet<SE2025.Models.Carer> Carers { get; set; }
        public DbSet<SE2025.Models.Patient> Patients { get; set; }
        public DbSet<SE2025.Models.Carer_Access> Carer_Accesses { get; set; }
        public DbSet<SE2025.Models.Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SE2025.Models.User_Type>()
                .HasData(
                    new SE2025.Models.User_Type { User_Type_ID = 1, Type_Name = "Admin", Description = "N/A" },
                    new SE2025.Models.User_Type { User_Type_ID = 2, Type_Name = "Clinician", Description = "N/A" },
                    new SE2025.Models.User_Type { User_Type_ID = 3, Type_Name = "Patient", Description = "N/A" },
                    new SE2025.Models.User_Type { User_Type_ID = 4, Type_Name = "Carer", Description = "N/A" }
                );

            modelBuilder.Entity<SE2025.Models.Gender>()
                .HasData(
                    new SE2025.Models.Gender { Gender_ID = 1, Name = "Male" },
                    new SE2025.Models.Gender { Gender_ID = 2, Name = "Female" },
                    new SE2025.Models.Gender { Gender_ID = 3, Name = "Other" }
                 );

            modelBuilder.Entity<SE2025.Models.User>()
                .HasData(
                    new User
                    {
                        User_ID = 1,
                        User_Type_ID = 4,
                        Title = "Mr",
                        First_Name = "John",
                        Last_Name = "Smith",
                        Email = "john.smith@example.com",
                        Password_Hash = "hash123",
                        Status = "Active",
                        Created_At = new DateTime(2024, 01, 15),
                        Is_Activated = true,
                        Activation_Code = "ABC123"
                    },
                    new User
                    {
                        User_ID = 2,
                        User_Type_ID = 4,
                        Title = "Ms",
                        First_Name = "Sarah",
                        Last_Name = "Johnson",
                        Email = "sarah.j@example.com",
                        Password_Hash = "hash456",
                        Status = "Active",
                        Created_At = new DateTime(2024, 01, 16),
                        Is_Activated = true,
                        Activation_Code = "DEF456"
                    },
                    new User
                    {
                        User_ID = 3,
                        User_Type_ID = 3,
                        Title = "Mrs",
                        First_Name = "Emma",
                        Last_Name = "Williams",
                        Email = "emma.w@example.com",
                        Password_Hash = "hash789",
                        Status = "Active",
                        Created_At = new DateTime(2024, 01, 17),
                        Is_Activated = true,
                        Activation_Code = "GHI789"
                    },
                    new User
                    {
                        User_ID = 4,
                        User_Type_ID = 3,
                        Title = "Mr",
                        First_Name = "Michael",
                        Last_Name = "Brown",
                        Email = "michael.b@example.com",
                        Password_Hash = "hash101",
                        Status = "Active",
                        Created_At = new DateTime(2024, 01, 18),
                        Is_Activated = true,
                        Activation_Code = "JKL101"
                    },
                    new User
                    {
                        User_ID = 5,
                        User_Type_ID = 2,
                        Title = "Dr",
                        First_Name = "Lisa",
                        Last_Name = "Anderson",
                        Email = "dr.anderson@example.com",
                        Password_Hash = "hash202",
                        Status = "Active",
                        Created_At = new DateTime(2024, 01, 19),
                        Is_Activated = true,
                        Activation_Code = "MNO202"
                    }
                );
            modelBuilder.Entity<SE2025.Models.Carer>()
                .HasData(
                    new Carer { User_ID = 1, Availability_Schedule = "Mon-Fri 9am-5pm" },
                    new Carer { User_ID = 2, Availability_Schedule = "Tue-Thu 10am-4pm" }
                );

            modelBuilder.Entity<SE2025.Models.Patient>()
                .HasData(
                    new Patient { User_ID = 3, Gender_ID = 2, Date_of_Birth = new DateTime(1985, 03, 20), Notes = "N/A" },
                    new Patient { User_ID = 4, Gender_ID = 1, Date_of_Birth = new DateTime(1992, 07, 14), Notes = "N/A" }
                );

            modelBuilder.Entity<SE2025.Models.Carer_Access>()
                .HasData(
                    new Carer_Access { 
                        Access_ID = 1, 
                        Carer_User_ID = 1, 
                        Patient_User_ID = 3, 
                        Permission_Level = 2, 
                        Granted_By_User_ID = 5, 
                        Revoked_By_User_ID = 0,
                        Granted_At = new DateTime(2024, 01, 20),
                        Revoked_At = null
                    },
                    new Carer_Access
                    {
                        Access_ID = 2,
                        Carer_User_ID = 1,
                        Patient_User_ID = 4,
                        Permission_Level = 3,
                        Granted_By_User_ID = 5,
                        Revoked_By_User_ID = 0,
                        Granted_At = new DateTime(2024, 01, 21),
                        Revoked_At = null
                    },
                    new Carer_Access
                    {
                        Access_ID = 3,
                        Carer_User_ID = 2,
                        Patient_User_ID = 3,
                        Permission_Level = 1,
                        Granted_By_User_ID = 5,
                        Revoked_By_User_ID = 0,
                        Granted_At = new DateTime(2024, 01, 22),
                        Revoked_At = null
                    }
                );
        }
    }
}

