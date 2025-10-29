<p align="center">
<img src="https://i.postimg.cc/tJjFPpFj/566713130-2648065195543491-8938382609362833392-n.png">
</p>

----

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

## Codes
### Admin POV
#### Home
```C#
@code {
    private string quote = string.Empty;
    private readonly string[] quotes =
    {
        "Every drop counts — keep pushing forward!",
        "Success flows like water — steady and unstoppable.",
        "Stay consistent, even when progress feels slow.",
        "Hard work beats talent when talent doesn't work hard.",
        "Be patient. Great results take time and persistence.",
        "Each small effort adds up to something big.",
        "You are not tired, you are just one step away from greatness."
    };

    protected override void OnInitialized()
    {
        var rand = new Random();
        quote = quotes[rand.Next(quotes.Length)];
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeVoidAsync("renderSalesChart");
        }
    }
}
```
Selects a random motivational quote and renders the sales chart
####  Order
```C#
@code {
    private List<OrderModel> orders = new();
    private List<OrderModel> filteredOrders = new();
    private bool showSearchPanel = false;
    private string searchName = "";
    private DateTime? searchDate;
    private string searchPaymentStatus = "";
    private bool groupByDay = false;

    protected override void OnInitialized()
    {
        // Sample data with dates, payment status, amounts, and addresses
        orders = new List<OrderModel>
        {
            new() { Id = "ORD-006", Customer = "Anna Cruz", Address = "123 Main St, Manila", Status = "Pending", 
                   PaymentStatus = "Pending", Amount = 125.50m,
                   OrderDate = DateTime.Today.AddHours(10).AddMinutes(30) },
            new() { Id = "ORD-005", Customer = "Marco Diaz", Address = "456 Oak Ave, Quezon City", Status = "Picked Up", 
                   PaymentStatus = "Successful", Amount = 89.99m,
                   OrderDate = DateTime.Today.AddHours(14).AddMinutes(15) },
            new() { Id = "ORD-004", Customer = "Jessa Flores", Address = "789 Pine St, Makati", Status = "Delivered", 
                   PaymentStatus = "Successful", Amount = 215.75m,
                   OrderDate = DateTime.Today.AddDays(-1).AddHours(9).AddMinutes(45) },
            new() { Id = "ORD-003", Customer = "Carlos Reyes", Address = "321 Elm St, Taguig", Status = "Pending", 
                   PaymentStatus = "Failed", Amount = 45.25m,
                   OrderDate = DateTime.Today.AddDays(-1).AddHours(16).AddMinutes(20) },
            new() { Id = "ORD-002", Customer = "Maria Santos", Address = "654 Maple Dr, Pasig", Status = "Picked Up", 
                   PaymentStatus = "Refunded", Amount = 150.00m,
                   OrderDate = DateTime.Today.AddHours(11).AddMinutes(0) },
            new() { Id = "ORD-001", Customer = "John Smith", Address = "987 Cedar Ln, Mandaluyong", Status = "Delivered", 
                   PaymentStatus = "Successful", Amount = 299.99m,
                   OrderDate = DateTime.Today.AddDays(-2).AddHours(13).AddMinutes(30) }
        };
        
        filteredOrders = orders;
    }

    private void ToggleSearchPanel()
    {
        showSearchPanel = !showSearchPanel;
    }

    private void ApplyFilters()
    {
        filteredOrders = orders.Where(order =>
            (string.IsNullOrEmpty(searchName) || 
             order.Customer.Contains(searchName, StringComparison.OrdinalIgnoreCase)) &&
            (!searchDate.HasValue || 
             order.OrderDate.Date == searchDate.Value.Date) &&
            (string.IsNullOrEmpty(searchPaymentStatus) || 
             order.PaymentStatus == searchPaymentStatus)
        ).ToList();
        
        StateHasChanged(); // Refresh UI after filtering
    }

    private void ClearFilters()
    {
        searchName = "";
        searchDate = null;
        searchPaymentStatus = "";
        groupByDay = false;
        filteredOrders = orders;
        StateHasChanged(); // Refresh UI after clearing filters
    }

    private void OnOrderStatusChange(OrderModel order, ChangeEventArgs e)
    {
        order.Status = e.Value?.ToString() ?? "Pending";
        StateHasChanged(); // Force UI refresh to update colors
        
        Console.WriteLine($"Order {order.Id} status changed to: {order.Status}");
    }

    private void OnPaymentStatusChange(OrderModel order, ChangeEventArgs e)
    {
        order.PaymentStatus = e.Value?.ToString() ?? "Pending";
        StateHasChanged(); // Force UI refresh to update colors
        
        Console.WriteLine($"Order {order.Id} payment status changed to: {order.PaymentStatus}");
    }

    private string GetOrderStatusClass(string orderStatus)
    {
        return orderStatus?.ToLower() switch
        {
            "pending" => "order-pending",
            "picked up" => "order-picked-up",
            "delivered" => "order-delivered",
            "cancelled" => "order-cancelled",
            _ => "order-pending"
        };
    }

    private string GetPaymentStatusClass(string paymentStatus)
    {
        return paymentStatus?.ToLower() switch
        {
            "pending" => "payment-pending",
            "successful" => "payment-successful",
            "failed" => "payment-failed",
            "refunded" => "payment-refunded",
            _ => "payment-pending"
        };
    }

    public class OrderModel
    {
        public string Id { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public decimal Amount { get; set; }  // Use decimal for currency
        public DateTime OrderDate { get; set; }  // Changed from DateTime? to DateTime
    }
}
```
### Customer POV
#### Home
```C#
```
### Login/Signup Pages

## 🚨 Important Links
1. Figma - [Figma](https://www.figma.com/design/qDKawO6WHZ6pZayIyJRWcE/Wireframing-WSOA?node-id=0-1&t=2q8IbWdNnUfIcZg5-1)
2. UML - [Relative Link](/UML.puml) OR [Google Drive](https://drive.google.com/file/d/1J8QeOCYmqnLIjpQS3NhUWjs6BF_PW3Lr/view?usp=sharing)
3. Logo - [Google Drive](https://drive.google.com/file/d/1Zp4fHttLC4M-Rqi34LmliEfKzrQ4-Np3/view)
