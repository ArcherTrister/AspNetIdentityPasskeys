// Copyright (c) Duende Software. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using IdentityServerAspNetIdentityPasskeys.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerAspNetIdentityPasskeys.Data;

// public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
// {
//     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//         : base(options)
//     {
//     }
//
//     protected override void OnModelCreating(ModelBuilder builder) =>
//         base.OnModelCreating(
//             builder); // Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);
// }

public class ApplicationDbContext : IdentityDbContext<
    ApplicationUser, IdentityRole, string,
    IdentityUserClaim<string>, IdentityUserRole<string>,
    IdentityUserLogin<string>, IdentityRoleClaim<string>,
    IdentityUserToken<string>, IdentityUserPasskey<string>>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
     {
     }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<IdentityUserPasskey<string>>(b =>
        {
            b.HasKey(p => p.CredentialId);
            b.ToTable("AspNetUserPasskeys");
            b.Property(p => p.CredentialId).HasMaxLength(1024);
            b.OwnsOne(p => p.Data).ToJson();
        });
    }
}
