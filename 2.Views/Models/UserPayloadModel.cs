namespace Todoly.Views.Models;

public record UserPayloadModel
{
    public long? Id { get; set; } = null;
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public double? TimeZone { get; set; } = null;
    public bool? IsProUser { get; set; } = null;
    public long? DefaultProjectId { get; set; } = null;
    public bool? AddItemMoreExpanded { get; set; } = null;
    public bool? EditDueDateMoreExpanded { get; set; } = null;
    public int? ListSortType { get; set; } = null;
    public int? FirstDayOfWeek { get; set; } = null;
    public int? NewTaskDueDate { get; set; } = null;
    public string? TimeZoneId { get; set; } = null;

    public UserPayloadModel(
        string? email,
        string? password,
        string? fullName,
        long? id,
        double? timeZone,
        bool? isProUser,
        long? defaultProjectId,
        bool? addItemMoreExpanded,
        bool? editDueDateMoreExpanded,
        int? listSortType,
        int? firstDayOfWeek,
        int? newTaskDueDate,
        string? timeZoneId
    )
    {
        Id = id;
        Email = email;
        Password = password;
        FullName = fullName;
        TimeZone = timeZone;
        IsProUser = isProUser;
        DefaultProjectId = defaultProjectId;
        AddItemMoreExpanded = addItemMoreExpanded;
        EditDueDateMoreExpanded = editDueDateMoreExpanded;
        ListSortType = listSortType;
        FirstDayOfWeek = firstDayOfWeek;
        NewTaskDueDate = newTaskDueDate;
        TimeZoneId = timeZoneId;
    }
}
