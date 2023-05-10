using GraphQL;
using GraphQL.Types;
using GraphQLExample.Data;
using GraphQLExample.Data.Entity;
using Newtonsoft.Json.Linq;

namespace GraphQLExample.GraphQL
{
    public class GraphqlQueryParameter
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }

    }

    public class ProductQuery : ObjectGraphType<object>
    {
        public ProductQuery(DB _db)
        {
            Name = "Product_Query";

            //TODO: Graphql endpointlerini belirliyoruz.
            Field<ListGraphType<ProductType>>("Products", resolve: ctx => _db.Products.ToList());
            Field<ListGraphType<ProductType>>("ProductByBrandId",
                arguments: new QueryArguments
                {
                 new QueryArgument<IntGraphType>{
                     Name="Id",
                     Description="Brand Id"
                 }
                },
             resolve: ctx => _db.Products.FirstOrDefault(a => a.BrandId == ctx.GetArgument<int>("Id", 0)));
            Field<ListGraphType<BrandType>>("Brands", resolve: ctx => _db.Brands.ToList());
        }
    }

    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "Product";
            Field(p => p.Id);
            Field(p => p.Title);
            Field(p => p.Price);
            Field<BrandType>("Brand", resolve: _ => _.Source.Brand);
        }
    }

    public class BrandType : ObjectGraphType<Brand>
    {
        public BrandType()
        {
            Name = "Brand";
            Field(p => p.Id);
            Field(p => p.Name);
        }
    }
}