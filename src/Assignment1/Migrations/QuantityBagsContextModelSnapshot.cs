using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Assignment1.Data;

namespace Assignment1.Migrations
{
    [DbContext(typeof(QuantityBagsContext))]
    partial class QuantityBagsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment1.Models.AllocateProductOrder", b =>
                {
                    b.Property<int>("AllocateProductOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<int>("Value");

                    b.HasKey("AllocateProductOrderID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("Allocate Product Order");
                });

            modelBuilder.Entity("Assignment1.Models.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandDescription");

                    b.Property<string>("BrandName");

                    b.Property<string>("BrandPicture");

                    b.HasKey("BrandID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Assignment1.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryDescription");

                    b.Property<string>("CategoryPicture");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Assignment1.Models.Colour", b =>
                {
                    b.Property<int>("ColourID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColourName");

                    b.Property<string>("ColourPicture");

                    b.HasKey("ColourID");

                    b.ToTable("Colour");
                });

            modelBuilder.Entity("Assignment1.Models.ColourAllocation", b =>
                {
                    b.Property<int>("ColourAllocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColourID");

                    b.Property<int>("ProductID");

                    b.HasKey("ColourAllocationID");

                    b.HasIndex("ColourID");

                    b.HasIndex("ProductID");

                    b.ToTable("Colour Allocation");
                });

            modelBuilder.Entity("Assignment1.Models.Material", b =>
                {
                    b.Property<int>("MaterialID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MaterialDescription");

                    b.HasKey("MaterialID");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Assignment1.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GST");

                    b.Property<int>("GrossAmount");

                    b.Property<int>("NetAmount");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderNumber");

                    b.Property<string>("OrderStatus");

                    b.Property<int>("UserID");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Assignment1.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandID");

                    b.Property<int>("CategoryID");

                    b.Property<string>("LargeImage");

                    b.Property<int>("MaterialID");

                    b.Property<string>("MediumImage");

                    b.Property<int>("Price");

                    b.Property<string>("ProductDescription");

                    b.Property<int>("SizeID");

                    b.Property<string>("SmallImage");

                    b.Property<int>("TotalValue");

                    b.HasKey("ProductID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("MaterialID");

                    b.HasIndex("SizeID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Assignment1.Models.Size", b =>
                {
                    b.Property<int>("SizeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SizeDescription");

                    b.HasKey("SizeID");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("Assignment1.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Password");

                    b.Property<int>("PostCode");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("Suburb");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Assignment1.Models.AllocateProductOrder", b =>
                {
                    b.HasOne("Assignment1.Models.Order", "Orders")
                        .WithMany("AllocateProductOrders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment1.Models.Product", "Products")
                        .WithMany("AllocateProductOrders")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assignment1.Models.ColourAllocation", b =>
                {
                    b.HasOne("Assignment1.Models.Colour", "Colours")
                        .WithMany("ColourAllocations")
                        .HasForeignKey("ColourID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment1.Models.Product", "Products")
                        .WithMany("ColourAllocations")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assignment1.Models.Order", b =>
                {
                    b.HasOne("Assignment1.Models.User", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Assignment1.Models.Product", b =>
                {
                    b.HasOne("Assignment1.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment1.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment1.Models.Material", "Material")
                        .WithMany("Products")
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Assignment1.Models.Size", "Size")
                        .WithMany("Products")
                        .HasForeignKey("SizeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
