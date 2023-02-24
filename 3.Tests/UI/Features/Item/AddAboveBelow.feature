Feature: Add Below Item
    As a logged user, given an existing item, the user wants to be able to add below another item in a todo list
    so that the user can organize its tasks better

    Background:
        Given the user is logged in

    @smoke @create.project.Kids @create.item.Lunch @create.item.Sleep
    Scenario Outline: Successfully addition of an item above or below an existing item
        When the user clicks on 'Project Button' <Kids> on 'Project Component'
        And the user hovers on "Get Item" <Lunch> on 'Items Component'
        And the user clicks on "Item Contextmenu" <Lunch> on "Add item <position>" option on "Items Component"
        Then the user enters "<new_item>" and saves it
        And the "<new_item>" should be added <position> the "Lunch"

        Examples:
            | position | new_item  |
            | above    | Breakfast |
            | below    | Dinner    |
            | above    | School    |
            | below    | Homework  |