Feature: Add Above Item
    As a logged user, given an existing item, the user wants to be able to add above another item in a todo list
    so that the user can organize its tasks better

    Background:
        Given the user is logged in

    @smoke @create.project.Kids @create.item.Sleep
    Scenario Outline: Successfully addition of an item above an existing item
        Given the user has selected the "Kids" project
        When the user clicks on the "<existing_item>" 
            And selects "Add above"
        Then an input text box should be displayed above the "<existing_item>"
        When the user enters "<new_item>" and saves it
        Then the "<new_item>" should be added above the "<existing_item>"

Examples:
| existing_item     | new_item              |
| Sleep             | Brush your teeth      |
| Brush your teeth  | Eat your dinner       |
| Eat your dinner   | Make your homework    |
| Eat your dinner   | Play with friends     |
