Feature: Item Due Date
    As a logged in user, the user should be able to update the name to an existing item from a project.

    Background:
        Given the user is logged in

    @Smoke @Regression @create.project.Calendar @create.item.NewItem @Due_Date_Item
    Scenario: Update the Due Date of an item succesfully
        When the user clicks on 'Project Button' <Calendar> at 'Project Component'
        And the user clicks on the Set Due Date option
        And inputs "1 Mar 12:00 AM" as due date
        Then the item should be displayed with the "1 Mar 12:00 AM" date-tag

    @Smoke @Regression @create.project.PastNotes @create.item.Apples @Due_Date_Item
    Scenario: Update the Due Date of an item succesfully to a date in the past
        When the user clicks on 'Project Button' <PastNotes> at 'Project Component'
        And the user clicks on the Set Due Date option
        And inputs "20 Jun 2020 02:00 AM" as due date
        Then the item should be displayed as overdue

    @Smoke @Regression @create.project.NotImportant @delete.projects @create.item.Clean @Due_Date_Item
    Scenario Outline: Postpone the Due Date of an item succesfully
        When the user clicks on 'Project Button' <NotImportant> at 'Project Component'
        And the user clicks on the Set Due Date option
        And inputs "20 Jun 12:00 PM" as due date
        And clicks on Postpone <Postpone>
        Then the item should be displayed with the "<PostposeDate>" date-tag

        Examples:
            | Postpone | PostposeDate    |
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
