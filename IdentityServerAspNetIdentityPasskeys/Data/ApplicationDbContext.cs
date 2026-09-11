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
    
        // builder.Entity<IdentityUserPasskey<string>>(b =>
        // {
        //     b.HasKey(p => p.CredentialId);
        //     b.ToTable("AspNetUserPasskeys");
        //     b.Property(p => p.CredentialId).HasMaxLength(1024); // Defined in WebAuthn spec to be no longer than 1023 bytes
        //     b.OwnsOne(p => p.Data).ToJson();
        // });
        // builder.Entity<IdentityUserPasskey<string>>(b =>
        // {
        //     b.HasKey(p => p.CredentialId);
        //     b.ToTable("AspNetUserPasskeys");
        //     b.Property(p => p.CredentialId).HasMaxLength(1024);
        //     // Unable to create a 'DbContext' of type 'ApplicationDbContext'.
        //     // The exception 'The property or navigation 'Data' cannot be added to the 'IdentityUserPasskey<string>' type because a property or navigation with the same name already exists on the 'IdentityUserPasskey<string>' type.' was thrown while attempting to create an instance.
        //     // For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728   
        //     b.ComplexProperty(p => p.Data).ToJson();
        // });
        
        // // 配置 IdentityUserPasskey
        // var passkey = builder.Entity<IdentityUserPasskey<string>>();
        //
        // // 先移除已存在的 Data 属性（如果存在）
        // if (passkey.Metadata.FindProperty(nameof(IdentityUserPasskey<string>.Data)) != null)
        // {
        //     passkey.Ignore(nameof(IdentityUserPasskey<string>.Data));
        // }
        //
        // // 然后再添加为 ComplexProperty
        // passkey.ComplexProperty(p => p.Data).ToJson();
    }
}
