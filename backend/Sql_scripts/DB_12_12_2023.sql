-- Create User table
CREATE TABLE [User] (
    Id INT PRIMARY KEY,
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
    Id INT PRIMARY KEY,
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
    Id INT PRIMARY KEY,
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
    Id INT PRIMARY KEY,
    AuctionId INT FOREIGN KEY REFERENCES Auction(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create Post table
CREATE TABLE Post (
    Id INT PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    Text VARCHAR(2048) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create Comment table
CREATE TABLE Comment (
    Id INT PRIMARY KEY,
    PostId INT FOREIGN KEY REFERENCES Post(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    Text VARCHAR(1024) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create Like table
CREATE TABLE [Like] (
    Id INT PRIMARY KEY,
    PostId INT FOREIGN KEY REFERENCES Post(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create FixedPriceListing table
CREATE TABLE FixedPriceListing (
    Id INT PRIMARY KEY,
    ProductId INT FOREIGN KEY REFERENCES Product(Id) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    IsArchived BIT NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Create FixedPriceListingPurchase table
CREATE TABLE FixedPriceListingPurchase (
    Id INT PRIMARY KEY,
    BuyerId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    FixedPriceListingId INT FOREIGN KEY REFERENCES FixedPriceListing(Id) ON DELETE CASCADE NOT NULL,
    CreatedAt DATETIME NOT NULL
);
