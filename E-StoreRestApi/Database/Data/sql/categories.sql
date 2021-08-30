--
-- File generated with SQLiteStudio v3.2.1 on Mon Feb 3 15:08:51 2020
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Categories
CREATE TABLE "Categories" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "CreateDate" TEXT NOT NULL,
    "ModifiedDate" TEXT NOT NULL,
    "IsDeleted" INTEGER NOT NULL,
    "Name" TEXT NULL,
    "Slug" TEXT NULL,
    "Description" TEXT NULL,
    "MetaDescription" TEXT NULL,
    "MetaKeywords" TEXT NULL,
    "CategoryStatus" INTEGER NOT NULL
);
INSERT INTO Categories (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, CategoryStatus) VALUES (1, '2021-08-05 12:19:31.2151155+01:00', '2019-09-05 12:19:31.2193723+01:00', 0, 'Shoes', 'shoes', 'Shoes', 'Shoes', 'Shoes', 0);
INSERT INTO Categories (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, CategoryStatus) VALUES (2, '2021-08-05 12:19:35.3914241+01:00', '2019-09-05 12:19:35.3914351+01:00', 0, 'Notebooks', 'notebooks', 'Notebooks', 'Notebooks', 'Notebooks', 0);
INSERT INTO Categories (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, CategoryStatus) VALUES (3, '2021-08-05 12:19:36.4270588+01:00', '2019-09-05 12:19:36.4270806+01:00', 0, 'Clothes', 'clothes', 'Clothes', 'Clothes', 'Clothes', 0);
INSERT INTO Categories (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, CategoryStatus) VALUES (4, '2021-08-05 12:19:37.3761237+01:00', '2019-09-05 12:19:37.3761351+01:00', 0, 'Accessories', 'accessories', 'Accessories', 'Accessories', 'Accessories', 0);
INSERT INTO Categories (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, CategoryStatus) VALUES (5, '2021-08-05 12:19:38.5843523+01:00', '2019-09-05 12:19:38.5843629+01:00', 0, 'Jewelry', 'jewelry', 'Jewelry', 'Jewelry', 'Jewelry', 0);
INSERT INTO Categories (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, CategoryStatus) VALUES (6, '2021-08-05 12:19:39.598841+01:00', '2019-09-05 12:19:39.598852+01:00', 0, 'Phones', 'phones', 'Phones', 'Phones', 'Phones', 0);
INSERT INTO Categories (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, CategoryStatus) VALUES (7, '2021-08-05 12:19:41.0836632+01:00', '2019-09-05 12:19:41.0836742+01:00', 0, 'Computers', 'computers', 'Computers', 'Computers', 'Computers', 0);
INSERT INTO Categories (Id, CreateDate, ModifiedDate, IsDeleted, Name, Slug, Description, MetaDescription, MetaKeywords, CategoryStatus) VALUES (8, '2021-08-05 12:19:42.165861+01:00', '2019-09-05 12:19:42.1658817+01:00', 0, 'Tools', 'tools', 'Tools', 'Tools', 'Tools', 0);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
