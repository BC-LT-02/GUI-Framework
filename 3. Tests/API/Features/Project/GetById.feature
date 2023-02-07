Feature: Retrieve an existing project

    @acceptance
    Scenario: Retrieve a specific project with valid ID and valid authentication
        Given the user is authenticated
        When the user sends a GET request to the api endpoint with a valid project ID
        Then the response should have a status code of "OK" and should contain the details of the valid project

        Examples:
            | Parameter              | Value                 |
            | Id                     | 1                     |
            | Content                | Study                 |
            | ItemsCount             | 0                     |
            | Icon                   | 4                     |
            | ItemType               | 2                     |
            | ParentId               | null                  |
            | Collapsed              | false                 |
            | ItemOrder              | 3                     |
            | Children               | List<T>               |
            | IsProjectShared        | false                 |
            | ProjectShareOwnerName  | null                  |
            | ProjectShareOwnerEmail | null                  |
            | IsShareApproved        | false                 |
            | IsOwnProject           | true                  |
            | LastSyncedDateTime     | /Date(1674319686391)/ |
            | LastUpdatedDate        | /Date(1674008683710)/ |
            | Deleted                | false                 |
            | SyncClientCreationId   | null                  |

    @negative
    Scenario: Attempt to retrieve a project with invalid ID
        Given the user is authenticated
        When the user sends a GET request to the api endpoint with an invalid project ID "1"
        Then the response should have a status code of "OK" and the response should contain an error message "Not Authenticated"

    @negative
    Scenario: Attempt to retrieve a specific project with valid ID but without authentication
        Given the user is not authenticated
        When the user sends a GET request to the api endpoint with an valid project ID
        Then the response should have a status code of "OK" and a "Not Authenticated" error message indicating that the user is not authorized to access the resource.
