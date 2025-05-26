namespace Project.WebAPI.Models.MappingService
{
    public static class RequestResponseMapperResolver
    {
        public static void AddRequestResponseMapperService(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ResponseAndRequstMapping));
        }
    }
}
