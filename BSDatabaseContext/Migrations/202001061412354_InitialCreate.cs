namespace BSDatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        AccountUser_UserId = c.Int(),
                        Currency_CurrencyId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Users", t => t.AccountUser_UserId)
                .ForeignKey("dbo.Currencies", t => t.Currency_CurrencyId)
                .Index(t => t.AccountUser_UserId)
                .Index(t => t.Currency_CurrencyId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        EmailAddress = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        Code = c.String(unicode: false),
                        Symbol = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        AccountFromId = c.Int(nullable: false),
                        AccountToId = c.Int(nullable: false),
                        DateAndTime = c.DateTime(nullable: false, precision: 0),
                        Description = c.String(unicode: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Accounts", t => t.AccountFromId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.AccountToId, cascadeDelete: true)
                .Index(t => t.AccountFromId)
                .Index(t => t.AccountToId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountToId", "dbo.Accounts");
            DropForeignKey("dbo.Transactions", "AccountFromId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Currency_CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "AccountUser_UserId", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "AccountToId" });
            DropIndex("dbo.Transactions", new[] { "AccountFromId" });
            DropIndex("dbo.Accounts", new[] { "Currency_CurrencyId" });
            DropIndex("dbo.Accounts", new[] { "AccountUser_UserId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Currencies");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
