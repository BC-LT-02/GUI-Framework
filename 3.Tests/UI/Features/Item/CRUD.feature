Feature: Items CRUD operations
    As a logged user, the user wants to be able to do the basic CRUD operations for items.

    Background:
        Given the user is logged in

    @create.project.NewProject @UI_Create_Item
    Scenario: Create an Item Successfully
        When the user clicks on 'Project Button' <NewProject> at 'Project Component'
        When enters the item "new katas for monday" on Add New Todo input
        Then the "new katas for monday" should be displayed

    @Smoke @Regression @create.project.Exercise @create.item.Math @UI_Update_Item
    Scenario: Update a name of an item succesfully
        When the user clicks on 'Project Button' <Exercise> at 'Project Component'
        And the user hovers on "Get Item" <Math> at 'Items Component'
        And the user clicks on "Item Contextmenu" <Math> on "Edit" option at "Items Component"
        And inputs "New name" as new item name
        Then the "New name" should be displayed

    @Smoke @Regression @create.project.Shopping @create.item.Bananas @UI_Delete_Item
    Scenario: Delete a pending item succesfully
        When the user clicks on 'Project Button' <Shopping> at 'Project Component'
        And the user hovers on "Get Item" <Bananas> at 'Items Component'
        And the user clicks on "Item Contextmenu" <Bananas> on "Delete" option at "Items Component"
        Then the item should be removed from the section
