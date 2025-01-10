using Microsoft.EntityFrameworkCore;

namespace ITB2203Application.Model;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Test>? Tests { get; set; }

	public DbSet<Test>? Attendees { get; set; }

	public DbSet<Test>? Events { get; set; }

	public DbSet<Test>? Speakers { get; set; }



}
