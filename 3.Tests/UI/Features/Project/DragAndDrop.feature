Feature: Project drag and drop actions
    As a logged in user, the user should be able to interact with the project links to reorganize them.
    
    Background:
        Given the user is logged in

    @Regression @create.project #@delete.project
    Scenario: Make a project child of another
        When the user drags and drop a project on top of another project of the list
        Then the project should be displayed as a child of the other project