
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/23/2016 16:06:18
-- Generated from EDMX file: C:\Users\sreichert\Documents\GitHub\Bazaar\DeVes.Bazaar.DataModel\BazaarStockSet.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BazaarTbl];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SupplierSet'
CREATE TABLE [dbo].[SupplierSet] (
    [Number] int IDENTITY(1,1) NOT NULL,
    [Salutation] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [Adress] nvarchar(50)  NULL,
    [ZipCode] nvarchar(50)  NULL,
    [Town] nvarchar(50)  NULL,
    [Phone01] nvarchar(50)  NULL,
    [EMail01] nvarchar(50)  NULL,
    [Memo] nvarchar(50)  NULL,
    [CreatedAt] datetime  NULL,
    [ChangedAt] datetime  NULL,
    [SoldOutAt] datetime  NULL
);
GO

-- Creating table 'MaterialsSet'
CREATE TABLE [dbo].[MaterialsSet] (
    [Number] int IDENTITY(1,1) NOT NULL,
    [SupplierNumber] int  NOT NULL,
    [Materialname] nvarchar(50)  NOT NULL,
    [MaterialCategory] nvarchar(50)  NOT NULL,
    [MaterialManufacturer] nvarchar(50)  NOT NULL,
    [PriceMin] float  NULL,
    [PriceMax] float  NOT NULL,
    [Memo] nvarchar(50)  NULL,
    [SoldFor] float  NULL,
    [CreatedAt] datetime  NULL,
    [ChangedAt] datetime  NULL,
    [ReturnedAt] datetime  NULL,
    [SoldAt] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Number] in table 'SupplierSet'
ALTER TABLE [dbo].[SupplierSet]
ADD CONSTRAINT [PK_SupplierSet]
    PRIMARY KEY CLUSTERED ([Number] ASC);
GO

-- Creating primary key on [Number] in table 'MaterialsSet'
ALTER TABLE [dbo].[MaterialsSet]
ADD CONSTRAINT [PK_MaterialsSet]
    PRIMARY KEY CLUSTERED ([Number] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SupplierNumber] in table 'MaterialsSet'
ALTER TABLE [dbo].[MaterialsSet]
ADD CONSTRAINT [FK_SupplierMaterials]
    FOREIGN KEY ([SupplierNumber])
    REFERENCES [dbo].[SupplierSet]
        ([Number])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SupplierMaterials'
CREATE INDEX [IX_FK_SupplierMaterials]
ON [dbo].[MaterialsSet]
    ([SupplierNumber]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------