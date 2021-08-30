--
-- File generated with SQLiteStudio v3.2.1 on Mon Feb 3 15:09:26 2020
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Products
CREATE TABLE "Products" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "CreateDate" TEXT NOT NULL,
    "ModifiedDate" TEXT NOT NULL,
    "IsDeleted" INTEGER NOT NULL,
    "Name" TEXT NULL,
    "Slug" TEXT NULL,
    "Description" TEXT NULL,
    "MetaDescription" TEXT NULL,
    "MetaKeywords" TEXT NULL,
    "SKU" TEXT NULL,
    "Model" TEXT NULL,
    "Price" TEXT NOT NULL,
    "SalePrice" TEXT NOT NULL,
    "OldPrice" TEXT NOT NULL,
    "ImageUrl" TEXT NULL,
    "QuantityInStock" INTEGER NOT NULL,
    "IsBestseller" INTEGER NOT NULL,
    "IsFeatured" INTEGER NOT NULL,
    "CategoryId" INTEGER NOT NULL,
    "BrandId" INTEGER NOT NULL,
    "ProductStatus" INTEGER NOT NULL,
    CONSTRAINT "FK_Products_Brands_BrandId" FOREIGN KEY ("BrandId") REFERENCES "Brands" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Products_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE CASCADE
);
INSERT INTO Products (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, SKU, Model, Price, SalePrice, OldPrice, ImageUrl, QuantityInStock, IsBestseller, IsFeatured, CategoryId, BrandId, ProductStatus) VALUES (1, '2021-08-07 19:43:49.1205091+01:00', '2021-08-07 19:43:49.1244219+01:00', 0, 'Samsung Galaxy S20 128Gb SM-G981U Gray 1Sim', 'samsung-galaxy-s20-128gb-sm-g981u-gray-1sim', 'Samsung Galaxy S20 128Gb SM-G981U Gray 1Sim', 'Samsung Galaxy S20 128Gb SM-G981U Gray 1Sim', 'Samsung Galaxy S20 128Gb SM-G981U Gray 1Sim', 'Samsung Galaxy S20 128Gb SM-G981U Gray 1Sim', 'Samsung Galaxy S20 128Gb SM-G981U Gray 1Sim', '799', '700.0', '0.0', 'samsung-galaxy-s20-128gb-sm-g981u-gray-1sim.jpg', 142, 0, 0, 6, 7, 0);

-- Index: IX_Products_BrandId
CREATE INDEX "IX_Products_BrandId" ON "Products" ("BrandId");

-- Index: IX_Products_CategoryId
CREATE INDEX "IX_Products_CategoryId" ON "Products" ("CategoryId");

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
