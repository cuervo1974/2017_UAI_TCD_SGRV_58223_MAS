Public Class DataRowHelper

    Public Shared Function DataRow2ArrayList(pDataRow As DataRow) As ArrayList
        Dim ItemsAux As New ArrayList
        ItemsAux.AddRange(pDataRow.ItemArray)
        ItemsAux.RemoveAt(ItemsAux.Count - 1)
        Return ItemsAux
    End Function

End Class
