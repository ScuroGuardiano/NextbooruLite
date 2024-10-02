using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextbooruLite.Migrations
{
    /// <inheritdoc />
    public partial class opsie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_album_users_created_by_id",
                table: "album");

            migrationBuilder.DropForeignKey(
                name: "fk_album_image_album_albums_id",
                table: "album_image");

            migrationBuilder.DropForeignKey(
                name: "fk_album_image_image_images_id",
                table: "album_image");

            migrationBuilder.DropForeignKey(
                name: "fk_image_users_uploaded_by_id",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "fk_image_tag_image_images_id",
                table: "image_tag");

            migrationBuilder.DropForeignKey(
                name: "fk_image_tag_tag_tags_id",
                table: "image_tag");

            migrationBuilder.DropForeignKey(
                name: "fk_image_variant_image_image_id",
                table: "image_variant");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tag",
                table: "tag");

            migrationBuilder.DropPrimaryKey(
                name: "pk_image_variant",
                table: "image_variant");

            migrationBuilder.DropPrimaryKey(
                name: "pk_image",
                table: "image");

            migrationBuilder.DropPrimaryKey(
                name: "pk_album",
                table: "album");

            migrationBuilder.RenameTable(
                name: "tag",
                newName: "tags");

            migrationBuilder.RenameTable(
                name: "image_variant",
                newName: "image_variants");

            migrationBuilder.RenameTable(
                name: "image",
                newName: "images");

            migrationBuilder.RenameTable(
                name: "album",
                newName: "albums");

            migrationBuilder.RenameIndex(
                name: "ix_tag_name",
                table: "tags",
                newName: "ix_tags_name");

            migrationBuilder.RenameIndex(
                name: "ix_image_variant_image_id",
                table: "image_variants",
                newName: "ix_image_variants_image_id");

            migrationBuilder.RenameIndex(
                name: "ix_image_uploaded_by_id",
                table: "images",
                newName: "ix_images_uploaded_by_id");

            migrationBuilder.RenameIndex(
                name: "ix_image_tags_arr",
                table: "images",
                newName: "ix_images_tags_arr");

            migrationBuilder.RenameIndex(
                name: "ix_album_created_by_id",
                table: "albums",
                newName: "ix_albums_created_by_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "image_variants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "image_variants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "images",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "images",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "albums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "albums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tags",
                table: "tags",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_image_variants",
                table: "image_variants",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_images",
                table: "images",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_albums",
                table: "albums",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_album_image_albums_albums_id",
                table: "album_image",
                column: "albums_id",
                principalTable: "albums",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_album_image_images_images_id",
                table: "album_image",
                column: "images_id",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_albums_users_created_by_id",
                table: "albums",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_image_tag_images_images_id",
                table: "image_tag",
                column: "images_id",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_image_tag_tags_tags_id",
                table: "image_tag",
                column: "tags_id",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_image_variants_images_image_id",
                table: "image_variants",
                column: "image_id",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_images_users_uploaded_by_id",
                table: "images",
                column: "uploaded_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_album_image_albums_albums_id",
                table: "album_image");

            migrationBuilder.DropForeignKey(
                name: "fk_album_image_images_images_id",
                table: "album_image");

            migrationBuilder.DropForeignKey(
                name: "fk_albums_users_created_by_id",
                table: "albums");

            migrationBuilder.DropForeignKey(
                name: "fk_image_tag_images_images_id",
                table: "image_tag");

            migrationBuilder.DropForeignKey(
                name: "fk_image_tag_tags_tags_id",
                table: "image_tag");

            migrationBuilder.DropForeignKey(
                name: "fk_image_variants_images_image_id",
                table: "image_variants");

            migrationBuilder.DropForeignKey(
                name: "fk_images_users_uploaded_by_id",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tags",
                table: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "pk_images",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "pk_image_variants",
                table: "image_variants");

            migrationBuilder.DropPrimaryKey(
                name: "pk_albums",
                table: "albums");

            migrationBuilder.RenameTable(
                name: "tags",
                newName: "tag");

            migrationBuilder.RenameTable(
                name: "images",
                newName: "image");

            migrationBuilder.RenameTable(
                name: "image_variants",
                newName: "image_variant");

            migrationBuilder.RenameTable(
                name: "albums",
                newName: "album");

            migrationBuilder.RenameIndex(
                name: "ix_tags_name",
                table: "tag",
                newName: "ix_tag_name");

            migrationBuilder.RenameIndex(
                name: "ix_images_uploaded_by_id",
                table: "image",
                newName: "ix_image_uploaded_by_id");

            migrationBuilder.RenameIndex(
                name: "ix_images_tags_arr",
                table: "image",
                newName: "ix_image_tags_arr");

            migrationBuilder.RenameIndex(
                name: "ix_image_variants_image_id",
                table: "image_variant",
                newName: "ix_image_variant_image_id");

            migrationBuilder.RenameIndex(
                name: "ix_albums_created_by_id",
                table: "album",
                newName: "ix_album_created_by_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "tag",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "tag",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "image",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "image",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "image_variant",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "image_variant",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "album",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "album",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tag",
                table: "tag",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_image",
                table: "image",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_image_variant",
                table: "image_variant",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_album",
                table: "album",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_album_users_created_by_id",
                table: "album",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_album_image_album_albums_id",
                table: "album_image",
                column: "albums_id",
                principalTable: "album",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_album_image_image_images_id",
                table: "album_image",
                column: "images_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_image_users_uploaded_by_id",
                table: "image",
                column: "uploaded_by_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_image_tag_image_images_id",
                table: "image_tag",
                column: "images_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_image_tag_tag_tags_id",
                table: "image_tag",
                column: "tags_id",
                principalTable: "tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_image_variant_image_image_id",
                table: "image_variant",
                column: "image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
