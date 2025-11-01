**Expense Tracker (Console Application)**

A simple and functional C# console application for tracking personal expenses.
This project allows users to record, remove, view, and export expenses in multiple categories, with all data saved locally in JSON files.

**Features**

- **Add Expenses**
Add new expenses to one of four categories: Groceries, Clothing, Housing, or Other.
- **Remove Expenses**
Remove specific items by selecting them from a displayed list.
- **Display Expenses**
View expenses from a single category or view all categories at once.
Automatically displays the total for each category and for all expenses combined.
- **Clear Expense Lists**
Clear one or all categories, with confirmation prompts to avoid accidental deletion.
- **Export Expenses**
Save all current expenses to a expenses.txt file for external viewing or backup.
- **Persistent Storage**
Expenses are automatically saved and loaded from JSON files (groceries.json, clothing.json, housing.json, and other.json).

**Technologies Used**

**Language:** C#
**Framework:** .NET 6.0 or later
**Data Format:** JSON (using System.Text.Json)
**File I/O:** Local file persistence for storing expenses

**Getting Started**

**Prerequisites**

- .NET 6 SDK or later
- A code editor such as Visual Studio, Visual Studio Code, or Rider, or
- Download the current build from Releases

**Installation**

**1. Clone the repository:**
- git clone https://github.com/your-username/ExpenseTracker.git

**2. Navigate to the project folder:**
- cd ExpenseTracker

**3. Build the project:**
- dotnet build

**4. Run the application:**
- dotnet run

**Usage**

When the program starts, you’ll see a main menu with options:

EXPENSE TRACKER
---------------
1. Add expense
2. Remove expense
3. Display expenses
4. Clear expense list
5. Export expenses
6. Exit application

**Typical workflow**

1. Add a few expenses to different categories.
2. Display your expenses to verify totals.
3. Optionally remove or clear entries.
4. Export the final report to expenses.txt.

All data is saved automatically to local JSON files.

**File Structure**

ExpenseTracker/
│
├── Program.cs           # Main application loop
├── Helpers.cs           # Helper methods for logic, display, and persistence
├── groceries.json       # Saved expenses (auto-created)
├── clothing.json        # Saved expenses (auto-created)
├── housing.json         # Saved expenses (auto-created)
├── other.json           # Saved expenses (auto-created)
└── expenses.txt         # Exported report (generated on demand)

Example Output
GROCERIES
-----------
1. Bread - 2.49€
2. Milk - 1.89€
-----------
 Total: 4.38€

Total of all expenses: 4.38€

**Possible future Improvements:**

- Add monthly or yearly summaries
- Support sorting and searching expenses

- 
- Export to CSV format
- Add configuration options for custom categories

**License**

This project is released under the MIT License.
You are free to use, modify, and distribute this software.
