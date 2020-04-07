using GraphQL.Types;

namespace GraphQLAPI.GraphQL.Types
{
    public class AirportType: ObjectGraphType<Airport>
    {
        public AirportType()
        {
            Field(a => a.AirportID, type: typeof(IdGraphType));
            Field(a => a.Title).Description("The name of the Airport");
            Field(a => a.Lat);
            Field(a => a.Lon);
            Field(a => a.IATACode, nullable:true);
            Field(a => a.ICAOCode, nullable:true);
            Field(a => a.CityID, type: typeof(IdGraphType));
            Field<CityType>("City", "The city the airport is in");
        }
    }
}
