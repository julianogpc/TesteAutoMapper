using TesteAutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using System.Linq;
using System.Web;

namespace TesteAutoMapper.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DBContext:DbContext
    {

        public DBContext()
            :base("name=AutoMapper")
        {
            // disable proxy creation
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(
            DbModelBuilder modelBuilder)
        {
            // Tell Code First to ignore PluralizingTableName convention
            // If you keep this convention then the generated tables will have pluralized names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
    }
}