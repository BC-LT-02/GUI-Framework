Feature: Items CRUD operations
    As a logged in user, the user should be able to create a project.
    
    Background:
        Given the user is logged in

    @Smoke @Regression
    Scenario: Create a new project
        When the user clicks on 'Add New Project' at 'Home Page'
            And types "My New Project" on 'New Project Name'
            And clicks on 'Add New Project Name'
        Then the 'Project Button' <My New Project> should be displayed at 'Project Component'

    @Smoke @Regression @create.project.MyProject
    Scenario: Delete a project
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
            And clicks on 'Delete' on the Project Context Menu
            And accepts the alert
        Then the 'Project Button' <MyProject> should not be displayed

    @Regression @create.project.MyProject @delete.projects
    Scenario: Edit a project
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
            And clicks on 'Edit' on the Project Context Menu
            And types "My New Project Name" on 'Edit Project Input'
            And clicks on 'Save Edit Project'
        Then the 'Project Button' <My New Project Name> should be displayed