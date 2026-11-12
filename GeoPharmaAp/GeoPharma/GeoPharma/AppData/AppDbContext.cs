using GeoPharma.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoPharma.AppData;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {}

    public DbSet<Pharmacy> Pharmacies { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    ConfigureAddress(modelBuilder.Entity<Doctor>());
    //    ConfigureAddress(modelBuilder.Entity<Pharmacy>());
    //}
    //private void ConfigureAddress<T>(EntityTypeBuilder<T> builder) where T : class
    //{
    //    builder.OwnsOne("Address", "Address", a =>
    //    {
    //        a.Property("PhoneNumber1").HasColumnName("PhoneNumber1");
    //        a.Property("PhoneNumber2").HasColumnName("PhoneNumber2");
    //        a.Property("Email").HasColumnName("Email");
    //        a.Property("District").HasColumnName("District");
    //        a.Property("Street").HasColumnName("Street");
    //        a.Property("ZipCode").HasColumnName("ZipCode");
    //        a.Property("WebSiteUrl").HasColumnName("WebSiteUrl");
    //        a.Property("YoutubeUrl").HasColumnName("YoutubeUrl");
    //        a.Property("XUrl").HasColumnName("XUrl");
    //        a.Property("FacebookUrl").HasColumnName("FacebookUrl");
    //        a.Property("LinkedInUrl").HasColumnName("LinkedInUrl");
    //        a.Property("InstagramUrl").HasColumnName("InstagramUrl");
    //    });
    //}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pharmacy>().OwnsOne(p => p.Address);
        modelBuilder.Entity<Doctor>().OwnsOne(d => d.Address);
        modelBuilder.Entity<Doctor>(builder =>
        {
            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(ad => ad.PhoneNumber1).HasColumnName("PhoneNumber1");
                a.Property(ad => ad.PhoneNumber2).HasColumnName("PhoneNumber2");
                a.Property(ad => ad.Email).HasColumnName("Email");
                a.Property(ad => ad.District).HasColumnName("District");
                a.Property(ad => ad.Street).HasColumnName("Street");
                a.Property(ad => ad.ZipCode).HasColumnName("ZipCode");
                a.Property(ad => ad.WebSiteUrl).HasColumnName("WebSiteUrl");
                a.Property(ad => ad.YoutubeUrl).HasColumnName("YoutubeUrl");
                a.Property(ad => ad.XUrl).HasColumnName("XUrl");
                a.Property(ad => ad.FacebookUrl).HasColumnName("FacebookUrl");
                a.Property(ad => ad.LinkedInUrl).HasColumnName("LinkedInUrl");
                a.Property(ad => ad.InstagramUrl).HasColumnName("InstagramUrl");
            });
        });
        modelBuilder.Entity<Pharmacy>(builder =>
        {
            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(ad => ad.PhoneNumber1).HasColumnName("PhoneNumber1");
                a.Property(ad => ad.PhoneNumber2).HasColumnName("PhoneNumber2");
                a.Property(ad => ad.Email).HasColumnName("Email");
                a.Property(ad => ad.District).HasColumnName("District");
                a.Property(ad => ad.Street).HasColumnName("Street");
                a.Property(ad => ad.ZipCode).HasColumnName("ZipCode");
                a.Property(ad => ad.WebSiteUrl).HasColumnName("WebSiteUrl");
                a.Property(ad => ad.YoutubeUrl).HasColumnName("YoutubeUrl");
                a.Property(ad => ad.XUrl).HasColumnName("XUrl");
                a.Property(ad => ad.FacebookUrl).HasColumnName("FacebookUrl");
                a.Property(ad => ad.LinkedInUrl).HasColumnName("LinkedInUrl");
                a.Property(ad => ad.InstagramUrl).HasColumnName("InstagramUrl");
            });
        });
    }
}
