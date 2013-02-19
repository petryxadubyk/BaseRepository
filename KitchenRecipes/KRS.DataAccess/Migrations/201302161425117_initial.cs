namespace KRS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Description = c.String(),
                        IsDelivered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Category_Id = c.Int(),
                        NationalCategory_Id = c.Int(),
                        Ingredient_Id = c.Int(),
                        CookProcess_Id = c.Int(),
                        Kitchenware_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipeCategory", t => t.Category_Id)
                .ForeignKey("dbo.NationalCategory", t => t.NationalCategory_Id)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_Id)
                .ForeignKey("dbo.CookProcess", t => t.CookProcess_Id)
                .ForeignKey("dbo.Kitchenware", t => t.Kitchenware_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.NationalCategory_Id)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.CookProcess_Id)
                .Index(t => t.Kitchenware_Id);
            
            CreateTable(
                "dbo.RecipeCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NationalCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoPath = c.String(nullable: false),
                        Order = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Recipe_Id = c.Int(),
                        Ingredient_Id = c.Int(),
                        CookProcess_Id = c.Int(),
                        Kitchenware_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_Id)
                .ForeignKey("dbo.CookProcess", t => t.CookProcess_Id)
                .ForeignKey("dbo.Kitchenware", t => t.Kitchenware_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.CookProcess_Id)
                .Index(t => t.Kitchenware_Id);
            
            CreateTable(
                "dbo.KRSUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        LastLoginTime = c.DateTime(),
                        Activated = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IngredientCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KitchenwareCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IngredientCategory", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.CookProcess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kitchenware",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KitchenwareCategory", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.RecipeSchema",
                c => new
                    {
                        SchemaId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        RecipePartId = c.Int(nullable: false),
                        RecipePartMajor = c.Int(),
                    })
                .PrimaryKey(t => t.SchemaId);
            
            CreateTable(
                "dbo.KRSUserRecipe",
                c => new
                    {
                        KRSUser_Id = c.Int(nullable: false),
                        Recipe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KRSUser_Id, t.Recipe_Id })
                .ForeignKey("dbo.KRSUser", t => t.KRSUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id, cascadeDelete: true)
                .Index(t => t.KRSUser_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.KRSUserRecipe", new[] { "Recipe_Id" });
            DropIndex("dbo.KRSUserRecipe", new[] { "KRSUser_Id" });
            DropIndex("dbo.Kitchenware", new[] { "Category_Id" });
            DropIndex("dbo.Ingredient", new[] { "Category_Id" });
            DropIndex("dbo.Photo", new[] { "Kitchenware_Id" });
            DropIndex("dbo.Photo", new[] { "CookProcess_Id" });
            DropIndex("dbo.Photo", new[] { "Ingredient_Id" });
            DropIndex("dbo.Photo", new[] { "Recipe_Id" });
            DropIndex("dbo.Recipe", new[] { "Kitchenware_Id" });
            DropIndex("dbo.Recipe", new[] { "CookProcess_Id" });
            DropIndex("dbo.Recipe", new[] { "Ingredient_Id" });
            DropIndex("dbo.Recipe", new[] { "NationalCategory_Id" });
            DropIndex("dbo.Recipe", new[] { "Category_Id" });
            DropIndex("dbo.Delivery", new[] { "CustomerId" });
            DropForeignKey("dbo.KRSUserRecipe", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.KRSUserRecipe", "KRSUser_Id", "dbo.KRSUser");
            DropForeignKey("dbo.Kitchenware", "Category_Id", "dbo.KitchenwareCategory");
            DropForeignKey("dbo.Ingredient", "Category_Id", "dbo.IngredientCategory");
            DropForeignKey("dbo.Photo", "Kitchenware_Id", "dbo.Kitchenware");
            DropForeignKey("dbo.Photo", "CookProcess_Id", "dbo.CookProcess");
            DropForeignKey("dbo.Photo", "Ingredient_Id", "dbo.Ingredient");
            DropForeignKey("dbo.Photo", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "Kitchenware_Id", "dbo.Kitchenware");
            DropForeignKey("dbo.Recipe", "CookProcess_Id", "dbo.CookProcess");
            DropForeignKey("dbo.Recipe", "Ingredient_Id", "dbo.Ingredient");
            DropForeignKey("dbo.Recipe", "NationalCategory_Id", "dbo.NationalCategory");
            DropForeignKey("dbo.Recipe", "Category_Id", "dbo.RecipeCategory");
            DropForeignKey("dbo.Delivery", "CustomerId", "dbo.Customer");
            DropTable("dbo.KRSUserRecipe");
            DropTable("dbo.RecipeSchema");
            DropTable("dbo.Kitchenware");
            DropTable("dbo.CookProcess");
            DropTable("dbo.Ingredient");
            DropTable("dbo.KitchenwareCategory");
            DropTable("dbo.IngredientCategory");
            DropTable("dbo.KRSUser");
            DropTable("dbo.Photo");
            DropTable("dbo.NationalCategory");
            DropTable("dbo.RecipeCategory");
            DropTable("dbo.Recipe");
            DropTable("dbo.Customer");
            DropTable("dbo.Delivery");
        }
    }
}
