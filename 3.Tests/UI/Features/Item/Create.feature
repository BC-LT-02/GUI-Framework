Feature: Create an Item in a Project
    As a logged user, the user wants to create an item in a project so that he can keep track of my tasks.

    Background:
        Given the user is logged in
    #And the user has an existing project

    @create.project.NewProject
    Scenario: Create an Item Successfully
        When the user clicks on 'Project Button' <NewProject> on 'Project Component'
        When enters the item "new katas for monday" on Add New Todo input
        Then the item should be displayed in the project list
        
    # @Draft
    # @Negative @create.project.NewProject
    # Scenario: Failed to Create an Item Due to Empty Name
    #     Given the user has selected the "NewProject" project
    #     When the user tries to create an item with an empty string
    #     Then an error message "Name is required" should be displayed 
