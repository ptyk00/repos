USE [master]
GO
/****** Object:  Database [BDII_proj]    Script Date: 2020-05-21 14:17:04 ******/
CREATE DATABASE [BDII_proj]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDII_proj', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDII_proj.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDII_proj_log', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDII_proj_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDII_proj] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDII_proj].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDII_proj] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDII_proj] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDII_proj] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDII_proj] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDII_proj] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDII_proj] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDII_proj] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDII_proj] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDII_proj] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDII_proj] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDII_proj] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDII_proj] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDII_proj] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDII_proj] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDII_proj] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDII_proj] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDII_proj] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDII_proj] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDII_proj] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDII_proj] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDII_proj] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDII_proj] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDII_proj] SET RECOVERY FULL 
GO
ALTER DATABASE [BDII_proj] SET  MULTI_USER 
GO
ALTER DATABASE [BDII_proj] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDII_proj] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDII_proj] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDII_proj] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDII_proj] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDII_proj', N'ON'
GO
ALTER DATABASE [BDII_proj] SET QUERY_STORE = OFF
GO
USE [BDII_proj]
GO
/****** Object:  Table [dbo].[FakturaSprzedaży]    Script Date: 2020-05-21 14:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FakturaSprzedaży](
	[NrFakturySprz] [int] NOT NULL,
	[Opis] [varchar](50) NOT NULL,
	[DataWystawienia] [date] NOT NULL,
	[IDProduktu] [int] NOT NULL,
	[CenaNetto] [decimal](18, 2) NOT NULL,
	[CenaBrutto] [decimal](18, 2) NOT NULL,
	[IDKontrahenta] [int] NOT NULL,
	[TerminPłatności] [date] NOT NULL,
	[VAT] [int] NOT NULL,
 CONSTRAINT [PK_FakturaSprzedaży] PRIMARY KEY CLUSTERED 
(
	[NrFakturySprz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FakturaZakupu]    Script Date: 2020-05-21 14:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FakturaZakupu](
	[NrFakturyZak] [int] NOT NULL,
	[Opis] [varchar](50) NOT NULL,
	[DataWystawienia] [date] NOT NULL,
	[IDProduktu] [int] NOT NULL,
	[CenaNetto] [decimal](18, 2) NOT NULL,
	[CenaBrutto] [decimal](18, 2) NOT NULL,
	[IDKontrahenta] [int] NOT NULL,
	[TerminPłatności] [date] NOT NULL,
	[VAT] [int] NOT NULL,
 CONSTRAINT [PK_FakturaZakupu] PRIMARY KEY CLUSTERED 
(
	[NrFakturyZak] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KasaPrzyjmie]    Script Date: 2020-05-21 14:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KasaPrzyjmie](
	[NrDokumentu] [int] NOT NULL,
	[NrFakturySprz] [int] NOT NULL,
	[Data] [date] NOT NULL,
	[Kwota] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_KasaPrzyjmie] PRIMARY KEY CLUSTERED 
(
	[NrDokumentu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KasaWypłaci]    Script Date: 2020-05-21 14:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KasaWypłaci](
	[NrDokumentu] [int] NOT NULL,
	[NrFakturyZak] [int] NOT NULL,
	[Data] [date] NOT NULL,
	[Kwota] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_KasaWypłaci] PRIMARY KEY CLUSTERED 
(
	[NrDokumentu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategorie]    Script Date: 2020-05-21 14:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorie](
	[IDKategori] [int] NOT NULL,
	[NazwaKategori] [varchar](50) NOT NULL,
	[Opis] [varchar](50) NULL,
 CONSTRAINT [PK_Kategorie] PRIMARY KEY CLUSTERED 
(
	[IDKategori] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kontrahenci]    Script Date: 2020-05-21 14:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kontrahenci](
	[IDKontrahenta] [int] NOT NULL,
	[NazwaKontrahenta] [varchar](50) NOT NULL,
	[Adres] [varchar](50) NOT NULL,
	[NIP] [int] NOT NULL,
	[RodzajKonrahenta] [varchar](50) NOT NULL,
	[Stan] [varchar](50) NOT NULL,
	[NrFakturySprz] [int] NOT NULL,
	[NrFakturyZak] [int] NOT NULL,
	[Należność] [decimal](18, 2) NULL,
	[Zobowiązanie] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Kontrahenci] PRIMARY KEY CLUSTERED 
(
	[IDKontrahenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produkty]    Script Date: 2020-05-21 14:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produkty](
	[IDProduktu] [int] NOT NULL,
	[NazwaProduktu] [varchar](50) NOT NULL,
	[IDKategori] [int] NOT NULL,
	[IlośćJedkostkowa] [int] NOT NULL,
	[CenaSprzedaży] [decimal](18, 2) NOT NULL,
	[CenaZakupu] [decimal](18, 2) NOT NULL,
	[StanMagazynu] [int] NOT NULL,
 CONSTRAINT [PK_Produkty] PRIMARY KEY CLUSTERED 
(
	[IDProduktu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RaportKasowy]    Script Date: 2020-05-21 14:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RaportKasowy](
	[IDRaportu] [int] NOT NULL,
	[NrDokumentu] [int] NOT NULL,
	[Okres] [date] NOT NULL,
	[SaldoPoczatkowe] [decimal](18, 2) NOT NULL,
	[Wpłaty] [decimal](18, 2) NOT NULL,
	[Wypłaty] [decimal](18, 2) NOT NULL,
	[SaldoKońcowe] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_RaportKasowy] PRIMARY KEY CLUSTERED 
(
	[IDRaportu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FakturaSprzedaży]  WITH CHECK ADD  CONSTRAINT [FK_FakturaSprzedaży_Kontrahenci] FOREIGN KEY([IDKontrahenta])
REFERENCES [dbo].[Kontrahenci] ([IDKontrahenta])
GO
ALTER TABLE [dbo].[FakturaSprzedaży] CHECK CONSTRAINT [FK_FakturaSprzedaży_Kontrahenci]
GO
ALTER TABLE [dbo].[FakturaSprzedaży]  WITH CHECK ADD  CONSTRAINT [FK_FakturaSprzedaży_Produkty] FOREIGN KEY([IDProduktu])
REFERENCES [dbo].[Produkty] ([IDProduktu])
GO
ALTER TABLE [dbo].[FakturaSprzedaży] CHECK CONSTRAINT [FK_FakturaSprzedaży_Produkty]
GO
ALTER TABLE [dbo].[FakturaZakupu]  WITH CHECK ADD  CONSTRAINT [FK_FakturaZakupu_Kontrahenci] FOREIGN KEY([IDKontrahenta])
REFERENCES [dbo].[Kontrahenci] ([IDKontrahenta])
GO
ALTER TABLE [dbo].[FakturaZakupu] CHECK CONSTRAINT [FK_FakturaZakupu_Kontrahenci]
GO
ALTER TABLE [dbo].[FakturaZakupu]  WITH CHECK ADD  CONSTRAINT [FK_FakturaZakupu_Produkty] FOREIGN KEY([IDProduktu])
REFERENCES [dbo].[Produkty] ([IDProduktu])
GO
ALTER TABLE [dbo].[FakturaZakupu] CHECK CONSTRAINT [FK_FakturaZakupu_Produkty]
GO
ALTER TABLE [dbo].[KasaPrzyjmie]  WITH CHECK ADD  CONSTRAINT [FK_KasaPrzyjmie_FakturaSprzedaży] FOREIGN KEY([NrFakturySprz])
REFERENCES [dbo].[FakturaSprzedaży] ([NrFakturySprz])
GO
ALTER TABLE [dbo].[KasaPrzyjmie] CHECK CONSTRAINT [FK_KasaPrzyjmie_FakturaSprzedaży]
GO
ALTER TABLE [dbo].[KasaWypłaci]  WITH CHECK ADD  CONSTRAINT [FK_KasaWypłaci_FakturaZakupu] FOREIGN KEY([NrFakturyZak])
REFERENCES [dbo].[FakturaZakupu] ([NrFakturyZak])
GO
ALTER TABLE [dbo].[KasaWypłaci] CHECK CONSTRAINT [FK_KasaWypłaci_FakturaZakupu]
GO
ALTER TABLE [dbo].[Produkty]  WITH CHECK ADD  CONSTRAINT [FK_Produkty_Kategorie] FOREIGN KEY([IDKategori])
REFERENCES [dbo].[Kategorie] ([IDKategori])
GO
ALTER TABLE [dbo].[Produkty] CHECK CONSTRAINT [FK_Produkty_Kategorie]
GO
ALTER TABLE [dbo].[RaportKasowy]  WITH CHECK ADD  CONSTRAINT [FK_RaportKasowy_KasaPrzyjmie] FOREIGN KEY([NrDokumentu])
REFERENCES [dbo].[KasaPrzyjmie] ([NrDokumentu])
GO
ALTER TABLE [dbo].[RaportKasowy] CHECK CONSTRAINT [FK_RaportKasowy_KasaPrzyjmie]
GO
ALTER TABLE [dbo].[RaportKasowy]  WITH CHECK ADD  CONSTRAINT [FK_RaportKasowy_KasaWypłaci] FOREIGN KEY([NrDokumentu])
REFERENCES [dbo].[KasaWypłaci] ([NrDokumentu])
GO
ALTER TABLE [dbo].[RaportKasowy] CHECK CONSTRAINT [FK_RaportKasowy_KasaWypłaci]
GO
USE [master]
GO
ALTER DATABASE [BDII_proj] SET  READ_WRITE 
GO
