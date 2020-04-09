using System;
using GraphQL;
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

            Field<CityType>()
                .Name("city")
                .Argument<NonNullGraphType<IdGraphType>>("cityID", "The ID of the city to fetch")
                .Resolve(context =>
                {
                    var cityId = context.GetArgument<Guid>("cityID");
                    return cityRepository.GetOne(cityId);
                });

            Field<ListGraphType<AirportType>>("airportList", description: "Query to get a list of airports", resolve: fieldContext => airportRepository.GetAll());

        Field<AirportType>()
            .Name("airport")
            .Argument<NonNullGraphType<IdGraphType>>("airportID", "The ID of the airport to fetch")
            .Resolve(context =>
            {
                var airportId = context.GetArgument<Guid>("airportID");
                return airportRepository.GetOne(airportId);
            });

        }
    }
}
