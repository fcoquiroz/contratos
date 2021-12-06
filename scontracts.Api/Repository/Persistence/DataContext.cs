using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Core.Domain;
using Repository.Persistence.EntityDefinition;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repository.Persistence
{
    /// <summary>
    /// ConsisContext
    /// </summary>
    public class DataContext :  DbContext
    {
        /// <summary>
        /// ConsisContext
        /// </summary>
        public DataContext()
        {
        }
        /// <summary>
        /// ConsisContext
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                var configuration = builder.Build();
                var cnx = configuration.GetConnectionString("ConsisDatabase");
                optionsBuilder.UseSqlServer(cnx);
            }
        }
        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.AddConfiguration(new CAT_AVISOSConfiguration());
            modelBuilder.AddConfiguration(new Cat_ComercialConfiguration());
            modelBuilder.AddConfiguration(new Cat_DiaFestivoConfiguration());
            modelBuilder.AddConfiguration(new Cat_DocumentacionConfiguration());
            modelBuilder.AddConfiguration(new Cat_EstatusConfiguration());
            modelBuilder.AddConfiguration(new cat_IdiomaConfiguration());
            modelBuilder.AddConfiguration(new Cat_IdiomaUsuarioConfiguration());
            modelBuilder.AddConfiguration(new Cat_LDAPConfiguration());
            modelBuilder.AddConfiguration(new Cat_ModulosConfiguration());
            modelBuilder.AddConfiguration(new Cat_ModulosMenuporRolConfiguration());
            modelBuilder.AddConfiguration(new Cat_PaisConfiguration());
            modelBuilder.AddConfiguration(new Cat_PantallasConfiguration());
            modelBuilder.AddConfiguration(new Cat_PermisosConfiguration());
            modelBuilder.AddConfiguration(new Cat_PrioridadConfiguration());
            modelBuilder.AddConfiguration(new Cat_ProveedorConfiguration());
            modelBuilder.AddConfiguration(new Cat_ResponsablesConfiguration());
            modelBuilder.AddConfiguration(new Cat_RolConfiguration());
            modelBuilder.AddConfiguration(new Cat_TipoAccionConfiguration());
            modelBuilder.AddConfiguration(new Cat_TipoContratoConfiguration());
            modelBuilder.AddConfiguration(new Cat_TipoContratoSolicitudConfiguration());
            modelBuilder.AddConfiguration(new Cat_TipoDocumentoConfiguration());
            modelBuilder.AddConfiguration(new Cat_TipoMonedaConfiguration());
            modelBuilder.AddConfiguration(new Cat_UnidadConfiguration());
            modelBuilder.AddConfiguration(new Cat_Unidad_UsuarioConfiguration());
            modelBuilder.AddConfiguration(new Cat_UsuarioConfiguration());
            modelBuilder.AddConfiguration(new Cfg_ContratoUsuarioConfiguration());
            modelBuilder.AddConfiguration(new Cfg_CorreosConfiguration());
            modelBuilder.AddConfiguration(new Cfg_PrioridadComplejidadConfiguration());
            modelBuilder.AddConfiguration(new Cfg_PrioridadComplejidad_HistoricoConfiguration());
            modelBuilder.AddConfiguration(new Cfg_PrioridadComplejidadSegundaConfiguration());
            modelBuilder.AddConfiguration(new Cfg_UsuarioUnidadConsultaConfiguration());
            modelBuilder.AddConfiguration(new TB_Base_UnidadesConfiguration());
            modelBuilder.AddConfiguration(new TB_ContratosConfiguration());
            modelBuilder.AddConfiguration(new TB_Contratos_AppointmentConfiguration());
            modelBuilder.AddConfiguration(new TB_Contratos_DetalleConfiguration());
            modelBuilder.AddConfiguration(new TB_Contratos_DocumentacionConfiguration());
            modelBuilder.AddConfiguration(new TB_Contratos_EmailConfiguration());
            modelBuilder.AddConfiguration(new TB_Contratos_FinalesConfiguration());
            modelBuilder.AddConfiguration(new TB_Contratos_HistorialConfiguration());
            modelBuilder.AddConfiguration(new TB_Contratos_SeguimientoConfiguration());
            modelBuilder.AddConfiguration(new TB_Contratos_VersionesConfiguration());
            modelBuilder.AddConfiguration(new TB_FolioConsecutivoConfiguration());
            modelBuilder.AddConfiguration(new TB_Historial_ContratosConfiguration());
            modelBuilder.AddConfiguration(new TB_Historial_EstatusConfiguration());
            modelBuilder.AddConfiguration(new TB_Historial_ParosConfiguration());
            modelBuilder.AddConfiguration(new TB_Historial_PrioridadConfiguration());
            modelBuilder.AddConfiguration(new TB_Historial_TipoContratoConfiguration());
            modelBuilder.AddConfiguration(new TB_LogConfiguration());
            modelBuilder.AddConfiguration(new TB_Log2Configuration());
            modelBuilder.AddConfiguration(new TB_ParametrosConfiguration());
            modelBuilder.AddConfiguration(new TB_Usuario_ContraseniasConfiguration());
            modelBuilder.AddConfiguration(new RefreshTokenConfiguration());
            modelBuilder.AddConfiguration(new Cat_AutorizadoresConfiguration());
            modelBuilder.AddConfiguration(new Cat_Autorizadores_extraConfiguration());
            modelBuilder.AddConfiguration(new Cat_TipoAutorizadorConfiguration());
            modelBuilder.AddConfiguration(new Cat_TipoSolicitudConfiguration());
            modelBuilder.AddConfiguration(new TB_Autorizadores_AutConfiguration());
            modelBuilder.AddConfiguration(new TB_CaratulaConfiguration());
            modelBuilder.AddConfiguration(new TB_Relacion_ProductoPaisResponsablesConfiguration());
            modelBuilder.AddConfiguration(new Cat_ProductoConfiguration());
            modelBuilder.AddConfiguration(new TB_MultiProductoConfiguration());
            modelBuilder.AddConfiguration(new TB_Email_Supervisor_ContratoConfiguration());
            modelBuilder.AddConfiguration(new TB_Relacion_Formato_UnidadConfiguration());
            modelBuilder.AddConfiguration(new Cat_FormatoLiberadosConfiguration());
            modelBuilder.AddConfiguration(new TB_Campos_CaratulaConfiguration());
            modelBuilder.AddConfiguration(new TB_Detalle_CaratulaConfiguration());
            modelBuilder.AddConfiguration(new TB_Detalle_DocumentoLiberadoConfiguration());
            modelBuilder.AddConfiguration(new TB_Autorizadores_ContratoConfiguration());
        }


        /// <summary>
        /// CAT_AVISOSRoutines
        /// </summary>
        public virtual DbSet<CAT_AVISOS> CAT_AVISOSRoutines { get; set; }
        /// <summary>
        /// Cat_ComercialRoutines
        /// </summary>
        public virtual DbSet<Cat_Comercial> Cat_ComercialRoutines { get; set; }
        /// <summary>
        /// Cat_DiaFestivoRoutines
        /// </summary>
        public virtual DbSet<Cat_DiaFestivo> Cat_DiaFestivoRoutines { get; set; }
        /// <summary>
        /// Cat_DocumentacionRoutines
        /// </summary>
        public virtual DbSet<Cat_Documentacion> Cat_DocumentacionRoutines { get; set; }
        /// <summary>
        /// Cat_EstatusRoutines
        /// </summary>
        public virtual DbSet<Cat_Estatus> Cat_EstatusRoutines { get; set; }
        /// <summary>
        /// cat_IdiomaRoutines
        /// </summary>
        public virtual DbSet<cat_Idioma> cat_IdiomaRoutines { get; set; }

        /// <summary>
        /// cat_IdiomaRoutines
        /// </summary>
        public virtual DbSet<Cat_IdiomaUsuario> cat_IdiomaUsuarioRoutines { get; set; }
        /// <summary>
        /// Cat_LDAPRoutines
        /// </summary>
        public virtual DbSet<Cat_LDAP> Cat_LDAPRoutines { get; set; }
        /// <summary>
        /// Cat_ModulosRoutines
        /// </summary>
        public virtual DbSet<Cat_Modulos> Cat_ModulosRoutines { get; set; }
        /// <summary>
        /// Cat_ModulosMenuporRolRoutines
        /// </summary>
        public virtual DbSet<Cat_ModulosMenuporRol> Cat_ModulosMenuporRolRoutines { get; set; }
        /// <summary>
        /// Cat_PaisRoutines
        /// </summary>
        public virtual DbSet<Cat_Pais> Cat_PaisRoutines { get; set; }
        /// <summary>
        /// Cat_PantallasRoutines
        /// </summary>
        public virtual DbSet<Cat_Pantallas> Cat_PantallasRoutines { get; set; }
        /// <summary>
        /// Cat_PermisosRoutines
        /// </summary>
        public virtual DbSet<Cat_Permisos> Cat_PermisosRoutines { get; set; }
        /// <summary>
        /// Cat_PrioridadRoutines
        /// </summary>
        public virtual DbSet<Cat_Prioridad> Cat_PrioridadRoutines { get; set; }
        /// <summary>
        /// Cat_ProveedorRoutines
        /// </summary>
        public virtual DbSet<Cat_Proveedor> Cat_ProveedorRoutines { get; set; }
        /// <summary>
        /// Cat_ResponsablesRoutines
        /// </summary>
        public virtual DbSet<Cat_Responsables> Cat_ResponsablesRoutines { get; set; }
        /// <summary>
        /// Cat_RolRoutines
        /// </summary>
        public virtual DbSet<Cat_Rol> Cat_RolRoutines { get; set; }
        /// <summary>
        /// Cat_TipoAccionRoutines
        /// </summary>
        public virtual DbSet<Cat_TipoAccion> Cat_TipoAccionRoutines { get; set; }
        /// <summary>
        /// Cat_TipoContratoRoutines
        /// </summary>
        public virtual DbSet<Cat_TipoContrato> Cat_TipoContratoRoutines { get; set; }
        /// <summary>
        /// Cat_TipoContratoSolicitudRoutines
        /// </summary>
        public virtual DbSet<Cat_TipoContratoSolicitud> Cat_TipoContratoSolicitudRoutines { get; set; }
        /// <summary>
        /// Cat_TipoDocumentoRoutines
        /// </summary>
        public virtual DbSet<Cat_TipoDocumento> Cat_TipoDocumentoRoutines { get; set; }
        /// <summary>
        /// Cat_TipoMonedaRoutines
        /// </summary>
        public virtual DbSet<Cat_TipoMoneda> Cat_TipoMonedaRoutines { get; set; }
        /// <summary>
        /// Cat_UnidadRoutines
        /// </summary>
        public virtual DbSet<Cat_Unidad> Cat_UnidadRoutines { get; set; }
        /// <summary>
        /// Cat_Unidad_UsuarioRoutines
        /// </summary>
        public virtual DbSet<Cat_Unidad_Usuario> Cat_Unidad_UsuarioRoutines { get; set; }
        /// <summary>
        /// Cat_UsuarioRoutines
        /// </summary>
        public virtual DbSet<Cat_Usuario> Cat_UsuarioRoutines { get; set; }
        /// <summary>
        /// Cfg_ContratoUsuarioRoutines
        /// </summary>
        public virtual DbSet<Cfg_ContratoUsuario> Cfg_ContratoUsuarioRoutines { get; set; }
        /// <summary>
        /// Cfg_CorreosRoutines
        /// </summary>
        public virtual DbSet<Cfg_Correos> Cfg_CorreosRoutines { get; set; }
        /// <summary>
        /// Cfg_PrioridadComplejidadRoutines
        /// </summary>
        public virtual DbSet<Cfg_PrioridadComplejidad> Cfg_PrioridadComplejidadRoutines { get; set; }
        /// <summary>
        /// Cfg_PrioridadComplejidad_HistoricoRoutines
        /// </summary>
        public virtual DbSet<Cfg_PrioridadComplejidad_Historico> Cfg_PrioridadComplejidad_HistoricoRoutines { get; set; }
        /// <summary>
        /// Cfg_PrioridadComplejidadSegundaRoutines
        /// </summary>
        public virtual DbSet<Cfg_PrioridadComplejidadSegunda> Cfg_PrioridadComplejidadSegundaRoutines { get; set; }
        /// <summary>
        /// Cfg_UsuarioUnidadConsultaRoutines
        /// </summary>
        public virtual DbSet<Cfg_UsuarioUnidadConsulta> Cfg_UsuarioUnidadConsultaRoutines { get; set; }
        /// <summary>
        /// TB_Base_UnidadesRoutines
        /// </summary>
        public virtual DbSet<TB_Base_Unidades> TB_Base_UnidadesRoutines { get; set; }
        /// <summary>
        /// TB_ContratosRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos> TB_ContratosRoutines { get; set; }
        /// <summary>
        /// TB_Contratos_AppointmentRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos_Appointment> TB_Contratos_AppointmentRoutines { get; set; }
        /// <summary>
        /// TB_Contratos_DetalleRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos_Detalle> TB_Contratos_DetalleRoutines { get; set; }
        /// <summary>
        /// TB_Contratos_DocumentacionRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos_Documentacion> TB_Contratos_DocumentacionRoutines { get; set; }
        /// <summary>
        /// TB_Contratos_EmailRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos_Email> TB_Contratos_EmailRoutines { get; set; }
        /// <summary>
        /// TB_Contratos_FinalesRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos_Finales> TB_Contratos_FinalesRoutines { get; set; }
        /// <summary>
        /// TB_Contratos_HistorialRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos_Historial> TB_Contratos_HistorialRoutines { get; set; }
        /// <summary>
        /// TB_Contratos_SeguimientoRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos_Seguimiento> TB_Contratos_SeguimientoRoutines { get; set; }
        /// <summary>
        /// TB_Contratos_VersionesRoutines
        /// </summary>
        public virtual DbSet<TB_Contratos_Versiones> TB_Contratos_VersionesRoutines { get; set; }
        /// <summary>
        /// TB_FolioConsecutivoRoutines
        /// </summary>
        public virtual DbSet<TB_FolioConsecutivo> TB_FolioConsecutivoRoutines { get; set; }
        /// <summary>
        /// TB_Historial_ContratosRoutines
        /// </summary>
        public virtual DbSet<TB_Historial_Contratos> TB_Historial_ContratosRoutines { get; set; }
        /// <summary>
        /// TB_Historial_EstatusRoutines
        /// </summary>
        public virtual DbSet<TB_Historial_Estatus> TB_Historial_EstatusRoutines { get; set; }
        /// <summary>
        /// TB_Historial_ParosRoutines
        /// </summary>
        public virtual DbSet<TB_Historial_Paros> TB_Historial_ParosRoutines { get; set; }
        /// <summary>
        /// TB_Historial_PrioridadRoutines
        /// </summary>
        public virtual DbSet<TB_Historial_Prioridad> TB_Historial_PrioridadRoutines { get; set; }
        /// <summary>
        /// TB_Historial_TipoContratoRoutines
        /// </summary>
        public virtual DbSet<TB_Historial_TipoContrato> TB_Historial_TipoContratoRoutines { get; set; }
        /// <summary>
        /// TB_LogRoutines
        /// </summary>
        public virtual DbSet<TB_Log> TB_LogRoutines { get; set; }
        /// <summary>
        /// TB_Log2Routines
        /// </summary>
        public virtual DbSet<TB_Log2> TB_Log2Routines { get; set; }
        /// <summary>
        /// TB_ParametrosRoutines
        /// </summary>
        public virtual DbSet<TB_Parametros> TB_ParametrosRoutines { get; set; }
        /// <summary>
        /// TB_Usuario_ContraseniasRoutines
        /// </summary>
        public virtual DbSet<TB_Usuario_Contrasenias> TB_Usuario_ContraseniasRoutines { get; set; }

        /// <summary>
        /// RefreshTokenRoutines
        /// </summary>
        public virtual DbSet<RefreshToken> RefreshTokenRoutines { get; set; }
        /// <summary>
        /// TB_Usuario_ContraseniasRoutines
        /// </summary>
        public virtual DbSet<Cat_Autorizadores> Cat_AutorizadoresRoutines { get; set; }
        /// <summary>
        /// Cat_Autorizadores_extraRoutines
        /// </summary>
        public virtual DbSet<Cat_Autorizadores_extra> Cat_Autorizadores_extraRoutines { get; set; }
        /// <summary>
        /// Cat_TipoAutorizadorRoutines
        /// </summary>
        public virtual DbSet<Cat_TipoAutorizador> Cat_TipoAutorizadorRoutines { get; set; }
        /// <summary>
        /// Cat_TipoSolicitudRoutines
        /// </summary>
        public virtual DbSet<Cat_TipoSolicitud> Cat_TipoSolicitudRoutines { get; set; }
        /// <summary>
        /// TB_Autorizadores_AutRoutines
        /// </summary>
        public virtual DbSet<TB_Autorizadores_Aut> TB_Autorizadores_AutRoutines { get; set; }
        /// <summary>
        /// TB_CaratulaRoutines
        /// </summary>
        public virtual DbSet<TB_Caratula> TB_CaratulaRoutines { get; set; }
        /// <summary>
        /// TB_Relacion_ProductoPaisResponsablesRoutines
        /// </summary>
        public virtual DbSet<TB_Relacion_ProductoPaisResponsables> TB_Relacion_ProductoPaisResponsablesRoutines { get; set; }
        /// <summary>
        /// TB_MultiProductoRoutines
        /// </summary>
        public virtual DbSet<TB_MultiProducto> TB_MultiProductoRoutines { get; set; }
        /// <summary>
        /// TB_Email_Supervisor_ContratoRoutines
        /// </summary>
        public virtual DbSet<TB_Email_Supervisor_Contrato> TB_Email_Supervisor_ContratoRoutines { get; set; }
        /// <summary>
        /// Cat_ProductoRoutines
        /// </summary>
        public virtual DbSet<Cat_Producto> Cat_ProductoRoutines { get; set; }
        /// <summary>
        /// TB_Relacion_Formato_UnidadRoutines
        /// </summary>
        public virtual DbSet<TB_Relacion_Formato_Unidad> TB_Relacion_Formato_UnidadRoutines { get; set; }
        /// <summary>
        /// Cat_FormatoLiberadosRoutines
        /// </summary>
        public virtual DbSet<Cat_FormatoLiberados> Cat_FormatoLiberadosRoutines { get; set; }
        /// <summary>
        /// TB_Campos_CaratulaRoutines
        /// </summary>
        public virtual DbSet<TB_Campos_Caratula> TB_Campos_CaratulaRoutines { get; set; }
        /// <summary>
        /// TB_Detalle_CaratulaRoutines
        /// </summary>
        public virtual DbSet<TB_Detalle_Caratula> TB_Detalle_CaratulaRoutines { get; set; }
        /// <summary>
        /// TB_Detalle_DocumentoLiberadoRoutines
        /// </summary>
        public virtual DbSet<TB_Detalle_DocumentoLiberado> TB_Detalle_DocumentoLiberadoRoutines { get; set; }
        /// <summary>
        /// TB_Autorizadores_ContratoRoutines
        /// </summary>
        public virtual DbSet<TB_Autorizadores_Contrato> TB_Autorizadores_ContratoRoutines { get; set; }

    }
}

