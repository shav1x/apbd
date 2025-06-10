using Microsoft.EntityFrameworkCore;
using tut11.Core.Data;

namespace tut11.Core.Database;

public class AppDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<ActorMovie> ActorMovies { get; set; }
    public DbSet<AgeRating> AgeRatings { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActorMovie>()
            .HasKey(x => new { x.IdMovie, x.IdActor });
        
        modelBuilder.Entity<Actor>()
            .HasKey(x => x.IdActor);
        
        modelBuilder.Entity<Movie>()
            .HasKey(x => x.IdMovie);
        
        modelBuilder.Entity<AgeRating>()
            .HasKey(x => x.IdAgeRating);
        
        modelBuilder.Entity<ActorMovie>()
            .HasOne(x => x.Actor)
            .WithMany(x => x.ActorMovies)
            .HasForeignKey(x => x.IdActor);
        
        modelBuilder.Entity<ActorMovie>()
            .HasOne(x => x.Movie)
            .WithMany(x => x.ActorMovies)
            .HasForeignKey(x => x.IdMovie);

        modelBuilder.Entity<Actor>()
            .Property(x => x.Name)
            .HasMaxLength(30);
        
        modelBuilder.Entity<Actor>()
            .Property(x => x.Surname)
            .HasMaxLength(30);
        
        modelBuilder.Entity<Actor>()
            .Property(x => x.Nickname)
            .HasMaxLength(30);
        
        modelBuilder.Entity<ActorMovie>()
            .Property(x => x.CharacterName)
            .HasMaxLength(50);
        
        modelBuilder.Entity<AgeRating>()
            .Property(x => x.Name)
            .HasMaxLength(30);
        
        modelBuilder.Entity<Movie>()
            .Property(x => x.Name)
            .HasMaxLength(30);
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<AgeRating>().HasData(
            new AgeRating { IdAgeRating = 1, Name = "G" },
            new AgeRating { IdAgeRating = 2, Name = "PG" },
            new AgeRating { IdAgeRating = 3, Name = "PG-13" },
            new AgeRating { IdAgeRating = 4, Name = "R" }
        );
        
        modelBuilder.Entity<Movie>().HasData(
            new Movie { IdMovie = 1, AgeRatingId = 1, Name = "Toy Story", ReleaseDate = new DateTime(1995, 11, 22) },
            new Movie { IdMovie = 2, AgeRatingId = 3, Name = "The Avengers", ReleaseDate = new DateTime(2012, 5, 4) }
        );
        
        modelBuilder.Entity<Actor>().HasData(
            new Actor { IdActor = 1, Name = "Tom", Surname = "Hanks", Nickname = "Tommy" },
            new Actor { IdActor = 2, Name = "Robert", Surname = "Downey Jr.", Nickname = "RDJ" }
        );
        
        modelBuilder.Entity<ActorMovie>().HasData(
            new ActorMovie { IdActor = 1, IdMovie = 1, CharacterName = "Woody" },
            new ActorMovie { IdActor = 2, IdMovie = 2, CharacterName = "Tony Stark" }
        );

    }
    
}
