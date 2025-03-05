# **Banking Management System** 🏦  

## **Project Overview**  
The **Banking Management System** is a C# console-based application that allows users to create and manage bank accounts. It provides functionalities such as account creation, deposits, withdrawals, and balance inquiries. The system supports both **Savings Accounts** and **Current Accounts** with specific withdrawal limits.

## **Features** ✨  
✅ **Account Creation** – Users can create Savings or Current accounts.  
✅ **Deposit Money** – Users can deposit money into their account.  
✅ **Withdraw Money** – Users can withdraw money (with specific limits for different account types).  
✅ **Balance Inquiry** – Users can check their account balance.  
✅ **Data Persistence** – All account details are stored in a text file (`example.txt`) for future reference.  

## **Project Structure** 📂  
```
📂 Banking-Management-System
│-- 📄 Bank Account Management System.sln            (Solution file)
│-- 📂 Bank Account Management System                (Main project folder)
│   │-- 📄 Program.cs                                (Main entry point)
│   │-- 📄 Bank Account Management System.csproj     (Includes project metadata)
│-- 📄 .gitignore                                    (File to exclude unnecessary files)
│-- 📄 README.md                                     (Project documentation)
```

## **Technologies Used** 🛠️  
- **C#** (Object-Oriented Programming)  
- **.NET Framework / .NET Core**  
- **File Handling** (Text file for storing account details)  

## **How to Run the Project** 🚀  
1. **Clone the Repository**  
   ```bash
   git clone https://github.com/Danyal-Raza/Banking-Management-System.git
   ```
2. **Open in Visual Studio 2022**  
   - Open `BankingManagementSystem.sln` in **Visual Studio**.  

3. **Run the Program**  
   - Press `Ctrl + F5` to run the console application.  

## **Usage Instructions**  
1️⃣ **Create an Account** – Choose between Savings or Current account.  
2️⃣ **Deposit Money** – Enter account number and deposit amount.  
3️⃣ **Withdraw Money** – Enter account number and withdrawal amount (limits apply).  
4️⃣ **Check Balance** – Enter account number to see current balance.  
5️⃣ **Exit** – Close the application.  

## **Future Enhancements** 🔥  
🚀 Implement a database for account storage instead of a text file.  
🚀 Add a graphical user interface (GUI) using **WinForms/WPF**.  
🚀 Add authentication (username/password) for better security.  
