using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocator
{
    public class DIContainer : MonoBehaviour
    {
        private static Dictionary<System.Type, object> services = new Dictionary<System.Type, object>();

        public static void Register<T>(T service)
        {
            services[typeof(T)] = service;
        }

        public static T Resolve<T>()
        {
            services.TryGetValue(typeof(T), out var service);
            return (T)service;
        }
    }
}