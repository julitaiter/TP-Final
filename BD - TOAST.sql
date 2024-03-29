USE [master]
GO
/****** Object:  Database [BD - TOAST]    Script Date: 4/12/2019 11:19:34 ******/
CREATE DATABASE [BD - TOAST]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD - TOAST', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BD - TOAST.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD - TOAST_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BD - TOAST_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BD - TOAST] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD - TOAST].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD - TOAST] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD - TOAST] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD - TOAST] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD - TOAST] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD - TOAST] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD - TOAST] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD - TOAST] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD - TOAST] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD - TOAST] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD - TOAST] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD - TOAST] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD - TOAST] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD - TOAST] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD - TOAST] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD - TOAST] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD - TOAST] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD - TOAST] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD - TOAST] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD - TOAST] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD - TOAST] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD - TOAST] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD - TOAST] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD - TOAST] SET RECOVERY FULL 
GO
ALTER DATABASE [BD - TOAST] SET  MULTI_USER 
GO
ALTER DATABASE [BD - TOAST] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD - TOAST] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD - TOAST] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD - TOAST] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD - TOAST] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD - TOAST', N'ON'
GO
ALTER DATABASE [BD - TOAST] SET QUERY_STORE = OFF
GO
USE [BD - TOAST]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BD - TOAST]
GO
/****** Object:  User [alumno]    Script Date: 4/12/2019 11:19:34 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 4/12/2019 11:19:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IDCategoria] [int] IDENTITY(1,1) NOT NULL,
	[NomCategoria] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IDCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dificultades]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dificultades](
	[IDDificultad] [int] IDENTITY(1,1) NOT NULL,
	[NombreDificultad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Dificultades] PRIMARY KEY CLUSTERED 
(
	[IDDificultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favoritos]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favoritos](
	[IDFavorito] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDReceta] [int] NOT NULL,
 CONSTRAINT [PK_Favoritos] PRIMARY KEY CLUSTERED 
(
	[IDFavorito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[IDIngrediente] [int] IDENTITY(1,1) NOT NULL,
	[NombreIngrediente] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[IDIngrediente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recetas]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recetas](
	[IDReceta] [int] IDENTITY(1,1) NOT NULL,
	[NombreReceta] [varchar](100) NOT NULL,
	[Categoria] [int] NOT NULL,
	[Preparacion] [varchar](2000) NOT NULL,
	[TiempoPreparacion] [int] NOT NULL,
	[CantidadPlatos] [float] NOT NULL,
	[Dificultad] [float] NOT NULL,
	[Foto] [varchar](200) NULL,
	[Cant_Likes] [int] NOT NULL,
	[Autor] [int] NULL,
 CONSTRAINT [PK_Recetas] PRIMARY KEY CLUSTERED 
(
	[IDReceta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RxI]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RxI](
	[IDRxI] [int] IDENTITY(1,1) NOT NULL,
	[IDIngrediente] [int] NOT NULL,
	[IDReceta] [int] NOT NULL,
	[Cantidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RxI] PRIMARY KEY CLUSTERED 
(
	[IDRxI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Mail] [varchar](200) NOT NULL,
	[Admin] [bit] NOT NULL,
	[Contraseña] [varchar](200) NOT NULL,
	[Nombre_Foto] [varchar](200) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (1, N'Aves')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (2, N'Bebidas')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (3, N'Carnes')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (4, N'Verduras')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (5, N'Guisos y Sopas')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (6, N'Pastas y Arroces')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (7, N'Pastelería')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (8, N'Pescados y Mariscos')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (9, N'Pizzas')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (10, N'Postres')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (11, N'Panadería')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (12, N'Salsas')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (13, N'Huevos y Lácteos')
INSERT [dbo].[Categorias] ([IDCategoria], [NomCategoria]) VALUES (14, N'Otros')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
SET IDENTITY_INSERT [dbo].[Dificultades] ON 

INSERT [dbo].[Dificultades] ([IDDificultad], [NombreDificultad]) VALUES (1, N'Fácil')
INSERT [dbo].[Dificultades] ([IDDificultad], [NombreDificultad]) VALUES (2, N'Medio')
INSERT [dbo].[Dificultades] ([IDDificultad], [NombreDificultad]) VALUES (3, N'Difícil')
SET IDENTITY_INSERT [dbo].[Dificultades] OFF
SET IDENTITY_INSERT [dbo].[Ingredientes] ON 

INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (1, N'Cebolla')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (2, N'Maicena')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (3, N'Leche')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (4, N'Caldo de verduras')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (5, N'Vino Blanco')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (6, N'Queso Rallado')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (7, N'Pan')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (8, N'Sal')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (9, N'Pimienta')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (10, N'Zanahorias')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (11, N'Azúcar')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (12, N'Gelatina sin sabor')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (13, N'Perejil')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (14, N'Chauchas')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (15, N'Zanahoria')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (16, N'Blanco de Apio')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (17, N'Cebolla de Verdeo')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (18, N'Zapallito')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (19, N'Papa')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (20, N'Porotos')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (21, N'Tomates')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (22, N'Albahaca')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (23, N'Pimentón')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (24, N'Huevos')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (25, N'Perejil picado')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (26, N'Cebollines picados')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (27, N'Pollo')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (28, N'Champignones')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (29, N'Cebollines')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (30, N'Caldo')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (31, N'Tomillo')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (32, N'Ají')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (33, N'Berenjena')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (34, N'Tomate')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (35, N'Laurel')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (36, N'Filet de Merluza')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (37, N'Cebollas de verdeo')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (38, N'Ají Rojo')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (39, N'Ají Verde')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (40, N'Atún')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (41, N'Anchoas')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (42, N'Ajo')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (43, N'Vinagre')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (44, N'Aceite de Oliva')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (45, N'Aceitunas negras')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (46, N'Leche descremada')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (47, N'Nuez Moscada')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (48, N'Lomito Ahumado')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (49, N'Crema')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (50, N'Tarta')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (51, N'Cognac')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (52, N'Vino Borgoña')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (53, N'Romero')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (54, N'Salmón')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (55, N'Tomates cherry')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (56, N'Limones')
INSERT [dbo].[Ingredientes] ([IDIngrediente], [NombreIngrediente]) VALUES (77, N'')
SET IDENTITY_INSERT [dbo].[Ingredientes] OFF
SET IDENTITY_INSERT [dbo].[Recetas] ON 

INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (1, N'Soupe l''Oignon (Sopa de cebollas)', 5, N'1- Pelar, lavar y picar finamente las cebollas. Lubricar una olla con rocío vegetal y dorarlas
2- Agregar el caldo y el vino y proseguir la cocción durante 15''. Salar.
3- Disolver la maicena con la leche fría e incorporar a la sopa. Revolver hasta que hierva durante 3''.
4- Servir con queso rallado y pimienta. Decorar cada plato con una rebanada de pan tostado cortada en diagonal.', 45, 4, 1, N'Soupe_L''Oignon.jpg', 0, 2)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (2, N'Zanahorias Glaceadas', 4, N'1- Lavar y pelar las zanahorias, secarlas y cortarlas en rodajas oblicuas y finas. Pelar y lavar la cebolla y cortarla en aros.
2- Colocar el caldo y el edulcorante en una sartén profunda y llevar al fuego. Cuando rompe el hervor añadir las zanahorias. Tapar y cocinar entre 10 y 15''. Luego, agregar las cebollas y continuar la cocción con el recipiente destapado. Procurar que no se seque; si fuera necesario, incorporar más caldo.
3- Cuando la cebolla esté transparente, espolvorear la gelatina sobre la preparación mientras se mezcla con cuidad para no romper las zanahorias
4- Servir de inmediato con perejil picado.', 35, 4, 2, N'Zanahorias_Glaseadas.jpg', 0, 1)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (3, N'Cazuela de vegetales y legumbres', 4, N'1- Lavar las chauchas, retirarles la punta y cortar
2- Pelar, lavar y cortar en cubos las papas, la cebolla de verdeo y la zanahoria. Lavar, raspar y picar las ramitas de blanco de apio. Partir, retirar las semillas y cortar en cubos el zapallito.
3- Pasar los tomates por agua hirviendo, pelarlos y picarlos.
4- Disolver el pimentón en medio vaso de vino blanco. Picar la albahaca.
5- Colocar todos los ingredientes en un recipiente de vidrio o porcelana apto para cocción en microondas. Rociar con el vino, salar y tapar con papel antiadherente.
6- Cocinar a temperatura máxima durante 10'' en el horno microondas. Dar vuelta la preparación con cuchara. Volver a cubri y cocinar por 5'' más. Dejar reposar 5''.', 40, 4, 1, N'Cazuela_de_Vegetales_y_Legumbres.png', 0, 10)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (4, N'Omelette de finas hierbas', 13, N'1- Colocar el perejil y los cebollines en agua durante unos minutos. Retirar y secar con un repasador. Picar.
2- Partir los huevos y separar las yemas de las claras.
3- Mezclar las yemas con el perejil y los cebollines, agregar la sal, la pimienta y el queso rallado
4- Aparte, batir las claras a punto de nieve e incorporar la preparación de las yemas.
5- Lubricar una sartén con rocío vegetal y calentar. Volcar la preparación y cocinar dejándola blanda y jugosa. Servir inmediatamente.', 20, 4, 1, N'Omelette_de_finas_hierbas.jpg', 0, 5)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (5, N'Pollo a la crema', 1, N'1- Sacar la piel al pollo, partir en presar y retirar toda la grasa visible. Lavar y secar bien.

2- Partir la cebolla en cuatro pedazos. Lavar, pelar y cortar las zanahorias en cuatro, a lo largo. Limpiar los champignones con un repasador. Cortar los cebollines o puerros en trozos.

3- Calentar un recipiente, lubricar con rocío vegetal; dorar las presas de pollo y retirar. Incorporar el vino, la cebolla, las zanahorias y el caldo; tapar el recipiente y cocinar 20''. Enfriar y licuar. Volcar el licuado en la olla, agregar el pollo, los champignones, los cebollines, condimentar y continuar la cocción durante 25 a 30''.

4- Disolver la maicena en la leche fría, incorporar, hervir durante 3'' y apagar. Servir las presas con los cebollines y los champignones.', 95, 4, 2, N'Pollo_a_la_crema.jpg', 0, 1)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (6, N'Ratatouille', 5, N'1- Picar la cebolla en cubos o juliana. Limpiar el ají, picar en trozos grandes igual que la cebolla.

2- Lavar y pelar la berenjena, cortar en cubos y rociar con limón. Lavar y cortar el zapallito en cubos o rodajas finas.

3- Lubricar una cacerola con rocío vegetal y rehogar el ají y la cebolla hasta que esta última quede transparente, agregar la berenjena y el tomate.

4- Cocinar 20'', agregar el zapallito, salpimentar e incorporar las hierbas.

5- Continuar con la cocción durante 40'' más y servir.', 90, 4, 1, N'Ratatouille.jpeg', 0, 3)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (7, N'Ensalada Niçoise', 4, N'1- Salar el pescado; cocinar al vapor durante 10'', dejar enfriar.

2- Cortar los tomates en gajos. En un recipiente con agua hirviendo colocar las chauchas. Hervir, colar y pasar por agua helada.

3- Lavar los ajíes, asarlos, pelarlos y cortarlos en tiras finas.

4- Hervir los huevos 12'', pelar y cortar en cuatro.

5- Enjuagar las anchoas. Cortar las cebollas de verdeo.

6- Pelar los ajos y frotar con ellos el recipiente; luego picarlos finamente y mezclar con el vinagre, el aceite, la sal y la pimienta en un frasco con tapa y agitar.

7- Colocar los ingredientes en la fuente y rociarlos con el aderezo. Trozar la albahaca con la mano y colocarla al final, junto con las aceitunas.', 70, 4, 1, N'Ensalada_Nicoise.jpg', 0, 3)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (8, N'Quiche Lorraine', 13, N'1- Espolvorear la mesada con harina.

2- Extender las tapas de masa sobre ella y estirarlas con palote de amasar para que queden bien finas.

3- Lubricar una tartera con rocío vegetal, forrar con una tapa de masa y pinchar con un tenedor.

4- Disolver la maicena en leche fría, llevar al fuego para que se espese, retirar y condimentar con sal, pimeinta y nuez moscada.

5- Dejar enfriar.

6. Batir un poco los huevos y unir a la salsa anterior; volcar esta preparación sobre la masa de tarta.

7- Colocar encima el lomito ahumado cortado en tiras finas. Espolvorear con queso rallado.

8- [Cubrir con la otra tapa] - Opcional

9- Cortar la parte sobrante y hacer un repulgue alrededor; pinchar con un tenedor y cocinar en horno moderado entre 20'' y 30''', 60, 3, 2, N'Quiche_Lorraine.jpg', 0, 1)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (9, N'Coq-Au-Vin', 1, N'1- Reitrar la piel y la grasa visible del pollo. Cortar en presas. Picar las cebollas de verdeo en aros finos. Colocar los tomates en un recipiente con agua hirviendo durante 3'' y luego pasarlos por agua fría. Retirarles la piel y las semillas y picar. Limpiar con un repasador los champignones y cortarlos en láminas finas a lo largo. Rallar la zanahoria.

2- Lubricar una sartén con rocío vegetal y dorar las presas de pollo, agregar el cognac y encender con un fósforo para flambear.

3- Retirar del fuego, sacar el pollo de la sartén, agregar más rocío vegetal y rehogar la zanahoria y las cebollas hasta que esta ultima quede transparente.

4- Agregar entonces los tomates, el vino tinto y los champignones; salpimentar e incorporar las hierbas. Tapar y continuar con la cocción durante 25''.

5- Disolver la maicena en agua fría y volcar en la salsa para unir. Cocinar 2'' servir decorando con una ramita de romero.', 65, 4, 3, N'Coq_Au_Vin.jpg', 0, 2)
INSERT [dbo].[Recetas] ([IDReceta], [NombreReceta], [Categoria], [Preparacion], [TiempoPreparacion], [CantidadPlatos], [Dificultad], [Foto], [Cant_Likes], [Autor]) VALUES (10, N'Brochettes de Salmón', 8, N'1- Quitar la piel y espinas del pescado, cortar en trozos parejos, salpimentar, rociar con jugo de limón y reservar 60'' en la heladera.

2- Cortar el limón en rodajas.

3- Retirar de la heladera el pescado e insertar en un pinche de brochette un trozo de pescado, 1 de limón y 1 tomate.

4- Colocar en la parrilla del horno y cocinar 8'' de cada lado.

5- Servir espolvoreados con orégano y perejil. Rociar con aceite de oliva.', 36, 4, 1, N'Brochettes_de_Salmon.jpg', 0, 10)
SET IDENTITY_INSERT [dbo].[Recetas] OFF
SET IDENTITY_INSERT [dbo].[RxI] ON 

INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (1, 1, 1, N'150 grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (2, 2, 1, N'1/2 Cda.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (3, 3, 1, N'1/2 Vaso')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (4, 4, 1, N'4 Tazas')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (5, 5, 1, N'1/2 Vaso')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (6, 6, 1, N'4 Cditas.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (7, 7, 1, N'4 Rebanadas')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (8, 8, 1, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (9, 9, 1, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (10, 10, 2, N'4')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (11, 11, 2, N'1 Cda.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (12, 12, 2, N'1 Sobre')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (13, 4, 2, N'1 Taza')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (14, 1, 2, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (15, 13, 2, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (16, 8, 2, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (17, 14, 3, N'200 Grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (18, 15, 3, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (19, 16, 3, N'2 Ramas')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (20, 17, 3, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (21, 18, 3, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (22, 19, 3, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (23, 20, 3, N'1 Taza')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (24, 21, 3, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (25, 5, 3, N'1/2 Vaso')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (26, 22, 3, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (27, 8, 3, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (28, 23, 3, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (29, 24, 4, N'4')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (30, 25, 4, N'2 Cdas.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (31, 26, 4, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (32, 6, 4, N'4 Cditas.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (33, 8, 4, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (34, 9, 4, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (35, 27, 5, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (36, 10, 5, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (37, 1, 5, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (38, 3, 5, N'100 cm3')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (39, 5, 5, N'1/2 Vaso')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (40, 2, 5, N'1 Cdita.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (41, 28, 5, N'200 Grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (42, 29, 5, N'1/2 Kgr.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (43, 30, 5, N'1 Taza')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (44, 31, 5, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (45, 8, 5, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (46, 9, 5, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (47, 1, 6, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (48, 32, 6, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (49, 33, 6, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (50, 18, 6, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (51, 21, 6, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (52, 8, 6, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (53, 9, 6, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (54, 31, 6, N'1 Ramita')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (55, 35, 6, N'1/4 Ramita')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (56, 24, 7, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (57, 36, 7, N'200 grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (58, 14, 7, N'100 grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (59, 37, 7, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (60, 38, 7, N'1/2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (61, 39, 7, N'1/2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (62, 40, 7, N'1/2 Lata')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (63, 41, 7, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (64, 42, 7, N'2 Dientes')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (65, 43, 7, N'2 Cdas.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (66, 44, 7, N'4 Cditas.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (67, 22, 7, N'1 Cda.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (68, 45, 7, N'4')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (69, 24, 8, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (70, 46, 8, N'200 Cm3')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (71, 2, 8, N'2 Cdas.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (72, 6, 8, N'2 Cditas.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (73, 8, 8, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (74, 9, 8, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (75, 47, 8, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (76, 48, 8, N'250 Grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (77, 49, 8, N'4 Cdas.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (78, 50, 8, N'1 Tapa')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (79, 27, 9, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (80, 17, 9, N'200 Grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (81, 15, 9, N'1')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (82, 21, 9, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (83, 28, 9, N'250 Grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (84, 48, 9, N'50 Grs.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (85, 51, 9, N'1 Copa')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (86, 52, 9, N'1 Vaso')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (87, 31, 9, N'1 Ramito')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (88, 53, 9, N'1 Ramito')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (89, 35, 9, N'1/2 Hoja')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (90, 2, 9, N'1 Cdita.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (91, 8, 9, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (92, 9, 9, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (93, 54, 10, N'1 Kgr.')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (94, 55, 10, N'16')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (95, 56, 10, N'2')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (96, 8, 10, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (97, 9, 10, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (98, 13, 10, N'X')
INSERT [dbo].[RxI] ([IDRxI], [IDIngrediente], [IDReceta], [Cantidad]) VALUES (99, 44, 10, N'4 Cditas.')
GO
SET IDENTITY_INSERT [dbo].[RxI] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Admin], [Contraseña], [Nombre_Foto]) VALUES (1, N'Leo_Melman', N'Leonardo', N'Melman', N'leojmelman@gmail.com', 1, N'Ÿ²Yû0ÙŠ…A}È*XØ¨', N'melman.jpg')
INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Admin], [Contraseña], [Nombre_Foto]) VALUES (2, N'Juli_Taiter', N'Julián', N'Taiter', N'taiter.julian.2002@gmail.com', 1, N'æëæ;ô”tÁU’27‘.', N'taiter.jpg')
INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Admin], [Contraseña], [Nombre_Foto]) VALUES (3, N'Santi_Bugdadi', N'Santiago', N'Bugdadi', N'santiagobugdadi@gmail.com', 1, N'ÜÏä96Á&wôXGTrÔ', N'bugdadi.jpg')
INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Admin], [Contraseña], [Nombre_Foto]) VALUES (5, N'Ulises_Pasero', N'Ulises', N'Pasero', N'ulisespasero@gmail.com', 1, N'ÖÃWg`Êà~—v"|%‰™®', N'pasero.jpg')
INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Admin], [Contraseña], [Nombre_Foto]) VALUES (10, N'eze_binker', N'Ezequiel', N'Binker', N'ebinker@ort.edu.ar', 0, N'›7&éîzßBlé«­', N'binker.jfif')
INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Admin], [Contraseña], [Nombre_Foto]) VALUES (11, N'FrozenKnight', N'Daniel', N'Choi', N'danielchoi@gmail.com', 0, N'¥¯<?iÂ×®°ûp+”
', N'choi.jfif')
INSERT [dbo].[Usuarios] ([IDUsuario], [Nombre_Usuario], [Nombre], [Apellido], [Mail], [Admin], [Contraseña], [Nombre_Foto]) VALUES (12, N'hosomanda', N'Gaston', N'Hilu', N'gastonhilu12@gmail.com', 0, N'–ç’–^·,’¥IÝZ3', N'hoso.jpg')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  StoredProcedure [dbo].[BusquedaReceta]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BusquedaReceta]

	@NombreIngrediente varchar(100)

AS
BEGIN

	SELECT * from Recetas INNER JOIN RxI ON Recetas.IDReceta = RxI.IDReceta INNER JOIN Ingredientes ON RxI.IDIngrediente = Ingredientes.IDIngrediente WHERE NombreIngrediente LIKE '%' + @NombreIngrediente + '%'

END
GO
/****** Object:  StoredProcedure [dbo].[CantidadRecetas]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CantidadRecetas]

AS
BEGIN

	SELECT COUNT(*) AS cant FROM Recetas

END
GO
/****** Object:  StoredProcedure [dbo].[ComprobarIngrediente]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ComprobarIngrediente]
	
	@NombreIngrediente varchar(100)
AS
BEGIN
	
	SELECT NombreIngrediente FROM Ingredientes WHERE NombreIngrediente LIKE @NombreIngrediente

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarFavorito]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarFavorito]

	@IDUsuario int,
	@IDReceta int

AS
BEGIN
	
	DELETE FROM Favoritos WHERE IDUsuario = @IDUsuario AND IDReceta = @IDReceta

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarReceta]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarReceta]
	
	@IDReceta int

AS
BEGIN
	
	DELETE FROM Recetas WHERE IDReceta = @IDReceta
	DELETE FROM RxI WHERE IDReceta = @IDReceta

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUsuario]
	
	@IDUsuario int

AS
BEGIN
	
	DELETE FROM Usuarios WHERE IDUsuario = @IDUsuario

END
GO
/****** Object:  StoredProcedure [dbo].[FiltrarRecetas]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FiltrarRecetas]
	
	@NombreReceta varchar(100),
	@Categoria int,
	@TiempoPreparacion int,
	@Dificultad float,
	@Cantidad float,
	@Cant_Likes int,
	@Autor int

AS
BEGIN
	
	IF (@NombreReceta != '')
		BEGIN
			SELECT * FROM Recetas WHERE (NombreReceta LIKE '%' + @NombreReceta + '%') OR (Categoria = @Categoria)
			OR (TiempoPreparacion = @TiempoPreparacion) OR (Dificultad = @Dificultad) OR (CantidadPlatos = @Cantidad) OR (Cant_Likes = @Cant_Likes) OR (Autor = @Autor)
			ORDER BY NombreReceta ASC
		END
	ELSE
		BEGIN
			SELECT * FROM Recetas WHERE (Categoria = @Categoria)
			OR (TiempoPreparacion = @TiempoPreparacion) OR (Dificultad = @Dificultad) OR (CantidadPlatos = @Cantidad) OR (Cant_Likes = @Cant_Likes) OR (Autor = @Autor)
			ORDER BY NombreReceta ASC
		END
END
GO
/****** Object:  StoredProcedure [dbo].[IngresarIngrediente]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IngresarIngrediente]
	
	@NombreIngrediente varchar(100)

AS
BEGIN
	
	INSERT INTO Ingredientes (NombreIngrediente) VALUES (@NombreIngrediente)

END
GO
/****** Object:  StoredProcedure [dbo].[IngresarRecetas]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IngresarRecetas]
	@NombreReceta varchar(100),
	@Categoria int,
	@Preparacion varchar(2000),
	@TiempoPreparacion int,
	@CantidadPlatos int,
	@Dificultad int,
	@Foto varchar(200),
	@Cant_Likes int,
	@Autor int
AS
BEGIN
	IF (@NombreReceta IS NOT NULL AND @Categoria IS NOT NULL AND @Preparacion IS NOT NULL AND @TiempoPreparacion IS NOT NULL AND @CantidadPlatos IS NOT NULL AND @Dificultad IS NOT NULL)
	INSERT INTO Recetas (NombreReceta, Categoria, Preparacion, TiempoPreparacion, CantidadPlatos, Dificultad, Foto, Cant_Likes, Autor) VALUES (@NombreReceta, @Categoria, @Preparacion, @TiempoPreparacion, @CantidadPlatos, @Dificultad, @Foto, @Cant_Likes, @Autor)
END
GO
/****** Object:  StoredProcedure [dbo].[IngresarRxI]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IngresarRxI]
	
	@NombreIngrediente varchar(100),
	@NombreReceta varchar(100),
	@Cantidad varchar(50)
AS
BEGIN	
	DECLARE @IDR int , @IDI int;

	SELECT @IDR = Recetas.IDReceta FROM Recetas WHERE NombreReceta LIKE @NombreReceta;
	SELECT @IDI = Ingredientes.IDIngrediente FROM Ingredientes WHERE NombreIngrediente LIKE @NombreIngrediente;

	INSERT INTO RxI(IDReceta, IDIngrediente, Cantidad) VALUES (@IDR, @IDI, @Cantidad);

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarFavorito]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarFavorito]

	@IDUsuario int,
	@IDReceta int

AS
BEGIN
	
	INSERT INTO Favoritos(IDUsuario, IDReceta) VALUES (@IDUsuario, @IDReceta)

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuario]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarUsuario]

    @Nombre_Usuario varchar(100),
    @Nombre varchar(100),
    @Apellido varchar(100),
    @Mail varchar(200),
    @Contraseña varchar(200),
    @Admin bit,
	@Nombre_Foto varchar(200)
AS
BEGIN
	INSERT INTO Usuarios (Nombre_Usuario, Nombre, Apellido, Mail, Contraseña, Admin, Nombre_Foto) VALUES (@Nombre_Usuario, @Nombre, @Apellido, @Mail, HASHBYTES('MD5', @Contraseña), @Admin, @Nombre_Foto)

END
GO
/****** Object:  StoredProcedure [dbo].[ListarCategorias]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCategorias]
AS
BEGIN
	SELECT * FROM Categorias
END
GO
/****** Object:  StoredProcedure [dbo].[ListarDificultades]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarDificultades]
AS
BEGIN
	SELECT * FROM Dificultades
END
GO
/****** Object:  StoredProcedure [dbo].[ListarFavoritos]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarFavoritos]
	
AS
BEGIN
	SELECT * FROM Favoritos
END
GO
/****** Object:  StoredProcedure [dbo].[ListarRecetas]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarRecetas]
	

AS
BEGIN
	
	SELECT * FROM Recetas ORDER BY NombreReceta ASC
END
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarios]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarUsuarios]
	
AS
BEGIN
	
	SELECT * FROM Usuarios

END
GO
/****** Object:  StoredProcedure [dbo].[ModificarReceta]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarReceta]
	
	@IDReceta int,
	@NombreReceta varchar(100),
	@Categoria int,
	@Preparacion varchar(2000),
	@TiempoPreparacion int,
	@CantidadPlatos int,
	@Dificultad int,
	@Foto varchar(200),
	@Cant_Likes int,
	@Autor int

AS
BEGIN
	
	IF(@NombreReceta IS NOT NULL AND @Categoria IS NOT NULL AND @Preparacion IS NOT NULL AND @TiempoPreparacion IS NOT NULL AND @CantidadPlatos IS NOT NULL AND @Dificultad IS NOT NULL AND @Foto IS NOT NULL AND @Cant_Likes IS NOT NULL AND @Autor IS NOT NULL)
	UPDATE Recetas SET NombreReceta = @NombreReceta, Categoria = @Categoria, Preparacion = @Preparacion, TiempoPreparacion = @TiempoPreparacion, CantidadPlatos = @CantidadPlatos, Dificultad = @Dificultad, Foto = @Foto, Cant_Likes = @Cant_Likes, Autor = @Autor WHERE IDReceta = @IDReceta

END
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarUsuario]
	
	@Nombre_Usuario varchar(100),
    @Nombre varchar(100),
    @Apellido varchar(100),
    @Mail varchar(200),
    @Contraseña varchar(200),
	@NombreFoto varchar(200)

AS
BEGIN
	
	IF (@Nombre_Usuario IS NOT NULL AND @Nombre IS NOT NULL AND @Apellido IS NOT NULL AND @Mail IS NOT NULL AND @Contraseña IS NOT NULL)
		BEGIN
			UPDATE Usuarios SET Nombre_Usuario = @Nombre_Usuario, Nombre = @Nombre, Apellido = @Apellido, Mail = @Mail, Contraseña = HASHBYTES('MD5', @Contraseña), Nombre_Foto = @NombreFoto
		END
END
GO
/****** Object:  StoredProcedure [dbo].[TraerCategoria]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerCategoria]
	@id int
AS
BEGIN
	SELECT * FROM Categorias WHERE IDCategoria = @id
END
GO
/****** Object:  StoredProcedure [dbo].[TraerDificultad]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerDificultad]
	@IDReceta int
AS
BEGIN
	SELECT * FROM Dificultades 
	INNER JOIN Recetas ON Recetas.Dificultad = Dificultades.IDDificultad 
	WHERE IDReceta = @IDReceta 
END
GO
/****** Object:  StoredProcedure [dbo].[TraerFavoritosxUsuario]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerFavoritosxUsuario]
	
	@IDUsuario int

AS
BEGIN

	SELECT * FROM Recetas INNER JOIN Favoritos ON Recetas.IDReceta = Favoritos.IDReceta
	INNER JOIN Usuarios ON Favoritos.IDUsuario = Usuarios.IDUsuario
	WHERE Favoritos.IDUsuario = @IDUsuario

END
GO
/****** Object:  StoredProcedure [dbo].[TraerIDCategoria]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerIDCategoria]
	
	@NomCategoria varchar(100)

AS
BEGIN
	
	SELECT * FROM Categorias WHERE NomCategoria = @NomCategoria

END
GO
/****** Object:  StoredProcedure [dbo].[TraerIDDificultad]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerIDDificultad]
	
	@NombreDificultad varchar(100)

AS
BEGIN
	
	SELECT * FROM Dificultades WHERE NombreDificultad = @NombreDificultad

END
GO
/****** Object:  StoredProcedure [dbo].[TraerIDReceta]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerIDReceta]

	@NombreReceta varchar(200)

AS
BEGIN
	
	SELECT IDReceta FROM Recetas WHERE NombreReceta = @NombreReceta

END
GO
/****** Object:  StoredProcedure [dbo].[TraerIDUsuario]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerIDUsuario]
	
	@Mail varchar(200),
	@Contraseña varchar(200)

AS
BEGIN
	
	SELECT * FROM Usuarios WHERE Mail = @Mail AND Contraseña = HASHBYTES('MD5', @Contraseña)

END
GO
/****** Object:  StoredProcedure [dbo].[TraerInfoReceta]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerInfoReceta]
	
	@id int

AS
BEGIN
	
	
	SELECT * FROM RECETAS WHERE IDReceta = @id

END
GO
/****** Object:  StoredProcedure [dbo].[TraerIngredientes]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerIngredientes]
	
	@IDReceta int

AS
BEGIN
	
	if(@IDReceta IS NOT NULL)
	SELECT Ingredientes.IDIngrediente, NombreIngrediente, RxI.Cantidad FROM Ingredientes INNER JOIN RxI ON RxI.IDIngrediente = Ingredientes.IDIngrediente INNER JOIN Recetas ON Recetas.IDReceta = RxI.IDReceta WHERE Recetas.IDReceta = @IDReceta

END
GO
/****** Object:  StoredProcedure [dbo].[TraerRecetaRandom]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerRecetaRandom]
	
	@NumeroRandom0 int,
	@NumeroRandom1 int,
	@NumeroRandom2 int,
	@NumeroRandom3 int

AS
BEGIN
	
	SELECT * FROM Recetas WHERE IDReceta = @NumeroRandom0 OR IDReceta = @NumeroRandom1 OR IDReceta = @NumeroRandom2 OR IDReceta = @NumeroRandom3

END
GO
/****** Object:  StoredProcedure [dbo].[TraerUsuario]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerUsuario]
	
	@IDUsuario int

AS
BEGIN
	
	SELECT * FROM Usuarios WHERE IDUsuario = @IDUsuario

END
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 4/12/2019 11:19:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ValidarUsuario]
	
	@Mail varchar(200),
	@Contraseña varchar(200)
	
AS
BEGIN
	
	SELECT Mail, Contraseña, IDUsuario FROM Usuarios WHERE Mail = @Mail AND Contraseña = HASHBYTES('MD5', @Contraseña)

END
GO
USE [master]
GO
ALTER DATABASE [BD - TOAST] SET  READ_WRITE 
GO
