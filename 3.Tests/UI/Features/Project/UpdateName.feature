Feature: Project Update
    As a logged in user, the user should be able to update a project.
    
    Background:
        Given the user is logged in

    @Regression @create.project.MyProject
    Scenario: Edit a project
        When the user clicks the edit button on "MyProject"
            And types "My New Project Name" on 'Edit Project Input' on 'Home Page'
            And clicks on 'Save Edit Project'
        Then the 'Project Button' <My New Project Name> should be displayed
