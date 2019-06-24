using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestionEscolar.Models
{
    public partial class GestionEscolar : DbContext
    {
        public GestionEscolar()
        {
        }

        public GestionEscolar(DbContextOptions<GestionEscolar> options)
            : base(options)
        {
        }

        public virtual DbSet<Administradores> Administradores { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Foro> Foro { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Nivel> Nivel { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<ParticipacionForo> ParticipacionForo { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<UsuarioDocente> UsuarioDocente { get; set; }
        public virtual DbSet<UsuarioEstudiante> UsuarioEstudiante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server="+DbConfig.SERVERNAME+";Database="+DbConfig.DBNAME+";User Id="+DbConfig.USER+";Password="+DbConfig.PASSWORD+";Trusted_connection=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Administradores>(entity =>
            {
                entity.ToTable("administradores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(300);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera);

                entity.ToTable("carrera");

                entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");

                entity.Property(e => e.DescripcionCarrera)
                    .IsRequired()
                    .HasColumnName("descripcion_carrera")
                    .HasMaxLength(200);

                entity.Property(e => e.DirectorCarrera).HasColumnName("director_carrera");

                entity.Property(e => e.NombreCarrera)
                    .IsRequired()
                    .HasColumnName("nombre_carrera")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.IdDocente);

                entity.ToTable("docente");

                entity.Property(e => e.IdDocente).HasColumnName("id_docente");

                entity.Property(e => e.ApellidoDos)
                    .IsRequired()
                    .HasColumnName("apellido_dos")
                    .HasMaxLength(50);

                entity.Property(e => e.ApellidoUno)
                    .IsRequired()
                    .HasColumnName("apellido_uno")
                    .HasMaxLength(50);

                entity.Property(e => e.CedulaDocente)
                    .IsRequired()
                    .HasColumnName("cedula_docente")
                    .HasMaxLength(13);

                entity.Property(e => e.NombreDos)
                    .IsRequired()
                    .HasColumnName("nombre_dos")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreUno)
                    .IsRequired()
                    .HasColumnName("nombre_uno")
                    .HasMaxLength(50);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.ToTable("estudiante");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");

                entity.Property(e => e.ApellidoDos)
                    .IsRequired()
                    .HasColumnName("apellido_dos")
                    .HasMaxLength(50);

                entity.Property(e => e.ApellidoUno)
                    .IsRequired()
                    .HasColumnName("apellido_uno")
                    .HasMaxLength(50);

                entity.Property(e => e.CedulaEstudiante)
                    .IsRequired()
                    .HasColumnName("cedula_estudiante")
                    .HasMaxLength(13);

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.IdNivel).HasColumnName("idNivel");

                entity.Property(e => e.NombreDos)
                    .IsRequired()
                    .HasColumnName("nombre_dos")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreUno)
                    .IsRequired()
                    .HasColumnName("nombre_uno")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Foro>(entity =>
            {
                entity.HasKey(e => e.IdForo);

                entity.ToTable("foro");

                entity.Property(e => e.IdForo).HasColumnName("id_foro");

                entity.Property(e => e.DescripcionForo)
                    .IsRequired()
                    .HasColumnName("descripcion_foro")
                    .HasMaxLength(500);

                entity.Property(e => e.HoraFinal)
                    .HasColumnName("hora_final")
                    .HasColumnType("datetime");

                entity.Property(e => e.HoraInicio)
                    .HasColumnName("hora_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.TemaForo)
                    .IsRequired()
                    .HasColumnName("tema_foro")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Foro)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_foro_materia");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.ToTable("materia");

                entity.Property(e => e.IdMateria).HasColumnName("id_materia");

                entity.Property(e => e.IdDocente).HasColumnName("idDocente");

                entity.Property(e => e.IdNivel).HasColumnName("idNivel");

                entity.Property(e => e.NombreMateria)
                    .IsRequired()
                    .HasColumnName("nombre_materia")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdDocente)
                    .HasConstraintName("FK_materia_docente");

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_materia_nivel");
            });

            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.HasKey(e => e.IdNivel);

                entity.ToTable("nivel");

                entity.Property(e => e.IdNivel).HasColumnName("id_nivel");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.Nivel1).HasColumnName("nivel");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Nivel)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nivel_carrera");
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasKey(e => e.IdNota);

                entity.ToTable("nota");

                entity.Property(e => e.IdNota).HasColumnName("id_nota");

                entity.Property(e => e.CalificacionNota).HasColumnName("calificacion_nota");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.Property(e => e.IdTarea).HasColumnName("idTarea");

                entity.Property(e => e.UriAdjunto)
                    .HasColumnName("uri_adjunto")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nota_estudiante");

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nota_tarea");
            });

            modelBuilder.Entity<ParticipacionForo>(entity =>
            {
                entity.HasKey(e => e.IdParticipacion);

                entity.ToTable("participacion_foro");

                entity.Property(e => e.IdParticipacion).HasColumnName("id_participacion");

                entity.Property(e => e.ContenidoParticipacion)
                    .IsRequired()
                    .HasColumnName("contenido_participacion")
                    .HasMaxLength(1000);

                entity.Property(e => e.HoraPublicado)
                    .HasColumnName("hora_publicado")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.Property(e => e.IdForo).HasColumnName("idForo");

                entity.Property(e => e.NotaParticipacion).HasColumnName("nota_participacion");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.ParticipacionForo)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_participacion_foro_estudiante");

                entity.HasOne(d => d.IdForoNavigation)
                    .WithMany(p => p.ParticipacionForo)
                    .HasForeignKey(d => d.IdForo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_participacion_foro_foro");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasKey(e => e.IdReporte);

                entity.ToTable("reporte");

                entity.Property(e => e.IdReporte).HasColumnName("id_reporte");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.NotaDeberes).HasColumnName("nota_deberes");

                entity.Property(e => e.NotaForos).HasColumnName("nota_foros");

                entity.Property(e => e.NotaProyecto).HasColumnName("nota_proyecto");

                entity.Property(e => e.NotaPrueba).HasColumnName("nota_prueba");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Reporte)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reporte_estudiante");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Reporte)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reporte_materia");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea);

                entity.ToTable("tarea");

                entity.Property(e => e.IdTarea).HasColumnName("id_tarea");

                entity.Property(e => e.DescripcionTarea)
                    .IsRequired()
                    .HasColumnName("descripcion_tarea")
                    .HasMaxLength(200);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.HoraFinal)
                    .HasColumnName("hora_final")
                    .HasColumnType("datetime");

                entity.Property(e => e.HoraInicio)
                    .HasColumnName("hora_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.TituloTarea)
                    .IsRequired()
                    .HasColumnName("titulo_tarea")
                    .HasMaxLength(200);

                entity.Property(e => e.UriAdjunto)
                    .HasColumnName("uri_adjunto")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Tarea)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tarea_materia");
            });

            modelBuilder.Entity<UsuarioDocente>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioDocente);

                entity.ToTable("usuario_docente");

                entity.Property(e => e.IdUsuarioDocente).HasColumnName("id_usuario_docente");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(300);

                entity.Property(e => e.IdDocente).HasColumnName("idDocente");

                entity.Property(e => e.Usuaio)
                    .IsRequired()
                    .HasColumnName("usuaio")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.UsuarioDocente)
                    .HasForeignKey(d => d.IdDocente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_docente_docente");
            });

            modelBuilder.Entity<UsuarioEstudiante>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioEstudiante);

                entity.ToTable("usuario_estudiante");

                entity.Property(e => e.IdUsuarioEstudiante).HasColumnName("id_usuario_estudiante");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(300);

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.UsuarioEstudiante)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_estudiante_estudiante");
            });
        }
    }
}
