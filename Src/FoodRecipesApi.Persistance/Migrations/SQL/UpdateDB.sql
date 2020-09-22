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

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RecipeStep]') AND [c].[name] = N'ImageUrl');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [RecipeStep] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [RecipeStep] ALTER COLUMN [ImageUrl] nvarchar(250) NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'Title');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Recipes] ALTER COLUMN [Title] nvarchar(150) NOT NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'ImageUrl');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Recipes] ALTER COLUMN [ImageUrl] nvarchar(250) NOT NULL;

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'Description');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Recipes] ALTER COLUMN [Description] nvarchar(1000) NOT NULL;

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MeasurementUnit]') AND [c].[name] = N'Unit');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [MeasurementUnit] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [MeasurementUnit] ALTER COLUMN [Unit] nvarchar(75) NOT NULL;

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ingredient]') AND [c].[name] = N'Name');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Ingredient] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Ingredient] ALTER COLUMN [Name] nvarchar(150) NOT NULL;

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'Surname');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Authors] ALTER COLUMN [Surname] nvarchar(50) NOT NULL;

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'Name');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Authors] ALTER COLUMN [Name] nvarchar(50) NOT NULL;

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'ImageUrl');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Authors] ALTER COLUMN [ImageUrl] nvarchar(250) NULL;

GO

CREATE INDEX [IX_Authors_Name_Surname_Born] ON [Authors] ([Name], [Surname], [Born]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200913204317_AlterMaxLengthConstrainsForBiggerSizes', N'3.1.8');

GO

DROP INDEX [IX_Authors_Name_Surname_Born] ON [Authors];

GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Authors]') AND [c].[name] = N'Born');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Authors] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Authors] DROP COLUMN [Born];

GO

CREATE INDEX [IX_Authors_Name_Surname] ON [Authors] ([Name], [Surname]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200913204950_RemoveAuthorEntityBornProp', N'3.1.8');

GO

CREATE INDEX [IX_Recipes_Title_AuthorId] ON [Recipes] ([Title], [AuthorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200913205909_MadeIndexesOfAuthorAndTitleRecipeProps', N'3.1.8');

GO

ALTER TABLE [Authors] ADD CONSTRAINT [AK_Authors_Name_Surname] UNIQUE ([Name], [Surname]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200913211131_AddAlternateKeyByAuthorNameAndSurnameProps', N'3.1.8');

GO

ALTER TABLE [Recipes] ADD CONSTRAINT [AK_Recipes_Title_AuthorId] UNIQUE ([Title], [AuthorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200913211251_AddAlternateKeyByRecipeAuthorIdAndTitleProps', N'3.1.8');

GO

ALTER TABLE [IngredientQuantity] DROP CONSTRAINT [FK_IngredientQuantity_Ingredient_IngredientId];

GO

ALTER TABLE [RecipeIngredient] DROP CONSTRAINT [FK_RecipeIngredient_Ingredient_IngredientId];

GO

ALTER TABLE [Recipes] DROP CONSTRAINT [FK_Recipes_Authors_AuthorId];

GO

ALTER TABLE [Ingredient] DROP CONSTRAINT [PK_Ingredient];

GO

EXEC sp_rename N'[Ingredient]', N'Ingredients';

GO

ALTER TABLE [Ingredients] ADD CONSTRAINT [PK_Ingredients] PRIMARY KEY ([IngredientId]);

GO

ALTER TABLE [IngredientQuantity] ADD CONSTRAINT [FK_IngredientQuantity_Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredients] ([IngredientId]) ON DELETE CASCADE;

GO

ALTER TABLE [RecipeIngredient] ADD CONSTRAINT [FK_RecipeIngredient_Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredients] ([IngredientId]) ON DELETE CASCADE;

GO

ALTER TABLE [Recipes] ADD CONSTRAINT [FK_Recipes_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([AuthorId]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200915082412_RenameIngredientTableToIngredients', N'3.1.8');

GO

ALTER TABLE [Authors] DROP CONSTRAINT [AK_Authors_Name_Surname];

GO

DROP INDEX [IX_Authors_Name_Surname] ON [Authors];

GO

ALTER TABLE [Authors] ADD [EmailAdress] nvarchar(60) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Authors] ADD CONSTRAINT [AK_Authors_Name_Surname_EmailAdress] UNIQUE ([Name], [Surname], [EmailAdress]);

GO

CREATE INDEX [IX_Authors_Name_Surname_EmailAdress] ON [Authors] ([Name], [Surname], [EmailAdress]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200922073753_AddAuthorEmailAdressProp', N'3.1.8');

GO

