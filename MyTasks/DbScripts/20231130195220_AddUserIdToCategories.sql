ALTER TABLE [Categories] ADD [UserId] nvarchar(450) NULL;

GO

CREATE INDEX [IX_Categories_UserId] ON [Categories] ([UserId]);

GO

ALTER TABLE [Categories] ADD CONSTRAINT [FK_Categories_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231130195220_AddUserIdToCategories', N'3.1.31');

GO

