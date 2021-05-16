namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        LessonTimeId = c.Int(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: false)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: false)
                .ForeignKey("dbo.LessonTimes", t => t.LessonTimeId, cascadeDelete: false)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId)
                .Index(t => t.GroupId)
                .Index(t => t.LessonTimeId)
                .Index(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfStudents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupsLoads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Load = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.LessonTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.Time(nullable: false, precision: 7),
                        End = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeachersLoads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Load = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.LessonFrames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        FreedoomOfLocation = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: false)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonFrames", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.LessonFrames", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.LessonFrames", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.TeachersLoads", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeachersLoads", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Lessons", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Lessons", "LessonTimeId", "dbo.LessonTimes");
            DropForeignKey("dbo.Lessons", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupsLoads", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.GroupsLoads", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Lessons", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.Subjects", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Classrooms", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.LessonFrames", new[] { "GroupId" });
            DropIndex("dbo.LessonFrames", new[] { "TeacherId" });
            DropIndex("dbo.LessonFrames", new[] { "SubjectId" });
            DropIndex("dbo.TeachersLoads", new[] { "SubjectId" });
            DropIndex("dbo.TeachersLoads", new[] { "TeacherId" });
            DropIndex("dbo.GroupsLoads", new[] { "SubjectId" });
            DropIndex("dbo.GroupsLoads", new[] { "GroupId" });
            DropIndex("dbo.Lessons", new[] { "ClassroomId" });
            DropIndex("dbo.Lessons", new[] { "LessonTimeId" });
            DropIndex("dbo.Lessons", new[] { "GroupId" });
            DropIndex("dbo.Lessons", new[] { "TeacherId" });
            DropIndex("dbo.Lessons", new[] { "SubjectId" });
            DropIndex("dbo.Subjects", new[] { "EquipmentId" });
            DropIndex("dbo.Classrooms", new[] { "EquipmentId" });
            DropTable("dbo.LessonFrames");
            DropTable("dbo.TeachersLoads");
            DropTable("dbo.Teachers");
            DropTable("dbo.LessonTimes");
            DropTable("dbo.GroupsLoads");
            DropTable("dbo.Groups");
            DropTable("dbo.Lessons");
            DropTable("dbo.Subjects");
            DropTable("dbo.Equipments");
            DropTable("dbo.Classrooms");
        }
    }
}
