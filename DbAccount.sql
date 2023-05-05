/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [idAccount]
      ,[username]
      ,[pwd]
      ,[date_of_creation]
  FROM [CredentialManager].[dbo].[Account]