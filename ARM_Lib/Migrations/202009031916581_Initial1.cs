namespace ARM_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.book_out", "dateIn", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("public.book_out", "dateIn", c => c.Long(nullable: false));
        }
    }
}
