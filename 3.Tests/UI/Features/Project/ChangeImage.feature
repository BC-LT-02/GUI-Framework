Feature: Project Image Selection
    As a logged in user, the user should be able to change the image of a project.
    
    Background:
        Given the user is logged in

    @Regression @create.project.MyProject
    Scenario: Change a project image
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
            And clicks on 'Shopping Bag Image'
        Then the 'Project With Shopping Bag Image' should be displayed
