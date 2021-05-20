using System;

namespace IOCcontainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Container.Add<IAsyncDisposable, MyClass>();
            var registeredServices = Container.GetServices();
        }
    }
}
