Imports System.Data
Imports System.Data.SqlClient

Public Class Comando

    Public Shared Sub RellenarDT(ByVal pSelectCommand As String, ByRef pDataTable As DataTable, Optional pSoloEstructura As Boolean = False)
        Dim ObjCommand As New SqlCommand(pSelectCommand, ServiciosDAL.Conexion.GetObjConnection)
        Dim DA As New SqlDataAdapter(ObjCommand)
        If pSoloEstructura Then
            DA.FillSchema(pDataTable, SchemaType.Mapped)
        Else
            DA.Fill(pDataTable)
        End If
    End Sub

    Public Shared Sub ActualizarBase(ByVal pSelectCommand As String, ByRef pDataTable As DataTable)
        Dim DA As New SqlDataAdapter(New SqlCommand(pSelectCommand, ServiciosDAL.Conexion.GetObjConnection))
        Dim CB As New SqlCommandBuilder(DA)
        DA.InsertCommand = CB.GetInsertCommand
        DA.DeleteCommand = CB.GetDeleteCommand
        DA.UpdateCommand = CB.GetUpdateCommand
        DA.Update(pDataTable)
    End Sub

End Class
