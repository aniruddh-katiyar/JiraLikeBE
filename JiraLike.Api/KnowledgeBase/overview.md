JiraLike is a Jira-like project management application.

The application allows users to create and manage projects.
Each project can contain multiple issues.
Issues are used to track tasks, bugs, or work items.
Users can update issue status and add comments.

The backend is implemented using .NET Web API following clean architecture principles.
The frontend is implemented using Angular and communicates with the backend through REST APIs.

SQLite is used as the database for storing application data.
SignalR is used to support real-time updates such as issue changes and notifications.

The application is containerized using Docker.
The backend is deployed on Render.
The frontend is deployed on Vercel.
