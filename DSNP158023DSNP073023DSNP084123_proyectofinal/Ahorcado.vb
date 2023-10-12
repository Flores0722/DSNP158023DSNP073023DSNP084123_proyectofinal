Public Class Ahorcado
    Dim indiceCategoria As SByte = -1
    Dim indicePalabra As SByte = -1

    Dim categorias As String() = {"Deportes", "Ciencia", "Cultura", "Comida", "Cine", "Lugares"}
    Dim palabras As String()() = {
        New String() {"Futbol", "Natacion", "Atletismo", "Tenis", "Golf", "Baloncesto", "Balon", "Estadio", "Cancha", "Gradas", "Jugador", "Arbitro"},
        New String() {"Atomo", "Celula", "Molecula", "Velocidad", "Energia", "Masa", "Gravedad", "Quimica", "Biologia", "Medicina", "Microbio", "Organismo"},
        New String() {"Paisaje", "Volcanes", "Pueblos", "Tipicos", "Tazumal", "Carnaval", "Fiestas", "Celebracion", "Artesania", "Molienda", "Cipitio", "Siguanaba"},
        New String() {"Pupusa", "Refresco", "Tacos", "Burritos", "Hamburguesa", "Pizza", "Chicharrones", "Casamiento", "Empanadas", "Enchiladas", "Queso", "Crema"},
        New String() {"Titanic", "Avatar", "Sirenita", "Protagonista", "Actriz", "Villano", "Hollywood", "Cameron", "Pelicula", "Largometraje", "Cortometraje", "Actuacion"},
        New String() {"Apulo", "Izalco", "Chaparrastique", "Conchagua", "Balneario", "Piscina", "Playa", "Hoteles", "Decameron", "Coatepeque", "Tunco", "Ichanmichen"}
    }

    Public Sub New()
        Randomize()
    End Sub

    Public Function pedirCategoria()
        indiceCategoria = CInt(Int((6 * Rnd())))
        If indiceCategoria > 5 Then
            indiceCategoria = 5
        End If
        Return categorias(indiceCategoria)
    End Function
    Public Function pedirPalabra()
        indicePalabra = CInt(Int((12 * Rnd())))
        If indicePalabra > 11 Then
            indicePalabra = 11
        End If
        Return palabras(indiceCategoria)(indicePalabra)
    End Function


End Class
