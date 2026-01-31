# Banking App 💳

A console-based banking application built in C# that allows users to create accounts, log in, perform transactions, and view their account history. This project demonstrates object-oriented programming principles such as **inheritance**, **polymorphism**, and **encapsulation**, as well as basic **user interface design** in the console.

---

## Features:

- **Account Creation**
  - Users can create **Cheque Accounts** or **Savings Accounts**.
  - PIN-protected accounts with 4-digit PINs.
  - Initial deposit validation.
  - Displays account number upon creation for future logins.

- **Login System**
  - Users log in using their **account number** and **PIN**.
  - Input validation ensures correct format.
  - Temporary session management using the logged-in account object.

- **Post-Login Menu**
  - **Deposit**: Add money to the account.
  - **Withdraw**: Remove money, with overdraft support for Cheque Accounts.
  - **Apply Interest**: Apply interest automatically for Savings Accounts.
  - **Transaction History**: View a detailed list of all transactions.
  - **Logout**: Exit back to the main menu.

- **Transaction Logging**
  - Every deposit, withdrawal, and interest application is recorded with timestamps.
  - Transaction history is accessible at any time.

---

## Architecture 🏛️

BankService
├── List<BankAccount>
├── CreateSavingsAccount()
├── CreateChequeAccount()
├── FindAccount()
└── Login()

BankAccount (abstract/base)
├── AccountNumber, HolderName, PIN, Balance
├── Deposit(), Withdraw(), ApplyInterest(), GetTransactionHistory()
└── Transactions log

SavingsAccount : BankAccount
└── Overrides ApplyInterest() with 5% interest

ChequeAccount : BankAccount
└── Overrides Withdraw() to allow overdraft up to R1000

---

## Installation & Running 💻

1. Clone the repository:
git clone https://github.com/YOUR_USERNAME/BankingApp.git

2. Open the solution in Visual Studio.

3. Build and run the project.

4. Navigate through the Main Menu to create an account, log in, and perform banking operations.

---

## Technologies & Concepts Used 🛠️

C# (Console Application)

Object-Oriented Programming (OOP)

Inheritance

Polymorphism

Encapsulation

Data Structures (List for account management)

Input validation and error handling

Transaction logging

Console-based user interface
