-- Drop tables if they exist
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bid]') AND type in (N'U'))
DROP TABLE [dbo].[Bid]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comment]') AND type in (N'U'))
DROP TABLE [dbo].[Comment]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FixedPriceListingPurchase]') AND type in (N'U'))
DROP TABLE [dbo].[FixedPriceListingPurchase]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Like]') AND type in (N'U'))
DROP TABLE [dbo].[Like]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FixedPriceListing]') AND type in (N'U'))
DROP TABLE [dbo].[FixedPriceListing]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Auction]') AND type in (N'U'))
DROP TABLE [dbo].[Auction]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductImage]') AND type in (N'U'))
DROP TABLE [dbo].[ProductImage]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Post]') AND type in (N'U'))
DROP TABLE [dbo].[Post]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]

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
    ImageLink VARCHAR(1024) NOT NULL,
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
    ImageLink VARCHAR(1024) NOT NULL,
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

CREATE TABLE ProductImage (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT FOREIGN KEY REFERENCES Product(Id) ON DELETE CASCADE NOT NULL,
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
INSERT INTO [User] (FirstName, LastName, Email, Password, Bio, Country, PersonalLink, ImageLink, Role, CreatedAt)
VALUES
    ('John', 'Doe', 'user1@example.com', '$2y$10$LlOJPlB32pvLticp4IOtzOaGEuSpYc2rbXaCP3y.SMZpKqdkT6gfe', 'A bio about John', 'USA', 'https://personal.link/user1', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', 0, '2023-11-28T12:00:00'),
    ('Jane', 'Smith', 'user2@example.com', '$2y$10$ezuuJVVZjoWN55kb/V28F.s.c/GXHAJ0UuyZHWcaHxL2tuk1v0uCm', 'A bio about Jane', 'Canada', 'https://personal.link/user2', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', 0, '2023-11-28T12:15:00'),
    ('Alice', 'Johnson', 'user3@example.com', '$2y$10$qDNITugQYSgDR/BnVhnkUeic1ipEpoqZWj0TNGLVNhoUOMuCFSOdC', 'A bio about Alice', 'UK', 'https://personal.link/user3', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', 0, '2023-11-28T12:30:00'),
    ('Bob', 'Brown', 'user4@example.com', '$2y$10$ZP7hcURMc5C6Kkns2cRLr.lw4CyoJcSIcHdAMB4EAn18X2SYBQk2y', 'A bio about Bob', 'Australia', 'https://personal.link/user4', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', 0, '2023-11-28T12:45:00'),
    ('Eve', 'White', 'user5@example.com', '$2y$10$El6ffgJWv7qt/T8ickI8lewVyu92jh0xsWg2rH6oMoMAh28sC/9r.', 'A bio about Eve', 'New Zealand', 'https://personal.link/user5', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', 0, '2023-11-28T13:00:00');

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

	INSERT INTO Post (UserId, Text, ImageLink, CreatedAt)
VALUES
    (1, 'This is the first post.', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-11-28T12:00:00'),
    (2, 'A post by user 2.', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-11-28T12:15:00'),
    (3, 'Post number 3.', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-11-28T12:30:00'),
    (4, 'User 4s post.', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-11-28T12:45:00'),
    (5, 'Post by the last user.', 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-11-28T13:00:00');

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

INSERT INTO ProductImage (ProductId, Link, CreatedAt)
VALUES
    (1, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00'),
    (2, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00'),
    (3, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00'),
    (4, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00'),
    (5, 'https://zongbucket.s3.eu-north-1.amazonaws.com/posts/5', '2023-10-01T12:15:00');