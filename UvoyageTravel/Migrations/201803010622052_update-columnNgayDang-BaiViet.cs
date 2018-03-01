namespace UvoyageTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecolumnNgayDangBaiViet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BaiViet", "NgayDang", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BaiViet", "NgayDang", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
