using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI.Repositories;

namespace GraphQLAPI.GraphQL.Types
{
    public class CountryType: ObjectGraphType<Country>
    {
        public CountryType() 
        {
            Field(c => c.CountryID, type: typeof(IdGraphType)).Description("The Unique Identifier Guid of the Country");
            Field(c => c.Title).Description("The name of the Country");
            Field<ListGraphType<CityType>>()
                .Name("cities")
                .Resolve(ctx => ctx.Source.Cities);
        }
    }
}
