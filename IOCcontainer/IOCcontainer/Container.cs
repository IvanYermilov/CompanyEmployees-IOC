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

        public static void Add<TA, TI>()
        {
            Type abstractionType = typeof(TA);
            Type implementationType = typeof(TI);
            services.Add(abstractionType, implementationType);
        }

        private static T GetInstance<T>()
        {
            List<object> parameters = new List<object>();
            ConstructorInfo classCtor;
            if (services.ContainsKey(typeof(T)))
            {
                classCtor = services[typeof(T)]
                    .GetConstructors()
                    .FirstOrDefault();
            }
            else
            {
                classCtor = typeof(T)
                    .GetConstructors()
                    .FirstOrDefault();
            }
            var ctorParams = classCtor.GetParameters();

            foreach (var param in ctorParams)
            {
                if (!services.ContainsKey(param.ParameterType)) return default;
                var parameterType = services[param.ParameterType];
                var containerType = typeof(Container);
                var methodInfo = containerType.GetMethod("GetInstance", BindingFlags.Static | BindingFlags.NonPublic);
                MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(parameterType);
                parameters.Add(genericMethodInfo.Invoke(null, null));
            }

            return (T) classCtor.Invoke(parameters.ToArray());
        }

        public static T GetImplementation<T>()
        {
            if (services.ContainsKey(typeof(T))) return GetInstance<T>();
            return default(T);
        }
    }
}
 