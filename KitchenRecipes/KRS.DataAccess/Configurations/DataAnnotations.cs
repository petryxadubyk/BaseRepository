namespace KRS.DataAccess.Configurations
{
    class DataAnnotations
    {
        /*
         *  1)  [MaxLength(30), MinLength(5)]
         *  
         *  2)  [Required]
          
         *  3)  public int ManagerId { get; set; }
                [ForeignKey("ManagerId")]
                public Person Manager { get; set; }
         * 
         *  4)  [Table("InternalBlogs")]
         *      [Column("Birth")]
         *      [Column(“BlogDescription", TypeName="ntext")]
         *      Don’t confuse Column’s TypeName attribute with the DataType DataAnnotation. 
         *      DataType is an annotation used for the UI and is ignored by code first.
         * 
         *  5)  [RegularExpression(@"(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})")]
         *  6)  [Range(1, 5),Column("RatingCode")]
         *  7)  [Key]
         *  8)  [NotMapped]
         *  
         *  9)  Complex types cannot be tracked on their own.
                However as a property in the Blog class, BlogDetails it will be tracked as part of a Blog object. 
         *      In order for code first to recognize this, you must mark the BlogDetails class as a ComplexType.

                [ComplexType]
                public class BlogDetails
                {
                    public DateTime? DateCreated { get; set; }
                    [MaxLength(250)]
                    public string Description { get; set; }
                } 
         *      Now you can add a property in the Blog class to represent the BlogDetails for that blog.
         *      And this 'Complex Group' becames a part of base class in db (two classes will be in 1 db table 'Blog')
                public BlogDetails BlogDetail { get; set; }
         * 
         *  10) An important database features is the ability to have computed properties. 
         *      If you're mapping your code first classes to tables that contain computed properties, you don't want Entity Framework 
         *      to try to update those columns. But you do want EF to return those values from the database after you've inserted or 
         *      updated data. You can use the DatabaseGenerated annotation to flag those properties in your class along with the 
         *      Computed enum. Other enums are None and Identity.

                [DatabaseGenerated(DatabaseGenerationOption.Computed)]
                public DateTime DateCreated { get; set; }
                You can use database generated on byte or timestamp columns when code first is generating the database, 
         *      otherwise you should only use this when pointing to existing databases because code first won't be able to 
         *      determine the formula for the computed column.

                You read above that by default, a key property will become an identity key in the database. 
         *      That would be the same as setting DatabaseGenerated to DatabaseGenerationOption.Identity. 
         *      If you do not want it to be an identity key, you can set the value to DatabaseGenerationOption.None
         *      
         *  11) The InverseProperty is used when you have multiple relationships between classes.
         *      In Post class:
         *      public Person CreatedBy { get; set; }
                public Person UpdatedBy { get; set; }
         * 
         *      In Person class
         *      [InverseProperty("CreatedBy")]
                public List<Post> PostsWritten { get; set; }
                [InverseProperty("UpdatedBy")]
                public List<Post> PostsUpdated { get; set; }
         */
    }
}
