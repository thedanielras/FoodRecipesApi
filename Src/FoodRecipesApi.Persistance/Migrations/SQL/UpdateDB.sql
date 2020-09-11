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

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IngredientQuantity]') AND [c].[name] = N'Ammount');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [IngredientQuantity] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [IngredientQuantity] DROP COLUMN [Ammount];

GO

ALTER TABLE [IngredientQuantity] ADD [Amount] real NOT NULL DEFAULT CAST(0 AS real);

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'Born');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Authors] ALTER COLUMN [Born] Date NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200911090408_SetAuthorBornPropColToTypeDate', N'3.1.8');

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'PreparationTime');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Recipes] DROP COLUMN [PreparationTime];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'TotalTime');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Recipes] DROP COLUMN [TotalTime];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IngredientQuantity]') AND [c].[name] = N'MeasurementUnit');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [IngredientQuantity] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [IngredientQuantity] DROP COLUMN [MeasurementUnit];

GO

ALTER TABLE [Recipes] ADD [PreparationTimeInMinutes] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Recipes] ADD [TotalTimeInMinutes] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [IngredientQuantity] ADD [MeasurementUnitId] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [MeasurementUnit] (
    [MeasurementUnitId] int NOT NULL IDENTITY,
    [Unit] nvarchar(15) NOT NULL,
    [IngredientQuantityId] int NOT NULL,
    CONSTRAINT [PK_MeasurementUnit] PRIMARY KEY ([MeasurementUnitId]),
    CONSTRAINT [FK_MeasurementUnit_IngredientQuantity_IngredientQuantityId] FOREIGN KEY ([IngredientQuantityId]) REFERENCES [IngredientQuantity] ([IngredientQuantityId]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_MeasurementUnit_IngredientQuantityId] ON [MeasurementUnit] ([IngredientQuantityId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200911212345_AddMeasurementUnitTableAndChangedTheRecipeTimesTypes', N'3.1.8');

GO

