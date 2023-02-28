Feature: Checking and Unchecking a Todo Item
    As a logged user I want to check and uncheck a todo item in a project
    So that I can keep track of my tasks

    Background:
        Given the user is logged in

    @Smoke @create.project.NewProject @create.item.NewItem @create.item.checked.DoneItem @delete.projects
    Scenario Outline: Checking and unchecking an Item in a Project successfully
        When the user clicks on 'Project Button' <NewProject> on 'Project Component'
        When the user <action> the item
        Then the item should be listed in the <status> Items

        Examples:
            | action   | status |
             | checks   | Done   |
            | unchecks | Undone |