Imports System.Collections.Generic

Public Class Patente

    Sub New()

    End Sub

    Sub New(pId As Integer, pNombre As String, pForm As String, pImagen As String)
        With Me
            ._Id = pId
            ._Nombre = pNombre
            ._Formulario = pForm
            ._Imagen = pImagen
        End With
    End Sub

    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _Formulario As String
    Public Property Formulario() As String
        Get
            Return _Formulario
        End Get
        Set(ByVal value As String)
            _Formulario = value
        End Set
    End Property

    Private _Imagen As String
    Public Property Imagen() As String
        Get
            Return _Imagen
        End Get
        Set(ByVal value As String)
            _Imagen = value
        End Set
    End Property

    Private _Hijos As List(Of Patente)
    Public Property Hijos() As List(Of Patente)
        Get
            Return _Hijos
        End Get
        Set(ByVal value As List(Of Patente))
            _Hijos = value
        End Set
    End Property

End Class
