﻿using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;
using PERUSTARS.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //*******************************************//
                     /*DEFINIENDO CLASES*/
        //*******************************************//

        public DbSet<Person> Persons { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<HobbyistSpecialty> Interests { get; set; }
        public DbSet<FavoriteArtwork> FavoriteArtworks { get; set; }

        public DbSet<ClaimTicket> ClaimTickets { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

                            //*******************************************//
                                              /*PERSON ENTITY*/
                            //*******************************************//
            builder.Entity<Person>().ToTable("Persons");
            builder.Entity<Person>().HasKey(p => p.Id);
            builder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Person>().Property(p => p.Firstname).IsRequired().HasMaxLength(20);
            builder.Entity<Person>().Property(p => p.Lastname).IsRequired().HasMaxLength(20);


            /*Una persona realiza muchos reportes*/
            builder.Entity<Person>()
                .HasMany(p => p.ClaimTickets)
                .WithOne(p => p.ReportMadeBy)
                .HasForeignKey(p => p.PersonId);




                                //*******************************************//
                                                   /*ARTITS ENTITY*/
                                //*******************************************//

            builder.Entity<Artist>().ToTable("Artists");

            builder.Entity<Artist>().HasKey(p => p.Id);
            builder.Entity<Artist>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Artist>().Property(p => p.BrandName).IsRequired().HasMaxLength(30);
            builder.Entity<Artist>().Property(p => p.Description).IsRequired().HasMaxLength(250);
            builder.Entity<Artist>().Property(p => p.Phrase).IsRequired().HasMaxLength(100);
            builder.Entity<Artist>().Property(p => p.SpecialtyArt).IsRequired().HasMaxLength(25);

            /*Un artista tiene muchas OBRAS*/
            builder.Entity<Artist>() 
                .HasMany(p => p.Artworks)
                .WithOne(p => p.Artist)
                .HasForeignKey(p => p.ArtistId);

            /*Un artista tiene muchos EVENTOS*/
            builder.Entity<Artist>()
                .HasMany(p => p.Events)
                .WithOne(p => p.Artist)
                .HasForeignKey(p => p.ArtistId);





                                //*******************************************//
                                                 /*EVENT ENTITY*/
                                //*******************************************//

            builder.Entity<Event>().ToTable("Events");

            builder.Entity<Event>().HasKey(p => p.EventId);
            builder.Entity<Event>().Property(p => p.EventId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Event>().Property(p => p.EventTitle).IsRequired().HasMaxLength(100);
            builder.Entity<Event>().Property(p => p.EventType).IsRequired().HasMaxLength(25);
            builder.Entity<Event>().Property(p => p.DateStart).IsRequired();
            builder.Entity<Event>().Property(p => p.DateEnd).IsRequired();
            builder.Entity<Event>().Property(p => p.EventDescription).IsRequired().HasMaxLength(250);
            builder.Entity<Event>().Property(p => p.EventAditionalInfo);




                                //*******************************************//
                                                /*ARTWORK ENTITY*/
                                //*******************************************//

            builder.Entity<Artwork>().ToTable("Artworks");
            builder.Entity<Artwork>().HasKey(p => p.ArtworkId);
            builder.Entity<Artwork>().Property(p => p.ArtworkId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Artwork>().Property(p => p.ArtTitle).IsRequired().HasMaxLength(100);
            builder.Entity<Artwork>().Property(p => p.ArtDescription).IsRequired().HasMaxLength(250);
            builder.Entity<Artwork>().Property(p => p.ArtCost);
            builder.Entity<Artwork>().Property(p => p.LinkInfo);


                                //*******************************************//
                                                /* SPECIALTY ENTITY */
                                //*******************************************//

            builder.Entity<Specialty>().ToTable("Specialties");
            builder.Entity<Specialty>().HasKey(p => p.SpecialtyId);
            builder.Entity<Specialty>().Property(p => p.SpecialtyId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Specialty>().Property(p => p.SpecialtyName).IsRequired().HasMaxLength(100);


                                //*******************************************//
                                                 /*Interests*/
                                 //*******************************************//

            builder.Entity<HobbyistSpecialty>().ToTable("Interests");
            builder.Entity<HobbyistSpecialty>().HasKey(pt => new { pt.HobbyistId, pt.SpecialtyId });


            //Relaciones
            builder.Entity<HobbyistSpecialty>()
                .HasOne(pt => pt.Hobbyist)
                .WithMany(p => p.HobbyistSpecialty)
                .HasForeignKey(pt => pt.HobbyistId);

            builder.Entity<HobbyistSpecialty>()
                .HasOne(pt => pt.Specialty)
                .WithMany(p => p.HobbyistSpecialty)
                .HasForeignKey(pt => pt.SpecialtyId);




            //*******************************************//
            /*ClaimTicket*/
            //*******************************************//

            builder.Entity<ClaimTicket>().ToTable("ClaimTickets");
            builder.Entity<ClaimTicket>().HasKey(p => p.ClaimId);
            builder.Entity<ClaimTicket>().Property(p => p.ClaimId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ClaimTicket>().Property(p => p.ClaimSubject).IsRequired().HasMaxLength(40);
            builder.Entity<ClaimTicket>().Property(p => p.ClaimDescription).IsRequired().HasMaxLength(300);
            builder.Entity<ClaimTicket>().Property(p => p.IncedentDate).IsRequired();
            builder.Entity<ClaimTicket>().Property(p => p.ReportedPerson).IsRequired();






                            //*******************************************//
                                         /*FAVORITE ARTWORK*/
                            //*******************************************//

            builder.Entity<FavoriteArtwork>().ToTable("FavoriteArtworks");

            builder.Entity<FavoriteArtwork>().HasKey(pt => new { pt.HobyyistId, pt.ArtworkId });

            //Relaciones
            builder.Entity<FavoriteArtwork>()
                .HasOne(pt => pt.Hobbyist)
                .WithMany(p => p.FavoriteArtworks)
                .HasForeignKey(pt => pt.HobyyistId);

            builder.Entity<FavoriteArtwork>()
                .HasOne(pt => pt.Artwork)
                .WithMany(p => p.FavoriteArtworks)
                .HasForeignKey(pt => pt.ArtworkId);




                                //*******************************************//
                                                /*Followers*/
                                //*******************************************//

            builder.Entity<Follower>().ToTable("Followers");

            builder.Entity<Follower>().HasKey(pt => new { pt.HobbyistId, pt.ArtistId });

            //Relaciones
            builder.Entity<Follower>()
                .HasOne(pt => pt.Hobbyist)
                .WithMany(p => p.Followers)
                .HasForeignKey(pt => pt.HobbyistId);

            builder.Entity<Follower>()
                .HasOne(pt => pt.Artist)
                .WithMany(p => p.Followers)
                .HasForeignKey(pt => pt.ArtistId);


                                //*******************************************//
                                               /*Booking*/
                                //*******************************************//

            builder.Entity<Booking>().ToTable("Bookings");
            builder.Entity<Booking>().HasKey(pt => new { pt.HobbyistId, pt.EventId });
            builder.Entity<Booking>().Property(pt => pt.AttendanceDay);
        

            //Relaciones
            builder.Entity<Booking>()
                .HasOne(pt => pt.Hobbyist)
                .WithMany(p => p.Assistance)
                .HasForeignKey(pt => pt.HobbyistId);

            builder.Entity<Booking>()
                .HasOne(pt => pt.Event)
                .WithMany(p => p.Assistance)
                .HasForeignKey(pt => pt.EventId);

            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();

        }
    }
}
