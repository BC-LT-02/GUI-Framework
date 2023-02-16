Feature: Item Priority
    As a logged in user, the user should be able to delete existing items from a project.

    Background:
        Given the user is logged in

    @Smoke @Regression @create.project.Kids @create.item @delete.projects @priority
    Scenario Outline: Delete a pending item succesfully
        When the user has selected the "Kids" project
        And the user clicks on the priority <Priority> option of an item
        Then the item color should be <Color>

        Examples:
            | Priority | Color             |
            | 1        | rgb(255, 51, 0)   |
            | 2        | rgb(22, 139, 184) |
            | 3        | rgb(81, 153, 45)  |
            | 4        | rgb(0, 0, 0)      |
