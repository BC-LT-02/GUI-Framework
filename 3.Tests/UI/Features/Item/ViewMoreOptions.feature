Feature: View More Options
    As a logged in user, the user should be able to see advanced options when creating an item.

    @create.project.NewProject
    Scenario: View More Options Successfully
        Given the user is logged in
        When the user clicks on 'Project Button' <NewProject> on 'Project Component'
            And clicks on 'More Options' on 'Items Component'
        Then the 'More Options Panel' should be displayed 