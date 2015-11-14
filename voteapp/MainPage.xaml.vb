' Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

Imports System.Net.Http
Imports Windows.Data.Json
''' <summary>
''' Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Dim tp As DispatcherTimer
    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        tp = New DispatcherTimer()
        tp.Interval = New TimeSpan(0, 0, 1)
        AddHandler tp.Tick, AddressOf ticking
        tp.Start()
    End Sub

    Private Async Sub ticking(sender As Object, e As Object)
        Dim client = New HttpClient()
        client.DefaultRequestHeaders.Add("Cache-Control", "no-cache")
        Dim json = Await client.GetStringAsync(New Uri("http://ppedv.de/msts/votes.json"))
        Dim root = JsonValue.Parse(json)
        Dim vier = root.GetObject("vote").GetObject("vier").GetNumber()
        Dim funf = root.GetObject("vote").GetObject("funf").GetNumber()
        vier2.Height = New GridLength(vier, GridUnitType.Star)
        vier1.Height = New GridLength(funf, GridUnitType.Star)
        funf2.Height = New GridLength(funf, GridUnitType.Star)
        funf1.Height = New GridLength(vier, GridUnitType.Star)

    End Sub
End Class
