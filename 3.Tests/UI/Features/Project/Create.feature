Feature: Project Creation
    As a logged in user, the user should be able to create a project.
    
    Background:
        Given the user is logged in

    @Smoke @Regression
    Scenario: Create a new project
        When the user clicks on 'Add New Project' on 'Home Page'
            And types "My New Project" on 'New Project Name'
            And clicks on 'Add New Project Name'
        Then the 'Project Button' <My New Project> should be displayed on 'Project Component'
