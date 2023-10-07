using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailLibrary.DomainModel;

namespace CMail.Config
{
    public class MailContext: DbContext
    {
        public MailContext(DbContextOptions<MailContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMail> UserMails { get; set; }
        public DbSet<MailViewer> MailViewers { get; set; }
        public DbSet<MailAttachment> MailAttachments { get; set; }
        public DbSet<UserToken> userTokens { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-8R5OI0I;Initial Catalog=MailDB;Integrated Security=True;");
        //}

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailViewer>()
                .HasOne<UserMail>(mv => mv.UserMail)
                .WithMany(us => us.Viewers)
                .HasForeignKey(mv => mv.MailUniqueID)
                .HasPrincipalKey(us => us.MailUniqueID);

            modelBuilder.Entity<MailAttachment>()
                .HasOne<UserMail>(ma => ma.UserMail)
                .WithMany(us => us.Attachments)
                .HasForeignKey(ma => ma.MailUniqueID)
                .HasPrincipalKey(us => us.MailUniqueID);
        }
    }
}
