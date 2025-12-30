using System.Net;

namespace BookstoreManagement.Exceptions;

public abstract class BookstoreManagementException : SystemException
{
    public BookstoreManagementException(string errorMessage) : base(errorMessage)
    {
    }

    public abstract List<string> GetErrors();
    public abstract HttpStatusCode GetHttpStatusCode();
}
