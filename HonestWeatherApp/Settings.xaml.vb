Imports System.IO.IsolatedStorage
Imports System.Device.Location
Imports Microsoft.Phone.Maps.Services

Partial Public Class Settings
    Inherits PhoneApplicationPage
    Dim settings As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings
    Dim lt As Double
    Dim lnt As Double
    Dim watcher As New GeoCoordinateWatcher(GeoPositionAccuracy.High)
    Dim query As New ReverseGeocodeQuery()
    Dim locations As List(Of MapLocation)
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Settings_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AddHandler watcher.StatusChanged, AddressOf watcher_StatusChanged
        AddHandler watcher.PositionChanged, AddressOf watcher_PositionChanged

        If Not settings.Contains("city") Then
            TextBox1.Text = "Type a city name"
        Else
            TextBox1.Text = settings("city").ToString
        End If

        If Not settings.Contains("UseImperial") Then
            RadioButton1.IsChecked = True
            RadioButton2.IsChecked = False
        Else
            RadioButton1.IsChecked = False
            RadioButton2.IsChecked = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If Not IsolatedStorageSettings.ApplicationSettings.Contains("city") Then
            settings.Add("city", TextBox1.Text)
            settings.Save()
        Else
            settings("city") = TextBox1.Text
            settings.Save()
        End If

        If RadioButton2.IsChecked = True Then

            Try
                settings.Remove("UseImperial")
            Catch ex As Exception : End Try

            settings.Add("UseImperial", "0")
            settings.Save()

        ElseIf RadioButton1.IsChecked = True Then

            settings.Remove("UseImperial")
            settings.Save()

        End If
        NavigationService.GoBack()
    End Sub

    Public Sub watcher_StatusChanged(sender As Object, e As GeoPositionStatusChangedEventArgs)
        Select Case e.Status
            Case GeoPositionStatus.Disabled
                ' The Location Service is disabled or unsupported.
                MessageBox.Show("The Location Service is disabled or unsupported. Please make sure it's turned on in Settings->Location", "Location Service Unavailable", MessageBoxButton.OK)
                watcher.Stop()
                Exit Select
            Case GeoPositionStatus.NoData
                ' The Location Service is working, but it cannot get location data.
                MessageBox.Show("Unable to get location data. A network connection is required to get GPS data: Please retry or manually type city", "Location Data Unavailable", MessageBoxButton.OK)
                watcher.Stop()
                Exit Select
        End Select
    End Sub

    Public Sub watcher_PositionChanged(sender As Object, e As GeoPositionChangedEventArgs(Of GeoCoordinate))
        If e.Position.Location.IsUnknown = False Then
            lt = e.Position.Location.Latitude
            lnt = e.Position.Location.Longitude
            query.GeoCoordinate = New GeoCoordinate(lt, lnt)
            AddHandler query.QueryCompleted, AddressOf query_QueryCompleted
            query.QueryAsync()
            watcher.Stop()
        ElseIf e.Position.Location.IsUnknown = True Then
            MessageBox.Show("Location is unknown. Please retry or manually type city name", "Error", MessageBoxButton.OK)
            watcher.Stop()
        End If
    End Sub

    Private Sub Button1_Click1(sender As Object, e As RoutedEventArgs) Handles Button1.Click
        watcher.MovementThreshold = 20
        watcher.Start()
    End Sub

    Public Sub query_QueryCompleted(sender As Object, e As QueryCompletedEventArgs(Of IList(Of MapLocation)))
        TextBox1.Text = e.Result(0).Information.Address.City
    End Sub
End Class
