using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQLAPI.GraphQL.Types
{
    public class AirportInputType: InputObjectGraphType
    {
        public AirportInputType()
        {
            Name = "airportInput";
            Field<IdGraphType>("airportID");
            Field<NonNullGraphType<IdGraphType>>("cityID");
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<DecimalGraphType>("lat");
            Field<DecimalGraphType>("lon");
            Field<StringGraphType>("iATACode");
            Field<StringGraphType>("iCAOCode");

        }
    }
}
