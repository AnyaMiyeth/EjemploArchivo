
Public Class Contactos
    Property Telefono As String
    Property Nombre As String
    Property Apellido As String
    Property Email As String
    Property Direccion As String
    ReadOnly Property NombreCompleto As String
        Get
            Return String.Format("{0} {1}", Nombre.Trim, Apellido.Trim)
        End Get
    End Property

End Class
