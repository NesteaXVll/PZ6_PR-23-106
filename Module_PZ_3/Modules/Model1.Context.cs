﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Module_PZ_3.Modules
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Real_Estate_AgencyEntities : DbContext
    {
        public Real_Estate_AgencyEntities()
            : base("name=Real_Estate_AgencyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Deals> Deals { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Inspections> Inspections { get; set; }
        public virtual DbSet<Object_type> Object_type { get; set; }
        public virtual DbSet<Objects> Objects { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Types_of_clients> Types_of_clients { get; set; }
    }
}
