namespace Demo.gRPCaggregate.Client.Discovery.Model
{
    public class ServiceDiscoveryOptions
    {
        public string ServiceName { get; set; }
        public string ServiceIP { get; set; }
        public int ServicePort { get; set; }
        public string ServiceHealthCheck { get; set; }
        public string ConsulAddress { get; set; }
    }
}
