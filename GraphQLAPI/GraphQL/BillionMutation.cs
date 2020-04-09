using GraphQL.Types;
using GraphQLAPI.GraphQL.Types;
using GraphQLAPI.Repositories;

namespace GraphQLAPI.GraphQL
{
    public partial class BillionMutation : ObjectGraphType
    {
        public BillionMutation(AirportRepository airportRepository, CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _airportRepository = airportRepository;

            FieldAsync<CityType>(
                name: "city",
                description: "Add or edit an exiting city entry",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CityInputType>>
                    {
                        Name = "city",
                        Description = "Set the cityID on the input object to edit, leave it blank or set to an empty Guid to add."
                    }),
                resolve: City);

            FieldAsync<CityType>(
                name: "deleteCity",
                description: "Delete a city",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "cityID",
                        Description = "The ID of the city to delete"
                    }),
                resolve: DeleteCity
                );

            FieldAsync<AirportType>(
                name: "airport",
                description: "Add or edit an exiting airport entry",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AirportInputType>>
                    {
                        Name = "airport",
                        Description = "Set the airportID on the input object to edit, leave it blank or set to an empty Guid to add."
                    }),
                resolve: Airport);

            FieldAsync<AirportType>(
                name: "deleteAirport",
                description: "Delete an airport",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "airportID",
                        Description = "The ID of the airport to delete"
                    }),
                resolve: DeleteAirport);
        }
    }
}
