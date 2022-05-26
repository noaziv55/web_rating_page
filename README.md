# WebApi
## Table of Contents
1. Introduction
2. Demonstration Images
3. Dependencies
4. Setup and User Guide
5. Contributors

***

# 1. Introduction

In this project we created ASP.net project for rating the [ChatApp website](https://github.com/noaziv55/web_rating_page).
  

***

# 2. Demonstration Images
### The openning Page:
![RatingPage](https://user-images.githubusercontent.com/92301625/170515616-56e92138-92e7-452c-9d99-956aad054ec6.png)
### Adding new rate:
![CreatenewRate](https://user-images.githubusercontent.com/92301625/170515657-d63f6cbc-bec0-4566-ae13-0384658d9c10.png)
![rating](https://user-images.githubusercontent.com/92301625/170515701-0b7805cc-1a23-4655-8d6c-f482211f392b.png)
### Serching:
![searching1](https://user-images.githubusercontent.com/92301625/170515670-dbc78954-cbea-41e4-8a77-80361456d42a.png)
![Searching2](https://user-images.githubusercontent.com/92301625/170515731-11125258-33ee-4c2f-a70d-f57b14ad5104.png)

***

# 3. Dependencies

This Web-Api server uses:
* NuGet packeges:
  * Microsoft.EntityFrameworkCore.Tools
  * Pomelo.EntityFrameworkCore.MySql

***

# 4. Setup and User Guide
## 4.1 Setup

* Clone the repo: 
  ```bash
  git clone https://github.com/noaziv55/web_rating_page.git
  ```
* Delete the Migration folder.
* In Case you want to change the `domain` go to `Properties\launchSettings.json` file and change the RatingPage `applicationUrl`.
* Install the requied dependencies by entering to the Package Manager Console: 
   ```bash
   Install-Package Pomelo.EntityFrameworkCore.MySql -Version 6.0.1
   ```
   ```bash
   Install-Package Microsoft.EntityFrameworkcore.Tools -Version 6.0.1
   ```
* Create a migartion by typing `Add-Migartion Init`
* Apply the migartion by typing `Update-Database`
* Run the server by press run project button in vs.
* Open `http://domain/` with a browser

## 4.2 User Guide

### How to create a new rate:
* Press on `Rate Us` button
* Fill all fields
* Press on `create` button
### How to search a specific feedback:
* Enter your search
* press on the `search` button

***

# 5. Contributors

* [Noam Gini](https://github.com/NoamGini)
* [Noa Ziv](https://github.com/noaziv55)

***
