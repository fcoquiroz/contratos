using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Core;
using Repository.Core.Domain;
using Repository.Core.Repositories;
using Repository.Persistence.Repositories;
namespace Repository.Persistence
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// UnitOfWork
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(DataContext context)
        {
            _context = context;
            CAT_AVISOSRoutines = new CAT_AVISOSRepository(_context);
            Cat_ComercialRoutines = new Cat_ComercialRepository(_context);
            Cat_DiaFestivoRoutines = new Cat_DiaFestivoRepository(_context);
            Cat_DocumentacionRoutines = new Cat_DocumentacionRepository(_context);
            Cat_EstatusRoutines = new Cat_EstatusRepository(_context);
            cat_IdiomaRoutines = new cat_IdiomaRepository(_context);
            Cat_IdiomaUsuarioRoutines = new Cat_IdiomaUsuarioRepository(_context);
            Cat_LDAPRoutines = new Cat_LDAPRepository(_context);
            Cat_ModulosRoutines = new Cat_ModulosRepository(_context);
            Cat_ModulosMenuporRolRoutines = new Cat_ModulosMenuporRolRepository(_context);
            Cat_PaisRoutines = new Cat_PaisRepository(_context);
            Cat_PantallasRoutines = new Cat_PantallasRepository(_context);
            Cat_PermisosRoutines = new Cat_PermisosRepository(_context);
            Cat_PrioridadRoutines = new Cat_PrioridadRepository(_context);
            Cat_ProveedorRoutines = new Cat_ProveedorRepository(_context);
            Cat_ResponsablesRoutines = new Cat_ResponsablesRepository(_context);
            Cat_RolRoutines = new Cat_RolRepository(_context);
            Cat_TipoAccionRoutines = new Cat_TipoAccionRepository(_context);
            Cat_TipoContratoRoutines = new Cat_TipoContratoRepository(_context);
            Cat_TipoContratoSolicitudRoutines = new Cat_TipoContratoSolicitudRepository(_context);
            Cat_TipoDocumentoRoutines = new Cat_TipoDocumentoRepository(_context);
            Cat_TipoMonedaRoutines = new Cat_TipoMonedaRepository(_context);
            Cat_UnidadRoutines = new Cat_UnidadRepository(_context);
            Cat_Unidad_UsuarioRoutines = new Cat_Unidad_UsuarioRepository(_context);
            Cat_UsuarioRoutines = new Cat_UsuarioRepository(_context);
            Cfg_ContratoUsuarioRoutines = new Cfg_ContratoUsuarioRepository(_context);
            Cfg_CorreosRoutines = new Cfg_CorreosRepository(_context);
            Cfg_PrioridadComplejidadRoutines = new Cfg_PrioridadComplejidadRepository(_context);
            Cfg_PrioridadComplejidad_HistoricoRoutines = new Cfg_PrioridadComplejidad_HistoricoRepository(_context);
            Cfg_PrioridadComplejidadSegundaRoutines = new Cfg_PrioridadComplejidadSegundaRepository(_context);
            Cfg_UsuarioUnidadConsultaRoutines = new Cfg_UsuarioUnidadConsultaRepository(_context);
            TB_Base_UnidadesRoutines = new TB_Base_UnidadesRepository(_context);
            TB_ContratosRoutines = new TB_ContratosRepository(_context);
            TB_Contratos_AppointmentRoutines = new TB_Contratos_AppointmentRepository(_context);
            TB_Contratos_DetalleRoutines = new TB_Contratos_DetalleRepository(_context);
            TB_Contratos_DocumentacionRoutines = new TB_Contratos_DocumentacionRepository(_context);
            TB_Contratos_EmailRoutines = new TB_Contratos_EmailRepository(_context);
            TB_Contratos_FinalesRoutines = new TB_Contratos_FinalesRepository(_context);
            TB_Contratos_HistorialRoutines = new TB_Contratos_HistorialRepository(_context);
            TB_Contratos_SeguimientoRoutines = new TB_Contratos_SeguimientoRepository(_context);
            TB_Contratos_VersionesRoutines = new TB_Contratos_VersionesRepository(_context);
            TB_FolioConsecutivoRoutines = new TB_FolioConsecutivoRepository(_context);
            TB_Historial_ContratosRoutines = new TB_Historial_ContratosRepository(_context);
            TB_Historial_EstatusRoutines = new TB_Historial_EstatusRepository(_context);
            TB_Historial_ParosRoutines = new TB_Historial_ParosRepository(_context);
            TB_Historial_PrioridadRoutines = new TB_Historial_PrioridadRepository(_context);
            TB_Historial_TipoContratoRoutines = new TB_Historial_TipoContratoRepository(_context);
            TB_LogRoutines = new TB_LogRepository(_context);
            TB_Log2Routines = new TB_Log2Repository(_context);
            TB_ParametrosRoutines = new TB_ParametrosRepository(_context);
            TB_Usuario_ContraseniasRoutines = new TB_Usuario_ContraseniasRepository(_context);
            RefreshTokenRoutines = new RefreshTokenRepository(_context);
            Cat_AutorizadoresRoutines = new Cat_AutorizadoresRepository(_context);
            Cat_Autorizadores_extraRoutines = new Cat_Autorizadores_extraRepository(_context);
            Cat_TipoAutorizadorRoutines = new Cat_TipoAutorizadorRepository(_context);
            Cat_TipoSolicitudRoutines = new Cat_TipoSolicitudRepository(_context);
            TB_Autorizadores_AutRoutines = new TB_Autorizadores_AutRepository(_context);
            TB_CaratulaRoutines = new TB_CaratulaRepository(_context);
            TB_Relacion_ProductoPaisResponsablesRoutines = new TB_Relacion_ProductoPaisResponsablesRepository(_context);
            Cat_ProductoRoutines = new Cat_ProductoRepository(_context); 
            TB_MultiProductoRoutines = new TB_MultiProductoRepository(_context);
            TB_Email_Supervisor_ContratoRoutines = new TB_Email_Supervisor_ContratoRepository(_context);
            TB_Relacion_Formato_UnidadRoutines = new TB_Relacion_Formato_UnidadRepository(_context);
            Cat_FormatoLiberadosRoutines = new Cat_FormatoLiberadosRepository(_context);
            TB_Detalle_DocumentoLiberadoRoutines = new TB_Detalle_DocumentoLiberadoRepository(_context);
            TB_Campos_CaratulaRoutines = new TB_Campos_CaratulaRepository(_context);
            TB_Detalle_CaratulaRoutines = new TB_Detalle_CaratulaRepository(_context);
            TB_Autorizadores_ContratoRoutines = new TB_Autorizadores_ContratoRepository(_context);
        }

        /// <summary>
        /// CAT_AVISOSRoutines
        /// </summary>
        public ICAT_AVISOSRepository CAT_AVISOSRoutines { get; private set; }

        /// <summary>
        /// Cat_ComercialRoutines
        /// </summary>
        public ICat_ComercialRepository Cat_ComercialRoutines { get; private set; }

        /// <summary>
        /// Cat_DiaFestivoRoutines
        /// </summary>
        public ICat_DiaFestivoRepository Cat_DiaFestivoRoutines { get; private set; }

        /// <summary>
        /// Cat_DocumentacionRoutines
        /// </summary>
        public ICat_DocumentacionRepository Cat_DocumentacionRoutines { get; private set; }
        /// <summary>
        /// ICat_EstatusRepository
        /// </summary>
        public ICat_EstatusRepository Cat_EstatusRoutines { get; private set; }
        /// <summary>
        /// cat_IdiomaRoutines
        /// </summary>
        public Icat_IdiomaRepository cat_IdiomaRoutines { get; private set; }
        /// <summary>
        /// cat_IdiomaRoutines
        /// </summary>
        public ICat_IdiomaUsuarioRepository Cat_IdiomaUsuarioRoutines { get; private set; }
        /// <summary>
        /// Cat_LDAPRoutines
        /// </summary>
        public ICat_LDAPRepository Cat_LDAPRoutines { get; private set; }
        /// <summary>
        /// Cat_ModulosRoutines
        /// </summary>
        public ICat_ModulosRepository Cat_ModulosRoutines { get; private set; }
        /// <summary>
        /// Cat_ModulosMenuporRolRoutines
        /// </summary>
        public ICat_ModulosMenuporRolRepository Cat_ModulosMenuporRolRoutines { get; private set; }
        /// <summary>
        /// Cat_PaisRoutines
        /// </summary>
        public ICat_PaisRepository Cat_PaisRoutines { get; private set; }
        /// <summary>
        /// Cat_PantallasRoutines
        /// </summary>
        public ICat_PantallasRepository Cat_PantallasRoutines { get; private set; }
        /// <summary>
        /// Cat_PermisosRoutines
        /// </summary>
        public ICat_PermisosRepository Cat_PermisosRoutines { get; private set; }
        /// <summary>
        /// Cat_PrioridadRoutines
        /// </summary>
        public ICat_PrioridadRepository Cat_PrioridadRoutines { get; private set; }
        /// <summary>
        /// Cat_ProveedorRoutines
        /// </summary>
        public ICat_ProveedorRepository Cat_ProveedorRoutines { get; private set; }
        /// <summary>
        /// Cat_ResponsablesRoutines
        /// </summary>
        public ICat_ResponsablesRepository Cat_ResponsablesRoutines { get; private set; }
        /// <summary>
        /// Cat_RolRoutines
        /// </summary>
        public ICat_RolRepository Cat_RolRoutines { get; private set; }
        /// <summary>
        /// Cat_TipoAccionRoutines
        /// </summary>
        public ICat_TipoAccionRepository Cat_TipoAccionRoutines { get; private set; }
        /// <summary>
        /// Cat_TipoContratoRoutines
        /// </summary>
        public ICat_TipoContratoRepository Cat_TipoContratoRoutines { get; private set; }
        /// <summary>
        /// Cat_TipoContratoSolicitudRoutines
        /// </summary>
        public ICat_TipoContratoSolicitudRepository Cat_TipoContratoSolicitudRoutines { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public ICat_TipoDocumentoRepository Cat_TipoDocumentoRoutines { get; private set; }
        /// <summary>
        /// Cat_TipoMonedaRoutines
        /// </summary>
        public ICat_TipoMonedaRepository Cat_TipoMonedaRoutines { get; private set; }
        /// <summary>
        /// Cat_UnidadRoutines
        /// </summary>
        public ICat_UnidadRepository Cat_UnidadRoutines { get; private set; }
        /// <summary>
        /// Cat_Unidad_UsuarioRoutines
        /// </summary>
        public ICat_Unidad_UsuarioRepository Cat_Unidad_UsuarioRoutines { get; private set; }
        /// <summary>
        /// Cat_UsuarioRoutines
        /// </summary>
        public ICat_UsuarioRepository Cat_UsuarioRoutines { get; private set; }
        /// <summary>
        /// Cfg_ContratoUsuarioRoutines
        /// </summary>
        public ICfg_ContratoUsuarioRepository Cfg_ContratoUsuarioRoutines { get; private set; }
        /// <summary>
        /// Cfg_CorreosRoutines
        /// </summary>
        public ICfg_CorreosRepository Cfg_CorreosRoutines { get; private set; }
        /// <summary>
        /// Cfg_PrioridadComplejidadRoutines
        /// </summary>
        public ICfg_PrioridadComplejidadRepository Cfg_PrioridadComplejidadRoutines { get; private set; }
        /// <summary>
        /// Cfg_PrioridadComplejidad_HistoricoRoutines
        /// </summary>
        public ICfg_PrioridadComplejidad_HistoricoRepository Cfg_PrioridadComplejidad_HistoricoRoutines { get; private set; }
        /// <summary>
        /// Cfg_PrioridadComplejidadSegundaRoutines
        /// </summary>
        public ICfg_PrioridadComplejidadSegundaRepository Cfg_PrioridadComplejidadSegundaRoutines { get; private set; }
        /// <summary>
        /// Cfg_UsuarioUnidadConsultaRoutines
        /// </summary>
        public ICfg_UsuarioUnidadConsultaRepository Cfg_UsuarioUnidadConsultaRoutines { get; private set; }
        /// <summary>
        /// TB_Base_UnidadesRoutines
        /// </summary>
        public ITB_Base_UnidadesRepository TB_Base_UnidadesRoutines { get; private set; }
        /// <summary>
        /// TB_ContratosRoutines
        /// </summary>
        public ITB_ContratosRepository TB_ContratosRoutines { get; private set; }
        /// <summary>
        /// TB_Contratos_AppointmentRoutines
        /// </summary>
        public ITB_Contratos_AppointmentRepository TB_Contratos_AppointmentRoutines { get; private set; }
        /// <summary>
        /// TB_Contratos_DetalleRoutines
        /// </summary>
        public ITB_Contratos_DetalleRepository TB_Contratos_DetalleRoutines { get; private set; }
        /// <summary>
        /// TB_Contratos_DocumentacionRoutines
        /// </summary>
        public ITB_Contratos_DocumentacionRepository TB_Contratos_DocumentacionRoutines { get; private set; }
        /// <summary>
        /// TB_Contratos_EmailRoutines
        /// </summary>
        public ITB_Contratos_EmailRepository TB_Contratos_EmailRoutines { get; private set; }
        /// <summary>
        /// TB_Contratos_FinalesRoutines
        /// </summary>
        public ITB_Contratos_FinalesRepository TB_Contratos_FinalesRoutines { get; private set; }
        /// <summary>
        /// TB_Contratos_HistorialRoutines
        /// </summary>
        public ITB_Contratos_HistorialRepository TB_Contratos_HistorialRoutines { get; private set; }
        /// <summary>
        /// TB_Contratos_SeguimientoRoutines
        /// </summary>
        public ITB_Contratos_SeguimientoRepository TB_Contratos_SeguimientoRoutines { get; private set; }
        /// <summary>
        /// TB_Contratos_VersionesRoutines
        /// </summary>
        public ITB_Contratos_VersionesRepository TB_Contratos_VersionesRoutines { get; private set; }
        /// <summary>
        /// TB_FolioConsecutivoRoutines
        /// </summary>
        public ITB_FolioConsecutivoRepository TB_FolioConsecutivoRoutines { get; private set; }
        /// <summary>
        /// TB_Historial_ContratosRoutines
        /// </summary>
        public ITB_Historial_ContratosRepository TB_Historial_ContratosRoutines { get; private set; }
        /// <summary>
        /// TB_Historial_EstatusRoutines
        /// </summary>
        public ITB_Historial_EstatusRepository TB_Historial_EstatusRoutines { get; private set; }
        /// <summary>
        /// TB_Historial_ParosRoutines
        /// </summary>
        public ITB_Historial_ParosRepository TB_Historial_ParosRoutines { get; private set; }
        /// <summary>
        /// TB_Historial_PrioridadRoutines
        /// </summary>
        public ITB_Historial_PrioridadRepository TB_Historial_PrioridadRoutines { get; private set; }
        /// <summary>
        /// TB_Historial_TipoContratoRoutines
        /// </summary>
        public ITB_Historial_TipoContratoRepository TB_Historial_TipoContratoRoutines { get; private set; }
        /// <summary>
        /// TB_LogRoutines
        /// </summary>
        public ITB_LogRepository TB_LogRoutines { get; private set; }
        /// <summary>
        /// TB_Log2Routines
        /// </summary>
        public ITB_Log2Repository TB_Log2Routines { get; private set; }
        /// <summary>
        /// TB_ParametrosRoutines
        /// </summary>
        public ITB_ParametrosRepository TB_ParametrosRoutines { get; private set; }
        /// <summary>
        /// TB_Usuario_ContraseniasRoutines
        /// </summary>
        public ITB_Usuario_ContraseniasRepository TB_Usuario_ContraseniasRoutines { get; private set; }

        /// <summary>
        /// RefreshTokenRoutines
        /// </summary>
        public IRefreshTokenRepository RefreshTokenRoutines { get; private set; }
        /// <summary>
        /// Cat_AutorizadoresRoutines
        /// </summary>
        public ICat_AutorizadoresRepository Cat_AutorizadoresRoutines { get; private set; }
        /// <summary>
        /// Cat_Autorizadores_extraRoutines
        /// </summary>
        public ICat_Autorizadores_extraRepository Cat_Autorizadores_extraRoutines { get; private set; }
        /// <summary>
        /// Cat_TipoAutorizadorRoutines
        /// </summary>
        public ICat_TipoAutorizadorRepository Cat_TipoAutorizadorRoutines { get; private set; }
        /// <summary>
        /// Cat_TipoSolicitudRoutines
        /// </summary>
        public ICat_TipoSolicitudRepository Cat_TipoSolicitudRoutines { get; private set; }
        /// <summary>
        /// TB_Autorizadores_AutRoutines
        /// </summary>
        public ITB_Autorizadores_AutRepository TB_Autorizadores_AutRoutines { get; private set; }
        /// <summary>
        /// TB_CaratulaRoutines
        /// </summary>
        public ITB_CaratulaRepository TB_CaratulaRoutines { get; private set; }
        /// <summary>
        /// TB_Relacion_ProductoPaisResponsablesRoutines
        /// </summary>
        public ITB_Relacion_ProductoPaisResponsablesRepository TB_Relacion_ProductoPaisResponsablesRoutines { get; private set; }
        /// <summary>
        /// TB_MultiProductoRoutines
        /// </summary>
        public ITB_MultiProductoRepository TB_MultiProductoRoutines { get; private set; }
        /// <summary>
        /// TB_Email_Supervisor_ContratoRoutines
        /// </summary>
        public ITB_Email_Supervisor_ContratoRepository TB_Email_Supervisor_ContratoRoutines { get; private set; }
        /// <summary>
        /// Cat_ProductoRoutines
        /// </summary>
        public ICat_ProductoRepository Cat_ProductoRoutines { get; private set; }
        /// <summary>
        /// TB_Relacion_Formato_UnidadRoutines
        /// </summary>
        public ITB_Relacion_Formato_UnidadRepository TB_Relacion_Formato_UnidadRoutines { get; private set; }
        /// <summary>
        /// Cat_FormatoLiberadosRoutines
        /// </summary>
        public ICat_FormatoLiberadosRepository Cat_FormatoLiberadosRoutines { get; private set; }
        /// <summary>
        /// TB_Campos_CaratulaRoutines
        /// </summary>
        public ITB_Campos_CaratulaRepository TB_Campos_CaratulaRoutines { get; private set; }
        /// <summary>
        /// TB_Detalle_CaratulaRoutines
        /// </summary>
        public ITB_Detalle_CaratulaRepository TB_Detalle_CaratulaRoutines { get; private set; }
        /// <summary>
        /// TB_Detalle_DocumentoLiberadoRoutines
        /// </summary>
        public ITB_Detalle_DocumentoLiberadoRepository TB_Detalle_DocumentoLiberadoRoutines { get; private set; }
        /// <summary>
        /// TB_Autorizadores_ContratoRoutines
        /// </summary>
        public ITB_Autorizadores_ContratoRepository TB_Autorizadores_ContratoRoutines { get; set; }
    }
}
