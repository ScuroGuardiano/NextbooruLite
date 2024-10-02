﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NextbooruLite;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NextbooruLite.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlbumImage", b =>
                {
                    b.Property<long>("AlbumsId")
                        .HasColumnType("bigint")
                        .HasColumnName("albums_id");

                    b.Property<long>("ImagesId")
                        .HasColumnType("bigint")
                        .HasColumnName("images_id");

                    b.HasKey("AlbumsId", "ImagesId")
                        .HasName("pk_album_image");

                    b.HasIndex("ImagesId")
                        .HasDatabaseName("ix_album_image_images_id");

                    b.ToTable("album_image", (string)null);
                });

            modelBuilder.Entity("ImageTag", b =>
                {
                    b.Property<long>("ImagesId")
                        .HasColumnType("bigint")
                        .HasColumnName("images_id");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer")
                        .HasColumnName("tags_id");

                    b.HasKey("ImagesId", "TagsId")
                        .HasName("pk_image_tag");

                    b.HasIndex("TagsId")
                        .HasDatabaseName("ix_image_tag_tags_id");

                    b.ToTable("image_tag", (string)null);
                });

            modelBuilder.Entity("NextbooruLite.Auth.Model.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean")
                        .HasColumnName("is_valid");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_access");

                    b.Property<string>("LastIp")
                        .HasColumnType("text")
                        .HasColumnName("last_ip");

                    b.Property<string>("LastUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("last_user_agent");

                    b.Property<string>("LoggedInIpAddress")
                        .HasColumnType("text")
                        .HasColumnName("logged_in_ip_address");

                    b.Property<string>("UserAgent")
                        .HasColumnType("text")
                        .HasColumnName("user_agent");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_sessions");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_sessions_user_id");

                    b.ToTable("sessions", (string)null);
                });

            modelBuilder.Entity("NextbooruLite.Auth.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean")
                        .HasColumnName("disabled");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("display_name");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("hashed_password");

                    b.Property<bool>("IsInitial")
                        .HasColumnType("boolean")
                        .HasColumnName("is_initial");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasDatabaseName("ix_users_username");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("NextbooruLite.Model.Album", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("ImageCount")
                        .HasColumnType("integer")
                        .HasColumnName("image_count");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean")
                        .HasColumnName("is_public");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("published_at");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("pk_albums");

                    b.HasIndex("CreatedById")
                        .HasDatabaseName("ix_albums_created_by_id");

                    b.ToTable("albums", (string)null);
                });

            modelBuilder.Entity("NextbooruLite.Model.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ContentType")
                        .HasColumnType("text")
                        .HasColumnName("content_type");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Extension")
                        .HasColumnType("text")
                        .HasColumnName("extension");

                    b.Property<int>("Height")
                        .HasColumnType("integer")
                        .HasColumnName("height");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean")
                        .HasColumnName("is_public");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("published_at");

                    b.Property<long>("SizeInBytes")
                        .HasColumnType("bigint")
                        .HasColumnName("size_in_bytes");

                    b.Property<string>("Source")
                        .HasColumnType("text")
                        .HasColumnName("source");

                    b.Property<string>("StoreFileId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("store_file_id");

                    b.Property<List<int>>("TagsArr")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("tags_arr");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("UploadedById")
                        .HasColumnType("uuid")
                        .HasColumnName("uploaded_by_id");

                    b.Property<int>("Width")
                        .HasColumnType("integer")
                        .HasColumnName("width");

                    b.HasKey("Id")
                        .HasName("pk_images");

                    b.HasIndex("TagsArr")
                        .HasDatabaseName("ix_images_tags_arr");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("TagsArr"), "GIN");

                    b.HasIndex("UploadedById")
                        .HasDatabaseName("ix_images_uploaded_by_id");

                    b.ToTable("images", (string)null);
                });

            modelBuilder.Entity("NextbooruLite.Model.ImageVariant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ContentType")
                        .HasColumnType("text")
                        .HasColumnName("content_type");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Extension")
                        .HasColumnType("text")
                        .HasColumnName("extension");

                    b.Property<int>("Height")
                        .HasColumnType("integer")
                        .HasColumnName("height");

                    b.Property<long>("ImageId")
                        .HasColumnType("bigint")
                        .HasColumnName("image_id");

                    b.Property<long>("SizeInBytes")
                        .HasColumnType("bigint")
                        .HasColumnName("size_in_bytes");

                    b.Property<string>("StoreFileId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("store_file_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("VariantMode")
                        .HasColumnType("integer")
                        .HasColumnName("variant_mode");

                    b.Property<int>("Width")
                        .HasColumnType("integer")
                        .HasColumnName("width");

                    b.HasKey("Id")
                        .HasName("pk_image_variants");

                    b.HasIndex("ImageId")
                        .HasDatabaseName("ix_image_variants_image_id");

                    b.ToTable("image_variants", (string)null);
                });

            modelBuilder.Entity("NextbooruLite.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("ImagesCount")
                        .HasColumnType("integer")
                        .HasColumnName("images_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("TagType")
                        .HasColumnType("integer")
                        .HasColumnName("tag_type");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("pk_tags");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_tags_name");

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("AlbumImage", b =>
                {
                    b.HasOne("NextbooruLite.Model.Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_album_image_albums_albums_id");

                    b.HasOne("NextbooruLite.Model.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_album_image_images_images_id");
                });

            modelBuilder.Entity("ImageTag", b =>
                {
                    b.HasOne("NextbooruLite.Model.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_image_tag_images_images_id");

                    b.HasOne("NextbooruLite.Model.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_image_tag_tags_tags_id");
                });

            modelBuilder.Entity("NextbooruLite.Auth.Model.Session", b =>
                {
                    b.HasOne("NextbooruLite.Auth.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_sessions_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NextbooruLite.Model.Album", b =>
                {
                    b.HasOne("NextbooruLite.Auth.Model.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_albums_users_created_by_id");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("NextbooruLite.Model.Image", b =>
                {
                    b.HasOne("NextbooruLite.Auth.Model.User", "UploadedBy")
                        .WithMany()
                        .HasForeignKey("UploadedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_images_users_uploaded_by_id");

                    b.Navigation("UploadedBy");
                });

            modelBuilder.Entity("NextbooruLite.Model.ImageVariant", b =>
                {
                    b.HasOne("NextbooruLite.Model.Image", "Image")
                        .WithMany("Variants")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_image_variants_images_image_id");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("NextbooruLite.Model.Image", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
