using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //Field<BooleanGraphType>("IsDeleted");
        }
    }
}
