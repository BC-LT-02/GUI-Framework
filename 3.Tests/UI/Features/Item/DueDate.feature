Feature: Item Due Date
    As a logged in user, the user should be able to update the name to an existing item from a project.

    Background:
        Given the user is logged in

    @Draft @create.project.Calendar @delete.projects @create.item @Due_Date_Item
    Scenario Outline: Update the Due Date of an item succesfully
        When the user has selected the "Calendar" project
        And the user clicks on the Set Due Date option
        And inputs a new <Due Date>
        Then the item should be displayed with the <Date Showed> tag

        Examples:
            | Due Date        | Date Showed     |
            | 1 Mar 12:00 AM  | 1 Mar 12:00 AM  |
            | 24 Mar 03:00 PM | 24 Mar 03:00 PM |
            | 15 Jun 03:00 PM | 15 Jun 03:00 PM |
