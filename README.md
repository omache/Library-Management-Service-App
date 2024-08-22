# Library Management System

![License](https://img.shields.io/badge/License-MIT-blue.svg)

## Project Overview

The **Library Management System** is a comprehensive web application built with ASP.NET Core MVC, Entity Framework, and MSSQL. It enables the efficient management of a library's operations and services through an intuitive interface for three distinct roles: Administrator, Librarian, and Member. This project demonstrates proficiency in full-stack development, with a focus on clean architecture, database management, and user experience.

## Features

### Administrator

- **Full System Access**: Administrators have complete control over the system, including the ability to manage books, authors, publishers, categories, and users (Librarians & Members).
- **User Management**: Set limits on the number of books a member can issue and the number of times a book can be re-issued.
- **Book Management**: Add, edit, and delete books, authors, publishers, and categories/genres.

### Librarian

- **Book Issuance**: Issue books to members, respecting individual member limits.
- **Returns and Fines**: Manage book returns and calculate/accept overdue fines.
- **Reporting**: Generate reports for all books, authors, publishers, categories, issued books, and overdue books.
- **Search and Availability**: Search for books by title, author, publisher, or category, and check the availability of copies.
- **Return Date Extension**: Extend book return dates upon request, with validation against other member requests.

### Member

- **Book Search**: Search for books by title, author, publisher, or category, and view available copies.
- **Book Requests**: Request to issue or return a book, adhering to member limits.
- **Account Management**: View issued books, unpaid overdues, and history of transactions. Edit profile information, upload a profile picture, and request account deletion.
- **Profile Management**: Members can update their personal details and password.

## Technologies Used

- **Backend**: ASP.NET Core MVC, C#
- **Frontend**: HTML5, CSS3, JavaScript
- **Database**: MSSQL with Entity Framework Core
- **IDE**: Visual Studio

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or higher)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (with ASP.NET and web development workload)

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/LibraryManagementSystem.git
    ```
2. Navigate to the project directory:
    ```bash
    cd LibraryManagementSystem
    ```
3. Update the database connection string in `appsettings.json` to match your SQL Server instance.
4. Apply migrations and update the database:
    ```bash
    dotnet ef database update
    ```
5. Run the application:
    ```bash
    dotnet run
    ```

### Usage

1. Access the application in your browser at `http://localhost:5000`.
2. Use the following default credentials to log in as an Administrator, Librarian, or Member:
    - **Administrator**: admin@example.com / Password123
    - **Librarian**: librarian@example.com / Password123
    - **Member**: member@example.com / Password123

### Testing

Unit tests and integration tests are provided to ensure the application's functionality. Run the tests using the following command:

```bash
dotnet test


2. **Database Setup**:
   - Ensure MSSQL is installed and running on your machine.
   - Update the `appsettings.json` file with your database connection string.
   - Run the following commands to apply migrations and seed the database:
     ```bash
     dotnet ef database update
     ```

3. **Run the Application**:
   ```bash
   dotnet run
   ```

4. **Access the Application**:
   - Open your browser and navigate to `https://localhost:5001`.

## Technologies Used

- **ASP.NET Core MVC**: Backend and frontend web development.
- **Entity Framework Core**: ORM for database management.
- **MSSQL**: Database management system.
- **HTML/CSS**: Styling and structure of the frontend.
- **JavaScript**: Dynamic and interactive user experience.

## Project Structure

- **Models**: Defines the data structures (e.g., Books, Authors, Users).
- **Controllers**: Manages the application logic and handles user input.
- **Views**: Renders the user interface.
- **Data**: Handles database context and migrations.

## Contributions and Enhancements

This project is open for contributions! If you have ideas for new features or improvements, feel free to fork the repository and create a pull request. Any other feasible feature or option can also be included.


## Contact

For any inquiries or suggestions, feel free to reach out:

- Email: omacherenox@gmail.com
- GitHub: [Omache](https://github.com/omache)

---

