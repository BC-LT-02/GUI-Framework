Feature: Project Creation
    As a logged in user, the user should be able to create a project.
    
    Background:
        Given the user is logged in

    @Smoke @Regression
    Scenario: Create a new project
        When the user clicks the New Project button
            And inputs a new project name
            And clicks the Add button
        Then a new project with the chosen name should be displayed in the projects list
