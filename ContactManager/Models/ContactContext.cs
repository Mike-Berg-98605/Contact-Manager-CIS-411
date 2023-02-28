using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<ContactInfo>().HasData(
                new ContactInfo
                {
                    ContactInfoID = 1,
                    FirstName = "Luke",
                    LastName = "Skywalker",
                    PhoneNumber = "502-896-1234",
                    Email = "FlyBoy@gmail.com",
                    CategoryID = 1,
                    Organization = "The Rebellion",
                    CreateDate = DateTime.Today
                    

                },
                new ContactInfo
                {
                    ContactInfoID = 2,
                    FirstName = "Boba",
                    LastName = "Fett",
                    PhoneNumber = "502-999-5555",
                    Email = "BountyHunter@gmail.com",
                    CategoryID = 5,
                    Organization = "Bounty Hunter's Guild",
                    CreateDate = DateTime.Today


                },
                new ContactInfo
                {
                    ContactInfoID = 3,
                    FirstName = "Imperial ",
                    LastName = "StormTrooper",
                    PhoneNumber = "502-444-4123",
                    Email = "PewPewLasers@gmail.com",
                    CategoryID = 4,
                    Organization = "The Empire",
                    CreateDate = DateTime.Today



                }
            );
            modelBuilder.Entity<Category>().HasData(
                 new Category { CategoryID = 1, Name = "Friend" },
                 new Category { CategoryID = 2, Name = "Work" },
                 new Category { CategoryID = 3, Name = "Family" },
                 new Category { CategoryID = 4, Name = "Foe" },
                 new Category { CategoryID = 5, Name = "Bestie" }
             );

        }
    }
}

