namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class double_change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LessonFrames", "FreedoomOfLocation", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LessonFrames", "FreedoomOfLocation", c => c.Int());
        }
    }
}
