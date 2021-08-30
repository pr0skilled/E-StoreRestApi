--
-- File generated with SQLiteStudio v3.2.1 on Mon Feb 3 15:08:31 2020
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Brands
CREATE TABLE "Brands" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Brands" PRIMARY KEY AUTOINCREMENT,
    "CreateDate" TEXT NOT NULL,
    "ModifiedDate" TEXT NOT NULL,
    "IsDeleted" INTEGER NOT NULL,
    "Name" TEXT NULL,
    "Slug" TEXT NULL,
    "Description" TEXT NULL,
    "MetaDescription" TEXT NULL,
    "MetaKeywords" TEXT NULL,
    "BrandStatus" INTEGER NOT NULL
);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (1, '2021-08-05 12:11:26.9625642+01:00', '2021-08-05 12:11:26.9625642+01:00', 0, 'Adidas', 'adidas', 'ADIDAS', 'ADIDAS', 'ADIDAS', 0);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (2, '2021-08-05 12:11:35.0107962+01:00', '2021-08-05 12:11:35.0107962+01:00', 0, 'Nike', 'nike', 'NIKE', 'NIKE', 'NIKE', 0);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (3, '2021-08-05 12:11:38.1845219+01:00', '2021-08-05 12:11:38.1845219+01:00', 0, 'Saucony', 'saucony', 'Saucony', 'Saucony', 'Saucony', 0);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (4, '2021-08-05 12:11:39.7762466+01:00', '2021-08-05 12:11:39.7762466+01:00', 0, 'New Balance', 'new-balance', 'New Balance', 'New Balance', 'New Balance', 0);
INSERT INTO Brands (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, BrandStatus) VALUES (5, '2021-08-05 12:11:41.4107006+01:00', '2021-08-05 12:11:41.4107006+01:00', 0, 'Dr. Martens', 'drmartens', 'Dr. Martens', 'Dr. Martens', 'Dr. Martens', 0);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
