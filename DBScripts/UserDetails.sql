IF NOT EXISTS ( SELECT
                    *
                FROM
                    INFORMATION_SCHEMA.TABLES T
                WHERE
                    T.TABLE_NAME = 'Users'
                    AND T.TABLE_SCHEMA = 'dbo' )
    BEGIN
        CREATE TABLE dbo.Users
            (
              UserId INT NOT NULL CONSTRAINT Pk_User PRIMARY KEY IDENTITY(1, 1) ,
			  FirstName NVARCHAR(255),
			  LastName NVARCHAR(255),
			  MobileNumber NVARCHAR(25),
			  Email NVARCHAR(100),
			  DOB DATETIME,
              DateAdded DATETIME ,
              DateModified DATETIME
            )
    END

IF NOT EXISTS ( SELECT
                    *
                FROM
                    sys.columns
                WHERE
                    columns.object_id = OBJECT_ID(N'dbo.Users')
                    AND columns.name = 'IsDeleted' )
    BEGIN
        ALTER TABLE dbo.Users
        ADD IsDeleted BIt ;
    END
