# 📚 Library Kiosk AVL Tree System

## Overview
This project implements an AVL Tree-based library system in C#.  
Books are stored in self-balancing binary search trees and can be ordered dynamically using different comparison rules (Title, Author, Publisher).

The system demonstrates AVL tree insertion, deletion, balancing, and in-order traversal through a console-based interface.

## Features
- AVL Tree self-balancing insertion
- Dynamic sorting using comparison delegates
- Sort by Title, Author, and Publisher
- Console-based user interface
- Insert and remove book operations
- Tree visualization in console

## Language & Version
- Language: C#
- Framework: .NET Console Application
- Version: .NET 6.0 or later (recommended)

## How to Run the Program

1. Clone the repository:
git clone https://github.com/NoahFordGit/LibraryKioskAVLTree.git

2. Open the project in Visual Studio or Visual Studio Code.

3. Build the project:
dotnet build

4. Run the program:
dotnet run

5. Ensure books.csv is located in the correct directory referenced in Program.cs.

## Deviations / Assumptions
- Duplicate books (based on comparison rule) are not inserted.
- Removal is primarily demonstrated using title-based matching.
- CSV input is assumed to be correctly formatted (Title, Author, Pages, Publisher).
- No persistent storage (data resets each run).

## Notes
This project demonstrates AVL Trees, recursion, and delegate-based sorting strategies in a structured console application.

Made for ETSU CSCI-2210 (Data Structures and Algorithms)
