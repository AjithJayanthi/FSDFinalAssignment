﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManager.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectManagerEntities : DbContext
    {
        public ProjectManagerEntities()
            : base("name=ProjectManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Parent_Task_Table> Parent_Task_Table { get; set; }
        public virtual DbSet<Project_Table> Project_Table { get; set; }
        public virtual DbSet<Task_Table> Task_Table { get; set; }
        public virtual DbSet<Users_Table> Users_Table { get; set; }
    }
}
