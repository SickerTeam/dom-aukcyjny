-- Drop foreign key constraints if they exist
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'FOREIGN KEY')
BEGIN
    ALTER TABLE Bid DROP CONSTRAINT IF EXISTS FK_Bid_Auction;
    ALTER TABLE Bid DROP CONSTRAINT IF EXISTS FK_Bid_User;

    ALTER TABLE Product DROP CONSTRAINT IF EXISTS FK_Product_User;

    ALTER TABLE Post DROP CONSTRAINT IF EXISTS FK_Post_User;

    ALTER TABLE Comment DROP CONSTRAINT IF EXISTS FK_Comment_Post;
    ALTER TABLE Comment DROP CONSTRAINT IF EXISTS FK_Comment_User;

    ALTER TABLE Picture DROP CONSTRAINT IF EXISTS FK_Picture_Post;
    ALTER TABLE Picture DROP CONSTRAINT IF EXISTS FK_Picture_User;

    ALTER TABLE [Like] DROP CONSTRAINT IF EXISTS FK_Like_Post;
    ALTER TABLE [Like] DROP CONSTRAINT IF EXISTS FK_Like_User;

    ALTER TABLE Auction DROP CONSTRAINT IF EXISTS FK_Auction_Product;

    ALTER TABLE FixedPriceListing DROP CONSTRAINT IF EXISTS FK_FixedPriceListing_Product;

    ALTER TABLE FixedPriceListingPurchase DROP CONSTRAINT IF EXISTS FK_FixedPriceListingPurchase_User;
    ALTER TABLE FixedPriceListingPurchase DROP CONSTRAINT IF EXISTS FK_FixedPriceListingPurchase_FixedPriceListing;
END

-- Drop tables if they exist
IF OBJECT_ID('Bid', 'U') IS NOT NULL
    DROP TABLE Bids;

IF OBJECT_ID('FixedPriceListingPurchase', 'U') IS NOT NULL
    DROP TABLE InstaBuyPurchases;

IF OBJECT_ID('[Like]', 'U') IS NOT NULL
    DROP TABLE Likes;   

IF OBJECT_ID('Comment', 'U') IS NOT NULL
    DROP TABLE Comment;

IF OBJECT_ID('Picture', 'U') IS NOT NULL
    DROP TABLE Picture;
    
IF OBJECT_ID('Auction', 'U') IS NOT NULL
    DROP TABLE Auction;

IF OBJECT_ID('FixedPriceListing', 'U') IS NOT NULL
    DROP TABLE InstaBuy;

IF OBJECT_ID('Post', 'U') IS NOT NULL
    DROP TABLE Post;

IF OBJECT_ID('Product', 'U') IS NOT NULL
    DROP TABLE Product;

IF OBJECT_ID('[User]', 'U') IS NOT NULL
    DROP TABLE [User];

