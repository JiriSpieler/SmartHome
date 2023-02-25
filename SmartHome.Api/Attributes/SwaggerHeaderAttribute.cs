using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Reflection.Metadata;

namespace SmartHome.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class SwaggerHeaderAttribute : Attribute
    {
        public string Name { get; private set; }
        public bool AllowEmptyValue { get; set; } = true;
        public ParameterLocation ParameterType { get; private set; }
        public string Description { get; private set; }
        public bool Required { get; set; } = false;
        public IOpenApiAny Example { get; set; }

        public SwaggerHeaderAttribute(string headerName, string description, string defaultValue, bool isRequired)
        {
            Name = headerName;
            Description = description;
            Required = isRequired;
        }
    }

    public class SwaggerHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var headerAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<SwaggerHeaderAttribute>();
            foreach (var attribute in headerAttributes)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = attribute.Name,
                    Description = attribute.Description,
                    Required = attribute.Required,
                    AllowEmptyValue = true,
                    In = ParameterLocation.Header,
                    Example = attribute.Example
                });
            }            
        }
    }

}
