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
        }
    }
  
}