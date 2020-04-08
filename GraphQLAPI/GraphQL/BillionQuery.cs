using GraphQL.Types;
using GraphQLAPI.GraphQL.Types;
using GraphQLAPI.Repositories;

namespace GraphQLAPI.GraphQL.Queries
{
    public partial class BillionQuery: ObjectGraphType
    {
        public BillionQuery(CityRepository cityRepository, AirportRepository airportRepository)
        {
            Field<ListGraphType<CityType>>("cityList", description: "Query to get a list of cities", resolve: fieldContext => cityRepository.GetAll());

            Field<ListGraphType<AirportType>>("airportList", description: "Query to get a list of airports", resolve: fieldContext => airportRepository.GetAll());
        }
    }
}
