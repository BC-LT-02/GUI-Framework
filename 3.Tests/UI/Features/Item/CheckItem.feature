Feature: Checking a Todo Item
    As a logged user I want to check a todo item in a project
    So that I can keep track of my tasks

    Background:
        Given the user is logged in

    @Smoke @create.project.NewProject @create.item
    Scenario: Checking an Item in a Project successfully
        Given the user has selected the "NewProject" project
        When the user checks the item
        Then the item should be listed in the Done Items