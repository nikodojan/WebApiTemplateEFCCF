using Microsoft.EntityFrameworkCore;
using WebApiTemplateV1.Controllers;
using WebApiTemplateV1.Data;
using WebApiTemplateV1.Managers;
using WebApiTemplateV1.Models;

namespace WebApiTemplateV1
{
    public class README
    {
        // ASP.NET Web API with EF Core CF - Latest update: 03.01.2022, 20:10 - V.0.202201032010

        // This class is for documentation purposes only and should be deleted after applying all changes.
        // This project is a basic template to implement a WebApi with repository pattern.
        // One of each of the following classes are implemented:
        // Entity model class: Item
        // DbContext: ApplicationDbContext
        // Manager class: ItemsManager
        // Api controller: ItemsController

        // !!! For renaming use the build in renaming or refactoring functions. Do not simply delete the old and write new name.
        // This file contains references to the rYou can use the references to the classes/types in this file by clicking on the type name (e.g. Item) and using CTRL+R,R

        // Item - Model class with one property
        // TODO: Use the refactoring/renaming function of the IDE to rename the model to whatever your model is supposed to be, e.g. Book.
        // TODO: Implement the rest of the model class.
        private Item _item;

        // ApplicationDbContext - Context class with one DbSet property
        // The DbContext is already registered in the Startup.cs for dependency injection in the manager.
        // TODO: Use the refactoring/renaming function to rename the Items property to the name you need, e.g. Books. 
        private static ApplicationDbContext _context;
        private DbSet<Item> testSet = _context.Items;

        // ItemsManager - Manager class for Items
        // The manager is already registered in the Startup.cs for dependency injection into the controller.
        // TODO: Use the refactoring/renaming function to rename manager, e.g. BooksManager.
        private ItemsManager _manager;

        // ItemsController - Controller for Items, uses ItemsManager
        // Implemented methods: Get, GetById, Post, Put, Delete
        // TODO: Use the refactoring/renaming function to rename manager, e.g. BooksManager.
        private ItemsController _controller;

        // TODO: Add a connection string for the database in appsettings.json file

        // Furthermore:
        // CORS - Configured in Startup.cs to allow all origins, methods and headers.
        // Swagger - Configured

        // TODO: add a migration and update the database
        // In Package Manager Console use
        // Add-migration <migration name>
        // update-database
    }
}
