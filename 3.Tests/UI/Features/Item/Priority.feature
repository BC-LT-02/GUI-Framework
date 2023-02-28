Feature: Item Priority
    As a logged in user, the user should be able to delete existing items from a project.

    Background:
        Given the user is logged in

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
