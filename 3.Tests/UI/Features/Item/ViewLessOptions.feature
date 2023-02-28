Feature: View Less Options
    As a logged in user, the user should be able to see less options when creating an item.

    @create.project.NewProject
    Scenario: View More Options Successfully
        Given the user is logged in
        When the user clicks on 'Project Button' <NewProject> at 'Project Component'
            And clicks on 'More Option' at 'Items Component'
            And clicks on 'Less Option'
        Then the 'Less Options Panel' should not be displayed