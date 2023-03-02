Feature: Items actions operations
    As a logged user, the user wants to be able to perform different actions on the items.

    Background:
        Given the user is logged in

    @create.project.Cleaning @delete.projects @UI_View_More_Less
    Scenario: View More and Less Options Successfully
        When the user clicks on 'Project Button' <Cleaning> at 'Project Component'
        And clicks on 'More Option' at 'Items Component'
        Then the 'More Options Panel' should be displayed
        When clicks on 'Less Option'
        Then the 'Less Options Panel' should not be displayed

    @Regression @create.project.HouseChores @create.item.WashDishes @create.item.SweepFloor @delete.projects @retrieve.projects
    Scenario: Drag and drop above another item
        When the user clicks on 'Project Button' <HouseChores> at 'Project Component'
        When the user drags and drop 'SweepFloor' 'Item Handle' above 'WashDishes' at 'Items Component'
        Then the item 'SweepFloor' should appear before 'WashDishes'

    @Regression @create.project.MarketList @create.item.Eggs @create.item.Flour @delete.projects
    Scenario: Drang and drop inside another item
        When the user clicks on 'Project Button' <MarketList> at 'Project Component'
        When the user drags and drop 'Flour' 'Item Handle' on top of 'Eggs' at 'Items Component'
        Then the 'Child Item' <Flour> should be displayed

    @Smoke @Regression @create.project.Kids @create.item.EatLunch @delete.projects @UI_Priority_Item
    Scenario Outline: Place item priority
        When the user clicks on 'Project Button' <Kids> at 'Project Component'
        And the user hovers on "Get Item" <EatLunch> at 'Items Component'
        And the user clicks on "Item Contextmenu" <EatLunch> on "<Priority>" option at "Items Component"
        Then the <EatLunch> color should be <Color>

        Examples:
            | Priority | Color             |
            | 1        | rgb(255, 51, 0)   |
            | 2        | rgb(22, 139, 184) |
            | 3        | rgb(81, 153, 45)  |
            | 4        | rgb(0, 0, 0)      |


    @smoke @create.project.Kids @create.item.Lunch @create.item.Sleep @delete.projects
    Scenario Outline: Successfully addition of an item above or below an existing item
        When the user clicks on 'Project Button' <Kids> at 'Project Component'
        And the user hovers on "Get Item" <Lunch> at 'Items Component'
        And the user clicks on "Item Contextmenu" <Lunch> on "Add item <Position>" option at "Items Component"
        And enters the item "<New_item>" on "Edit Item" input
        Then the "<New_item>" should be added <Position> the "Lunch"

        Examples:
            | Position | New_item  |
            | above    | Breakfast |
            | below    | Dinner    |


    @Smoke @create.project.NewProject @create.item.NewItem @create.item.checked.DoneItem @delete.projects
    Scenario Outline: Checking and unchecking an Item in a Project successfully
        When the user clicks on 'Project Button' <NewProject> at 'Project Component'
        When the user <action> the item
        Then the item should be listed in the <status> Items

        Examples:
            | action   | status |
            | checks   | Done   |
            | unchecks | Undone |
