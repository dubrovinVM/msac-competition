using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace msac_competition.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamCompetition> TeamCompetitions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Fst> Fsts { get; set; }
        public DbSet<Sportman> Sportmen { get; set; }
        public DbSet<SportmanCompetition> SportmenCompetitions { get; set; }
        

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamCompetition>()
                .HasKey(t => new { t.TeamId, t.CompetitionId });

            modelBuilder.Entity<TeamCompetition>()
                .HasOne(pt => pt.Team)
                .WithMany(p => p.TeamCompetitions)
                .HasForeignKey(pt => pt.TeamId);

            modelBuilder.Entity<TeamCompetition>()
                .HasOne(pt => pt.Competition)
                .WithMany(t => t.TeamCompetitions)
                .HasForeignKey(pt => pt.CompetitionId);

            modelBuilder.Entity<SportmanCompetition>()
                .HasKey(t => new { t.SportmanId, t.CompetitionId });

            modelBuilder.Entity<SportmanCompetition>()
                .HasOne(pt => pt.Sportman)
                .WithMany(p => p.SportmanCompetitions)
                .HasForeignKey(pt => pt.SportmanId);

            modelBuilder.Entity<SportmanCompetition>()
                .HasOne(pt => pt.Competition)
                .WithMany(t => t.SportmenCompetitions)
                .HasForeignKey(pt => pt.CompetitionId);

            modelBuilder.Entity<Coach>()
                .HasMany(r => r.Sportmen)
                .WithOne(s => s.Coach)
                .HasForeignKey(s => s.CoachId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Coach>()
                .HasOne(r => r.Team)
                .WithOne(t => t.Coach)
                .HasForeignKey<Team>(t => t.CoachId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<City>()
                .HasMany(r => r.Coaches)
                .WithOne(s => s.City)
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
  
}