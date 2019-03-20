namespace Checkout.Data.Services.Interceptors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Castle.DynamicProxy;

    public class MerchantInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            string interfaceShortName = invocation.Method.DeclaringType.Name;
            string interfaceFullname = invocation.Method.DeclaringType.FullName;
            string methodName = invocation.Method.Name;
            
            List<ParameterInfo> parameterInfo = new List<ParameterInfo>(invocation.GetConcreteMethod().GetParameters());
            System.Diagnostics.Trace.WriteLine($"{interfaceFullname}.{methodName}, Method arguments: " + string.Join(", ", parameterInfo.Select(a => a.Name)));

            ParameterInfo item = parameterInfo.FirstOrDefault(a => a.Name == "merchantId");
            if (item != null)
            {
                int argumentPositionByName = parameterInfo.IndexOf(item);

                int merchantId = Convert.ToInt32(invocation.Arguments[argumentPositionByName]);
                int targetMerchantId = 3;
                
                // translate original id to another id
                invocation.Arguments[argumentPositionByName] = targetMerchantId;

                System.Diagnostics.Trace.WriteLine($"translated {merchantId} to {targetMerchantId}");
            }
            
            invocation.Proceed(); //Intercepted method is executed here.
        }
    }
}
