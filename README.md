Here's a polished README for your Library Management System project:

```markdown
# Library Management System

## Project Overview

The **Library Management System** is a robust application built using **ASP.NET Core MVC**, **Entity Framework**, and **MSSQL**. It provides a complete solution for managing a library's operations, including book management, user roles, and reporting. This system caters to three types of users: **Administrators**, **Librarians**, and **Members**. Each role has specific privileges and responsibilities, ensuring a streamlined and efficient library management experience.

## Features

### Administrator
- **Full System Access**: Complete control over the system.
- **Manage Books**: Add, edit, and delete books.
- **Manage Authors, Publishers, and Categories**: Maintain a comprehensive catalog.
- **User Management**: 
  - Create and manage librarian and member accounts.
  - Set borrowing limits for members.
  - Define re-issue limits for books.

### Librarian
- **Book Issuance**: Issue books to members within their borrowing limits.
- **Returns Management**: Process book returns and calculate overdue fines.
- **Reporting**:
  - Generate detailed reports on books, authors, publishers, and categories.
  - Track issued and overdue books.
- **Book Search**: 
  - Search by title, author, publisher, or category.
  - Check availability of copies in the library.
- **Extend Return Dates**: Manage book return date extensions based on availability.

### Member
- **Book Search**: Search for books by title, author, publisher, or category.
- **Request Management**:
  - Request to issue or return a book within the member's borrowing limits.
- **Account Overview**: 
  - View issued books, unpaid overdue fines, and borrowing history.
  - Edit profile, including uploading a profile picture and changing contact info.
  - Request account deletion if no books are issued and no overdue fines are pending.

## Installation and Setup

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/library-management-system.git
   cd library-management-system
   ```

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

