Feature: Project Creation

    @acceptance
    Scenario: Create a new project with valid parameters and valid authentication
        Given the user is authenticated
        When the user sends a POST request to the API endpoint with a valid JSON or XML payload
        Then the response should have a status code of "OK" and the new project should be added to the database and the response should contain the details of the newly created project
            
            Examples:
            | Parameter              | Value                 |
            | Id                     | 4052842               |
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
    Scenario: Attempt to create a new project without valid parameters
        Given the user is authenticated
        When the user sends a POST request to the API endpoint with a JSON or XML payload that is missing required fields
        Then the response should have a status code of "OK" and a error message indicating missing fields