-- Create tables
CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Bio VARCHAR(2048),
    Country VARCHAR(255),
    PersonalLink VARCHAR(255),
    ProfilePictureLink VARCHAR(255),
    Role INT NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Product (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Height DECIMAL(18,2) NOT NULL,
    Width DECIMAL(18,2) NOT NULL,
    Depth DECIMAL(18,2) NOT NULL,
    Weight DECIMAL(18,2) NOT NULL,
    Title VARCHAR(255) NOT NULL,
    Description VARCHAR(2048) NOT NULL,
    Artist VARCHAR(255) NOT NULL,
    SellerId INT FOREIGN KEY REFERENCES [User](Id) ON DELETE CASCADE NOT NULL,
    Year INT,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Auction (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT FOREIGN KEY REFERENCES Product(Id) ON DELETE CASCADE NOT NULL,
    StartingPrice DECIMAL(18,2) NOT NULL,
    ReservePrice DECIMAL(18,2) NOT NULL,
    EstimateMinPrice DECIMAL(18,2) NOT NULL,
    EstimateMaxPrice DECIMAL(18,2) NOT NULL,
    EndsAt DATETIME NOT NULL,
    IsArchived BIT NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Bid (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AuctionId INT FOREIGN KEY REFERENCES Auction(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) ON DELETE NO ACTION NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Post (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES [User](Id) ON DELETE CASCADE NOT NULL,
    Text VARCHAR(2048) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Comment (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT FOREIGN KEY REFERENCES Post(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) ON DELETE NO ACTION NOT NULL,
    Text VARCHAR(1024) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE [Like] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT FOREIGN KEY REFERENCES Post(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) ON DELETE NO ACTION NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE Picture (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PostId INT FOREIGN KEY REFERENCES Post(Id) ON DELETE CASCADE NOT NULL,
    UserId INT FOREIGN KEY REFERENCES [User](Id) ON DELETE NO ACTION NOT NULL,
    Link VARCHAR(1024) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE FixedPriceListing (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT FOREIGN KEY REFERENCES Product(Id) ON DELETE CASCADE NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    IsArchived BIT NOT NULL,
    CreatedAt DATETIME NOT NULL
);

CREATE TABLE FixedPriceListingPurchase (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BuyerId INT FOREIGN KEY REFERENCES [User](Id) ON DELETE NO ACTION NOT NULL,
    FixedPriceListingId INT FOREIGN KEY REFERENCES FixedPriceListing(Id) ON DELETE NO ACTION NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Insert mock data into the tables
INSERT INTO [User] (FirstName, LastName, Email, Password, Bio, Country, PersonalLink, ProfilePictureLink, Role, CreatedAt)
VALUES
    ('John', 'Doe', 'user1@example.com', 'password1', 'A bio about John', 'USA', 'https://personal.link/user1', 'https://personal.link/user1', 0, '2023-11-28T12:00:00'),
    ('Jane', 'Smith', 'user2@example.com', 'password2', 'A bio about Jane', 'Canada', 'https://personal.link/user2', 'https://personal.link/user1', 0, '2023-11-28T12:15:00'),
    ('Alice', 'Johnson', 'user3@example.com', 'password3', 'A bio about Alice', 'UK', 'https://personal.link/user3', 'https://personal.link/user1', 0, '2023-11-28T12:30:00'),
    ('Bob', 'Brown', 'user4@example.com', 'password4', 'A bio about Bob', 'Australia', 'https://personal.link/user4', 'https://personal.link/user1', 0, '2023-11-28T12:45:00'),
    ('Eve', 'White', 'user5@example.com', 'password5', 'A bio about Eve', 'New Zealand', 'https://personal.link/user5', 'https://personal.link/user1', 0, '2023-11-28T13:00:00');

INSERT INTO Product (Height, Width, Depth, Weight, Title, Description, Artist, SellerId, Year, CreatedAt)
VALUES
    (10.5, 20.5, 5.0, 2.3, 'Product 1', 'Description for Product 1', 'Leonardo da Vinci', 1, 1500, '2023-11-28T12:00:00'),
    (15.0, 25.0, 8.2, 3.1, 'Product 2', 'Description for Product 2', 'Artemisia Gentileschi', 2, 1800, '2023-11-28T12:15:00'),
    (12.2, 18.0, 6.5, 2.8, 'Product 3', 'Description for Product 3', 'Rembrandt', 3, 1700, '2023-11-28T12:30:00'),
    (18.5, 30.0, 10.0, 4.2, 'Product 4', 'Description for Product 4', 'Claude Monet', 4, 1950, '2023-11-28T12:45:00'),
    (22.0, 35.5, 12.5, 5.5, 'Product 5', 'Description for Product 5', 'Mary Cassatt', 5, 2000, '2023-11-28T13:00:00');

INSERT INTO FixedPriceListing (ProductId, Price, IsArchived, CreatedAt)
VALUES
    (1, 50.99, 0, '2023-11-28T12:00:00'),
    (2, 75.50, 0, '2023-11-28T12:15:00'),
    (3, 60.25, 1, '2023-11-28T12:30:00'),
    (4, 90.00, 0, '2023-11-28T12:45:00'),
    (5, 110.75, 0, '2023-11-28T13:00:00');

INSERT INTO FixedPriceListingPurchase (BuyerId, FixedPriceListingId, CreatedAt)
VALUES
    (1, 1, '2023-11-28T12:05:00'),
    (2, 2, '2023-11-28T12:20:00'),
    (3, 3, '2023-11-28T12:35:00'),
    (4, 4, '2023-11-28T12:50:00'),
    (5, 5, '2023-11-28T13:05:00');

INSERT INTO Auction (ProductId, StartingPrice, ReservePrice, EstimateMinPrice, EstimateMaxPrice, EndsAt, IsArchived, CreatedAt)
VALUES
    (1, 30, 50, 40.00, 80.00, '2023-12-01T12:00:00', 0, '2023-11-28T12:00:00'),
    (2, 50, 60, 60.00, 100.00, '2023-12-02T12:00:00', 0, '2023-11-28T12:00:00'),
    (3, 55, 60, 45.00, 90.00, '2023-12-03T12:00:00', 1, '2023-11-28T12:00:00'),
    (4, 80, 80, 70.00, 120.00, '2023-12-04T12:00:00', 0, '2023-11-28T12:00:00'),
    (5, 100, 120, 90.00, 150.00, '2023-12-05T12:00:00', 0, '2023-11-28T12:00:00');

INSERT INTO Bid (AuctionId, UserId, Amount, CreatedAt)
VALUES
    (1, 2, 55.00, '2023-12-01T12:15:00'),
    (2, 3, 80.00, '2023-12-02T12:15:00'),
    (3, 4, 65.00, '2023-12-03T12:15:00'),
    (4, 5, 95.00, '2023-12-04T12:15:00'),
    (5, 1, 115.00, '2023-12-05T12:15:00');

	INSERT INTO Post (UserId, Text, CreatedAt)
VALUES
    (1, 'This is the first post.', '2023-11-28T12:00:00'),
    (2, 'A post by user 2.', '2023-11-28T12:15:00'),
    (3, 'Post number 3.', '2023-11-28T12:30:00'),
    (4, 'User 4s post.', '2023-11-28T12:45:00'),
    (5, 'Post by the last user.', '2023-11-28T13:00:00');

INSERT INTO Comment (PostId, UserId, Text, CreatedAt)
VALUES
    (1, 2, 'Nice post!', '2023-11-28T12:05:00'),
    (2, 3, 'Interesting.', '2023-11-28T12:20:00'),
    (3, 4, 'I agree.', '2023-11-28T12:35:00'),
    (4, 5, 'User 5s comment.', '2023-11-28T12:50:00'),
    (5, 1, 'Great stuff!', '2023-11-28T13:05:00');

INSERT INTO [Like] (PostId, UserId, CreatedAt)
VALUES
    (1, 2, '2023-11-28T12:15:00'),
    (2, 3, '2023-11-28T12:30:00'),
    (3, 4, '2023-11-28T12:45:00'),
    (4, 5, '2023-11-28T13:00:00'),
    (5, 1, '2023-11-28T13:15:00');

INSERT INTO Picture (PostId, UserId, Link, CreatedAt)
VALUES
    (1, 2, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00'),
    (2, 3, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00'),
    (3, 4, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00'),
    (4, 5, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00'),
    (5, 1, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00');