namespace ARM_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.book_out",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateOut = c.Long(nullable: false),
                        dateIn = c.Long(nullable: false),
                        book_id = c.Int(),
                        reader_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.books", t => t.book_id)
                .ForeignKey("public.readers", t => t.reader_id)
                .Index(t => t.book_id)
                .Index(t => t.reader_id);
            
            CreateTable(
                "public.books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        authorName = c.String(),
                        name = c.String(),
                        genre = c.String(),
                        datePublish = c.String(),
                        publishingHouse = c.String(),
                        amountPages = c.Int(nullable: false),
                        isbn = c.String(),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "public.readers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        secondName = c.String(),
                        thirdName = c.String(),
                        birthDay = c.Long(nullable: false),
                        city = c.String(),
                        street = c.String(),
                        houseNumber = c.Int(nullable: false),
                        flat = c.Int(nullable: false),
                        phoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.book_out", "reader_id", "public.readers");
            DropForeignKey("public.book_out", "book_id", "public.books");
            DropIndex("public.book_out", new[] { "reader_id" });
            DropIndex("public.book_out", new[] { "book_id" });
            DropTable("public.readers");
            DropTable("public.books");
            DropTable("public.book_out");
        }
    }
}
