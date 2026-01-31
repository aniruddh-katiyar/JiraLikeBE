using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JiraLike.Infrastructure.Migrations
{
    public partial class Issue_Update_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Type
            migrationBuilder.Sql("""
                ALTER TABLE "Issues"
                ALTER COLUMN "Type" TYPE integer
                USING
                  CASE "Type"
                    WHEN 'Bug' THEN 0
                    WHEN 'Task' THEN 1
                    WHEN 'Story' THEN 2
                    ELSE 0
                  END;
            """);

            // Status
            migrationBuilder.Sql("""
                ALTER TABLE "Issues"
                ALTER COLUMN "Status" TYPE integer
                USING
                  CASE "Status"
                    WHEN 'Open' THEN 0
                    WHEN 'InProgress' THEN 1
                    WHEN 'Done' THEN 2
                    ELSE 0
                  END;
            """);

            // Priority
            migrationBuilder.Sql("""
                ALTER TABLE "Issues"
                ALTER COLUMN "Priority" TYPE integer
                USING
                  CASE "Priority"
                    WHEN 'Low' THEN 0
                    WHEN 'Medium' THEN 1
                    WHEN 'High' THEN 2
                    ELSE 1
                  END;
            """);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE "Issues" ALTER COLUMN "Type" TYPE text;
                ALTER TABLE "Issues" ALTER COLUMN "Status" TYPE text;
                ALTER TABLE "Issues" ALTER COLUMN "Priority" TYPE text;
            """);
        }
    }
}
