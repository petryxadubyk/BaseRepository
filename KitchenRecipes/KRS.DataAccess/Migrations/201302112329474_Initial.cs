namespace KRS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Description = c.String(),
                        IsDelivered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Category_CategoryId = c.Int(),
                        NationalCategory_CategoryId = c.Int(),
                        Ingredient_Id = c.Int(),
                        CookProcess_Id = c.Int(),
                        Kitchenware_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipeCategories", t => t.Category_CategoryId)
                .ForeignKey("dbo.NationalCategories", t => t.NationalCategory_CategoryId)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id)
                .ForeignKey("dbo.CookProcesses", t => t.CookProcess_Id)
                .ForeignKey("dbo.Kitchenwares", t => t.Kitchenware_Id)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.NationalCategory_CategoryId)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.CookProcess_Id)
                .Index(t => t.Kitchenware_Id);
            
            CreateTable(
                "dbo.RecipeCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.NationalCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Photos",
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
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id)
                .ForeignKey("dbo.CookProcesses", t => t.CookProcess_Id)
                .ForeignKey("dbo.Kitchenwares", t => t.Kitchenware_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.CookProcess_Id)
                .Index(t => t.Kitchenware_Id);
            
            CreateTable(
                "dbo.KRSUsers",
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
                "dbo.IngredientCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.KitchenwareCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IngredientCategories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.CookProcesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kitchenwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KitchenwareCategories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.RecipeSchemas",
                c => new
                    {
                        SchemaId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        RecipePartId = c.Int(nullable: false),
                        RecipePartMajor = c.Int(),
                    })
                .PrimaryKey(t => t.SchemaId);
            
            CreateTable(
                "dbo.KRSUserRecipes",
                c => new
                    {
                        KRSUser_Id = c.Int(nullable: false),
                        Recipe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KRSUser_Id, t.Recipe_Id })
                .ForeignKey("dbo.KRSUsers", t => t.KRSUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .Index(t => t.KRSUser_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.KRSUserRecipes", new[] { "Recipe_Id" });
            DropIndex("dbo.KRSUserRecipes", new[] { "KRSUser_Id" });
            DropIndex("dbo.Kitchenwares", new[] { "Category_CategoryId" });
            DropIndex("dbo.Ingredients", new[] { "Category_CategoryId" });
            DropIndex("dbo.Photos", new[] { "Kitchenware_Id" });
            DropIndex("dbo.Photos", new[] { "CookProcess_Id" });
            DropIndex("dbo.Photos", new[] { "Ingredient_Id" });
            DropIndex("dbo.Photos", new[] { "Recipe_Id" });
            DropIndex("dbo.Recipes", new[] { "Kitchenware_Id" });
            DropIndex("dbo.Recipes", new[] { "CookProcess_Id" });
            DropIndex("dbo.Recipes", new[] { "Ingredient_Id" });
            DropIndex("dbo.Recipes", new[] { "NationalCategory_CategoryId" });
            DropIndex("dbo.Recipes", new[] { "Category_CategoryId" });
            DropIndex("dbo.Deliveries", new[] { "CustomerId" });
            DropForeignKey("dbo.KRSUserRecipes", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.KRSUserRecipes", "KRSUser_Id", "dbo.KRSUsers");
            DropForeignKey("dbo.Kitchenwares", "Category_CategoryId", "dbo.KitchenwareCategories");
            DropForeignKey("dbo.Ingredients", "Category_CategoryId", "dbo.IngredientCategories");
            DropForeignKey("dbo.Photos", "Kitchenware_Id", "dbo.Kitchenwares");
            DropForeignKey("dbo.Photos", "CookProcess_Id", "dbo.CookProcesses");
            DropForeignKey("dbo.Photos", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.Photos", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "Kitchenware_Id", "dbo.Kitchenwares");
            DropForeignKey("dbo.Recipes", "CookProcess_Id", "dbo.CookProcesses");
            DropForeignKey("dbo.Recipes", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.Recipes", "NationalCategory_CategoryId", "dbo.NationalCategories");
            DropForeignKey("dbo.Recipes", "Category_CategoryId", "dbo.RecipeCategories");
            DropForeignKey("dbo.Deliveries", "CustomerId", "dbo.Customers");
            DropTable("dbo.KRSUserRecipes");
            DropTable("dbo.RecipeSchemas");
            DropTable("dbo.Kitchenwares");
            DropTable("dbo.CookProcesses");
            DropTable("dbo.Ingredients");
            DropTable("dbo.KitchenwareCategories");
            DropTable("dbo.IngredientCategories");
            DropTable("dbo.KRSUsers");
            DropTable("dbo.Photos");
            DropTable("dbo.NationalCategories");
            DropTable("dbo.RecipeCategories");
            DropTable("dbo.Recipes");
            DropTable("dbo.Customers");
            DropTable("dbo.Deliveries");
        }
    }
}
