// using System;
// using System.Diagnostics.CodeAnalysis;
// using Data.Models;
// using Microsoft.EntityFrameworkCore.Infrastructure;
// using Microsoft.EntityFrameworkCore.Migrations;

// namespace DeviceBE.Migrations

// {
//     [DbContext(typeof(CoreDbContext))]
//     [Migration("TableMigrations_202202271531")]
//     public class TableMigrations_202202271531: Migration 
    
//     {
//         protected override void Up(
//             [NotNullAttribute] MigrationBuilder migrationBuilder)
//         {
//                         migrationBuilder.CreateTable (
//              name: "Users",
//              columns: table => new
//              {
//                  Id = table.Column<int>(nullable: false)
//                  .Annotation("SqlServer:Identity", "1, 1"),
//                  FirstName = table.Column<string>(nullable: false),
//                  LastName = table.Column<string>(nullable: false),
//                  Email = table.Column<string>(nullable: false),
//                  Role = table.Column<string>(nullable: false),
//                  Password = table.Column<string>(nullable: true),
//                  CreatedAt = table.Column<DateTime>(nullable: true),
//                  ModifiedAt = table.Column<DateTime>(nullable: true),
//                  Deleted = table.Column<string>(nullable: true),
//                  DeletedAt = table.Column<DateTime>(nullable: true),
//                  DeletedBy = table.Column<string>(nullable: true)

//              },
//              constraints: table =>
//              {
//                  table.PrimaryKey("PK_EmployeeID_Key", x => x.Id);
//              });
            
//         }
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name:"Employees");
//         }

//     } 
// }
