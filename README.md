# Test Automation Project using Playwright and Specflow

## Summary
Test Automation Project using Playwright and Specflow

## Dev Instructions

Once this project has been cloned the dependencies will need to be downloaded by executing this command in the project root:

```bash
dotnet restore
```

Update the following in `appsettings`

- url - Application Url to run tests against

Ensure the proper browser drivers(s) is(are) downloaded locally: see below.

Build the tests project

```bash
dotnet build
```

Run the tests by executing:

```bash
dotnet test
```

You may need to re-install Playwright, by

```bash
playwright install
```

## Implementation Guidelines

#### Automation Coding Standards

1. PageObject Models should be implemented by following of KISS, YAGNI and DRY principles
2. Classes, Methods, Fields, Constants and Properties should be named by following C# Naming Conventions
``` C#
/// <Summary>
/// Use camel-case style for Class/Interface naming.
/// </summary>
public class Example
{
  ... _fields
  ... Properties
  ... Constructors
  ... Methods
}

public interface IExample
{

}

/// <Summary>
/// Use camel-case style for property/field naming.
/// Public or protected property/field name begins with upper case.
/// </summary>
public void PublicPropertyName {get; set; }
protected void ProtectedPropertyName {get; set; }

/// <Summary>
/// Use camel-case style for method naming.
/// Private field name begins with lower case.
/// </summary>
private void privatePropertyName;

/// <Summary>
/// Use camel-case style for method naming.
/// Public/protected/private method begins with upper case.
/// </summary>
public void PublicMethodName()
{

}
```

3. Page Object Model is code representation of particular page of the application. Therefore, it should contain only elements and methods that are related to a particular page.
4. Use regions in POMs to device code into logical structures.
```
#region Selectors

# endregion

#region Fields and Properties

# endregion

#region Constructors

# endregion

#region Methods

# endregion
```

5. Methods inside POMs should do only one logical action
6. Description and comments should escape all characters

| Invalid XML Characters| Replace With|
| --------------------- |------------ |
| <                     | \&lt;       |
| >                     | \&gt;       |
| "                     | \&quot;     |
| '                     | \&apos;     |
| &                     | \&amp;      |

7. Variables names should be meaningful and not shortened. 
```c#
/// <Summary>
/// Variable names should be meaningful and not shortened.
/// </summary>
public void VariablesNames()
{
  /*** DON'T DO ***/
  var docMatDat = DateTime.Now;
  
  /*** DO ***/
  var documentModifcationDate = DateTime.Now;
}
```
8. If some magic number or magic string is used only in a single place - create local constant with meaningful name
```c#
/// <Summary>
/// DO
/// </summary>
public void LocalConstantsUsage()
{
  const int pageSize = 30;
  SomeMethod(pageSize);
}

/// <Summary>
/// DON'T DO
/// </summary>
public void LocalConstantsUsage()
{
  SomeMethod(30);
}
```
9. Parameters in methods and constructors should be aligned and readable.
10. Passed Parameters to the method should be aligned, formatted and readable.
```c#
public void PassingParametersToMethodFormatting()
{
    /// DON'T DO
    
    Do(new SomeLongTypeNameForExample(), new SomeLongTypeNameForExample(), new SomeLongTypeNameForExample(), new SomeLongTypeNameForExample());
    
    /// DO
    
    Do(new SomeLongTypeNameForExample(), 
       new SomeLongTypeNameForExample(), 
       new SomeLongTypeNameForExample(), 
       new SomeLongTypeNameForExample());   
}
```
11. Use Switch expressions instead of if-else-if wherever possible to make code simple and readable.
12. Code should be logically split into commits.
13. Solution should be built before creating Pull Requests without errors or warnings.
14. After Pull Request is created, all GitActions checks should pass.
15. Use LINQ where possible to make code simple and readable.
16. Use Switch expressions instead of if-else-if wherever possible to make code simple and readable.
```c#
// DON'T DO
if(_action.ToLower(.Equals(Open)))
{
  Page.OpenItem();
}
else if (_action.ToLower(.Equals(Close)))
{
  Page.CloseItem();
}
else if (_action.ToLower(.Equals(Edit)))
{
  Page.EditItem();
}

// DO
switch (_action)
{
  case {} when _action.Equals(Open, StringComparison.InvariantCultureIgnoreCase):
   Page.OpenItem();
   break;
   case {} when _action.Equals(Close, StringComparison.InvariantCultureIgnoreCase):
   Page.CloseItem();
   break;
   case {} when _action.Equals(Edit, StringComparison.InvariantCultureIgnoreCase):
   Page.EditItem();
   break;
}
```
#### Page Object Models

Method naming convention should be based on user intent. Avoid too much granularity and avoid prefixing each method.
```c#
/// DON'T 
page.ClickNewButton();
page.ClickSave();
page.ClickEditButton();

// DO
page.AddItem();
page.SaveItem();
page.EditItem();
```
#### Assertions

Assertion methods naming convention should be based on user intent. Avoid too much granularity and avoid prefixing each method.
Assertions methods should begin with Validate, Verify or Assert.
Use Validation assertions fluent assertions for assertions.

```c#
/// DON'T 
page.TextShouldContain();
page.ItemShouldNotBeInTheList();

// DO
page.ValidateTextIs();
page.VerifyItemCreated();
page.VerifyItemDeleted();
```



