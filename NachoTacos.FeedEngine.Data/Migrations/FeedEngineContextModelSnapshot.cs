﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NachoTacos.FeedEngine.Data;

namespace NachoTacos.FeedEngine.Data.Migrations
{
    [DbContext(typeof(FeedEngineContext))]
    partial class FeedEngineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItem", b =>
                {
                    b.Property<string>("FeedItemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("FeedSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BaseUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Copyright")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FeedItemId", "FeedSourceId");

                    b.ToTable("FeedItems");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItemAuthor", b =>
                {
                    b.Property<Guid>("FeedItemAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FeedItemFeedSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeedItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedItemId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedItemAuthorId");

                    b.HasIndex("FeedItemId1", "FeedItemFeedSourceId");

                    b.ToTable("FeedItemAuthors");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItemCategory", b =>
                {
                    b.Property<Guid>("FeedItemCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FeedItemFeedSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeedItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedItemId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scheme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedItemCategoryId");

                    b.HasIndex("FeedItemId1", "FeedItemFeedSourceId");

                    b.ToTable("FeedItemCategories");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItemContributor", b =>
                {
                    b.Property<Guid>("FeedItemContributorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FeedItemFeedSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeedItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedItemId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedItemContributorId");

                    b.HasIndex("FeedItemId1", "FeedItemFeedSourceId");

                    b.ToTable("FeedItemContributors");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItemLink", b =>
                {
                    b.Property<Guid>("FeedItemLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FeedItemFeedSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeedItemId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedItemId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MediaType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationshipType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedItemLinkId");

                    b.HasIndex("FeedItemId1", "FeedItemFeedSourceId");

                    b.ToTable("FeedItemLinks");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedSource", b =>
                {
                    b.Property<Guid>("FeedSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FeedUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FeedSourceId");

                    b.HasIndex("FeedTypeCode");

                    b.ToTable("FeedSources");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedType", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("FeedTypes");

                    b.HasData(
                        new
                        {
                            Code = "RSS091",
                            Description = "RSS 0.91"
                        },
                        new
                        {
                            Code = "RSS092",
                            Description = "RSS 0.92"
                        },
                        new
                        {
                            Code = "RSS1",
                            Description = "RSS 1.0"
                        },
                        new
                        {
                            Code = "RSS2",
                            Description = "RSS 2.0"
                        },
                        new
                        {
                            Code = "ATOM",
                            Description = "ATOM"
                        });
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItemAuthor", b =>
                {
                    b.HasOne("NachoTacos.FeedEngine.Domain.FeedItem", null)
                        .WithMany("Authors")
                        .HasForeignKey("FeedItemId1", "FeedItemFeedSourceId");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItemCategory", b =>
                {
                    b.HasOne("NachoTacos.FeedEngine.Domain.FeedItem", null)
                        .WithMany("Categories")
                        .HasForeignKey("FeedItemId1", "FeedItemFeedSourceId");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItemContributor", b =>
                {
                    b.HasOne("NachoTacos.FeedEngine.Domain.FeedItem", null)
                        .WithMany("Contributors")
                        .HasForeignKey("FeedItemId1", "FeedItemFeedSourceId");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedItemLink", b =>
                {
                    b.HasOne("NachoTacos.FeedEngine.Domain.FeedItem", null)
                        .WithMany("Links")
                        .HasForeignKey("FeedItemId1", "FeedItemFeedSourceId");
                });

            modelBuilder.Entity("NachoTacos.FeedEngine.Domain.FeedSource", b =>
                {
                    b.HasOne("NachoTacos.FeedEngine.Domain.FeedType", "FeedType")
                        .WithMany()
                        .HasForeignKey("FeedTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
