namespace Todoly.Views.Models;

using System;
using System.Collections.Generic;

public record ItemsPayload
{
    public long? Id { get; set; } = null;
    public string? Content { get; set; } = null;
    public long? ItemType { get; set; } = null;
    public bool? Checked { get; set; } = null;
    public long? ProjectId { get; set; } = null;
    public object? ParentId { get; set; } = null;
    public string? Path { get; set; } = null;
    public bool? Collapsed { get; set; } = null;
    public string? DateString { get; set; } = null;
    public int? DateStringPriority { get; set; } = null;
    public string? DueDate { get; set; } = null;
    public object? Recurrence { get; set; } = null;
    public int? ItemOrder { get; set; } = null;
    public int? Priority { get; set; } = null;
    public string? LastSyncedDateTime { get; set; } = null;
    public List<ItemsPayload>? Children { get; set; } = null;
    public string? DueDateTime { get; set; } = null;
    public string? CreatedDate { get; set; } = null;
    public string? LastCheckedDate { get; set; } = null;
    public string? LastUpdatedDate { get; set; } = null;
    public bool? Deleted { get; set; } = null;
    public string? Notes { get; set; } = null;
    public bool? InHistory { get; set; } = null;
    public object? SyncClientCreationId { get; set; } = null;
    public bool? DueTimeSpecified { get; set; } = null;
    public long? OwnerId { get; set; } = null;

    public ItemsPayload(
        long? id,
        string? content,
        long? itemType,
        bool? checkeds,
        long? projectId,
        object? parentId,
        string? path,
        bool? collapsed,
        string? dateString,
        int? dateStringPriority,
        string? dueDate,
        object? recurrence,
        int? itemOrder,
        int? priority,
        string? lastSyncedDateTime,
        List<ItemsPayload>? children,
        string? dueDateTime,
        string? createdDate,
        string? lastCheckedDate,
        string? lastUpdatedDate,
        bool? deleted,
        string? notes,
        bool? inHistory,
        object? syncClientCreationId,
        bool? dueTimeSpecified,
        long? ownerId
    )
    {
        Id = id;
        Content = content;
        ItemType = itemType;
        Checked = checkeds;
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
        Children = children;
        DueDateTime = dueDateTime;
        CreatedDate = createdDate;
        LastCheckedDate = lastCheckedDate;
        LastUpdatedDate = lastUpdatedDate;
        Deleted = deleted;
        Notes = notes;
        InHistory = inHistory;
        SyncClientCreationId = syncClientCreationId;
        DueTimeSpecified = dueTimeSpecified;
        OwnerId = ownerId;
    }
}
