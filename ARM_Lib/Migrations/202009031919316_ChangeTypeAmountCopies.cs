namespace ARM_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeAmountCopies : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.books", "amountCopies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.books", "amountCopies");
        }
    }
}
