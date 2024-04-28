using Microsoft.EntityFrameworkCore;

namespace XSISDataAccess.Models;

public partial class XsisbackEndContext : DbContext
{
    public XsisbackEndContext()
    {
    }

    public XsisbackEndContext(DbContextOptions<XsisbackEndContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movie_pkey");

            entity.ToTable("movie");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Images)
                .HasMaxLength(2000)
                .HasColumnName("images");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
