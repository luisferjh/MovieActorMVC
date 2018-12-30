using Microsoft.EntityFrameworkCore;
using MovieActorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieActorMVC.Data
{
    public class MovieDbContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(x => x.Title).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Movie>().Property(x => x.Description).HasMaxLength(120).IsRequired();
            modelBuilder.Entity<Movie>().Property(x => x.Genre).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Movie>().Property(x => x.Rating).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Movie>().Property(x => x.Price).IsRequired();

            modelBuilder.Entity<Actor>().Property(x => x.FirtsName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Actor>().Property(x => x.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Actor>().Property(x => x.Email).HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Director>().Property(x => x.FirtsName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Director>().Property(x => x.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Director>().Property(x => x.Email).HasMaxLength(30).IsRequired();

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<MovieActor>()
                .HasKey(x => new { x.ActorId, x.MovieId });

            // ma = entidad MovieActor
            // a = entidad Actor
            // m = entidad Movie
            // md = entidad MovieDirector
            // d = entidad Director

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActor)
                .HasForeignKey(ma => ma.ActorId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActor)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieDirector>()
                .HasKey(x => new { x.DirectorId, x.MovieId });

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Director)
                .WithMany(d => d.MovieDirector)
                .HasForeignKey(md => md.DirectorId);

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Movie)
                .WithMany(m => m.MovieDirector)
                .HasForeignKey(md => md.MovieId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
