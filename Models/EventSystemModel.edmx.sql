
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/16/2019 05:05:17
-- Generated from EDMX file: C:\Users\LEGION\source\repos\FIT5032_Assignment_Portfolio_Final\Models\EventSystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EventSystemDB];
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

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventId] int IDENTITY(1,1) NOT NULL,
    [EventName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Rating] decimal(18,0)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Latitude] decimal(18,0)  NOT NULL,
    [Longitude] decimal(18,0)  NOT NULL,
    [CustomerCustId] int  NOT NULL
);
GO

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [FriendId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [CustomerCustId] int  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [BookingId] int IDENTITY(1,1) NOT NULL,
    [BookingStatus] nvarchar(max)  NOT NULL,
    [CustomerCustId] int  NOT NULL,
    [EventEventId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustId] ASC);
GO

-- Creating primary key on [EventId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [FriendId] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([FriendId] ASC);
GO

-- Creating primary key on [BookingId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([BookingId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerCustId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_CustomerEvent]
    FOREIGN KEY ([CustomerCustId])
    REFERENCES [dbo].[Customers]
        ([CustId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerEvent'
CREATE INDEX [IX_FK_CustomerEvent]
ON [dbo].[Events]
    ([CustomerCustId]);
GO

-- Creating foreign key on [CustomerCustId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_CustomerBooking]
    FOREIGN KEY ([CustomerCustId])
    REFERENCES [dbo].[Customers]
        ([CustId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerBooking'
CREATE INDEX [IX_FK_CustomerBooking]
ON [dbo].[Bookings]
    ([CustomerCustId]);
GO

-- Creating foreign key on [EventEventId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_EventBooking]
    FOREIGN KEY ([EventEventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventBooking'
CREATE INDEX [IX_FK_EventBooking]
ON [dbo].[Bookings]
    ([EventEventId]);
GO

-- Creating foreign key on [CustomerCustId] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK_CustomerFriend]
    FOREIGN KEY ([CustomerCustId])
    REFERENCES [dbo].[Customers]
        ([CustId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerFriend'
CREATE INDEX [IX_FK_CustomerFriend]
ON [dbo].[Friends]
    ([CustomerCustId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------