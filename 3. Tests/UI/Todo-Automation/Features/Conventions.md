# NARRATIVE
- Use third person e.g. 
```
Given THE USER IS logged in
```

# TAGS
- @Smoke
- @Regression
- @Negative

# BACKGROUND
Use Background for repetead steps for different scenarios in the same feature:

```
    Background:
        Given the user is logged in
            And has an existing project
```

# COMMON STEPS EXAMPLES
```
    Given the user is logged in
        And has an existing project
```

```
    Given the user is logged in
        And has an existing item
```

# SCENARIOS
- Titles: start the title with an action verb e.g. 
```
    Scenario: Create a new project succesfully
```
- Use "Scenario" and Unique ID generator method for @Acceptance test cases
- Use "Scenario Outline" and Examples for @Negative test cases

