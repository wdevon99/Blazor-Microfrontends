using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microfrontend.two;

namespace Microfrontend.two
{
    public class Module : IMfModule
    {
        public Module(IConfiguration configuration)
        {
            // Inject here what you want, e.g., the global `IConfiguration`.
        }

        public void Configure(IServiceCollection services)
        {
            // Configure your services in this function
            services.AddHttpClient();
        }

        public Task Setup(IMfAppService app)
        {
            // Register components and more
            app.MapComponent<ContainerComponent>("microfrontend.two");
            return Task.CompletedTask;
        }

        public Task Teardown(IMfAppService app)
        {
            // Unregister things that need to be cleaned up
            return Task.CompletedTask;
        }
    }
}
