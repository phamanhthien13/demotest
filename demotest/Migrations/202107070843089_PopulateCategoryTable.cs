namespace demotest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES(ID,NAME) VALUES(1,'Decelopment')");
            Sql("INSERT INTO CATEGORIES(ID,NAME) VALUES(2,'Bussiness')");
            Sql("INSERT INTO CATEGORIES(ID,NAME) VALUES(3,'Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
