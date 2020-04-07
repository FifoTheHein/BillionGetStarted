using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarvedRock.Api.Repositories;
using GraphQL.Types;
using GraphQLAPI.GraphQL.Types;

namespace GraphQLAPI.GraphQL.Queries
{
    public partial class BillionQuery: ObjectGraphType
    {
        public BillionQuery(CityRepository cityRepository, AirportRepository airportRepository)
        {
            Field<ListGraphType<CityType>>("cities", description: "Query to get a list of cities", resolve: fieldContext => cityRepository.GetAll());

            Field<ListGraphType<AirportType>>("airports", description: "Query to get a list of airports", resolve: fieldContext => airportRepository.GetAll());
        }
    }
}
