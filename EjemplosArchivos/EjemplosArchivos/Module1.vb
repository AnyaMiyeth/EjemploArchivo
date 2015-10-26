Imports System.IO

Module Module1
    Sub Main()
        'Ejercicio Crear una clase que permita gestionar un archivo para almacenar los contactos (Nombre, Telefono, Email, Direccion)
        'La clase debe tener un metodo para abrir el archivo, un metodo para escribir un contacto, un metodo para buscarlo por numero de 
        'telefono,  y un metodo que retorno todos los contactos

        ' Guardar datos en Archivo
        Dim datos As New ContactosDAO
        Dim c As New Contactos
        c.Telefono = "317777785"
        c.Nombre = "Andrea"
        c.Apellido = "Llanos"
        c.Email = "Jllanosa@gmail.com"
        c.Direccion = "cll 6 No 30 - 11"

        Dim msg As String
        msg = datos.Insert(c)
        Console.WriteLine(msg)
        Console.ReadKey()


        ' Consultar todos los Registros de un Archivo
        Console.WriteLine("Consultar Todos")
        Dim lst As List(Of Contactos)
        lst = datos.GetAll()
        For Each item In lst
            Console.WriteLine(item.Telefono + " " + item.NombreCompleto)
        Next
        Console.ReadKey()

        ' Consultar un Registro de un Archivo
        Console.WriteLine("Consultar x Telefono")
        Dim contacto As Contactos
        contacto = datos.GetPk("317777777")
        If Not contacto Is Nothing Then
            Console.WriteLine(contacto.Nombre)
        Else
            Console.WriteLine("Es Nulo")
        End If
        Console.ReadKey()


    End Sub

   

End Module
