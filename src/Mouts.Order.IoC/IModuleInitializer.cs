using Microsoft.AspNetCore.Builder;

namespace MoutsOrder.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
