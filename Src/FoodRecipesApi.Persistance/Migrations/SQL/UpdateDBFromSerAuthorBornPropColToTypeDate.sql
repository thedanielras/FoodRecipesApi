DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'PreparationTime');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Recipes] DROP COLUMN [PreparationTime];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Recipes]') AND [c].[name] = N'TotalTime');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Recipes] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Recipes] DROP COLUMN [TotalTime];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IngredientQuantity]') AND [c].[name] = N'MeasurementUnit');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [IngredientQuantity] DROP CONSTRAINT [' + @var2 + '];');
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

