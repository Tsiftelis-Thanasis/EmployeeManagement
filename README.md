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
