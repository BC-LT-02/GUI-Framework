Feature: Items CRUD operations
    As a logged user, the user wants to be able to do the basic CRUD operations for items.

    Background:
        Given the user is logged in

    @create.project.NewProject @delete.projects @UI_Create_Item
    Scenario: Create an Item Successfully
        When the user clicks on 'Project Button' <NewProject> at 'Project Component'
            And enters the item "new katas for monday" on "Add New Todo" input
        Then the 'Get Item' <new katas for monday> should be displayed at 'Items Component'

    @Smoke @Regression @create.project.Exercise @delete.projects @create.item.Math @UI_Update_Item
    Scenario: Update a name of an item succesfully
        When the user clicks on 'Project Button' <Exercise> at 'Project Component'
            And the user hovers on "Get Item" <Math> at 'Items Component'
            And the user clicks on "Item Contextmenu" <Math> on "Edit" option at "Items Component"
            And enters the item "New name" on "Edit Item" input
        Then the 'Get Item' <New name> should be displayed at 'Items Component'

    @Smoke @Regression @create.project.Shopping @delete.projects @create.item.Bananas @UI_Delete_Item
    Scenario: Delete a pending item succesfully
        When the user clicks on 'Project Button' <Shopping> at 'Project Component'
            And the user hovers on "Get Item" <Bananas> at 'Items Component'
            And the user clicks on "Item Contextmenu" <Bananas> on "Delete" option at "Items Component"
        Then the 'Get Item' <Bananas> should not be displayed at 'Items Component'

    # @create.project.NewProject @UI_Create_Item
    # Scenario: Create an Item Due Tomorrow Successfully
    #     When the user clicks on 'Project Button' <NewProject> at 'Project Component'
    #     And enters the item "new katas for monday" on "Add New Todo" input
    #     Then the 'Get Item' <new katas for monday> should be displayed at 'Items Component'