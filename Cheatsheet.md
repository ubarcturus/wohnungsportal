# Cheatsheet <!-- omit in toc -->

- [1. Database and Migrations](#1-database-and-migrations)
  - [1.1. Migration](#11-migration)
- [2. Anhang](#2-anhang)
  - [2.1. Dateibeispiele](#21-dateibeispiele)

## 1. Database and Migrations

[Contextfile Beispiel](#contextfile-beispiel)

### 1.1. Migration

```powershell
Add-Migration InitialCreate
Update-Database
```

## 2. Anhang

### 2.1. Dateibeispiele

#### Contextfile Beispiel

```csharp
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Copernicus_Weather.Models;

namespace Copernicus_Weather.Data
{
 public class Copernicus_WeatherContext : IdentityDbContext
 {
  public Copernicus_WeatherContext(DbContextOptions<Copernicus_WeatherContext> options)
   : base(options)
  {
   Database.Migrate();
  }

  public DbSet<Apod> Apod { get; set; }
  public DbSet<UserApod> UserApod { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   base.OnModelCreating(modelBuilder);

   //Festlegen, dass die Tabelle einen Eindeutigen Schlüssel aus zwei Spalten hat
   //Erforderlich für pure join tables
   modelBuilder.Entity<UserApod>()
    .HasKey(userApod => new { userApod.IdentityUserId, userApod.ApodId });
  }
 }
}
```
