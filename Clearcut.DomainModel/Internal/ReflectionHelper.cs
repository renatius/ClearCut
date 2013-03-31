using System;
using System.Reflection;
using Clearcut.DomainModel.Properties;

namespace Clearcut.DomainModel.Internal
{
    internal class ReflectionHelper
    {
        public static bool PropertyExists(Type type, string targetProperty)
        {
            Precondition.Requires(
                type != null, 
                Resources.TYPE_CANNOT_BE_NULL
                );

            Precondition.Requires(
                targetProperty != null, 
                Resources.TARGET_PROPERTY_CANNOT_BE_NULL)
                ;

            var pi = type.GetProperty(
                targetProperty,
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.FlattenHierarchy
            );
            return pi != null;
        }
    }
}
