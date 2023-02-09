Feature: Create an Item in a Project
    As a logged user, the user wants to create an item in a project so that he can keep track of my tasks.

    Background:
        Given the user is logged in
<<<<<<< HEAD
    #And the user has an existing project

    @create.project
=======
            #And the user has an existing project

    @Smoke
>>>>>>> c321402 (Create item with the new actualizations)
    Scenario: Create an Item Successfully
        Given the user has selected a project
        When enters the item "new katas for monday" on Add New Todo input
        Then the item should be displayed in the project list
<<<<<<< HEAD
        
    @Draft
    @Negative
    Scenario: Failed to Create an Item Due to Empty Name
        Given the user has selected a project
        When the user tries to create an item with an empty string
        Then an error message "Name is required" should be displayed 
=======

    #@Draft
    #@Negative
    #Scenario: Failed to Create an Item Due to Empty Name
        #Given the user has selected a project
        #When the user tries to create an item with an empty string
        #Then an error message indicating that the item name is required should be displayed
>>>>>>> c321402 (Create item with the new actualizations)
