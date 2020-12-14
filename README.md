### StackOF_Clone

This is a forum like stackoverflow. This project has some basic functionalities like posting question, commenting answer, voting etc.

### Technologies
* ASP .NET MVC Framework
* NHibernate, Fluent NHibernate
* Autofac MVC 5
* MS SQL Server

### Necessary Setups
* connectionString="Data Source=.\SQLEXPRESS; Initial Catalog =Onnorokom; Integrated Security=True;"
* Admin is seeded. Admin has all 3 roles. 1.Member, 2.Moderator, 3.Admin. Admin's userName = "admin@onnorokom.com"; password = "P@ss1234";
* Users can register, post questions, reply to other's questions.
* Admin can change roles of the users. To block someone, just change the roles.
* The member that creates a question and moderators has ability to accept answer.
* Users can upvote or downvote only once in a comment or question.
