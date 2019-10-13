/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[TB_USUARIOS]
           ([usu_usuario]
           ,[USU_PASSWORD]
           ,[USU_ROL_ADMINISTRADOR]
           ,[USU_ESTATUS]
           ,[USU_FECHA_CREACIOn]
           ,[USU_FECHA_CAMBIO_PASSWORD]
           ,[USU_CANTIDAD_LOGIN_ERROR]
           ,[USU_FLAG_ACTIVO])
     VALUES
           ('Josue'
           ,'123'
           ,'Administrador'
           ,'Activo'
           ,GETDATE()
           ,getdate()
           ,null
           ,1)

