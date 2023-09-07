# Week 3 Assessment

## Setup
* Fork and Clone this repository
* Run `update-database` - let the instructors know if you run into any issues!

## Exercise (10 Points)
### Securing the Application (4 points)
* Use Secrets Managemnt to remove the database connection string from the application.
* So that we can see the full implmentation, include a screenshot below to show your `secrets.json` file

<img width="352" alt="Screenshot 2023-09-07 091741" src="https://github.com/RafiWick/Mod4Week3_Assessment/assets/130600943/0e984524-134e-4099-a12b-a2688e67d898">


### Maintaining Current-User (6 points)

This application includes some starter code so that we could maintain a current user.  Review the Login and Logout code in the Home Controller, along with the Login and Logout buttons in the Home/Index.cshtml file.  Building on this pre-existing structure:
* Create a cookie that holds a key for "currentUser" when a user logs in.
* Delete that cookie when a user logs out.
* Add the value of "current user" to all views

## Questions (10 Points)

For the following questions, answer as if you are in an interview!
1. Describe one strategy you have used to maintain state in a web application. (2 points)
  One strategy that I have used to maintain the state in a web application is the use of cookies. With cookies I can set user specific variables that persist on the users client allowing my program to remember things like: what user is currently logged in; what progress has the user made in a series of forms; or even personalized UI/UX preferences.
2. How would you protect sensitive data that we need to store in our database - for example, passwords? (2 points)
  In order to safely store sensitive data in my database I would use a hashing function to remove the meaning of the data. For passwords this stored data doesn't need to be able to be unencrypted and a hashed entry of the password can match the stored hashed value. with other sensitive datatypes like social security nembers that may need to be seen as they are I would use a public key to encript the data before its stored and use a private key to unencrypt it as needed.
3. Describe 3 additional common security risks in web development. (make sure you discuss what you know about the risk, and if you know how to minimize the risk) (6 points)
   1. Overposting is when a bad actor uses html or an api request to provide more data than the program is requesting and then changing things in the database you dont want being changed, such as, someone elses password, admin permissions, or even a DateTime property that is supposed to be permenent. In order to prevent this you can use DTOs (data transfer objects) to only take the data that is specified as something you want to be able to take.
   2. Direct Denile of Service is when a bad actor sends a mass of requests in order to fill up the bandwidth of a server denying users the opportunity to use it. One way you can prevent this is with API Rate Limiting where you set a cap on how many requests a user can make per second stopping them from sending enough to cause the server to not be able to respond to real users.
   3. SQL injection is when a bad actor enters SQL commands into a data field changing the data returned, often in order to get sensitive data. One way to combat this is to use strict data typing both in the conroller actions as well as in the form fields so that SQL commands either cant be entered or get stopped before they are ran.

