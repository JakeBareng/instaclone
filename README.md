## Front-End
https://github.com/JakeBareng/instacloneclient

# Instagram Clone

A functional Instagram clone built with **ASP.NET Core**, **C#**, **React**, and **PostgreSQL**, featuring image uploads, user profiles, and a post feed. Cloud storage is handled via **Azure Blob Storage**.

## Features
- **User Authentication**: Sign-up/login using ASP.NET Core Identity.
- **Image Uploads**: Secure image storage via Azure Blob Storage.
- **Post Feed**: View posts from users you follow.
- **Likes & Comments**: Engage with posts.
- **Responsive Design**: Works on all devices.

## Tech Stack
- **Frontend**: React, JavaScript, TypeScript, HTML, CSS, Bootstrap
- **Backend**: ASP.NET Core, C#, PostgreSQL
- **Cloud**: Azure Blob Storage

## Getting Started

### Prerequisites
- **Node.js**, **.NET SDK**, **PostgreSQL**, **Azure Blob Storage**

### Setup
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/instagram-clone.git
    ```
2. Backend setup:
    ```bash
    cd Backend
    dotnet restore
    dotnet run
    ```
3. Frontend setup:
    ```bash
    cd Frontend
    npm install
    npm start
    ```

## API Endpoints
- **POST** `/api/auth/register`: Register a user.
- **GET** `/api/posts`: Fetch posts from followed users.
- **POST** `/api/posts`: Create a post.

## License
This project is open source and available under the MIT License.
