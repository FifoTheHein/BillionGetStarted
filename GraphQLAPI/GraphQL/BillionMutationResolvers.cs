using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLAPI.Repositories;

namespace GraphQLAPI.GraphQL
{
    public partial class BillionMutation
    {
        private readonly AirportRepository _airportRepository;
        private readonly CityRepository _cityRepository;

        private async Task<object> City(ResolveFieldContext<object> context)
        {
            var city = context.GetArgument<City>("city");
            City result;

            if (city.CityID == Guid.Empty)
                result = await _cityRepository.AddCity(city);
            else
                result = await _cityRepository.UpdateCity(city);

            if (result == null) context.Errors.Add(new ExecutionError($"Could not find city with specified cityID '{city.CityID}'. Nothing updated / added."));

            return city;
        }

        private async Task<object> DeleteCity(ResolveFieldContext<object> context)
        {
            var cityId = context.GetArgument<Guid>("cityID");
            var city = await _cityRepository.Delete(cityId);

            if (city == null)
            {
                context.Errors.Add(new ExecutionError("Couldn't find city to delete"));
            }

            return city;
        }

        private async Task<object> Airport(ResolveFieldContext<object> context)
        {
            var airport = context.GetArgument<Airport>("airport");

            Airport result;

            if (airport.AirportID == Guid.Empty)
                result = await _airportRepository.AddAirport(airport);
            else
                result = await _airportRepository.UpdateAirport(airport);

            if (result == null) context.Errors.Add(new ExecutionError($"Could not find airport with specified airportID '{airport.AirportID}'. Nothing updated / added."));

            return airport;
        }

        private async Task<object> DeleteAirport(ResolveFieldContext<object> context)
        {
            var airportId = context.GetArgument<Guid>("airportID");
            var airport = await _airportRepository.Delete(airportId);

            if (airport == null)
            {
                context.Errors.Add(new ExecutionError("Couldn't find airport to delete"));
            }

            return airport;
        }


    }
}
