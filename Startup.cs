using Microsoft.Extensions.DependencyInjection;
using SpecFlowWithSelenium.Helpers;
using SpecFlowWithSelenium.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowWithSelenium
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions()
                .AddScoped<IMethodsCollection, MethodsCollection>()
                .AddScoped<ILoginPage, LoginPage>();
                
        }
    }
}
