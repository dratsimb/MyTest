

namespace Safran.Client
{
    public class NotFoundException(string message): Exception(message)
    {
    }
}