ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [YourDay_v4], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

