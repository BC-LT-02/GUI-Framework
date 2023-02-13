namespace Todoly.Views.Models;

public record ErrorModel
{
    public string ErrorMessage { get; set; }
    public int ErrorCode { get; set; }

    public ErrorModel(string errorMessage, int errorCode)
    {
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }
}
