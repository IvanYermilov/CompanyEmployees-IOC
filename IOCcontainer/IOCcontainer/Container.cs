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
            if (interfaceType.IsInterface) services.Add(interfaceType, classType);
            else if (interfaceType.IsClass)
            {
                if (CheckClass(interfaceType)) services.Add(interfaceType, classType);
                else throw new Exception("First parameter is class and has unregistered interface");
            }
            else throw new Exception("First parameter is not class or interface");
        }

        public static Dictionary<Type, Type> GetServices()
        {
            return services;
        }

        private static T GetInstance<T>()
        {
            if (typeof(T).IsInterface)
            {
                var interfaceCtor = services[typeof(T)]
                    .GetConstructors()
                    .FirstOrDefault(_ => _.GetParameters().Length == 0);
                return (T) interfaceCtor.Invoke(new Object[0]);
            }

            var classCtor = services[typeof(T)]
                .GetConstructors()
                .FirstOrDefault(_ => _.GetParameters().Length == 1);
            var parameterType = classCtor.GetParameters().First().ParameterType;

            var containerType = typeof(Container);
            var methodInfo = containerType.GetMethod("GetInstance", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(parameterType);
            var interfaceInstance = genericMethodInfo.Invoke(null, null);
            return (T) classCtor.Invoke(new object[] {interfaceInstance});
        }

        public static T GetImplementation<T>()
        {
            if (services.ContainsKey(typeof(T))) return GetInstance<T>();
            return default(T);
        }

        private static bool CheckClass(Type classType)
        {
            var ctor = classType
                .GetConstructors()
                .FirstOrDefault(_ => _.GetParameters().Length == 1 &&
                                     services.ContainsKey(_.GetParameters().First().ParameterType));
            return ctor != null;
        }
    }

}
 