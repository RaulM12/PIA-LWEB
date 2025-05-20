using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaRecetas.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios_Roles",
                table: "usuarios_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles_Permisos",
                table: "roles_Permisos");

            migrationBuilder.AlterColumn<int>(
                name: "usuario_id",
                table: "usuarios_Roles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "usuarios_Roles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "rol_id",
                table: "roles_Permisos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "roles_Permisos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "estatus",
                table: "reportes_Comentarios",
                type: "TINYINT(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "estatus",
                table: "reporte_Recetas",
                type: "TINYINT(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "id",
                table: "estatus_Reportes",
                type: "TINYINT(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios_Roles",
                table: "usuarios_Roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles_Permisos",
                table: "roles_Permisos",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios_Roles",
                table: "usuarios_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles_Permisos",
                table: "roles_Permisos");

            migrationBuilder.DropColumn(
                name: "id",
                table: "usuarios_Roles");

            migrationBuilder.DropColumn(
                name: "id",
                table: "roles_Permisos");

            migrationBuilder.AlterColumn<int>(
                name: "usuario_id",
                table: "usuarios_Roles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "rol_id",
                table: "roles_Permisos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<bool>(
                name: "estatus",
                table: "reportes_Comentarios",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "TINYINT(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "estatus",
                table: "reporte_Recetas",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "TINYINT(1)");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "estatus_Reportes",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "TINYINT(1)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios_Roles",
                table: "usuarios_Roles",
                column: "usuario_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles_Permisos",
                table: "roles_Permisos",
                column: "rol_id");
        }
    }
}
