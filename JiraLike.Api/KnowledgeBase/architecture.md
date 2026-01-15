JiraLike is a Jira-like project management application designed to manage and track work items.

The application allows users to create and manage projects.
Each project acts as a container for related work items.

Within a project, users can create issues.
Issues are used to represent tasks, bugs, or work items.
Each issue contains information such as title, description, and status.

Users can update issue status to track progress.
Users can also add comments to issues for collaboration and discussion.

The backend of the application is implemented using .NET Web API.
The backend follows clean architecture principles to separate concerns and improve maintainability.

The frontend of the application is implemented using Angular.
The frontend communicates with the backend through REST APIs.

SQLite is used as the database to store application data such as projects, issues, and comments.

SignalR is used to provide real-time updates.
When issues are created or updated, connected clients receive notifications without refreshing the page.

The application is containerized using Docker.
The backend service is deployed on Render.
The frontend application is deployed on Vercel.
