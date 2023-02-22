Feature: Add Below Item
    As a logged user, given an existing item, the user wants to be able to add below another item in a todo list
    so that the user can organize its tasks better

    Background:
        Given the user is logged in

    @smoke @create.project.Kids @create.item.Lunch @create.item.Sleep
    Scenario: Successfully addition of an item below an existing item
        Given the user has selected the "Kids" project
        When the user selects Add below on the "Lunch"
        Then the user enters "Brush your teeth" and saves it
        Then the "Brush your teeth" should be added below the "Lunch"