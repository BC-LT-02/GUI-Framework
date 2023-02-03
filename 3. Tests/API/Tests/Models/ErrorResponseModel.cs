namespace Models;

public record ErrorResponseModel
{
    public string ErrorMessage { get; set; }
    public int ErrorCode { get; set; }

    public ErrorResponseModel(string errorMessage, int errorCode)
    {
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }
}
