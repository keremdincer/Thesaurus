using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastracture.Data
{
    public class ThesaurusContext : DbContext
    {
        public ThesaurusContext(DbContextOptions<ThesaurusContext> options) : base(options) { }

        public DbSet<Word> Words { get; set; }
        public DbSet<Synonym> Synonyms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Synonym>().HasKey(s => new { s.FromId, s.ToId });

            modelBuilder.Entity<Synonym>(entity =>
            {
                entity.HasOne(s => s.FromWord)
                    .WithMany(s => s.Synonyms)
                    .HasForeignKey(w => w.FromId);

                entity.HasOne(s => s.ToWord)
                    .WithMany(s => s.FromSynonyms)
                    .HasForeignKey(w => w.ToId);
            });
        }
    }
}
