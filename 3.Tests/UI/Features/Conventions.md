# NARRATIVE
- Use third person e.g. 
```
Given THE USER IS logged in
```
<br>

# TAGS
- `@Smoke`
- `@Regression`
- `@Negative`
<br>

# HOOKS
- Use all lowercase letters separated by dots(.)
- Start the hook name with an action verb followed by an object e.g.
  - `@delete.projects @create.project.NAME_OF_PROJECT`
  - `@delete.project`
  - `@go.to.login.page`
<br>

# BACKGROUND
Use Background for repeated steps for different scenarios in the same feature:

```
    Background:
        Given the user is logged in
            And has an existing project
```
<br>

# COMMON STEPS EXAMPLES
```
    Given the user is logged in
        And has an existing project
```

```
    Given the user is logged in
        And has an existing item
```
<br>

# SCENARIOS
- Titles: start the title with an action verb e.g. 
```
    Scenario: Create a new project successfully
```
- Use "Scenario" and Unique ID generator method for @Acceptance test cases
- Use "Scenario Outline" and Examples for @Negative test cases
