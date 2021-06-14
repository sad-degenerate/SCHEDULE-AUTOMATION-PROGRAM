namespace BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_database_again : DbMigration
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
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
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
                "dbo.SpecialEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EquipmentId = c.Int(nullable: false),
                        SubjectTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: false)
                .ForeignKey("dbo.SubjectTypes", t => t.SubjectTypeId, cascadeDelete: false)
                .Index(t => t.EquipmentId)
                .Index(t => t.SubjectTypeId);
            
            CreateTable(
                "dbo.LessonFrames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        FlowId = c.Int(nullable: false),
                        FreedoomOfLocation = c.Double(),
                        LessonFrameCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flows", t => t.FlowId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId)
                .Index(t => t.FlowId);
            
            CreateTable(
                "dbo.Flows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FlowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flows", t => t.FlowId, cascadeDelete: false)
                .Index(t => t.FlowId);
            
            CreateTable(
                "dbo.Subgroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfStudents = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Lesson_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: false)
                .ForeignKey("dbo.Lessons", t => t.Lesson_Id)
                .Index(t => t.GroupId)
                .Index(t => t.Lesson_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        LessonTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassroomId)
                .Index(t => t.DayId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
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
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.SubjectTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlowsLoads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlowId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Load = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flows", t => t.FlowId, cascadeDelete: false)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: false)
                .Index(t => t.FlowId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.GroupsInFlows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlowId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OptimalityCriterions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecialEquipmentInEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecialEquipmentId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubgroupsInGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SubgroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubgroupsInLessonFrames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubgroupId = c.Int(nullable: false),
                        LessonFrameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LessonFrames", t => t.LessonFrameId, cascadeDelete: true)
                .ForeignKey("dbo.Subgroups", t => t.SubgroupId, cascadeDelete: true)
                .Index(t => t.SubgroupId)
                .Index(t => t.LessonFrameId);
            
            CreateTable(
                "dbo.SubgroupsInLessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubgroupId = c.Int(nullable: false),
                        LessonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Subgroups", t => t.SubgroupId, cascadeDelete: true)
                .Index(t => t.SubgroupId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.SpecialEquipmentEquipments",
                c => new
                    {
                        SpecialEquipment_Id = c.Int(nullable: false),
                        Equipment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SpecialEquipment_Id, t.Equipment_Id })
                .ForeignKey("dbo.SpecialEquipments", t => t.SpecialEquipment_Id, cascadeDelete: false)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id, cascadeDelete: false)
                .Index(t => t.SpecialEquipment_Id)
                .Index(t => t.Equipment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubgroupsInLessons", "SubgroupId", "dbo.Subgroups");
            DropForeignKey("dbo.SubgroupsInLessons", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.SubgroupsInLessonFrames", "SubgroupId", "dbo.Subgroups");
            DropForeignKey("dbo.SubgroupsInLessonFrames", "LessonFrameId", "dbo.LessonFrames");
            DropForeignKey("dbo.FlowsLoads", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.FlowsLoads", "FlowId", "dbo.Flows");
            DropForeignKey("dbo.Subjects", "SubjectTypeId", "dbo.SubjectTypes");
            DropForeignKey("dbo.TeachersLoads", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeachersLoads", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Lessons", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subgroups", "Lesson_Id", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "DayId", "dbo.Days");
            DropForeignKey("dbo.Lessons", "ClassroomId", "dbo.Classrooms");
            DropForeignKey("dbo.LessonFrames", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.LessonFrames", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.LessonFrames", "FlowId", "dbo.Flows");
            DropForeignKey("dbo.Subgroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "FlowId", "dbo.Flows");
            DropForeignKey("dbo.Subjects", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.SpecialEquipmentEquipments", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.SpecialEquipmentEquipments", "SpecialEquipment_Id", "dbo.SpecialEquipments");
            DropForeignKey("dbo.Classrooms", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.SpecialEquipmentEquipments", new[] { "Equipment_Id" });
            DropIndex("dbo.SpecialEquipmentEquipments", new[] { "SpecialEquipment_Id" });
            DropIndex("dbo.SubgroupsInLessons", new[] { "LessonId" });
            DropIndex("dbo.SubgroupsInLessons", new[] { "SubgroupId" });
            DropIndex("dbo.SubgroupsInLessonFrames", new[] { "LessonFrameId" });
            DropIndex("dbo.SubgroupsInLessonFrames", new[] { "SubgroupId" });
            DropIndex("dbo.FlowsLoads", new[] { "SubjectId" });
            DropIndex("dbo.FlowsLoads", new[] { "FlowId" });
            DropIndex("dbo.TeachersLoads", new[] { "SubjectId" });
            DropIndex("dbo.TeachersLoads", new[] { "TeacherId" });
            DropIndex("dbo.Lessons", new[] { "DayId" });
            DropIndex("dbo.Lessons", new[] { "ClassroomId" });
            DropIndex("dbo.Lessons", new[] { "TeacherId" });
            DropIndex("dbo.Lessons", new[] { "SubjectId" });
            DropIndex("dbo.Subgroups", new[] { "Lesson_Id" });
            DropIndex("dbo.Subgroups", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "FlowId" });
            DropIndex("dbo.LessonFrames", new[] { "FlowId" });
            DropIndex("dbo.LessonFrames", new[] { "TeacherId" });
            DropIndex("dbo.LessonFrames", new[] { "SubjectId" });
            DropIndex("dbo.Subjects", new[] { "SubjectTypeId" });
            DropIndex("dbo.Subjects", new[] { "EquipmentId" });
            DropIndex("dbo.Classrooms", new[] { "EquipmentId" });
            DropTable("dbo.SpecialEquipmentEquipments");
            DropTable("dbo.SubgroupsInLessons");
            DropTable("dbo.SubgroupsInLessonFrames");
            DropTable("dbo.SubgroupsInGroups");
            DropTable("dbo.SpecialEquipmentInEquipments");
            DropTable("dbo.OptimalityCriterions");
            DropTable("dbo.GroupsInFlows");
            DropTable("dbo.FlowsLoads");
            DropTable("dbo.SubjectTypes");
            DropTable("dbo.TeachersLoads");
            DropTable("dbo.Days");
            DropTable("dbo.Lessons");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subgroups");
            DropTable("dbo.Groups");
            DropTable("dbo.Flows");
            DropTable("dbo.LessonFrames");
            DropTable("dbo.Subjects");
            DropTable("dbo.SpecialEquipments");
            DropTable("dbo.Equipments");
            DropTable("dbo.Classrooms");
        }
    }
}
