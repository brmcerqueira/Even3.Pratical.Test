using System.Web.Optimization;

namespace Even3.Pratical.Test.Presentation
{
    public class AngularTemplateCacheBundle : Bundle
    {
        public AngularTemplateCacheBundle(string moduleName, string virtualPath)
            : base(virtualPath, new[] { new AngularTemplateCacheTransform(moduleName) })
        {
        }
    }
}