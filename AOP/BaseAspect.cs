using Castle.DynamicProxy;

namespace AOP
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Method |
        AttributeTargets.Assembly,
        AllowMultiple = true, Inherited = true)]
    public abstract class BaseAspect : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
