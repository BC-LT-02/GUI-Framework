Feature: Project Drag and Drop actions
    As a logged in user, the user should be able to drag and drop a project into a different position.
    
    Background:
        Given the user is logged in

    @Regression@create.project.MyProject1 @create.project.MyProject2 @delete.projects
    Scenario: Drag and drop above another project
        When the user drags and drop 'MyProject2' 'Project Handle' above 'MyProject1' at 'Project Component'
        Then the 'Second Project' <MyProject1> should be displayed

    @Regression @create.project.MyProject1 @create.project.MyProject2 @delete.projects
    Scenario: Drang and drop inside another project
        When the user drags and drop 'MyProject2' 'Project Handle' on top of 'MyProject1' at 'Project Component'
        Then the 'Child Project' <MyProject2> should be displayed
