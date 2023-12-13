-- Drop the existing primary key constraint (if exists)
ALTER TABLE [dbo].[Post]
DROP CONSTRAINT [PK__Post__3214EC0718A37F55];

-- Add the Id column as an identity column
ALTER TABLE [dbo].[Post]
ADD Id INT IDENTITY(1,1);

-- Add the new primary key constraint
ALTER TABLE [dbo].[Post]
ADD CONSTRAINT PK_Post PRIMARY KEY (Id);
