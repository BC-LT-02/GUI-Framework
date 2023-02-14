namespace Todoly.Views.Models;
using System.Collections.Generic;
public record ItemModel
{
    public int? Id { get; set; }
    public string Content { get; set; }
    public int? ItemType { get; set; }
    public bool? Checked { get; set; }
    public int? ProjectId { get; set; }
    public int? ParentId { get; set; }
    public string Path { get; set; }
    public bool? Collapsed { get; set; }
    public string? DateString { get; set; }
    public int? DateStringPriority { get; set; }
    public string? DueDate { get; set; }
    public RecurrenceObject? Recurrence { get; set; }
    public int? ItemOrder { get; set; }
    public int? Priority { get; set; }
    public string? LastSyncedDateTime { get; set; }
    public List<ItemModel>? Children { get; set; }
    public string? CreatedDate { get; set; }
    public string? LastCheckedDate { get; set; }
    public string? LastUpdatedDate { get; set; }
    public bool? Deleted { get; set; }
    public string? Notes { get; set; }
    public bool? InHistory { get; set; }
    public int? SyncClientCreationId { get; set; }
    public bool? DueTimeSpecified { get; set; }
    public int? OwnerId { get; set; }

    public ItemModel(
    string content,
    int? id = 0,
    int? itemType = 1,
    bool? @checked = false,
    int? projectId = null,
    int? parentId = null,
    string path = "",
    bool? collapsed = false,
    string? dateString = null,
    int? dateStringPriority = 0,
    string? dueDate = "",
    RecurrenceObject? recurrence = null,
    int? itemOrder = 1,
    int? priority = 4,
    string? lastSyncedDateTime = null,
    List<ItemModel>? children = null,
    string? createdDate = null,
    string? lastCheckedDate = null,
    string? lastUpdatedDate = null,
    bool? deleted = false,
    string? notes = "",
    bool? inHistory = false,
    int? syncClientCreationId = null,
    bool? dueTimeSpecified = null,
    int? ownerId = 0
    )
    {
        Id = id;
        Content = content;
        ItemType = itemType;
        Checked = @checked;
        ProjectId = projectId;
        ParentId = parentId;
        Path = path;
        Collapsed = collapsed;
        DateString = dateString;
        DateStringPriority = dateStringPriority;
        DueDate = dueDate;
        Recurrence = recurrence;
        ItemOrder = itemOrder;
        Priority = priority;
        LastSyncedDateTime = lastSyncedDateTime;
        CreatedDate = createdDate;
        LastCheckedDate = lastCheckedDate;
        LastUpdatedDate = lastUpdatedDate;
        Deleted = deleted;
        Notes = notes;
        InHistory = inHistory;
        SyncClientCreationId = syncClientCreationId;
        DueTimeSpecified = dueTimeSpecified;
        OwnerId = ownerId;

        if (children == null)
        {
            Children = new List<ItemModel>();
        }
        else
        {
            Children = children;
        }
    }
}
