Feature: Item Name
    As a logged in user, the user should be able to update the name to an existing item from a project.

    Background:
        Given the user is logged in

    @Acceptance
    Scenario Outline: Update a name of an item succesfully
        When the user clicks on "<oldItemName>" item in the main items section
        And the user types "<itemName>" as item name
        Then the item should be updated to be "<itemName>"

        Examples:
            | oldItemName               | itemName       |
            | 1sXwIO8z9X9X130I040O9Xag3 | My first item  |
            | 8465P8593MV215396xz53iOY6 | My second item |




