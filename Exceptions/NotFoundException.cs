using System.Net;

namespace BookstoreManagement.Exceptions;

public class NotFoundException : BookstoreManagementException
{
    public NotFoundException(string errorMessages) : base(errorMessages)
    {
    }

    public override List<string> GetErrors() => [Message];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}
