using LightInject;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Even3.Pratical.Test.Presentation
{
    public class RequestDelegatingHandler : DelegatingHandler
    {
        private readonly ServiceContainer serviceContainer;

        public RequestDelegatingHandler(ServiceContainer serviceContainer)
        {
            this.serviceContainer = serviceContainer;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            serviceContainer.BeginScope();

            return await base.SendAsync(request, cancellationToken).ContinueWith((task) =>
            {
                serviceContainer.ScopeManagerProvider.GetScopeManager(serviceContainer).CurrentScope.Dispose();
                return task.Result;
            });
        }
    }
}