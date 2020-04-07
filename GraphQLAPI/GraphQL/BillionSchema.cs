using GraphQL;
using GraphQL.Types;
using GraphQLAPI.GraphQL.Queries;

namespace GraphQLAPI.GraphQL
{
    public class BillionSchema : Schema
    {
        public BillionSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<BillionQuery>();
            Mutation = resolver.Resolve<BillionMutation>();
        }
    }
}
