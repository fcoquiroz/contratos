using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scontracts.Api.Migrations
{
    /// <summary>
    /// initial
    /// </summary>
    public partial class initial : Migration
    {
        /// <summary>
        /// Up
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }
        /// <summary>
        /// Down
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAT_AVISOSRoutines");

            migrationBuilder.DropTable(
                name: "Cat_ComercialRoutines");

            migrationBuilder.DropTable(
                name: "Cat_DiaFestivoRoutines");

            migrationBuilder.DropTable(
                name: "Cat_DocumentacionRoutines");

            migrationBuilder.DropTable(
                name: "Cat_EstatusRoutines");

            migrationBuilder.DropTable(
                name: "cat_IdiomaRoutines");

            migrationBuilder.DropTable(
                name: "Cat_LDAPRoutines");

            migrationBuilder.DropTable(
                name: "Cat_ModulosMenuporRolRoutines");

            migrationBuilder.DropTable(
                name: "Cat_ModulosRoutines");

            migrationBuilder.DropTable(
                name: "Cat_PaisRoutines");

            migrationBuilder.DropTable(
                name: "Cat_PantallasRoutines");

            migrationBuilder.DropTable(
                name: "Cat_PermisosRoutines");

            migrationBuilder.DropTable(
                name: "Cat_PrioridadRoutines");

            migrationBuilder.DropTable(
                name: "Cat_ProveedorRoutines");

            migrationBuilder.DropTable(
                name: "Cat_ResponsablesRoutines");

            migrationBuilder.DropTable(
                name: "Cat_RolRoutines");

            migrationBuilder.DropTable(
                name: "Cat_TipoAccionRoutines");

            migrationBuilder.DropTable(
                name: "Cat_TipoContratoRoutines");

            migrationBuilder.DropTable(
                name: "Cat_TipoContratoSolicitudRoutines");

            migrationBuilder.DropTable(
                name: "Cat_TipoDocumentoRoutines");

            migrationBuilder.DropTable(
                name: "Cat_TipoMonedaRoutines");

            migrationBuilder.DropTable(
                name: "Cat_Unidad_UsuarioRoutines");

            migrationBuilder.DropTable(
                name: "Cat_UnidadRoutines");

            migrationBuilder.DropTable(
                name: "Cat_Usuario");

            migrationBuilder.DropTable(
                name: "Cfg_ContratoUsuarioRoutines");

            migrationBuilder.DropTable(
                name: "Cfg_CorreosRoutines");

            migrationBuilder.DropTable(
                name: "Cfg_PrioridadComplejidad_HistoricoRoutines");

            migrationBuilder.DropTable(
                name: "Cfg_PrioridadComplejidadRoutines");

            migrationBuilder.DropTable(
                name: "Cfg_PrioridadComplejidadSegundaRoutines");

            migrationBuilder.DropTable(
                name: "Cfg_RefreshToken");

            migrationBuilder.DropTable(
                name: "Cfg_UsuarioUnidadConsultaRoutines");

            migrationBuilder.DropTable(
                name: "TB_Base_UnidadesRoutines");

            migrationBuilder.DropTable(
                name: "TB_Contratos_AppointmentRoutines");

            migrationBuilder.DropTable(
                name: "TB_Contratos_DetalleRoutines");

            migrationBuilder.DropTable(
                name: "TB_Contratos_DocumentacionRoutines");

            migrationBuilder.DropTable(
                name: "TB_Contratos_EmailRoutines");

            migrationBuilder.DropTable(
                name: "TB_Contratos_FinalesRoutines");

            migrationBuilder.DropTable(
                name: "TB_Contratos_HistorialRoutines");

            migrationBuilder.DropTable(
                name: "TB_Contratos_SeguimientoRoutines");

            migrationBuilder.DropTable(
                name: "TB_Contratos_VersionesRoutines");

            migrationBuilder.DropTable(
                name: "TB_ContratosRoutines");

            migrationBuilder.DropTable(
                name: "TB_FolioConsecutivoRoutines");

            migrationBuilder.DropTable(
                name: "TB_Historial_ContratosRoutines");

            migrationBuilder.DropTable(
                name: "TB_Historial_EstatusRoutines");

            migrationBuilder.DropTable(
                name: "TB_Historial_ParosRoutines");

            migrationBuilder.DropTable(
                name: "TB_Historial_PrioridadRoutines");

            migrationBuilder.DropTable(
                name: "TB_Historial_TipoContratoRoutines");

            migrationBuilder.DropTable(
                name: "TB_Log2Routines");

            migrationBuilder.DropTable(
                name: "TB_LogRoutines");

            migrationBuilder.DropTable(
                name: "TB_ParametrosRoutines");

            migrationBuilder.DropTable(
                name: "TB_Usuario_ContraseniasRoutines");
        }
    }
}
