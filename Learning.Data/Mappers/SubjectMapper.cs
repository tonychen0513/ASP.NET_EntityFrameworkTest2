using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Learning.Data.Entities;

namespace Learning.Data.Mappers
{
    class SubjectMapper : EntityTypeConfiguration<Subject>
    {
        public SubjectMapper()
        {
            this.ToTable("Subjects");

            this.HasKey(s => s.Id);
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.Id).IsRequired();

            this.Property(s => s.Name).IsRequired();
            this.Property(s => s.Name).HasMaxLength(255);
        }
    }
}
