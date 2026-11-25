using WitcherWorld.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Data;

public class WitcherWorldDbContext : DbContext
{
    public WitcherWorldDbContext(
        DbContextOptions<WitcherWorldDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<PasswordResetToken> PasswordResetTokens =>
        Set<PasswordResetToken>();

    public DbSet<Character> Characters => Set<Character>();

    public DbSet<Monster> Monsters => Set<Monster>();

    public DbSet<Weakness> Weaknesses => Set<Weakness>();

    public DbSet<MonsterWeakness> MonsterWeaknesses =>
        Set<MonsterWeakness>();

    public DbSet<Weapon> Weapons => Set<Weapon>();

    public DbSet<Armor> Armors => Set<Armor>();

    public DbSet<Quest> Quests => Set<Quest>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Favorite> Favorites => Set<Favorite>();

    public DbSet<Review> Reviews => Set<Review>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(WitcherWorldDbContext).Assembly);
    }

}
