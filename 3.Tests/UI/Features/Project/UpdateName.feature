Feature: Project Update
    As a logged in user, the user should be able to update a project.
    
    Background:
        Given the user is logged in

    @Smoke @Regression @create.project.MyProject
    Scenario: Edit a project
        When the user clicks the edit button on "MyProject"
            And inputs a new Project name
            And clicks on the Save icon
        Then the project should be displayed with the new name
