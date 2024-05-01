using System.ComponentModel;

namespace XSISDataAccess.Utils
{
    public static class CommonHelper
    {
        public static IEnumerable<string> GetColumns<T>()
        {
            return TypeDescriptor.GetProperties(typeof(T))
                .Cast<PropertyDescriptor>()
                .Where(propertyInfo =>
                    propertyInfo.PropertyType.Namespace != null &&
                    propertyInfo.PropertyType.Namespace.Equals("System"))
                .ToArray().Select(p => p.Name);
        }
    }
}
