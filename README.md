# Project

Project 2 - Avanade Practical Project


BRIEF

The project requires to making an application that generates “Objects” with a service service-orientated architecture with 2 different implementations:

* Service 1: Service's frontend; renders the HTML needed to interact with the application, communicate with the other 3 services, and persists     data in an SQL database.
  
* Service 2 & 3: Generate a random “Object” such as:
            - Random number
            - Random letter
            - Pull an item from an Array
            - Pull from a .csv
            - Pull from a database
            - API call to an external AP
     
* Service 4: Creates an “Object” based upon the results of service 2 + 3 using some pre-defined rules.
  
Implementations must perform swapping out for each other seamlessly, without disrupting the user experience.


REQUIREMENTS

1. Clear documentation 
2. A Kanban boards
3. Risk assessment
4. A fully integrated app using the Feature-Branch model into a Version Control System.
5. Azure Pipelines 
6. Deployed using Azure 


APPROACH

Step 1 

A service that creates Aliases to concil ones true identity was developed by having:
- Service 2 generating random names from a collection of 20 names 
- Service 3 generating random suranmes from a collecion of 20 surnames
- Service 4 combining names and surnames services to generate the Alias
The service's backbone is composed by Service 1, which is the frontend of the application

Step 2

The next step was to define the project management framework, Agile Scrum Framework. A Kanban board was created to identify project requirement and project backlog with user stories.

![image](https://user-images.githubusercontent.com/82107383/122572642-d6343a80-d045-11eb-909a-5fb43f41577b.png)

Step 3

A risk assessment was developed to evaluate the events that could negatively impact the project 
![risk assessment](https://user-images.githubusercontent.com/82107383/122806625-78f8ed00-d2c2-11eb-860a-b6a88bb9acdf.PNG)

![risk assessment](https://user-images.githubusercontent.com/82107383/122806625-78f8ed00-d2c2-11eb-860a-b6a88bb9acdf.PNG)

Step 4

Once evaluating the potential risks, the service's code was written to generate the Aliases as shown below 

![Frontend](https://user-images.githubusercontent.com/82107383/122808323-a9da2180-d2c4-11eb-9c7e-45ef613e0a08.PNG)

Step 5

The code was tested to ensure that the code is fully functional and it does not break

![code coverage](https://user-images.githubusercontent.com/82107383/122810951-d6436d00-d2c7-11eb-834b-d4b33e69f3ec.PNG)

https://user-images.githubusercontent.com/82107383/122810802-abf1af80-d2c7-11eb-9f65-aea7ef70d8c3.mp4
