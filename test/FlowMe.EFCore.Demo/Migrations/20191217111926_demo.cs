using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowMe.EFCore.Demo.Migrations
{
    public partial class demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FM_PROC_DEF",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BPMN_DEF_CONTENT = table.Column<string>(maxLength: 5000, nullable: false),
                    VERSION = table.Column<int>(maxLength: 5, nullable: false),
                    ENABLE = table.Column<bool>(nullable: false),
                    PROC_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_PROC_DEF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FM_PROC_INST",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PROC_DEF_REF = table.Column<Guid>(nullable: true),
                    START_USER = table.Column<string>(maxLength: 50, nullable: false),
                    START_TIME = table.Column<DateTime>(nullable: false),
                    FINISH_TIME = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_PROC_INST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FM_PROC_INST_FM_PROC_DEF_PROC_DEF_REF",
                        column: x => x.PROC_DEF_REF,
                        principalTable: "FM_PROC_DEF",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FM_PROC_TASK",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PROC_INST_REF = table.Column<Guid>(nullable: true),
                    TASK_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    TASK_TYPE = table.Column<string>(maxLength: 100, nullable: false),
                    ReceiveTime = table.Column<DateTime>(nullable: false),
                    RECEIVER = table.Column<string>(maxLength: 50, nullable: false),
                    EXECUTOR = table.Column<string>(nullable: true),
                    COMPLETE_TIME = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_PROC_TASK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FM_PROC_TASK_FM_PROC_INST_PROC_INST_REF",
                        column: x => x.PROC_INST_REF,
                        principalTable: "FM_PROC_INST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FM_PROC_VAR",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProcInstRefId = table.Column<Guid>(nullable: true),
                    JSON_VAR = table.Column<string>(maxLength: 1000, nullable: false),
                    VAR_TYPE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_PROC_VAR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FM_PROC_VAR_FM_PROC_INST_ProcInstRefId",
                        column: x => x.ProcInstRefId,
                        principalTable: "FM_PROC_INST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FM_PROC_INST_PROC_DEF_REF",
                table: "FM_PROC_INST",
                column: "PROC_DEF_REF");

            migrationBuilder.CreateIndex(
                name: "IX_FM_PROC_TASK_PROC_INST_REF",
                table: "FM_PROC_TASK",
                column: "PROC_INST_REF");

            migrationBuilder.CreateIndex(
                name: "IX_FM_PROC_VAR_ProcInstRefId",
                table: "FM_PROC_VAR",
                column: "ProcInstRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FM_PROC_TASK");

            migrationBuilder.DropTable(
                name: "FM_PROC_VAR");

            migrationBuilder.DropTable(
                name: "FM_PROC_INST");

            migrationBuilder.DropTable(
                name: "FM_PROC_DEF");
        }
    }
}
