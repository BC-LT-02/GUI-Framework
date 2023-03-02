Feature: Item Due Date
    As a logged in user, the user should be able to update the name to an existing item from a project.

    Background:
        Given the user is logged in

    @Smoke @Regression @create.project.Calendar @delete.projects @create.item.NewItem @Due_Date_Item
    Scenario Outline: Update the Due Date of an item succesfully
        When the user clicks on 'Project Button' <Calendar> at 'Project Component'
            And the user hovers on "Get Item" <NewItem> at 'Items Component'
            And the user clicks on 'Item DueDate' <NewItem> at 'Items Component'
            And inputs "<Date>" as due date
        Then the "NewItem" date-tag should be displayed as "<DateTag>"

        Examples:
            | Date                 | DateTag         |
            | 19 Mar 12:00 AM      | 19 Mar 12:00 AM |
            | 20 Jun 2020 02:00 AM | overdue         |
            | Today                | Today           |
            | Tomorrow             | Tomorrow        |

    @Smoke @Regression @delete.projects @create.project.NotImportant @delete.projects @create.item.Clean @Due_Date_Item
    Scenario Outline: Postpone the Due Date of an item succesfully
        When the user clicks on 'Project Button' <NotImportant> at 'Project Component'
            And the user hovers on "Get Item" <Clean> at 'Items Component'
            And the user clicks on 'Item DueDate' <Clean> at 'Items Component'
            And inputs "20 Jun 12:00 PM" as due date
            And clicks on <Postpone> "Clean"
        Then the "Clean" date-tag should be displayed as "<DateTag>"

        Examples:
            | Postpone | DateTag         |
            | 1 day    | 21 Jun 12:00 PM |
            | 2 days   | 22 Jun 12:00 PM |
            | 3 days   | 23 Jun 12:00 PM |
            | 4 days   | 24 Jun 12:00 PM |
            | 5 days   | 25 Jun 12:00 PM |
            | 6 days   | 26 Jun 12:00 PM |
            | 1 week   | 27 Jun 12:00 PM |
            | 2 weeks  | 4 Jul 12:00 PM  |
            | 1 month  | 20 Jul 12:00 PM |
            | 2 months | 20 Aug 12:00 PM |

    @Smoke @Regression @create.project.Errands @delete.projects @create.item.GoToGym @Due_Date_Item
    Scenario Outline: Check if item appear on given section
        When the user clicks on 'Project Button' <Errands> at 'Project Component'
            And the user hovers on "Get Item" <GoToGym> at 'Items Component'
            And the user clicks on 'Item DueDate' <GoToGym> at 'Items Component'
            And inputs "<Date>" as due date
        Then the "GoToGym" in "Errands" should be displayed in "<When>" section

        Examples:
            | Date      | When  |
            | Today     | Today |
            | Yesterday | Today |
            | Tomorrow  | Next  |
