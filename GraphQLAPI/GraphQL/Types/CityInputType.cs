using GraphQL.Types;

namespace GraphQLAPI.GraphQL.Types
{
    public class CityInputType: InputObjectGraphType
    {
        public CityInputType()
        {
            Name = "cityInput";
            Field<IdGraphType>("cityID");
            Field<NonNullGraphType<StringGraphType>>("title");
        }
    }
}
