-- Drop foreign key constraints
IF OBJECT_ID('FK_Post_User', 'F') IS NOT NULL
    ALTER TABLE Post DROP CONSTRAINT FK_Post_User;

IF OBJECT_ID('FK_Comment_Post', 'F') IS NOT NULL
    ALTER TABLE Comment DROP CONSTRAINT FK_Comment_Post;

IF OBJECT_ID('FK_Comment_User', 'F') IS NOT NULL
    ALTER TABLE Comment DROP CONSTRAINT FK_Comment_User;

IF OBJECT_ID('FK_Pictures_Post', 'F') IS NOT NULL
    ALTER TABLE Pictures DROP CONSTRAINT FK_Pictures_Post;

IF OBJECT_ID('FK_Likes_Post', 'F') IS NOT NULL
    ALTER TABLE Likes DROP CONSTRAINT FK_Likes_Post;
	
IF OBJECT_ID('FK_AuctionPurchases_Auction', 'F') IS NOT NULL
    ALTER TABLE AuctionPurchases DROP CONSTRAINT FK_AuctionPurchases_Auction;

IF OBJECT_ID('FK_AuctionPurchases_User_Buyer', 'F') IS NOT NULL
    ALTER TABLE AuctionPurchases DROP CONSTRAINT FK_AuctionPurchases_User_Buyer;

IF OBJECT_ID('FK_AuctionPurchases_User_Seller', 'F') IS NOT NULL
    ALTER TABLE AuctionPurchases DROP CONSTRAINT FK_AuctionPurchases_User_Seller;

IF OBJECT_ID('FK_Auction_Product', 'F') IS NOT NULL
    ALTER TABLE Auction DROP CONSTRAINT FK_Auction_Product;

IF OBJECT_ID('FK_InstaBuyPurchases_InstaBuy', 'F') IS NOT NULL
    ALTER TABLE InstaBuyPurchases DROP CONSTRAINT FK_InstaBuyPurchases_InstaBuy;

-- Drop tables if they exist
IF OBJECT_ID('AuctionPurchases', 'U') IS NOT NULL
    DROP TABLE AuctionPurchases;

IF OBJECT_ID('InstaBuyPurchases', 'U') IS NOT NULL
    DROP TABLE InstaBuyPurchases;

IF OBJECT_ID('Auction', 'U') IS NOT NULL
    DROP TABLE Auction;

IF OBJECT_ID('InstaBuy', 'U') IS NOT NULL
    DROP TABLE InstaBuy;

IF OBJECT_ID('Product', 'U') IS NOT NULL
    DROP TABLE Product;

IF OBJECT_ID('[User]', 'U') IS NOT NULL
    DROP TABLE [User];

IF OBJECT_ID('Bids', 'U') IS NOT NULL
    DROP TABLE Bids;

IF OBJECT_ID('Likes', 'U') IS NOT NULL
    DROP TABLE Likes;   

IF OBJECT_ID('Pictures', 'U') IS NOT NULL
    DROP TABLE Pictures;

IF OBJECT_ID('Comment', 'U') IS NOT NULL
    DROP TABLE Comment;

IF OBJECT_ID('Post', 'U') IS NOT NULL
    DROP TABLE Post;

IF OBJECT_ID('[User]', 'U') IS NOT NULL
    DROP TABLE [User];


-- Create [User] table
CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Bio VARCHAR(255),
    Country VARCHAR(255),
    PersonalLink VARCHAR(255),
    ProfilePictureLink VARCHAR(255)
);

-- Create Post table
CREATE TABLE Post (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT REFERENCES [User],
    Text VARCHAR(2047),
    TimePosted DATETIME
);

-- Create Comment table
CREATE TABLE Comment (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT REFERENCES Post,
    UserId INT REFERENCES [User],
    Text VARCHAR(1023),
    TimePosted DATETIME
);

-- Create Pictures table
CREATE TABLE Pictures (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT REFERENCES Post,
    PictureUrl VARCHAR(2047)
);

-- Create Likes table
CREATE TABLE Likes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT REFERENCES Post,
    UserId INT REFERENCES [User],
    TimeLiked DATETIME
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
    ArtistId INT REFERENCES [User]
);

-- Create InstaBuy table
CREATE TABLE InstaBuy (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT REFERENCES Product,
    Price DECIMAL(18,2),
    IsArchived BIT,
    CreatedAt DATETIME
);

-- Create InstaBuyPurchases table
CREATE TABLE InstaBuyPurchases (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT,
    InstaId INT REFERENCES InstaBuy ON DELETE CASCADE,
    PurchasedAt DATETIME
);

-- Create Auction table
CREATE TABLE Auction (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EndsAt DATETIME,
    FirstPrice DECIMAL(18,2),
    ProductId INT REFERENCES Product,
    EstimatedMinimum DECIMAL(18,2),
    EstimatedMaximum DECIMAL(18,2),
    IsArchived BIT,
    CreatedAt DATETIME
);

-- Create AuctionPurchases table
CREATE TABLE AuctionPurchases (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SellerId INT REFERENCES [User],
    BuyerId INT REFERENCES [User],
    AuctionId INT REFERENCES Auction ON DELETE CASCADE,
    FinalPrice DECIMAL(18,2),
    PurchasedAt DATETIME
);

-- Create Bids table
CREATE TABLE Bids (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AuctionId INT REFERENCES Auction ON DELETE CASCADE,
    BidderId INT REFERENCES [User],
    Amount DECIMAL(18,2),
    PlacedAt DATETIME
);

-- Insert data into [User] table
INSERT INTO [User] (Email, Password, FirstName, LastName, Bio, Country, PersonalLink)
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

	INSERT INTO Post (UserId, Text, TimePosted)
VALUES
    (1, 'This is the first post.', '2023-11-28T12:00:00'),
    (2, 'A post by user 2.', '2023-11-28T12:15:00'),
    (3, 'Post number 3.', '2023-11-28T12:30:00'),
    (4, 'User 4s post.', '2023-11-28T12:45:00'),
    (5, 'Post by the last user.', '2023-11-28T13:00:00');

-- Insert mock data into Comment table
INSERT INTO Comment (PostId, UserId, Text, TimePosted)
VALUES
    (1, 2, 'Nice post!', '2023-11-28T12:05:00'),
    (2, 3, 'Interesting.', '2023-11-28T12:20:00'),
    (3, 4, 'I agree.', '2023-11-28T12:35:00'),
    (4, 5, 'User 5s comment.', '2023-11-28T12:50:00'),
    (5, 1, 'Great stuff!', '2023-11-28T13:05:00');

-- Insert mock data into Pictures table
INSERT INTO Pictures (PostId, PictureUrl)
VALUES
    (1, 'https://example.com/pic1.jpg'),
    (2, 'https://example.com/pic2.jpg'),
    (3, 'https://example.com/pic3.jpg'),
    (4, 'https://example.com/pic4.jpg'),
    (5, 'https://example.com/pic5.jpg');

-- Insert mock data into Likes table
INSERT INTO Likes (PostId, UserId, TimeLiked)
VALUES
    (1, 2, '2023-11-28T12:15:00'),
    (2, 3, '2023-11-28T12:30:00'),
    (3, 4, '2023-11-28T12:45:00'),
    (4, 5, '2023-11-28T13:00:00'),
    (5, 1, '2023-11-28T13:15:00');