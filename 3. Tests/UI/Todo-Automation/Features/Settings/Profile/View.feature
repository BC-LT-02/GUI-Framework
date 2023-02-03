Feature: Profile settings view
    As a logged in user, the user should be able to view his profile settings with his information to update it.

    @Acceptance
    Scenario: View profile settings succesfully
        Given the user is logged in
        When the user clicks on the Settings option on the Nav Bar
        Then the Profile Settings view should be opened
            And the Full Name, Email, Time Zone, Old Password and New Password labels and inputs should appear

