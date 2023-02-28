Feature: Project Creation Above
    As a logged in user, the user should be able to add a project above or below another one.

    Background:
        Given the user is logged in

    @Regression @create.project.MyProject
    Scenario: Add a project above
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
            And clicks on 'Add item above' on the Project Context Menu
            And types "My New Project Name" on 'Edit Project Input'
            And clicks on 'Save Edit Project'
        Then the 'Project Button' <My New Project Name> should be displayed

    @Regression @create.project.MyProject
    Scenario: Add a project below
        When the user opens the Project Context Menu on <MyProject> at 'Project Component'
            And clicks on 'Add item below' on the Project Context Menu
            And types "My New Project Name" on 'Edit Project Input'
            And clicks on 'Save Edit Project'
        Then the 'Project Button' <My New Project Name> should be displayed
