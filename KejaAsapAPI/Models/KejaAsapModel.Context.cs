﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KejaAsapAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KejaAsapEntities : DbContext
    {
        public KejaAsapEntities()
            : base("name=KejaAsapEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Amenity> Amenities { get; set; }
        public virtual DbSet<BuildingPicture> BuildingPictures { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<HouseOwner> HouseOwners { get; set; }
        public virtual DbSet<HouseOwnerType> HouseOwnerTypes { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<HousePicture> HousePictures { get; set; }
    }
}