Feature: Project Deletion
    As a logged in user, the user should be able to delete a project.
    
    Background:
        Given the user is logged in

    @Smoke @Regression @delete.projects @create.project.MyProject
    Scenario: Delete a project
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
            And clicks on 'Delete' on the Project Context Menu
            And accepts the alert
        Then the 'Project Button' <MyProject> should not be displayed
