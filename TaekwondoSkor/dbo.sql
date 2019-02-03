/*
 Navicat Premium Data Transfer

 Source Server         : loc
 Source Server Type    : SQL Server
 Source Server Version : 11002100
 Source Host           : localhost\sqlexpress:1433
 Source Catalog        : taekwondo_skor
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 11002100
 File Encoding         : 65001

 Date: 10/05/2018 23:10:02
*/


-- ----------------------------
-- Table structure for Global_Veriler
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Global_Veriler]') AND type IN ('U'))
	DROP TABLE [dbo].[Global_Veriler]


CREATE TABLE [dbo].[Global_Veriler] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [mavirenk] varchar(50) COLLATE Turkish_CI_AS  NOT NULL,
  [kirmizirenk] varchar(50) COLLATE Turkish_CI_AS  NOT NULL,
  [arasuresi] time(7)  NOT NULL,
  [maxpuansayi] int  NOT NULL,
  [maxpuan] bit  NOT NULL,
  [raundsayisi] int  NOT NULL,
  [onikifarkpuani] bit  NOT NULL,
  [sureartan] bit  NOT NULL,
  [timeoutsureartan] bit  NOT NULL,
  [vucutpuani] int  NOT NULL,
  [kafapuani] int  NOT NULL,
  [raundsuresi] time(7)  NOT NULL,
  [skorrenk] varchar(50) COLLATE Turkish_CI_AS  NOT NULL
)


ALTER TABLE [dbo].[Global_Veriler] SET (LOCK_ESCALATION = TABLE)



-- ----------------------------
-- Records of Global_Veriler
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Global_Veriler] ON


INSERT INTO [dbo].[Global_Veriler] ([id], [mavirenk], [kirmizirenk], [arasuresi], [maxpuansayi], [maxpuan], [raundsayisi], [onikifarkpuani], [sureartan], [timeoutsureartan], [vucutpuani], [kafapuani], [raundsuresi], [skorrenk]) VALUES (N'2', N'#FF0B189C', N'#FFB70A0A', N'00:00:30.0000000', N'100', N'1', N'3', N'1', N'0', N'0', N'2', N'3', N'00:01:30.0000000', N'White')


SET IDENTITY_INSERT [dbo].[Global_Veriler] OFF



-- ----------------------------
-- Table structure for Kayitlar
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Kayitlar]') AND type IN ('U'))
	DROP TABLE [dbo].[Kayitlar]


CREATE TABLE [dbo].[Kayitlar] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [tarih] datetime  NULL,
  [islem] nvarchar(300) COLLATE Turkish_CI_AS  NULL,
  [macid] int  NULL
)


ALTER TABLE [dbo].[Kayitlar] SET (LOCK_ESCALATION = TABLE)



-- ----------------------------
-- Table structure for Maclar
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Maclar]') AND type IN ('U'))
	DROP TABLE [dbo].[Maclar]


CREATE TABLE [dbo].[Maclar] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [kisi1] nvarchar(100) COLLATE Turkish_CI_AS  NULL,
  [kisi2] nvarchar(100) COLLATE Turkish_CI_AS  NULL,
  [tarih] datetime  NULL
)


ALTER TABLE [dbo].[Maclar] SET (LOCK_ESCALATION = TABLE)



-- ----------------------------
-- Table structure for Sporcular
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Sporcular]') AND type IN ('U'))
	DROP TABLE [dbo].[Sporcular]


CREATE TABLE [dbo].[Sporcular] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [ad] nvarchar(100) COLLATE Turkish_CI_AS  NULL
)


ALTER TABLE [dbo].[Sporcular] SET (LOCK_ESCALATION = TABLE)



-- ----------------------------
-- Primary Key structure for table Global_Veriler
-- ----------------------------
ALTER TABLE [dbo].[Global_Veriler] ADD CONSTRAINT [PK_Global_Veriler] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]



-- ----------------------------
-- Primary Key structure for table Kayitlar
-- ----------------------------
ALTER TABLE [dbo].[Kayitlar] ADD CONSTRAINT [PK_Kayitlar] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]



-- ----------------------------
-- Primary Key structure for table Maclar
-- ----------------------------
ALTER TABLE [dbo].[Maclar] ADD CONSTRAINT [PK_Maclatr] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]



-- ----------------------------
-- Primary Key structure for table Sporcular
-- ----------------------------
ALTER TABLE [dbo].[Sporcular] ADD CONSTRAINT [PK_Sporcular] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]


