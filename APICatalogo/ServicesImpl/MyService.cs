using APICatalogo.Services;

namespace APICatalogo.ServicesImpl
{
    public class MyService : IMyService
    {
        async Task<string> IMyService.Introducing(string name)
        {
            return $"Olá, meu nome é {name}";
        }
    }
}
