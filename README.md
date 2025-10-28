# WSOA - Water Station Online Appointment

A simple application built with **ASP.NET Core Blazor Server** used for online transactions of water refill servicers.

## 🎯 Overview

With a simple, interactive web interface, this application uses Entity Framework Core to show basic database operations. It is intended for learning C# web development and object-oriented programming ideas.

## 🚀 How to Run

### Prerequisites
- .NET 8 SDK
- Visual Studio Code (recommended)

### Simple Instructions
1. **Navigate to the project directory**:
   ```bash
   **Admin POV**
   cd /workspaces/OOPsie/Admin
   **Customer POV**
   cd /workspaces/OOPsie/Customer
   **Login and Signup Page**
   cd /workspaces/OOPsie/LoginSignup
   ```

2. **Build the application**:
   ```bash
   dotnet build
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. **Open in browser**:
   - The application will show the URL (usually `http://localhost:5000` or similar)
   - Open that URL in your web browser

## 📱 How to Use the Application

### Sign-Up
1. Fill up the **full Name, username, address**
2. Add an **email address**
3. Enter the **contact number** 
4. Create a **password** and confirm by typing it again
5. Agree to the **terms and conditions** of creating an account
6. Click **"Create Account"** button

### Login
1. Choose whether to login as **Customer or Admin**
2. Write the **username** and **password**
3. Click the **login** button

### Admin POV
1. Open the **Home** page to view the sales summary
2. Open the **Orders** page to modify the order status
3. Press the **Order Status** of an order to change it to either **pending, picked up, delivered, or cancelled**
4. Press the **Payment Status** of an order to change it to either **pending, successful, failed, or refunded** 
5. Click **Search & Filter** to search for specific **name, status, or date & time**
6. Open the **Feedback** page to view the feedbacks
7. Click the **"reply"** button to reply on the feedbacks
8. Press **"send"** to post the reply
9. Open the **About Us** page to view information about the page

### Customer POV
1. Open the **Home** page to see what the site has to offer
2. Open the **Place Order** page to place an order
- **Select** your answer on the questions asking if you have a gallon and if you want to purchase one
- Choose the **type of gallon** and enter the **quantity** you want to **purchase**
- Write the **customer name** that you want to put in the gallon
- Choose the **type of gallon** and enter the **quantity** you want to **refill**
- Select the **payment method** by clicking the drop-down button
- Click the **"Place Order"** button to place the order
3. Open the **Order History** page to see your order status and history
4. Open the **Feedback** page to view other people's feedback as well as to write your own
- Enter your **feedback** about the product/service
- Choose if you want to make your name **hidden** for other users or not
- Select the **ratings** that you'll give to the system and company
- Click the **Submit Feedback** button to post your comment
5. Open the **About Us** page to view information about the page


### Logging Out
1. Click the **Logout** button to sign out of the program

## 🏗️ Project Structure
```
## 🗂 Project Structure

OOPsie/
├── Admin/
│   ├── Components/
│   │   ├── Layout/                   
│   │   │   └── MainLayout.razor          # Main layout for admin interface
│   │   └── Pages/                        # Admin pages
│   │       ├── Home.razor                # Admin dashboard or overview
│   │       ├── Order.razor               # Manage customer orders
│   │       ├── Feedback.razor            # View or manage customer feedback
│   │       └── AboutUs.razor             # Information about the business
│   ├── Routes.razor                      # Routing configuration for Admin
│   └── App.razor                         # Root Admin component
│
├── Customer/
│   ├── Components/
│   │   ├── Layout/                       
│   │   │   └── MainLayout.razor          # Layout for customer pages
│   │   └── Pages/                        # Customer pages
│   │       ├── Home.razor                # Customer homepage
│   │       ├── OrderPlace.razor          # Place new order page
│   │       ├── OrderHistory.razor        # View past orders
│   │       ├── Feedback.razor            # Submit feedback form
│   │       └── AboutUs.razor             # About the company page
│   ├── Routes.razor                      # Routing configuration for Customer
│   └── App.razor                         # Root Customer component
│
├── LoginSignup/
│   ├── Components/
│   │   └── Pages/
│   │       ├── Login.razor               # Login page
│   │       └── Signup.razor              # Signup page
│   └── Routes.razor                      # Routing for authentication pages
│
├── Data/
│   └── Entities/
│       ├── User.cs                       # User entity model
│       └── Order.cs                      # Order entity model
├── AppData/
│   └── app.db                            # SQLite database file
│
├── Program.cs                            # Application startup configuration
└── OOPsie.csproj                         # Project file
```

## 🚨 Important Links
1. Figma - https://www.figma.com/design/qDKawO6WHZ6pZayIyJRWcE/Wireframing-WSOA?node-id=0-1&t=2q8IbWdNnUfIcZg5-1
2. UML - /workspaces/OOPsie/UML.puml OR https://drive.google.com/file/d/1J8QeOCYmqnLIjpQS3NhUWjs6BF_PW3Lr/view?usp=sharing

