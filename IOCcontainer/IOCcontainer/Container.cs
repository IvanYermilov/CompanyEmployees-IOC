using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Transactions;

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

        private static T GetInstance<T>()
        {
            var ctor = services[typeof(T)]
                    .GetConstructors()
                    .FirstOrDefault(_ => _.GetParameters().Length == 0);
            return (T)ctor.Invoke(new Object[0]);
        }

        public static T GetInterfaceImplementation<T>()
        {
            if (services.ContainsKey(typeof(T))) return GetInstance<T>();
            return default(T);
        }
    }

}
 