Feature: User Login
    As a non-logged in user, the user should be able to login into the site

    @Smoke
    Scenario: Login into the site succesfully
    Given the user navigates to the URL
    When the user clicks on 'Login' on 'Login Page'
        And introduces his credentials
        And clicks on 'Confirm Login'
        Then the user should be able to see the 'Logout' button on 'Home Page'