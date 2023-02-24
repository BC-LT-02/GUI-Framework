Feature: Add Below Item
    As a logged user, given an existing item, the user wants to be able to add below another item in a todo list
    so that the user can organize its tasks better

    Background:
        Given the user is logged in

    @smoke @create.project.Kids @create.item.Lunch @create.item.Sleep
    Scenario: Successfully addition of an item above or below an existing item
        When the user clicks on 'Project Button' <Kids> on 'Project Component'
        And the user hovers on "Get Item" <Lunch> on 'Items Component'
        And the user clicks on "Item Contextmenu" <Lunch> on "Add item below" option on "Items Component"
        Then the user enters "Brush your teeth" and saves it
        And the "Brush your teeth" should be added below the "Lunch"