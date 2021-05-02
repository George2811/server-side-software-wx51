using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;
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

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobbyist> Hobbyists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FavoriteArtwork> FavoriteArtworks { get; set; }


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








        }
    }
}
