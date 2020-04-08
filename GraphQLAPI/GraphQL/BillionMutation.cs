﻿using System;
using GraphQL;
using GraphQL.Types;
using GraphQLAPI.GraphQL.Types;
using GraphQLAPI.Repositories;

namespace GraphQLAPI.GraphQL
{
    public class BillionMutation: ObjectGraphType
    {
        public BillionMutation(AirportRepository airportRepository, CityRepository cityRepository)
        {
            FieldAsync<CityType>(
                "mutateCity",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CityInputType>> {Name = "city"}), 
               
                resolve: async context =>
                {
                    var city = context.GetArgument<City>("city");
                    City result;

                    if(city.CityID == Guid.Empty)
                        result = await cityRepository.AddCity(city);
                    else
                        result = await cityRepository.UpdateCity(city);

                    if(result == null)
                        context.Errors.Add(new ExecutionError($"Could not find city with specified cityID '{city.CityID}'. Nothing updated / added."));

                    return city;
                });

            FieldAsync<AirportType>(
                "mutateAirport",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AirportInputType>> {Name = "airport"}), 
               
                resolve: async context =>
                {
                    var airport = context.GetArgument<Airport>("airport");

                    Airport result;

                    if(airport.AirportID == Guid.Empty)
                        result = await airportRepository.AddAirport(airport);
                    else
                        result = await airportRepository.UpdateAirport(airport);

                    if(result == null)
                        context.Errors.Add(new ExecutionError($"Could not find airport with specified airportID '{airport.AirportID}'. Nothing updated / added."));

                    return airport;
                });
            
        }
    }
}
