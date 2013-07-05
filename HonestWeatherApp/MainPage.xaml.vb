Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports HonestWeatherApp.WeatherData
Imports Newtonsoft.Json
Imports HonestWeatherApp.ForcecastWeatherData
Imports System.IO.IsolatedStorage
Imports System.Windows.Media.Imaging
Imports Microsoft.Xna.Framework.Media.PhoneExtensions
Imports System.IO
Imports Microsoft.Phone.Tasks
Imports Microsoft.Xna.Framework.Media
Imports System.Device.Location


Partial Public Class MainPage
    Inherits PhoneApplicationPage
    Public Shared content As String
    Public Shared content1 As String
    Public Shared IsCompleted As Boolean = False
    Public Shared wMsg As String
    Public Shared tTemp As Double
    Public Shared Temp As Integer
    Public Shared AvgTemp As Integer
    Public Shared MinTemp As Double
    Public Shared MaxTemp As Double
    Public Shared tAvgTemp As Double
    Public Shared uImp As Boolean = False
    Dim settings As IsolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings

    Public Sub New()
        InitializeComponent()
        DataContext = App.ViewModel
    End Sub
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        If Not App.ViewModel.IsDataLoaded Then
            App.ViewModel.LoadData()
        End If
    End Sub
    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ProgressBar1.Visibility = System.Windows.Visibility.Visible
        LoadingText1.Visibility = System.Windows.Visibility.Visible
        WeatherText1.Visibility = System.Windows.Visibility.Collapsed
        WeatherText2.Visibility = System.Windows.Visibility.Collapsed
        WeatherText3.Visibility = System.Windows.Visibility.Collapsed
        WeatherText4.Visibility = System.Windows.Visibility.Collapsed

        If Not settings.Contains("UseImperial") Then
            uImp = False
        ElseIf settings.Contains("UseImperial") Then
            uImp = True
        End If


        If Not settings.Contains("city") Then
            MessageBox.Show("You haven't added a city yet. Please goto settings and add your current city!", "Error", MessageBoxButton.OK)
            GetCurrentWeather("Boston")
            GetWeatherForecast("Boston")

        ElseIf settings.Contains("city") Then
            Dim curCity As String
            curCity = settings("city").ToString
            GetCurrentWeather(curCity)
            GetWeatherForecast(curCity)
        End If

    End Sub
    Public Sub GetCurrentWeather(city As String)
        Dim url As New Uri(Uri.EscapeUriString("http://api.openweathermap.org/data/2.5/weather?q=" + city))
        Dim syncClient As New WebClient()
        AddHandler syncClient.DownloadStringCompleted, AddressOf syncClient_DownloadStringCompleted
        syncClient.DownloadStringAsync(url)
    End Sub
    Public Sub syncClient_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            content = e.Result
            Dim obc = JsonConvert.DeserializeObject(Of RootObject)(content)
            IsCompleted = True
            wMsg = WeatherAPI.GetWeatherMsg(obc.weather.Item(0).id)
            WeatherText1.Text = wMsg
            tTemp = obc.main.temp
            tTemp = tTemp - 273.15
            Temp = Convert.ToInt32(tTemp)
            MinTemp = obc.main.temp_min
            MaxTemp = obc.main.temp_max
            tAvgTemp = MinTemp + MaxTemp
            tAvgTemp = tAvgTemp / 2
            tAvgTemp = tAvgTemp - 273.15
            AvgTemp = Convert.ToInt32(tAvgTemp)

            If uImp = False Then
                WeatherText2.Text = Temp & "°" & " C"
            ElseIf uImp = True Then
                Dim anTemp As Double
                anTemp = ((Temp * 1.8) + 32)
                WeatherText2.Text = Convert.ToInt32(anTemp) & "°" & " F"
            End If

            WeatherText3.Text = WeatherAPI.GetTempMsg(AvgTemp)
            WeatherText4.Text = "You live in " & obc.name & ", " & obc.sys.country
            WeatherText1.Visibility = System.Windows.Visibility.Visible
            WeatherText2.Visibility = System.Windows.Visibility.Visible
            WeatherText3.Visibility = System.Windows.Visibility.Visible
            WeatherText4.Visibility = System.Windows.Visibility.Visible
            ProgressBar1.Visibility = System.Windows.Visibility.Collapsed
            LoadingText1.Visibility = System.Windows.Visibility.Collapsed
        Catch ex As Exception
            MessageBox.Show("An error occured while fetching and deserializing weather data: " & ex.Message, "Error", MessageBoxButton.OK)
        End Try
    End Sub
    Public Sub GetWeatherForecast(city As String)
        Dim url As New Uri(Uri.EscapeUriString("http://api.openweathermap.org/data/2.5/forecast/daily?q=" & city & "&mode=json&units=metric&cnt=3"))
        Dim syncClient1 As New WebClient()
        AddHandler syncClient1.DownloadStringCompleted, AddressOf syncClient1_DownloadStringCompleted
        syncClient1.DownloadStringAsync(url)
    End Sub

    Public Sub syncClient1_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            content1 = e.Result
            Dim obc1 = JsonConvert.DeserializeObject(Of ForecastRootObject)(content1)
            '// Today vars
            Dim tmTemp As Double
            Dim tmmTemp As Double
            Dim mTemp As Integer
            Dim mmTemp As Integer
            Dim wwMsg As String
            Dim avgTmp As Integer
            '// Tomorrow vars
            Dim tmTemp1 As Double
            Dim tmmTemp1 As Double
            Dim mTemp1 As Integer
            Dim mmTemp1 As Integer
            Dim wwMsg1 As String
            Dim avgTmp1 As Integer
            '// Day after tomorrow vars
            Dim tmTemp2 As Double
            Dim tmmTemp2 As Double
            Dim mTemp2 As Integer
            Dim mmTemp2 As Integer
            Dim wwMsg2 As String
            Dim avgTmp2 As Integer
            '// Forecast for Today
            tmmTemp = obc1.list.Item(0).temp.max
            tmTemp = obc1.list.Item(0).temp.min
            mTemp = Convert.ToInt32(tmTemp)
            mmTemp = Convert.ToInt32(tmmTemp)
            avgTmp = Convert.ToInt32(((tmTemp + tmmTemp) / 2))
            wwMsg = WeatherAPI.GetTempMsg(avgTmp)

            If uImp = False Then
                fTextBox1.Text = mTemp & "°C Min / " & mmTemp & "°C Max"
            ElseIf uImp = True Then
                Dim anTemp As Double
                Dim anTemp2 As Double
                anTemp = ((mTemp * 1.8) + 32)
                anTemp2 = ((mmTemp * 1.8) + 32)
                fTextBox1.Text = Convert.ToInt32(anTemp) & "°F Min / " & Convert.ToInt32(anTemp2) & "°F Max"
            End If

            fTextBox2.Text = wwMsg
            '// Forecast for Tomorrow
            tmmTemp1 = obc1.list.Item(1).temp.max
            tmTemp1 = obc1.list.Item(1).temp.min
            mTemp1 = Convert.ToInt32(tmTemp1)
            mmTemp1 = Convert.ToInt32(tmmTemp1)
            avgTmp1 = Convert.ToInt32(((tmTemp1 + tmmTemp1) / 2))
            wwMsg1 = WeatherAPI.GetTempMsg(avgTmp1)

            If uImp = False Then
                fTextBox1.Text = mTemp & "°C Min / " & mmTemp & "°C Max"
            ElseIf uImp = True Then
                Dim anTemp1 As Double
                Dim anTemp3 As Double
                anTemp1 = ((mTemp1 * 1.8) + 32)
                anTemp3 = ((mmTemp1 * 1.8) + 32)
                fTextBox3.Text = Convert.ToInt32(anTemp1) & "°F Min / " & Convert.ToInt32(anTemp3) & "°F Max"
            End If

            fTextBox4.Text = wwMsg1
            '// Forecast for Day After Tomorrow
            tmmTemp2 = obc1.list.Item(2).temp.max
            tmTemp2 = obc1.list.Item(2).temp.min
            mTemp2 = Convert.ToInt32(tmTemp2)
            mmTemp2 = Convert.ToInt32(tmmTemp2)
            avgTmp2 = Convert.ToInt32(((tmTemp2 + tmmTemp2) / 2))
            wwMsg2 = WeatherAPI.GetTempMsg(avgTmp2)

            If uImp = False Then
                fTextBox1.Text = mTemp & "°C Min / " & mmTemp & "°C Max"
            ElseIf uImp = True Then
                Dim anTemp2 As Double
                Dim anTemp4 As Double
                anTemp2 = ((mTemp2 * 1.8) + 32)
                anTemp4 = ((mmTemp2 * 1.8) + 32)
                fTextBox5.Text = Convert.ToInt32(anTemp2) & "°F Min / " & Convert.ToInt32(anTemp4) & "°F Max"
            End If

            fTextBox6.Text = wwMsg2
        Catch ex As Exception
            MessageBox.Show("An error occured while fetching and deserializing forecast weather data: " & ex.Message, "Error", MessageBoxButton.OK)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        NavigationService.Navigate(New Uri("/Settings.xaml", UriKind.Relative))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If Not settings.Contains("city") Then
            MessageBox.Show("You haven't added a city yet. Please goto settings and add your current city!", "Error", MessageBoxButton.OK)
            GetCurrentWeather("Boston")
            GetWeatherForecast("Boston")
        Else
            Dim curCity1 As String
            curCity1 = settings("city").ToString
            GetCurrentWeather(curCity1)
            GetWeatherForecast(curCity1)
        End If
    End Sub

    Private Sub ShareMisery()
        Dim bmp = New WriteableBitmap(Me.LayoutRoot, Nothing)
        Dim width = CInt(bmp.PixelWidth)
        Dim height = CInt(bmp.PixelHeight)
        Using ms = New MemoryStream(width * height * 4)
            bmp.SaveJpeg(ms, width, height, 0, 100)
            ms.Seek(0, SeekOrigin.Begin)
            Dim [lib] = New MediaLibrary()
            Dim picture = [lib].SavePicture(String.Format("misery.jpg"), ms)
            Dim task = New ShareMediaTask()
            task.FilePath = picture.GetPath()
            task.Show()
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ShareMisery()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        NavigationService.Navigate(New Uri("/About.xaml", UriKind.Relative))
    End Sub

   
End Class