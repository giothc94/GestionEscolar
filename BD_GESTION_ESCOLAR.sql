USE [master]
GO
/****** Object:  Database [gestion_escolar]    Script Date: 23/6/2019 22:34:53 ******/
CREATE DATABASE [gestion_escolar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gestion_escolar', FILENAME = N'/var/opt/mssql/data/gestion_escolar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gestion_escolar_log', FILENAME = N'/var/opt/mssql/data/gestion_escolar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [gestion_escolar] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gestion_escolar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gestion_escolar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gestion_escolar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gestion_escolar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gestion_escolar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gestion_escolar] SET ARITHABORT OFF 
GO
ALTER DATABASE [gestion_escolar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gestion_escolar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gestion_escolar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gestion_escolar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gestion_escolar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gestion_escolar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gestion_escolar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gestion_escolar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gestion_escolar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gestion_escolar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gestion_escolar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gestion_escolar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gestion_escolar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gestion_escolar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gestion_escolar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gestion_escolar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gestion_escolar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gestion_escolar] SET RECOVERY FULL 
GO
ALTER DATABASE [gestion_escolar] SET  MULTI_USER 
GO
ALTER DATABASE [gestion_escolar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gestion_escolar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gestion_escolar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gestion_escolar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gestion_escolar] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'gestion_escolar', N'ON'
GO
ALTER DATABASE [gestion_escolar] SET QUERY_STORE = OFF
GO
USE [gestion_escolar]
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
USE [gestion_escolar]
GO
/****** Object:  Table [dbo].[administradores]    Script Date: 23/6/2019 22:34:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[administradores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nchar](100) NOT NULL,
	[clave] [nchar](300) NOT NULL,
 CONSTRAINT [PK_administradores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[area]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[area](
	[id_area] [int] IDENTITY(1,1) NOT NULL,
	[nombre_area] [nchar](100) NOT NULL,
 CONSTRAINT [PK_area] PRIMARY KEY CLUSTERED 
(
	[id_area] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carrera]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carrera](
	[id_carrera] [int] IDENTITY(1,1) NOT NULL,
	[nombre_carrera] [nchar](100) NOT NULL,
	[descripcion_carrera] [nchar](200) NOT NULL,
	[director_carrera] [int] NOT NULL,
 CONSTRAINT [PK_carrera] PRIMARY KEY CLUSTERED 
(
	[id_carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[docente]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docente](
	[id_docente] [int] IDENTITY(1,1) NOT NULL,
	[cedula_docente] [nchar](13) NOT NULL,
	[nombre_uno] [nchar](50) NOT NULL,
	[nombre_dos] [nchar](50) NOT NULL,
	[apellido_uno] [nchar](50) NOT NULL,
	[apellido_dos] [nchar](50) NOT NULL,
	[titulo] [nchar](50) NOT NULL,
 CONSTRAINT [PK_docente] PRIMARY KEY CLUSTERED 
(
	[id_docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estudiante]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estudiante](
	[id_estudiante] [int] IDENTITY(1,1) NOT NULL,
	[cedula_estudiante] [nchar](13) NOT NULL,
	[nombre_uno] [nchar](50) NOT NULL,
	[nombre_dos] [nchar](50) NOT NULL,
	[apellido_uno] [nchar](50) NOT NULL,
	[apellido_dos] [nchar](50) NOT NULL,
	[idCarrera] [int] NOT NULL,
	[idNivel] [int] NOT NULL,
 CONSTRAINT [PK_estudiante] PRIMARY KEY CLUSTERED 
(
	[id_estudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[foro]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[foro](
	[id_foro] [int] IDENTITY(1,1) NOT NULL,
	[idMateria] [int] NOT NULL,
	[tema_foro] [nchar](300) NOT NULL,
	[descripcion_foro] [nchar](500) NOT NULL,
	[hora_inicio] [datetime] NOT NULL,
	[hora_final] [datetime] NOT NULL,
 CONSTRAINT [PK_foro] PRIMARY KEY CLUSTERED 
(
	[id_foro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materia]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materia](
	[id_materia] [int] IDENTITY(1,1) NOT NULL,
	[idArea] [int] NOT NULL,
	[nombre_materia] [nchar](50) NOT NULL,
	[idNivel] [int] NOT NULL,
	[idDocente] [int] NULL,
 CONSTRAINT [PK_materia] PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nivel]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nivel](
	[id_nivel] [int] IDENTITY(1,1) NOT NULL,
	[nivel] [int] NOT NULL,
	[idCarrera] [int] NOT NULL,
 CONSTRAINT [PK_nivel] PRIMARY KEY CLUSTERED 
(
	[id_nivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nota]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nota](
	[id_nota] [int] IDENTITY(1,1) NOT NULL,
	[idTarea] [int] NOT NULL,
	[idEstudiante] [int] NOT NULL,
	[calificacion_nota] [float] NULL,
	[uri_adjunto] [nchar](500) NULL,
 CONSTRAINT [PK_nota] PRIMARY KEY CLUSTERED 
(
	[id_nota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participacion_foro]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participacion_foro](
	[id_participacion] [int] IDENTITY(1,1) NOT NULL,
	[idEstudiante] [int] NOT NULL,
	[hora_publicado] [datetime] NOT NULL,
	[idForo] [int] NOT NULL,
	[contenido_participacion] [nchar](1000) NOT NULL,
	[nota_participacion] [float] NULL,
 CONSTRAINT [PK_participacion_foro] PRIMARY KEY CLUSTERED 
(
	[id_participacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reporte]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reporte](
	[id_reporte] [int] IDENTITY(1,1) NOT NULL,
	[nota_deberes] [float] NULL,
	[nota_foros] [float] NULL,
	[nota_prueba] [float] NULL,
	[nota_proyecto] [float] NULL,
	[idMateria] [int] NOT NULL,
	[idEstudiante] [int] NOT NULL,
 CONSTRAINT [PK_reporte] PRIMARY KEY CLUSTERED 
(
	[id_reporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarea]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarea](
	[id_tarea] [int] IDENTITY(1,1) NOT NULL,
	[idMateria] [int] NOT NULL,
	[titulo_tarea] [nchar](200) NOT NULL,
	[descripcion_tarea] [nchar](200) NOT NULL,
	[hora_inicio] [datetime] NOT NULL,
	[hora_final] [datetime] NOT NULL,
	[uri_adjunto] [nchar](500) NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [PK_tarea] PRIMARY KEY CLUSTERED 
(
	[id_tarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_docente]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_docente](
	[id_usuario_docente] [int] IDENTITY(1,1) NOT NULL,
	[usuaio] [nchar](100) NOT NULL,
	[clave] [nchar](300) NOT NULL,
	[idDocente] [int] NOT NULL,
 CONSTRAINT [PK_usuario_docente] PRIMARY KEY CLUSTERED 
(
	[id_usuario_docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_estudiante]    Script Date: 23/6/2019 22:34:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_estudiante](
	[id_usuario_estudiante] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nchar](200) NOT NULL,
	[clave] [nchar](300) NOT NULL,
	[idEstudiante] [int] NOT NULL,
 CONSTRAINT [PK_usuario_estudiante] PRIMARY KEY CLUSTERED 
(
	[id_usuario_estudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[foro]  WITH NOCHECK ADD  CONSTRAINT [FK_foro_materia] FOREIGN KEY([idMateria])
REFERENCES [dbo].[materia] ([id_materia])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[foro] NOCHECK CONSTRAINT [FK_foro_materia]
GO
ALTER TABLE [dbo].[materia]  WITH NOCHECK ADD  CONSTRAINT [FK_materia_area] FOREIGN KEY([idArea])
REFERENCES [dbo].[area] ([id_area])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[materia] NOCHECK CONSTRAINT [FK_materia_area]
GO
ALTER TABLE [dbo].[materia]  WITH NOCHECK ADD  CONSTRAINT [FK_materia_docente] FOREIGN KEY([idDocente])
REFERENCES [dbo].[docente] ([id_docente])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[materia] NOCHECK CONSTRAINT [FK_materia_docente]
GO
ALTER TABLE [dbo].[materia]  WITH NOCHECK ADD  CONSTRAINT [FK_materia_nivel] FOREIGN KEY([idNivel])
REFERENCES [dbo].[nivel] ([id_nivel])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[materia] NOCHECK CONSTRAINT [FK_materia_nivel]
GO
ALTER TABLE [dbo].[nivel]  WITH NOCHECK ADD  CONSTRAINT [FK_nivel_carrera] FOREIGN KEY([idCarrera])
REFERENCES [dbo].[carrera] ([id_carrera])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[nivel] NOCHECK CONSTRAINT [FK_nivel_carrera]
GO
ALTER TABLE [dbo].[nota]  WITH NOCHECK ADD  CONSTRAINT [FK_nota_estudiante] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[estudiante] ([id_estudiante])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[nota] NOCHECK CONSTRAINT [FK_nota_estudiante]
GO
ALTER TABLE [dbo].[nota]  WITH NOCHECK ADD  CONSTRAINT [FK_nota_tarea] FOREIGN KEY([idTarea])
REFERENCES [dbo].[tarea] ([id_tarea])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[nota] NOCHECK CONSTRAINT [FK_nota_tarea]
GO
ALTER TABLE [dbo].[participacion_foro]  WITH NOCHECK ADD  CONSTRAINT [FK_participacion_foro_estudiante] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[estudiante] ([id_estudiante])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[participacion_foro] NOCHECK CONSTRAINT [FK_participacion_foro_estudiante]
GO
ALTER TABLE [dbo].[participacion_foro]  WITH NOCHECK ADD  CONSTRAINT [FK_participacion_foro_foro] FOREIGN KEY([idForo])
REFERENCES [dbo].[foro] ([id_foro])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[participacion_foro] NOCHECK CONSTRAINT [FK_participacion_foro_foro]
GO
ALTER TABLE [dbo].[reporte]  WITH NOCHECK ADD  CONSTRAINT [FK_reporte_estudiante] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[estudiante] ([id_estudiante])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reporte] NOCHECK CONSTRAINT [FK_reporte_estudiante]
GO
ALTER TABLE [dbo].[reporte]  WITH NOCHECK ADD  CONSTRAINT [FK_reporte_materia] FOREIGN KEY([idMateria])
REFERENCES [dbo].[materia] ([id_materia])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reporte] NOCHECK CONSTRAINT [FK_reporte_materia]
GO
ALTER TABLE [dbo].[tarea]  WITH NOCHECK ADD  CONSTRAINT [FK_tarea_materia] FOREIGN KEY([idMateria])
REFERENCES [dbo].[materia] ([id_materia])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[tarea] NOCHECK CONSTRAINT [FK_tarea_materia]
GO
ALTER TABLE [dbo].[usuario_docente]  WITH CHECK ADD  CONSTRAINT [FK_usuario_docente_docente] FOREIGN KEY([idDocente])
REFERENCES [dbo].[docente] ([id_docente])
GO
ALTER TABLE [dbo].[usuario_docente] CHECK CONSTRAINT [FK_usuario_docente_docente]
GO
ALTER TABLE [dbo].[usuario_estudiante]  WITH CHECK ADD  CONSTRAINT [FK_usuario_estudiante_estudiante] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[estudiante] ([id_estudiante])
GO
ALTER TABLE [dbo].[usuario_estudiante] CHECK CONSTRAINT [FK_usuario_estudiante_estudiante]
GO
USE [master]
GO
ALTER DATABASE [gestion_escolar] SET  READ_WRITE 
GO
