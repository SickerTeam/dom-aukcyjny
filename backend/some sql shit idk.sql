-- Drop foreign key constraints
IF OBJECT_ID('FK_product_user', 'F') IS NOT NULL ALTER TABLE product DROP CONSTRAINT FK_product_user;
IF OBJECT_ID('FK_instabuypurchases_instabuy', 'F') IS NOT NULL ALTER TABLE instabuypurchases DROP CONSTRAINT FK_instabuypurchases_instabuy;
IF OBJECT_ID('FK_auction_product', 'F') IS NOT NULL ALTER TABLE auction DROP CONSTRAINT FK_auction_product;
IF OBJECT_ID('FK_auctionpurchases_user_seller', 'F') IS NOT NULL ALTER TABLE auctionpurchases DROP CONSTRAINT FK_auctionpurchases_user_seller;
IF OBJECT_ID('FK_auctionpurchases_user_buyer', 'F') IS NOT NULL ALTER TABLE auctionpurchases DROP CONSTRAINT FK_auctionpurchases_user_buyer;
IF OBJECT_ID('FK_auctionpurchases_auction', 'F') IS NOT NULL ALTER TABLE auctionpurchases DROP CONSTRAINT FK_auctionpurchases_auction;
IF OBJECT_ID('FK_bids_auction', 'F') IS NOT NULL ALTER TABLE bids DROP CONSTRAINT FK_bids_auction;
IF OBJECT_ID('FK_bids_user', 'F') IS NOT NULL ALTER TABLE bids DROP CONSTRAINT FK_bids_user;

-- Drop existing tables and types
IF OBJECT_ID('product', 'U') IS NOT NULL DROP TABLE product;
IF OBJECT_ID('"user"', 'U') IS NOT NULL DROP TABLE "user";
IF OBJECT_ID('instabuy', 'U') IS NOT NULL DROP TABLE instabuy;
IF OBJECT_ID('instabuypurchases', 'U') IS NOT NULL DROP TABLE instabuypurchases;
IF OBJECT_ID('auction', 'U') IS NOT NULL DROP TABLE auction;
IF OBJECT_ID('auctionpurchases', 'U') IS NOT NULL DROP TABLE auctionpurchases;
IF OBJECT_ID('bids', 'U') IS NOT NULL DROP TABLE bids;


-- Create "user" table
CREATE TABLE "user" (
    userid INT IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(255) NOT NULL,
    pass VARCHAR(255) NOT NULL,
    firstName VARCHAR(255),
    lastName VARCHAR(255),
    UPID INT NOT NULL,
    bio VARCHAR(255),
    country VARCHAR(255),
    personal_link VARCHAR(255)
);

-- Create product table
CREATE TABLE product (
    productid INT IDENTITY(1,1) PRIMARY KEY,
    height REAL,
    widht REAL,
    [depth] REAL,
    weight REAL,
    title VARCHAR(255),
    description VARCHAR(255),
    artisid INT REFERENCES "user"
);

-- Create instabuy table
CREATE TABLE instabuy (
    instaid INT IDENTITY(1,1) PRIMARY KEY,
    price REAL,
    archived BIT
);

-- Create instabuypurchases table
CREATE TABLE instabuypurchases (
    purchaseid INT IDENTITY(1,1) PRIMARY KEY,
    userid INT,
    instaid INT REFERENCES instabuy,
    purchasetime DATETIME
);

-- Create auction table
CREATE TABLE auction (
    auctionid INT IDENTITY(1,1) PRIMARY KEY,
    endtime DATETIME,
    firstprice INT,
    productid INT REFERENCES product,
    estimatedminimum REAL,
    estimatedmaximum REAL,
    archived BIT
);

-- Create auctionpurchases table
CREATE TABLE auctionpurchases (
    purchaseid INT IDENTITY(1,1) PRIMARY KEY,
    sellerid INT REFERENCES "user",
    buyerid INT REFERENCES "user",
    auctionid INT REFERENCES auction,
    finalprice REAL,
    purchasetime DATETIME
);

-- Create bids table
CREATE TABLE bids (
    bidid INT IDENTITY(1,1) PRIMARY KEY,
    auctionid INT REFERENCES auction,
    bidderid INT REFERENCES "user",
    bidamount REAL
);

-- Insert data into "user" table
INSERT INTO "user" (email, pass, firstName, lastName, UPID, bio, country, personal_link)
VALUES 
    ('user1@example.com', 'password1', 'John', 'Doe', 1, 'Bio for user 1', 'USA', 'http://personal-link-1.com'),
    ('user2@example.com', 'password2', 'Jane', 'Smith', 2, 'Bio for user 2', 'Canada', 'http://personal-link-2.com'),
    ('user3@example.com', 'password3', 'Alice', 'Johnson',  3, 'Bio for user 3', 'UK', 'http://personal-link-3.com');

-- Insert data into "product" table
INSERT INTO product (height, widht, [depth], weight, title, description, artisid)
VALUES 
    (100, 80, 5, 10, 'Artwork 1', 'Description for Artwork 1', 2),
    (120, 90, 6, 15, 'Artwork 2', 'Description for Artwork 2', 1),
    (80, 60, 4, 8, 'Artwork 3', 'Description for Artwork 3', 3);

-- Insert data into "instabuy" table
INSERT INTO instabuy (price, archived)
VALUES 
    (50.0, 0),
    (75.0, 1),
    (100.0, 0);

-- Insert data into "instabuypurchases" table
INSERT INTO instabuypurchases (userid, instaid, purchasetime)
VALUES 
    (1, 1, CURRENT_TIMESTAMP),
    (2, 2, CURRENT_TIMESTAMP),
    (3, 3, CURRENT_TIMESTAMP);

-- Insert data into "auction" table
INSERT INTO auction (endtime, firstprice, productid, estimatedminimum, estimatedmaximum, archived)
VALUES 
    ('2023-12-01 12:00:00', 200, 1, 150.0, 300.0, 0),
    ('2023-12-05 15:30:00', 150, 2, 100.0, 200.0, 0),
    ('2023-12-10 10:00:00', 300, 3, 250.0, 400.0, 0);

-- Insert data into "auctionpurchases" table
INSERT INTO auctionpurchases (sellerid, buyerid, auctionid, finalprice, purchasetime)
VALUES 
    (2, 1, 1, 250.0, CURRENT_TIMESTAMP),
    (1, 3, 2, 180.0, CURRENT_TIMESTAMP),
    (3, 2, 3, 350.0, CURRENT_TIMESTAMP);

-- Insert data into "bids" table
INSERT INTO bids (auctionid, bidderid, bidamount)
VALUES 
    (1, 3, 220.0),
    (1, 1, 270.0),
    (2, 2, 160.0);
