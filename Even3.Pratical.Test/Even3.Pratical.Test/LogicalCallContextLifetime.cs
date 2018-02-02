using Even3.Pratical.Test.Properties;
using LightInject;
using System;
using System.Runtime.Remoting.Messaging;

namespace Even3.Pratical.Test
{
    internal sealed class LogicalCallContextLifetime : ILifetime
    {
        private readonly string key;

        public LogicalCallContextLifetime(string key)
        {
            this.key = key;
        }

        public object GetInstance(Func<object> instanceFactory, Scope currentScope)
        {
            var result = CallContext.LogicalGetData(key);

            if (result == null)
            {
                var instance = instanceFactory();
                var disposable = instance as IDisposable;
                if (disposable != null)
                {
                    if (currentScope == null)
                    {
                        throw new InvalidOperationException(Resource.LogicalCallContextLifetimeException);
                    }
                    currentScope.TrackInstance(disposable);
                }

                result = instance;
                CallContext.LogicalSetData(key, instance);
            }
            return result;
        }
    }
}