using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;

namespace TOTD.EntityFramework
{
    public static class ConfigurationExtensions
    {
        public static PrimitivePropertyConfiguration HasIndex(this PrimitivePropertyConfiguration configuration)
        {
            return configuration.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));
        }

        public static PrimitivePropertyConfiguration HasIndex(this PrimitivePropertyConfiguration configuration, string name)
        {
            return configuration.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name)));
        }

        public static PrimitivePropertyConfiguration HasIndex(this PrimitivePropertyConfiguration configuration, string name, int order)
        {
            return configuration.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name, order)));
        }

        public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration configuration)
        {
            return configuration.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()
            {
                IsUnique = true
            }));
        }

        public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration configuration, string name)
        {
            return configuration.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name)
            {
                IsUnique = true
            }));
        }

        public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration configuration, string name, int order)
        {
            return configuration.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(name, order)
            {
                IsUnique = true
            }));
        }

        public static PrimitivePropertyConfiguration IsIdentity(this PrimitivePropertyConfiguration configuration)
        {
            return configuration.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
