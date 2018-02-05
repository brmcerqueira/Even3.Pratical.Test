using LightInject;
using System;
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
                Finish(serviceContainer.ScopeManagerProvider.GetScopeManager(serviceContainer).CurrentScope);
                return task.Result;
            });
        }

        private void Finish(Scope scope)
        {
            if (scope.ChildScope != null)
            {
                scope.ChildScope.Completed += (s, e) => scope.Dispose();
                Finish(scope.ChildScope);
            }          
        }
    }
}