Imports System.IO

Public Class ContactosDAO
    
    Dim fs As FileStream = Nothing
    Dim sw As StreamWriter = Nothing
    Dim sr As StreamReader = Nothing

    Dim Archivo As String = "contactos.txt"
    Dim msg, str As String
    'Metodo para guardar en archivo
    Public Function Insert(Contacto As Contactos) As String
        Try

            If Not GetPk(Contacto.Telefono) Is Nothing Then
                Return "Error: Ya esta Registrado!!"
            Else
                fs = New FileStream(Archivo, FileMode.Append, FileAccess.Write)
                sw = New StreamWriter(fs)
                sw.WriteLine(Serializar(Contacto))
            End If
        Catch ex As Exception
            msg = ex.Message
        Finally
            If (Not sw Is Nothing) Then sw.Close()
            msg = "Se Guardó Satisfactoriamente"
        End Try
        Return msg
    End Function
    'Metodo para Consultar por un campo en archivo
    Public Function GetPk(Telefono As String) As Contactos
        Dim lst As New List(Of Contactos)
        Dim contacto As Contactos = Nothing
        Try
            sr = New StreamReader(Archivo)
            str = sr.ReadLine()
            While (str <> Nothing)
                contacto = DeSerializar(str)
                If contacto.Telefono.Trim() = Telefono.Trim() Then
                    Exit While
                Else
                    contacto = Nothing
                End If
                str = sr.ReadLine()
            End While
        Catch ex As Exception
            msg = ex.Message
        Finally
            If (Not sr Is Nothing) Then sr.Close()
            msg = "Se Guardó Satisfactoriamente"
        End Try
        Return contacto
    End Function
    'Metodo para Consultar todos los datos en archivo
    Public Function GetAll() As List(Of Contactos)
        Dim lst As New List(Of Contactos)
        Dim contacto As Contactos
        Try
            sr = New StreamReader(Archivo)
            Str = sr.ReadLine()
            While (str(0) <> Nothing)
                contacto = DeSerializar(str)
                lst.Add(contacto)
                str = sr.ReadLine()
            End While
        Catch ex As Exception
            msg = ex.Message
        Finally
            If (Not sr Is Nothing) Then sr.Close()
            msg = "Se Guardó Satisfactoriamente"
        End Try
        Return lst
    End Function
    'Metodo para serializar(guardar los datos sepaarado por coma)
    Private Function Serializar(Contacto As Contactos) As String
        Return String.Format("{0},{1},{2},{3},{4}", Contacto.Telefono, Contacto.Apellido, Contacto.Nombre, Contacto.Direccion, Contacto.Email)
    End Function
    'Metodo para separar los datos y asignarlos a cada propiedad de la clase
    Private Function DeSerializar(Linea As String) As Contactos
        Dim contacto As New Contactos
        Dim ArrayDatos() As String = Linea.Split(",")
        contacto.Telefono = ArrayDatos(0)
        contacto.Apellido = ArrayDatos(1)
        contacto.Nombre = ArrayDatos(2)
        contacto.Direccion = ArrayDatos(3)
        contacto.Email = ArrayDatos(4)
        Return contacto
    End Function



End Class
