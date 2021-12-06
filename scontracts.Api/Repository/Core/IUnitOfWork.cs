using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Repository.Core.Repositories;
    namespace Repository.Core
    {
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Commit
        /// </summary>
        /// <returns></returns>
        void Commit();

        /// <summary>
        /// CAT_AVISOSRoutines
        /// </summary>
        ICAT_AVISOSRepository CAT_AVISOSRoutines { get; }

        /// <summary>
        /// Cat_ComercialRoutines
        /// </summary>
        ICat_ComercialRepository Cat_ComercialRoutines { get; }

        /// <summary>
        /// Cat_DiaFestivoRoutines
        /// </summary>
        ICat_DiaFestivoRepository Cat_DiaFestivoRoutines { get; }
        /// <summary>
        /// Cat_DocumentacionRoutines
        /// </summary>
        ICat_DocumentacionRepository Cat_DocumentacionRoutines { get; }
        /// <summary>
        /// Cat_EstatusRoutines
        /// </summary>
        ICat_EstatusRepository Cat_EstatusRoutines { get; }
        /// <summary>
        /// Cat_IdiomaUsuarioRoutines
        /// </summary>
        ICat_IdiomaUsuarioRepository Cat_IdiomaUsuarioRoutines { get; }
        /// <summary>
        /// cat_IdiomaRoutines
        /// </summary>
        Icat_IdiomaRepository cat_IdiomaRoutines { get; }
        /// <summary>
        /// Cat_LDAPRoutines
        /// </summary>
        ICat_LDAPRepository Cat_LDAPRoutines { get; }
        /// <summary>
        /// Cat_ModulosRoutines
        /// </summary>
        ICat_ModulosRepository Cat_ModulosRoutines { get; }
        /// <summary>
        /// Cat_ModulosMenuporRolRoutines
        /// </summary>
        ICat_ModulosMenuporRolRepository Cat_ModulosMenuporRolRoutines { get; }
        /// <summary>
        /// Cat_PaisRoutines
        /// </summary>
        ICat_PaisRepository Cat_PaisRoutines { get; }
        /// <summary>
        /// Cat_PantallasRoutines
        /// </summary>
        ICat_PantallasRepository Cat_PantallasRoutines { get; }
        /// <summary>
        /// Cat_PermisosRoutines
        /// </summary>
        ICat_PermisosRepository Cat_PermisosRoutines { get; }
        /// <summary>
        /// Cat_PrioridadRoutines
        /// </summary>
        ICat_PrioridadRepository Cat_PrioridadRoutines { get; }
        /// <summary>
        /// Cat_ProveedorRoutines
        /// </summary>
        ICat_ProveedorRepository Cat_ProveedorRoutines { get; }
        /// <summary>
        /// Cat_ResponsablesRoutines
        /// </summary>
        ICat_ResponsablesRepository Cat_ResponsablesRoutines { get; }
        /// <summary>
        /// Cat_RolRoutines
        /// </summary>
        ICat_RolRepository Cat_RolRoutines { get; }
        /// <summary>
        /// Cat_TipoAccionRoutines
        /// </summary>
        ICat_TipoAccionRepository Cat_TipoAccionRoutines { get; }
        /// <summary>
        /// Cat_TipoContratoRoutines
        /// </summary>
        ICat_TipoContratoRepository Cat_TipoContratoRoutines { get; }
        /// <summary>
        /// Cat_TipoContratoSolicitudRoutines
        /// </summary>
        ICat_TipoContratoSolicitudRepository Cat_TipoContratoSolicitudRoutines { get; }
        /// <summary>
        /// Cat_TipoDocumentoRoutines
        /// </summary>
        ICat_TipoDocumentoRepository Cat_TipoDocumentoRoutines { get; }
        /// <summary>
        /// Cat_TipoMonedaRoutines
        /// </summary>
        ICat_TipoMonedaRepository Cat_TipoMonedaRoutines { get; }
        /// <summary>
        /// Cat_UnidadRoutines
        /// </summary>
        ICat_UnidadRepository Cat_UnidadRoutines { get; }
        /// <summary>
        /// Cat_Unidad_UsuarioRoutines
        /// </summary>
        ICat_Unidad_UsuarioRepository Cat_Unidad_UsuarioRoutines { get; }
        /// <summary>
        /// Cat_UsuarioRoutines
        /// </summary>
        ICat_UsuarioRepository Cat_UsuarioRoutines { get; }
        /// <summary>
        /// Cfg_ContratoUsuarioRoutines
        /// </summary>
        ICfg_ContratoUsuarioRepository Cfg_ContratoUsuarioRoutines { get; }
        /// <summary>
        /// Cfg_CorreosRoutines
        /// </summary>
        ICfg_CorreosRepository Cfg_CorreosRoutines { get; }
        /// <summary>
        /// Cfg_PrioridadComplejidadRoutines
        /// </summary>
        ICfg_PrioridadComplejidadRepository Cfg_PrioridadComplejidadRoutines { get; }
        /// <summary>
        /// Cfg_PrioridadComplejidad_HistoricoRoutines
        /// </summary>
        ICfg_PrioridadComplejidad_HistoricoRepository Cfg_PrioridadComplejidad_HistoricoRoutines { get; }
        /// <summary>
        /// Cfg_PrioridadComplejidadSegundaRoutines
        /// </summary>
        ICfg_PrioridadComplejidadSegundaRepository Cfg_PrioridadComplejidadSegundaRoutines { get; }
        /// <summary>
        /// Cfg_UsuarioUnidadConsultaRoutines
        /// </summary>
        ICfg_UsuarioUnidadConsultaRepository Cfg_UsuarioUnidadConsultaRoutines { get; }
        /// <summary>
        /// TB_Base_UnidadesRoutines
        /// </summary>
        ITB_Base_UnidadesRepository TB_Base_UnidadesRoutines { get; }
        /// <summary>
        /// TB_ContratosRoutines
        /// </summary>
        ITB_ContratosRepository TB_ContratosRoutines { get; }
        /// <summary>
        /// TB_Contratos_AppointmentRoutines
        /// </summary>
        ITB_Contratos_AppointmentRepository TB_Contratos_AppointmentRoutines { get; }
        /// <summary>
        /// TB_Contratos_DetalleRoutines
        /// </summary>
        ITB_Contratos_DetalleRepository TB_Contratos_DetalleRoutines { get; }
        /// <summary>
        /// TB_Contratos_DocumentacionRoutines
        /// </summary>
        ITB_Contratos_DocumentacionRepository TB_Contratos_DocumentacionRoutines { get; }
        /// <summary>
        /// TB_Contratos_EmailRoutines
        /// </summary>
        ITB_Contratos_EmailRepository TB_Contratos_EmailRoutines { get; }
        /// <summary>
        /// TB_Contratos_FinalesRoutines
        /// </summary>
        ITB_Contratos_FinalesRepository TB_Contratos_FinalesRoutines { get; }
        /// <summary>
        /// TB_Contratos_HistorialRoutines
        /// </summary>
        ITB_Contratos_HistorialRepository TB_Contratos_HistorialRoutines { get; }
        /// <summary>
        /// TB_Contratos_SeguimientoRoutines
        /// </summary>
        ITB_Contratos_SeguimientoRepository TB_Contratos_SeguimientoRoutines { get; }
        /// <summary>
        /// TB_Contratos_VersionesRoutines
        /// </summary>
        ITB_Contratos_VersionesRepository TB_Contratos_VersionesRoutines { get; }
        /// <summary>
        /// TB_FolioConsecutivoRoutines
        /// </summary>
        ITB_FolioConsecutivoRepository TB_FolioConsecutivoRoutines { get; }
        /// <summary>
        /// TB_Historial_ContratosRoutines
        /// </summary>
        ITB_Historial_ContratosRepository TB_Historial_ContratosRoutines { get; }
        /// <summary>
        /// TB_Historial_EstatusRoutines
        /// </summary>
        ITB_Historial_EstatusRepository TB_Historial_EstatusRoutines { get; }
        /// <summary>
        /// TB_Historial_ParosRoutines
        /// </summary>
        ITB_Historial_ParosRepository TB_Historial_ParosRoutines { get; }
        /// <summary>
        /// TB_Historial_PrioridadRoutines
        /// </summary>
        ITB_Historial_PrioridadRepository TB_Historial_PrioridadRoutines { get; }
        /// <summary>
        /// TB_Historial_TipoContratoRoutines
        /// </summary>
        ITB_Historial_TipoContratoRepository TB_Historial_TipoContratoRoutines { get; }
        /// <summary>
        /// TB_LogRoutines
        /// </summary>
        ITB_LogRepository TB_LogRoutines { get; }
        /// <summary>
        /// TB_Log2Routines
        /// </summary>
        ITB_Log2Repository TB_Log2Routines { get; }
        /// <summary>
        /// TB_ParametrosRoutines
        /// </summary>
        ITB_ParametrosRepository TB_ParametrosRoutines { get; }
        /// <summary>
        /// TB_Usuario_ContraseniasRoutines
        /// </summary>
        ITB_Usuario_ContraseniasRepository TB_Usuario_ContraseniasRoutines { get; }

        /// <summary>
        /// RefreshTokenRoutines
        /// </summary>
        IRefreshTokenRepository RefreshTokenRoutines { get; }
        /// <summary>
        /// Cat_Autorizadores
        /// </summary>
        ICat_AutorizadoresRepository Cat_AutorizadoresRoutines { get;}
        /// <summary>
        /// Cat_TipoAutorizador
        /// </summary>
        ICat_TipoAutorizadorRepository Cat_TipoAutorizadorRoutines { get; }
        ICat_TipoSolicitudRepository Cat_TipoSolicitudRoutines { get; }
        ITB_Autorizadores_AutRepository TB_Autorizadores_AutRoutines { get; }
        ITB_CaratulaRepository TB_CaratulaRoutines { get; }
        ITB_Relacion_ProductoPaisResponsablesRepository TB_Relacion_ProductoPaisResponsablesRoutines { get; }
        ICat_ProductoRepository Cat_ProductoRoutines { get; }
        ITB_Email_Supervisor_ContratoRepository TB_Email_Supervisor_ContratoRoutines { get; }

        ITB_Relacion_Formato_UnidadRepository TB_Relacion_Formato_UnidadRoutines { get; }
        ICat_FormatoLiberadosRepository Cat_FormatoLiberadosRoutines { get; }
        ITB_Detalle_DocumentoLiberadoRepository TB_Detalle_DocumentoLiberadoRoutines { get; }
    }
}
    