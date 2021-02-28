using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Data.Extension
{
    public static class DbContextExtensions
    {
        public static IEnumerable<IMutableEntityType> EntityTypes(this ModelBuilder builder)
        {
            return builder.Model.GetEntityTypes();
        }

        public static IEnumerable<IMutableProperty> Properties(this ModelBuilder builder)
        {
            return builder.EntityTypes().SelectMany(entityType => entityType.GetProperties());
        }

        public static IEnumerable<IMutableProperty> Properties<T>(this ModelBuilder builder)
        {
            return builder.EntityTypes().SelectMany(entityType => entityType.GetProperties().Where(x => x.ClrType == typeof(T)));
        }

        public static void Configure(this IEnumerable<IMutableEntityType> entityTypes, Action<IMutableEntityType> convention)
        {
            foreach (var entityType in entityTypes)
            {
                convention(entityType);
            }
        }

        public static void Configure(this IEnumerable<IMutableProperty> propertyTypes, Action<IMutableProperty> convention)
        {
            foreach (var propertyType in propertyTypes)
            {
                convention(propertyType);
            }
        }

        public static IEnumerable<IMutableProperty> SetColumnTypeProperties<T>(this ModelBuilder builder, string ColumnType)
        {
            var properties = builder.EntityTypes().SelectMany(entityType => entityType.GetProperties().Where(x => x.ClrType == typeof(T)));

            foreach (var property in properties)
                property.SetColumnType(ColumnType);

            return properties;
        }
    }
}
