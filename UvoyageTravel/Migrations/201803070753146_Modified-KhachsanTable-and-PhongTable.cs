namespace UvoyageTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedKhachsanTableandPhongTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhongKhachSan", "Img", c => c.String(maxLength: 500));
            AddColumn("dbo.KhachSan", "Img", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachSan", "Img");
            DropColumn("dbo.PhongKhachSan", "Img");
        }
    }
}
