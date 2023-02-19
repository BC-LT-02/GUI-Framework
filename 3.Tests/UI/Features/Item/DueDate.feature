Feature: Item Due Date
    As a logged in user, the user should be able to update the name to an existing item from a project.

    Background:
        Given the user is logged in

    @Smoke @Regression @create.project.Calendar @create.item @Due_Date_Item
    Scenario: Update the Due Date of an item succesfully
        When the user has selected the "Calendar" project
        And the user clicks on the Set Due Date option
        And inputs "1 Mar 12:00 AM" as due date
        Then the item should be displayed with the same date-tag
