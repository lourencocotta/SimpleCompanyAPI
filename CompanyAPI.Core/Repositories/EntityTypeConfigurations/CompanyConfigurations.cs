using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyAPI.Core.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyAPI.Core.Repositories.EntityTypeConfigurations
{
    public class CompanyConfigurations : EntityTypeConfiguration<Company>
    {
        public CompanyConfigurations()
        {
            Property(x => x.Name)
                .HasColumnName("Name").IsRequired();
            Property(x => x.Exchange)
                .HasColumnName("Exchange").IsRequired();
            Property(x => x.Ticker)
                .HasColumnName("Ticker").IsRequired();
            Property(x => x.Isin)
                .HasColumnName("Isin").IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_ISIN", 1) { IsUnique = true })); ;
            Property(x => x.WebSite)
                .HasColumnName("WebSite");

        }
    }
}
