-- Drop foreign key constraints

-- Drop constraints in the Comment table
ALTER TABLE Comment
DROP CONSTRAINT FK_Comment_Post;

ALTER TABLE Comment
DROP CONSTRAINT FK_Comment_User;

-- Drop constraints in the Like table
ALTER TABLE [Like]
DROP CONSTRAINT FK_Like_Post;

ALTER TABLE [Like]
DROP CONSTRAINT FK_Like_User;

-- Drop constraints in the Bid table
ALTER TABLE Bid
DROP CONSTRAINT FK_Bid_Auction;

ALTER TABLE Bid
DROP CONSTRAINT FK_Bid_User;

-- Drop constraints in the Auction table
ALTER TABLE Auction
DROP CONSTRAINT FK_Auction_Product;

-- Drop constraints in the FixedPriceListingPurchase table
ALTER TABLE FixedPriceListingPurchase
DROP CONSTRAINT FK_FixedPriceListingPurchase_User;

ALTER TABLE FixedPriceListingPurchase
DROP CONSTRAINT FK_FixedPriceListingPurchase_FixedPriceListing;

-- Drop constraints in the FixedPriceListing table
ALTER TABLE FixedPriceListing
DROP CONSTRAINT FK_FixedPriceListing_Product;

-- Drop constraints in the Post table
ALTER TABLE Post
DROP CONSTRAINT FK_Post_User;

-- Drop constraints in the Product table
ALTER TABLE Product
DROP CONSTRAINT FK_Product_User;

-- Drop tables
DROP TABLE IF EXISTS FixedPriceListingPurchase;
DROP TABLE IF EXISTS FixedPriceListing;
DROP TABLE IF EXISTS [Like];
DROP TABLE IF EXISTS Comment;
DROP TABLE IF EXISTS Post;
DROP TABLE IF EXISTS Bid;
DROP TABLE IF EXISTS Auction;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS [User];

-- Create User table
CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Bio VARCHAR(MAX),
    Country VARCHAR(255),
    PersonalLink VARCHAR(255),
    CreatedAt DATETIME NOT NULL
);

-- Create Product table
CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Height DECIMAL(18,2) NOT NULL,
    Width DECIMAL(18,2) NOT NULL,
    Depth DECIMAL(18,2) NOT NULL,
    Weight DECIMAL(18,2) NOT NULL,
    Title VARCHAR(255) NOT NULL,
    Description VARCHAR(MAX) NOT NULL,
    Artist VARCHAR(255) NOT NULL,
    SellerId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    Year INT,
    CreatedAt DATETIME NOT NULL
);

-- Create Auction table
CREATE TABLE Auction (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT FOREIGN KEY REFERENCES Product(Id) NOT NULL,
    StartingPrice DECIMAL(18,2) NOT NULL,
    ReservePrice DECIMAL(18,2) NOT NULL,
    EstimateMinPrice DECIMAL(18,2) NOT NULL,
    EstimateMaxPrice DECIMAL(18,2) NOT NULL,
    EndsAt DATETIME NOT NULL,
    IsArchived BIT NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create Bid table
CREATE TABLE Bid (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AuctionId INT FOREIGN KEY REFERENCES Auction(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create Post table
CREATE TABLE Post (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    Text VARCHAR(2048) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create Comment table
CREATE TABLE Comment (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT FOREIGN KEY REFERENCES Post(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    Text VARCHAR(1024) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create Like table
CREATE TABLE [Like] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT FOREIGN KEY REFERENCES Post(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create FixedPriceListing table
CREATE TABLE FixedPriceListing (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT FOREIGN KEY REFERENCES Product(Id) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    IsArchived BIT NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create FixedPriceListingPurchase table
CREATE TABLE FixedPriceListingPurchase (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BuyerId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    FixedPriceListingId INT FOREIGN KEY REFERENCES FixedPriceListing(Id) ON DELETE CASCADE NOT NULL,
    CreatedAt DATETIME NOT NULL
);
