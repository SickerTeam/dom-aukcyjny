-- Drop constraints and delete tables
-- (Please note that dropping constraints and deleting tables will result in data loss)
-- Drop foreign key constraints
ALTER TABLE InstaBuyPurchases DROP CONSTRAINT FK_InstaBuyPurchases_InstaBuy;
ALTER TABLE Auction DROP CONSTRAINT FK_Auction_Product;
ALTER TABLE AuctionPurchases DROP CONSTRAINT FK_AuctionPurchases_User_Seller;
ALTER TABLE AuctionPurchases DROP CONSTRAINT FK_AuctionPurchases_User_Buyer;
ALTER TABLE AuctionPurchases DROP CONSTRAINT FK_AuctionPurchases_Auction;

-- Drop tables
DROP TABLE IF EXISTS Bids;
DROP TABLE IF EXISTS AuctionPurchases;
DROP TABLE IF EXISTS Auction;
DROP TABLE IF EXISTS InstaBuyPurchases;
DROP TABLE IF EXISTS InstaBuy;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS User;

-- Create User table
CREATE TABLE User (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Bio VARCHAR(255),
    Country VARCHAR(255),
    PersonalLink VARCHAR(255)
);

-- Create Product table
CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Height DECIMAL(18,2),
    Width DECIMAL(18,2),
    Depth DECIMAL(18,2),
    Weight DECIMAL(18,2),
    Title VARCHAR(255),
    Description VARCHAR(255),
    ArtistId INT REFERENCES User
);

-- Create InstaBuy table
CREATE TABLE InstaBuy (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT REFERENCES Product,
    Price DECIMAL(18,2),
    IsArchived BOOLEAN,
    CreatedAt DATETIME
);

-- Create InstaBuyPurchases table
CREATE TABLE InstaBuyPurchases (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT,
    InstaId INT REFERENCES InstaBuy,
    PurchasedAt DATETIME
);

-- Create Auction table
CREATE TABLE Auction (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EndsAt DATETIME,
    FirstPrice INT,
    ProductId INT REFERENCES Product,
    EstimatedMinimum DECIMAL(18,2),
    EstimatedMaximum DECIMAL(18,2),
    IsArchived BOOLEAN,
    CreatedAt DATETIME
);

-- Create AuctionPurchases table
CREATE TABLE AuctionPurchases (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SellerId INT REFERENCES User,
    BuyerId INT REFERENCES User,
    AuctionId INT REFERENCES Auction,
    FinalPrice DECIMAL(18,2),
    PurchasedAt DATETIME
);

-- Create Bids table
CREATE TABLE Bids (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AuctionId INT REFERENCES Auction,
    BidderId INT REFERENCES User,
    Amount DECIMAL(18,2),
    PlacedAt DATETIME
);

-- Insert data into User table
INSERT INTO User (Email, Password, FirstName, LastName, Bio, Country, PersonalLink)
VALUES
    ('user1@example.com', 'password1', 'John', 'Doe', 'A bio about John', 'USA', 'https://personal.link/user1'),
    ('user2@example.com', 'password2', 'Jane', 'Smith', 'A bio about Jane', 'Canada', 'https://personal.link/user2'),
    ('user3@example.com', 'password3', 'Alice', 'Johnson', 'A bio about Alice', 'UK', 'https://personal.link/user3'),
    ('user4@example.com', 'password4', 'Bob', 'Brown', 'A bio about Bob', 'Australia', 'https://personal.link/user4'),
    ('user5@example.com', 'password5', 'Eve', 'White', 'A bio about Eve', 'New Zealand', 'https://personal.link/user5');

-- Insert data into Product table
INSERT INTO Product (Height, Width, Depth, Weight, Title, Description, ArtistId)
VALUES
    (10.5, 20.5, 5.0, 2.3, 'Product 1', 'Description for Product 1', 1),
    (15.0, 25.0, 8.2, 3.1, 'Product 2', 'Description for Product 2', 2),
    (12.2, 18.0, 6.5, 2.8, 'Product 3', 'Description for Product 3', 3),
    (18.5, 30.0, 10.0, 4.2, 'Product 4', 'Description for Product 4', 4),
    (22.0, 35.5, 12.5, 5.5, 'Product 5', 'Description for Product 5', 5);

-- Insert data into InstaBuy table
INSERT INTO InstaBuy (ProductId, Price, IsArchived, CreatedAt)
VALUES
    (1, 50.99, 0, '2023-11-28T12:00:00'),
    (2, 75.50, 0, '2023-11-28T12:15:00'),
    (3, 60.25, 1, '2023-11-28T12:30:00'),
    (4, 90.00, 0, '2023-11-28T12:45:00'),
    (5, 110.75, 0, '2023-11-28T13:00:00');

-- Insert data into InstaBuyPurchases table
INSERT INTO InstaBuyPurchases (UserId, InstaId, PurchasedAt)
VALUES
    (1, 1, '2023-11-28T12:05:00'),
    (2, 2, '2023-11-28T12:20:00'),
    (3, 3, '2023-11-28T12:35:00'),
    (4, 4, '2023-11-28T12:50:00'),
    (5, 5, '2023-11-28T13:05:00');

-- Insert data into Auction table
INSERT INTO Auction (EndsAt, FirstPrice, ProductId, EstimatedMinimum, EstimatedMaximum, IsArchived, CreatedAt)
VALUES
    ('2023-12-01T12:00:00', 50, 1, 40.00, 80.00, 0, '2023-11-28T12:00:00'),
    ('2023-12-02T12:00:00', 70, 2, 60.00, 100.00, 0, '2023-11-28T12:00:00'),
    ('2023-12-03T12:00:00', 55, 3, 45.00, 90.00, 1, '2023-11-28T12:00:00'),
    ('2023-12-04T12:00:00', 80, 4, 70.00, 120.00, 0, '2023-11-28T12:00:00'),
    ('2023-12-05T12:00:00', 100, 5, 90.00, 150.00, 0, '2023-11-28T12:00:00');

-- Insert data into AuctionPurchases table
INSERT INTO AuctionPurchases (SellerId, BuyerId, AuctionId, FinalPrice, PurchasedAt)
VALUES
    (1, 2, 1, 60.50, '2023-12-01T12:30:00'),
    (2, 3, 2, 85.75, '2023-12-02T12:30:00'),
    (3, 4, 3, 70.25, '2023-12-03T12:30:00'),
    (4, 5, 4, 100.00, '2023-12-04T12:30:00'),
    (5, 1, 5, 120.50, '2023-12-05T12:30:00');

-- Insert data into Bids table
INSERT INTO Bids (AuctionId, BidderId, Amount, PlacedAt)
VALUES
    (1, 2, 55.00, '2023-12-01T12:15:00'),
    (2, 3, 80.00, '2023-12-02T12:15:00'),
    (3, 4, 65.00, '2023-12-03T12:15:00'),
    (4, 5, 95.00, '2023-12-04T12:15:00'),
    (5, 1, 115.00, '2023-12-05T12:15:00');
