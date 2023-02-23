Feature: Add Above Item
    As a logged user, given an existing item, the user wants to be able to add above another item in a todo list
    so that the user can organize its tasks better

    Background:
        Given the user is logged in

    @smoke @create.project.Kids @create.item.Sleep
    Scenario: Successfully addition of an item above an existing item
        When the user clicks on 'Project Button' <Kids> on 'Project Component'
        And the user selects Add above on the "Sleep"
        Then the user enters "Brush your teeth" and saves it
        And the "Brush your teeth" should be added above the "Sleep"
