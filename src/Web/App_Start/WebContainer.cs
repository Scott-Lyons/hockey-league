using System.Linq;
using System.Reflection;
using DataAccess;
using SimpleInjector;
using SimpleInjector.Integration.Web;

namespace Web
{
    public class WebContainer : Container
    {
        public WebContainer()
        {
            Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            BatchRegistration();
          
            this.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            Verify();
        }

        private void BatchRegistration()
        {
            var repositoryAssembly = typeof(HockeyLeagueContext).Assembly;

            var registrations =
                repositoryAssembly.GetExportedTypes()
                    .Where(type => type.GetInterfaces().Any())
                    .Select(
                        type =>
                            new
                            {
                                Service = type.GetInterfaces().Single(i => i.Name == "I" + type.Name),
                                Implementation = type
                            });

            foreach (var reg in registrations)
            {
                Register(reg.Service, reg.Implementation, Lifestyle.Scoped);
            }
        }
    }
}