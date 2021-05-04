# department_admin_employee
Registering users / roles / assigning permissions

**Requirement:**

* Consider the following :
  * A user has: name, email, department and password
  * A user can adopt one or more roles
  * There is a hierarchy of roles.
  * By default there are two roles:
   * Employee and Manager
  * Any role will also be an Employee.



  * Users in a role have certain permissions
  * The permissions can be: read, add, update and delete
  * By default a Manager can perform all the operations
  * By default an Employee can only read



* The application must allow:
  * Register users. Verify that there is no other user with the same email.
  * Register roles. Be careful with the inheritance of roles. Don't define recursive roles.
  * Assign permissions to roles
  * Assign roles to users
  * Determine the permissions of a user based on her roles.
  * Notify the Manager that a user has been registered in their department

