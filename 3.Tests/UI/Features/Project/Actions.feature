Feature: Project actions operations
    As a logged in user, the user should be able to change the image of a project.

    Background:
        Given the user is logged in

    @Regression @create.project.MyProject @delete.projects
    Scenario: Change a project image
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
        And clicks on 'Shopping Bag Image'
        Then the 'Project With Shopping Bag Image' should be displayed
        
    @Regression @create.project.MyProject @delete_projects
    Scenario: Add a project above
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
        And clicks on 'Add item above' on the Project Context Menu
        And types "My New Project Name" on 'Edit Project Input'
        And clicks on 'Save Edit Project'
        Then the 'Project Button' <My New Project Name> should be displayed

    @Regression @create.project.MyProject @delete_projects
    Scenario: Add a project below
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
        And clicks on 'Add item below' on the Project Context Menu
        And types "My New Project Name" on 'Edit Project Input'
        And clicks on 'Save Edit Project'
        Then the 'Project Button' <My New Project Name> should be displayed

    @Regression @create.project.MyProject1 @create.project.MyProject2 @delete.projects @retrieve.projects
    Scenario: Drag and drop above another project
        When the user drags and drop 'MyProject2' 'Project Handle' above 'MyProject1' at 'Project Component'
        Then the project 'MyProject2' should appear before 'MyProject1'

    @Regression @create.project.MyProject1 @create.project.MyProject2 @delete.projects
    Scenario: Drang and drop inside another project
        When the user drags and drop 'MyProject2' 'Project Handle' on top of 'MyProject1' at 'Project Component'
        Then the 'Child Project' <MyProject2> should be displayed
