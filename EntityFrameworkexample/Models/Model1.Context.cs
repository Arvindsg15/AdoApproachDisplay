﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkexample.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeModelEntities : DbContext
    {
        public EmployeeModelEntities()
            : base("name=EmployeeModelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    
        public virtual ObjectResult<GetInfo_Result> GetInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetInfo_Result>("GetInfo");
        }
    }
}