Feature: Item Deletion
    As a logged in user, the user should be able to delete existing items from a project.

    Background:
        Given the user is logged in

    @Smoke @Regression @create.project.Shopping @create.item.Bananas @UI_Delete_Item
    Scenario: Delete a pending item succesfully
        When the user clicks on 'Project Button' <Shopping> on 'Project Component'
        And the user hovers on "Get Item" <Bananas> on 'Items Component'
        And the user clicks on "Item Contextmenu" <Bananas> on "Delete" option on "Items Component"
        Then the item should be removed from the section

# Scenario: Delete all done items succesfully
#     And has at least two done items located in the done items section
#     When the user clicks on the delete all option
#     Then the items should be removed from the section
#     And they should be added to the Recycle bin section
