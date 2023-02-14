Feature: Project Update
    As a logged in user, the user should be able to update a project.
    
    Background:
        Given the user is logged in

    @Regression @create.project
    Scenario: Edit a project
        When the user clicks the edit button on a Project
            And inputs a new Project name
            And clicks on the Save icon
        Then the project should be displayed with the new name
