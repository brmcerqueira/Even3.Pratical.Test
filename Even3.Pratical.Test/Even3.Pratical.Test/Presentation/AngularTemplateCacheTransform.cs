using System.IO;
using System.Text;
using System.Web.Optimization;

namespace Even3.Pratical.Test.Presentation
{
    public class AngularTemplateCacheTransform : IBundleTransform
    {
        public string ModuleName { get; }

        public AngularTemplateCacheTransform(string moduleName)
        {
            ModuleName = moduleName;
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat(
                @"angular.module('{0}').run(['$templateCache',function(t){{",
                ModuleName);

            foreach (var file in response.Files)
            {
                using (var reader = new StreamReader(file.VirtualFile.Open(), Encoding.UTF8))
                {
                    stringBuilder.AppendFormat(@"t.put('views/{0}','{1}');", 
                        file.VirtualFile.Name, 
                        reader.ReadToEnd().Replace("\r\n", "").Replace("'", "\\'"));
                }
            }

            stringBuilder.Append(@"}]);");

            response.Files = new BundleFile[] { };
            response.Content = stringBuilder.ToString();
            response.ContentType = "text/javascript";
        }
    }
}