Feature: Project Update
    As a logged in user, the user should be able to update a project.
    
    Background:
        Given the user is logged in

    @Regression @delete.projects @create.project.MyProject
    Scenario: Edit a project
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
            And clicks on 'Edit' on the Project Context Menu
            And types "My New Project Name" on 'Edit Project Input'
            And clicks on 'Save Edit Project'
        Then the 'Project Button' <My New Project Name> should be displayed
