IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Authors] (
    [AuthorId] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    [Surname] nvarchar(20) NOT NULL,
    [ImageUrl] nvarchar(100) NULL,
    [Born] datetime2 NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([AuthorId])
);

GO

CREATE TABLE [Ingredient] (
    [IngredientId] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [QuantityId] int NOT NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY ([IngredientId])
);

GO

CREATE TABLE [Recipes] (
    [RecipeId] int NOT NULL IDENTITY,
    [Title] nvarchar(30) NOT NULL,
    [Description] nvarchar(500) NOT NULL,
    [AuthorId] int NOT NULL,
    [ImageUrl] nvarchar(100) NOT NULL,
    [PreparationTime] time NOT NULL,
    [TotalTime] time NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY ([RecipeId]),
    CONSTRAINT [FK_Recipes_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([AuthorId]) ON DELETE CASCADE
);

GO

CREATE TABLE [IngredientQuantity] (
    [IngredientQuantityId] int NOT NULL IDENTITY,
    [Ammount] real NOT NULL,
    [MeasurementUnit] nvarchar(20) NOT NULL,
    [IngredientId] int NOT NULL,
    CONSTRAINT [PK_IngredientQuantity] PRIMARY KEY ([IngredientQuantityId]),
    CONSTRAINT [FK_IngredientQuantity_Ingredient_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredient] ([IngredientId]) ON DELETE CASCADE
);

GO

CREATE TABLE [RecipeIngredient] (
    [RecipeId] int NOT NULL,
    [IngredientId] int NOT NULL,
    CONSTRAINT [PK_RecipeIngredient] PRIMARY KEY ([RecipeId], [IngredientId]),
    CONSTRAINT [FK_RecipeIngredient_Ingredient_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredient] ([IngredientId]) ON DELETE CASCADE,
    CONSTRAINT [FK_RecipeIngredient_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([RecipeId]) ON DELETE CASCADE
);

GO

CREATE TABLE [RecipeStep] (
    [RecipeStepId] int NOT NULL IDENTITY,
    [RecipeId] int NOT NULL,
    [Instruction] nvarchar(500) NOT NULL,
    [ImageUrl] nvarchar(100) NULL,
    CONSTRAINT [PK_RecipeStep] PRIMARY KEY ([RecipeStepId]),
    CONSTRAINT [FK_RecipeStep_Recipes_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([RecipeId]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_IngredientQuantity_IngredientId] ON [IngredientQuantity] ([IngredientId]);

GO

CREATE INDEX [IX_RecipeIngredient_IngredientId] ON [RecipeIngredient] ([IngredientId]);

GO

CREATE INDEX [IX_Recipes_AuthorId] ON [Recipes] ([AuthorId]);

GO

CREATE INDEX [IX_RecipeStep_RecipeId] ON [RecipeStep] ([RecipeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200910211926_InitialCreate', N'3.1.8');

GO

