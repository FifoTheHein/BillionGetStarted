using System;
using CarvedRock.Api.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphQLAPI.GraphQL.Types
{
    public class CityType: ObjectGraphType<City>
    {
        public CityType(AirportRepository airportRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(c => c.CityID, type: typeof(IdGraphType)).Description("The Unique Identifier Guid of the City");
            Field(c => c.Title).Description("The name of the City");
            Field<ListGraphType<AirportType>>()
                .Name("airports")
                .Resolve(ctx => ctx.Source.Airports);
            //("airports",
            //resolve: context =>
            //{
            //    var loader =
            //        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<Guid, Airport>(
            //            "GetAirportsByCityId", airportRepository.GetForCities);
            //    return loader.LoadAsync(context.Source.CityID);
            //});
        }
    }
}
