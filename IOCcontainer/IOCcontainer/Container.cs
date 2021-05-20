using System;
using System.Collections.Generic;
using System.Text;

namespace IOCcontainer
{
    static class Container
    {
        static public Dictionary<Type, Type> services = new Dictionary<Type, Type>();

        public static void Add<TI, TC>()
        {
            Type interfaceType = typeof(TI);
            Type classType = typeof(TC);
            services.Add(interfaceType, classType);
        }

        public static Dictionary<Type, Type> GetServices()
        {
            return services;
        }

        private static T GetInstance<T>(Type classType)
        {
            var a = classType.GetConstructors();
            T b = default; 
            return b;
        }
    }

}
 