Feature: Item Update
    As a logged in user, the user should be able to update the name to an existing item from a project.

    Background:
        Given the user is logged in

    @Smoke @Regression @create.project.Exercise @create.item @update
    Scenario: Update a name of an item succesfully
        When the user has selected the "Exercise" project
        And the user clicks on the item
        And inputs a new item name and press enter
        Then the item should be displayed with the new name
