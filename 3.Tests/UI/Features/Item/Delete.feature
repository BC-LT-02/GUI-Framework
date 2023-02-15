Feature: Item Deletion
    As a logged in user, the user should be able to delete existing items from a project.

    Background:
        Given the user is logged in

    @Smoke @Regression @create.project @create.item @delete
    Scenario: Delete a pending item succesfully
        When the user has selected a project
        And the user clicks on the delete option of an item
        Then the item should be removed from the section

# Scenario: Delete all done items succesfully
#     And has at least two done items located in the done items section
#     When the user clicks on the delete all option
#     Then the items should be removed from the section
#     And they should be added to the Recycle bin section






