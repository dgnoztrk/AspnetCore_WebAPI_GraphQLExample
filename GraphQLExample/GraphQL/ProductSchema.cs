using GraphQL;
using GraphQL.Types;

namespace GraphQLExample.GraphQL
{
    public class ProductSchema : Schema
    {
        public ProductSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProductQuery>();
        }
    }
}