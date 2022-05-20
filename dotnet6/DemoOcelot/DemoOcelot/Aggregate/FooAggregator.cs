using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace DemoOcelot.Aggregate
{
    public class FooAggregator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            throw new NotImplementedException();
        }
    }
}
