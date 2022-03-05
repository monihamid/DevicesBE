using System;
using FluentMigrator;
using FluentMigrator.SqlServer;

namespace DevicesBE.Data.Migrations
{
    [Migration(202202261248)]    
    public class CreateTables: Migration  
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity(1, 1)  //better UUID or GUID
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable().Indexed()
                .WithColumn("Role").AsString().NotNullable().Indexed()   //admin or tenant
                .WithColumn("Password").AsString().Indexed().Nullable()               
                .WithColumn("CreatedAt").AsCustom("datetime").NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("ModifiedAt").AsCustom("datetime").Nullable()
                .WithColumn("Deleted").AsBoolean().WithDefaultValue(false)
                .WithColumn("DeletedAt").AsCustom("datetime").Nullable()
                .WithColumn("DeletedBy").AsString().Indexed().Nullable(); 
                //seed data
                Insert.IntoTable("Users").Row(new {  FirstName = "Tester1", LastName = "Tester", Email = "Tester1@gmail.com", Role = "Admin", CreatedAt = DateTime.Now });
                Insert.IntoTable("Users").Row(new {  FirstName = "Tester2", LastName = "Tester", Email = "Tester2@gmail.com", Role = "Admin",CreatedAt = DateTime.Now });
                Insert.IntoTable("Users").Row(new {  FirstName = "Tester3", LastName = "Tester", Email = "Tester3@gmail.com", Role = "Admin", CreatedAt = DateTime.Now });
                Insert.IntoTable("Users").Row(new {  FirstName = "Tester4", LastName = "Tester", Email = "Tester4@gmail.com", Role = "Admin", CreatedAt = DateTime.Now });
                
                Create.Table("Claims")
                .WithColumn("Id").AsInt32().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("ClaimValue").AsString().NotNullable().Indexed()
                .WithColumn("CreatedAt").AsCustom("datetime").NotNullable().WithDefault(SystemMethods.CurrentDateTime);
                
                Create.ForeignKey("FK_Users_Id_Claims_UserId")
                    .FromTable("Claims").ForeignColumn("UserId")
                    .ToTable("Users").PrimaryColumn("Id");

                Create.Table("DeviceType")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("DeviceType").AsString().NotNullable().Indexed()
                .WithColumn("Description").AsString().NotNullable().Indexed()
                .WithColumn("CreatedAt").AsCustom("datetime").NotNullable().WithDefault(SystemMethods.CurrentDateTime);
                //seed data
                Insert.IntoTable("DeviceType").Row(new {  DeviceType = "CCTV", description = "CCTV cameras", CreatedAt = DateTime.Now });
                Insert.IntoTable("DeviceType").Row(new {  DeviceType = "Scanner", description = " Door Frame Metal Detectors", CreatedAt = DateTime.Now });
                
                Create.Table("UserDevices")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity(1, 1)
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("MacAddress").AsString().NotNullable().Unique()
                .WithColumn("DeviceTypeId").AsInt32().NotNullable()
                .WithColumn("Status").AsString().NotNullable().Indexed()  //Online or offline
                .WithColumn("Temparature").AsString().NotNullable().Indexed()
                .WithColumn("CreatedAt").AsCustom("datetime").NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("Deleted").AsBoolean().WithDefaultValue(false)
                .WithColumn("DeletedAt").AsCustom("datetime").Nullable()
                .WithColumn("DeletedBy").AsString().Indexed().Nullable();
                
                Create.ForeignKey("FK_Users_Id_UserDevices_UserId") // You can give the FK a name or just let Fluent Migrator default to one
                    .FromTable("UserDevices").ForeignColumn("UserId")
                    .ToTable("Users").PrimaryColumn("Id");
                
                Create.ForeignKey("FK_Device_Type_UserDevices_DeviceTypeId")
                    .FromTable("UserDevices").ForeignColumn("DeviceTypeId")
                    .ToTable("DeviceType").PrimaryColumn("Id");
                //seed data    
                Insert.IntoTable("UserDevices").Row(new {  UserId = 1, MacAddress = "aa.q2.w3e.12", DeviceTypeId = 1,  Status = "Available", Temparature = "34 C", CreatedAt = DateTime.Now });
                Insert.IntoTable("UserDevices").Row(new {  UserId = 2, MacAddress = "ab.q3.w3e.12", DeviceTypeId = 2,  Status = "Available", Temparature = "34 C", CreatedAt = DateTime.Now });

                 Create.Table("DeviceUsage")    
                .WithColumn("Id").AsInt32().NotNullable()
                .WithColumn("DeviceMacAddress").AsString().NotNullable().PrimaryKey()
                .WithColumn("Usage").AsString().NotNullable().Indexed()
                .WithColumn("UseDate").AsCustom("datetime").NotNullable()
                .WithColumn("CreatedAt").AsCustom("datetime").NotNullable().WithDefault(SystemMethods.CurrentDateTime);
                
                Create.ForeignKey("FK_Users_Id_DeviceUsage_UserId") // You can give the FK a name or just let Fluent Migrator default to one
                    .FromTable("DeviceUsage").ForeignColumn("DeviceMacAddress")
                    .ToTable("UserDevices").PrimaryColumn("MacAddress");

                
                 


        }
        public override void Down()
        {
            Delete.Table("Users");
            Delete.Table("Claims");
            Delete.Table("DeviceType");
            Delete.Table("UserDevices");
            throw new System.NotImplementedException();
        }
        
    }
}
