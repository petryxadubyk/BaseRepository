namespace KRS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        ShortDescription = c.String(maxLength: 500),
                        PhotoPath = c.String(maxLength: 300),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        CategoryFilter = c.String(maxLength: 300),
                        CookProcessFilter = c.String(maxLength: 300),
                        KitchenwareFilter = c.String(maxLength: 300),
                        IngredientFilter = c.String(maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        ExtRecipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExtRecipe", t => t.ExtRecipe_Id)
                .Index(t => t.ExtRecipe_Id);
            
            CreateTable(
                "dbo.ExtRecipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullDescription = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 300),
                        PhotoPath = c.String(maxLength: 300),
                        Description = c.String(),
                        ParentCategoryId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryGroup", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.CategoryGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoPath = c.String(nullable: false, maxLength: 300),
                        Order = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Category_Id = c.Int(),
                        Ingredient_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_Id)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(),
                        PhotoPath = c.String(maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.RecipesIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentStep = c.Int(),
                        Step = c.Int(),
                        Unit_Value = c.String(maxLength: 100),
                        Unit_MeasureSign = c.String(maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Recipe_Id = c.Int(),
                        Ingredient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Ingredient_Id);
            
            CreateTable(
                "dbo.Kitchenware",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Material = c.String(maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(),
                        PhotoPath = c.String(maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.RecipesKitchenwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentStep = c.Int(),
                        Step = c.Int(),
                        Quontity = c.Int(),
                        Description = c.String(maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Recipe_Id = c.Int(),
                        Kitchenware_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id)
                .ForeignKey("dbo.Kitchenware", t => t.Kitchenware_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Kitchenware_Id);
            
            CreateTable(
                "dbo.RecipesCookProcesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentStep = c.Int(),
                        Step = c.Int(),
                        EstimatedTime = c.Time(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        Recipe_Id = c.Int(),
                        CookProcess_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id)
                .ForeignKey("dbo.CookProcess", t => t.CookProcess_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.CookProcess_Id);
            
            CreateTable(
                "dbo.CookProcess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.Time(),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(),
                        PhotoPath = c.String(maxLength: 300),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KRSUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        Blog = c.String(),
                        Twitter = c.String(),
                        Gender = c.String(),
                        Bio = c.String(),
                        LastLoginTime = c.DateTime(),
                        Activated = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeCategoryRecipe",
                c => new
                    {
                        RecipeCategory_Id = c.Int(nullable: false),
                        Recipe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeCategory_Id, t.Recipe_Id })
                .ForeignKey("dbo.Category", t => t.RecipeCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id, cascadeDelete: true)
                .Index(t => t.RecipeCategory_Id)
                .Index(t => t.Recipe_Id);
            
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
            DropIndex("dbo.RecipeCategoryRecipe", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeCategoryRecipe", new[] { "RecipeCategory_Id" });
            DropIndex("dbo.RecipesCookProcesses", new[] { "CookProcess_Id" });
            DropIndex("dbo.RecipesCookProcesses", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipesKitchenwares", new[] { "Kitchenware_Id" });
            DropIndex("dbo.RecipesKitchenwares", new[] { "Recipe_Id" });
            DropIndex("dbo.Kitchenware", new[] { "Category_Id" });
            DropIndex("dbo.RecipesIngredients", new[] { "Ingredient_Id" });
            DropIndex("dbo.RecipesIngredients", new[] { "Recipe_Id" });
            DropIndex("dbo.Ingredient", new[] { "Category_Id" });
            DropIndex("dbo.Photo", new[] { "Recipe_Id" });
            DropIndex("dbo.Photo", new[] { "Ingredient_Id" });
            DropIndex("dbo.Photo", new[] { "Category_Id" });
            DropIndex("dbo.Category", new[] { "Group_Id" });
            DropIndex("dbo.Recipe", new[] { "ExtRecipe_Id" });
            DropForeignKey("dbo.KRSUserRecipe", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.KRSUserRecipe", "KRSUser_Id", "dbo.KRSUser");
            DropForeignKey("dbo.RecipeCategoryRecipe", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.RecipeCategoryRecipe", "RecipeCategory_Id", "dbo.Category");
            DropForeignKey("dbo.RecipesCookProcesses", "CookProcess_Id", "dbo.CookProcess");
            DropForeignKey("dbo.RecipesCookProcesses", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.RecipesKitchenwares", "Kitchenware_Id", "dbo.Kitchenware");
            DropForeignKey("dbo.RecipesKitchenwares", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.Kitchenware", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.RecipesIngredients", "Ingredient_Id", "dbo.Ingredient");
            DropForeignKey("dbo.RecipesIngredients", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.Ingredient", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Photo", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.Photo", "Ingredient_Id", "dbo.Ingredient");
            DropForeignKey("dbo.Photo", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Category", "Group_Id", "dbo.CategoryGroup");
            DropForeignKey("dbo.Recipe", "ExtRecipe_Id", "dbo.ExtRecipe");
            DropTable("dbo.KRSUserRecipe");
            DropTable("dbo.RecipeCategoryRecipe");
            DropTable("dbo.KRSUser");
            DropTable("dbo.CookProcess");
            DropTable("dbo.RecipesCookProcesses");
            DropTable("dbo.RecipesKitchenwares");
            DropTable("dbo.Kitchenware");
            DropTable("dbo.RecipesIngredients");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Photo");
            DropTable("dbo.CategoryGroup");
            DropTable("dbo.Category");
            DropTable("dbo.ExtRecipe");
            DropTable("dbo.Recipe");
        }
    }
}
