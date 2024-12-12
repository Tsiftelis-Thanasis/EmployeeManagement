I used Blazor Server and Blazor WebAssembly.

I need to mention:
I choose this approach because is one of the latest technologies.
I used WebAssembly because it's faster and is native to the browser. 
I used the Identity for the Login of the users, but I didn't configure any email service.
I used the EF for the mapping and the database access. 
The DB is a local and is added in the Git project.

The project covers the register and the login of a new user.
A razor page with the Skills, all the skills are listed in a Quick Grid with sorting and searching. The user can create, edit or delete a skill. This is implemented in a modal dialog and not in a page.
A razor page with the Employees, all of the employees are listed in a Quick Grid with sorting and searching. 
The user can create, edit or delete an employee. This is implemented in a modal dialog and not in a seperate page.
I didn't add a button to add skills in the mentioned dialog. The user can click on the Edit Skills button that's on the Grid and add or remove skills.

Also, it's missing proper try catch handling.


I didn't do the following:
Seperate page for the skills or the employee.
Logging, I used an existing Logger Interface. I used the LogError to log exceptions in the Event viewer of the machine.
Delete multiple employees (optional).
View details like when the employee's latest skillset change occurred (optional).
Assign existing skills to the new employee as part of the creation form (optional).
Assign non-existing skills as part of the employee creation (optional).
Since many employees share the same skill(s), it would be nice if a scheduler could filter
employees by a skill - or multiple skills - from Page D. The team is free to extend search
capabilities as they see fit.
Schedulers need to audit employee data changes, so access history logs would be a
feature that adds value to the product.
Many schedulers are comfortable with spreadsheets, so it would expedite their work if they
could export all skills in a spreadsheet or similar format.
Schedulers are using an external system as the record keeping system for employee
demographics. It would be a well received feature if the new product supports importing
employees from the external system. This can be a scheduled operation or manually
triggered by a scheduler. The team is free to decide the integration format. In any case, the
process should impose functional limits which make sense and it should never abuse the
system's resources.
