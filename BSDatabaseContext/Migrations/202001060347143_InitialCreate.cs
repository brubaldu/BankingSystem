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
                        DateAndTime = c.DateTime(nullable: false, precision: 0),
                        Description = c.String(unicode: false),
                        Amount = c.Double(nullable: false),
                        AccountFrom_AccountId = c.Int(),
                        AccountTo_AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Accounts", t => t.AccountFrom_AccountId)
                .ForeignKey("dbo.Accounts", t => t.AccountTo_AccountId)
                .Index(t => t.AccountFrom_AccountId)
                .Index(t => t.AccountTo_AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountTo_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Transactions", "AccountFrom_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Currency_CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "AccountUser_UserId", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "AccountTo_AccountId" });
            DropIndex("dbo.Transactions", new[] { "AccountFrom_AccountId" });
            DropIndex("dbo.Accounts", new[] { "Currency_CurrencyId" });
            DropIndex("dbo.Accounts", new[] { "AccountUser_UserId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Currencies");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
