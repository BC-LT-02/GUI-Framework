namespace Models;

using System;
using System.Collections.Generic;

public record ProjectPayloadModel
{
    public int? Id { get; set; }
    public string? Content { get; set; }
    public int? ItemsCount { get; set; }
    public int? Icon { get; set; }
    public int? ItemType { get; set; }
    public int? ParentId { get; set; }
    public bool? Collapsed { get; set; }
    public int? ItemOrder { get; set; }
    public List<ProjectPayloadModel>? Children { get; set; }
    public bool? IsProjectShared { get; set; }
    public string? ProjectShareOwnerName { get; set; }
    public string? ProjectShareOwnerEmail { get; set; }
    public bool? IsShareApproved { get; set; }
    public bool? IsOwnProject { get; set; }
    public string? LastSyncedDateTime { get; set; }
    public string? LastUpdatedDate { get; set; }
    public bool? Deleted { get; set; }
    public int? SyncClientCreationId { get; set; }

    public ProjectPayloadModel(
        int? id,
        string? content,
        int? itemsCount = 0,
        int? icon = 0,
        int? itemType = 2,
        int? parentId = null,
        bool? collapsed = false,
        int? itemOrder = null,
        List<ProjectPayloadModel>? children = null,
        bool? isProjectShared = false,
        string? projectShareOwnerName = null,
        string? projectShareOwnerEmail = null,
        bool? isShareApproved = false,
        bool? isOwnProject = true,
        string? lastSyncedDateTime = null,
        string? lastUpdatedDate = null,
        bool? deleted = false,
        int? syncClientCreationId = null
    )
    {
        Content = content;
        ItemsCount = itemsCount;
        Icon = icon;
        ItemType = itemType;
        Id = id;
        ParentId = parentId;
        Collapsed = collapsed;
        ItemOrder = itemOrder;
        IsProjectShared = isProjectShared;
        ProjectShareOwnerName = projectShareOwnerName;
        ProjectShareOwnerEmail = projectShareOwnerEmail;
        IsShareApproved = isShareApproved;
        IsOwnProject = isOwnProject;
        LastSyncedDateTime = lastSyncedDateTime;
        LastUpdatedDate = lastUpdatedDate;
        Deleted = deleted;
        SyncClientCreationId = syncClientCreationId;

        if (children == null)
        {
            Children = new List<ProjectPayloadModel>();
        }
        else
        {
            Children = children;
        }
    }
}
