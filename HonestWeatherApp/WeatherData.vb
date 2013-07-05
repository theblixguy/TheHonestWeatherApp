Public Class WeatherData
   Public Class Coord
        Public Property lon() As Double
            Get
                Return m_lon
            End Get
            Set(value As Double)
                m_lon = Value
            End Set
        End Property
        Private m_lon As Double
        Public Property lat() As Double
            Get
                Return m_lat
            End Get
            Set(value As Double)
                m_lat = Value
            End Set
        End Property
        Private m_lat As Double
    End Class

    Public Class Sys
        Public Property country() As String
            Get
                Return m_country
            End Get
            Set(value As String)
                m_country = Value
            End Set
        End Property
        Private m_country As String
        Public Property sunrise() As Integer
            Get
                Return m_sunrise
            End Get
            Set(value As Integer)
                m_sunrise = Value
            End Set
        End Property
        Private m_sunrise As Integer
        Public Property sunset() As Integer
            Get
                Return m_sunset
            End Get
            Set(value As Integer)
                m_sunset = Value
            End Set
        End Property
        Private m_sunset As Integer
    End Class

    Public Class Weather
        Public Property id() As Integer
            Get
                Return m_id
            End Get
            Set(value As Integer)
                m_id = Value
            End Set
        End Property
        Private m_id As Integer
        Public Property main() As String
            Get
                Return m_main
            End Get
            Set(value As String)
                m_main = Value
            End Set
        End Property
        Private m_main As String
        Public Property description() As String
            Get
                Return m_description
            End Get
            Set(value As String)
                m_description = Value
            End Set
        End Property
        Private m_description As String
        Public Property icon() As String
            Get
                Return m_icon
            End Get
            Set(value As String)
                m_icon = Value
            End Set
        End Property
        Private m_icon As String
    End Class

    Public Class Main
        Public Property temp() As Double
            Get
                Return m_temp
            End Get
            Set(value As Double)
                m_temp = Value
            End Set
        End Property
        Private m_temp As Double
        Public Property temp_min() As Double
            Get
                Return m_temp_min
            End Get
            Set(value As Double)
                m_temp_min = Value
            End Set
        End Property
        Private m_temp_min As Double
        Public Property temp_max() As Double
            Get
                Return m_temp_max
            End Get
            Set(value As Double)
                m_temp_max = Value
            End Set
        End Property
        Private m_temp_max As Double
        Public Property pressure() As Double
            Get
                Return m_pressure
            End Get
            Set(value As Double)
                m_pressure = Value
            End Set
        End Property
        Private m_pressure As Double
        Public Property sea_level() As Double
            Get
                Return m_sea_level
            End Get
            Set(value As Double)
                m_sea_level = Value
            End Set
        End Property
        Private m_sea_level As Double
        Public Property grnd_level() As Double
            Get
                Return m_grnd_level
            End Get
            Set(value As Double)
                m_grnd_level = Value
            End Set
        End Property
        Private m_grnd_level As Double
        Public Property humidity() As Integer
            Get
                Return m_humidity
            End Get
            Set(value As Integer)
                m_humidity = Value
            End Set
        End Property
        Private m_humidity As Integer
    End Class

    Public Class Wind
        Public Property speed() As Double
            Get
                Return m_speed
            End Get
            Set(value As Double)
                m_speed = Value
            End Set
        End Property
        Private m_speed As Double
        Public Property deg() As Double
            Get
                Return m_deg
            End Get
            Set(value As Double)
                m_deg = Value
            End Set
        End Property
        Private m_deg As Double
    End Class

    Public Class Clouds
        Public Property all() As Integer
            Get
                Return m_all
            End Get
            Set(value As Integer)
                m_all = Value
            End Set
        End Property
        Private m_all As Integer
    End Class

    Public Class RootObject
        Public Property coord() As Coord
            Get
                Return m_coord
            End Get
            Set(value As Coord)
                m_coord = Value
            End Set
        End Property
        Private m_coord As Coord
        Public Property sys() As Sys
            Get
                Return m_sys
            End Get
            Set(value As Sys)
                m_sys = Value
            End Set
        End Property
        Private m_sys As Sys
        Public Property weather() As List(Of Weather)
            Get
                Return m_weather
            End Get
            Set(value As List(Of Weather))
                m_weather = Value
            End Set
        End Property
        Private m_weather As List(Of Weather)
        Public Property base() As String
            Get
                Return m_base
            End Get
            Set(value As String)
                m_base = Value
            End Set
        End Property
        Private m_base As String
        Public Property main() As Main
            Get
                Return m_main
            End Get
            Set(value As Main)
                m_main = Value
            End Set
        End Property
        Private m_main As Main
        Public Property wind() As Wind
            Get
                Return m_wind
            End Get
            Set(value As Wind)
                m_wind = Value
            End Set
        End Property
        Private m_wind As Wind
        Public Property clouds() As Clouds
            Get
                Return m_clouds
            End Get
            Set(value As Clouds)
                m_clouds = Value
            End Set
        End Property
        Private m_clouds As Clouds
        Public Property dt() As Integer
            Get
                Return m_dt
            End Get
            Set(value As Integer)
                m_dt = Value
            End Set
        End Property
        Private m_dt As Integer
        Public Property id() As Integer
            Get
                Return m_id
            End Get
            Set(value As Integer)
                m_id = Value
            End Set
        End Property
        Private m_id As Integer
        Public Property name() As String
            Get
                Return m_name
            End Get
            Set(value As String)
                m_name = Value
            End Set
        End Property
        Private m_name As String
        Public Property cod() As Integer
            Get
                Return m_cod
            End Get
            Set(value As Integer)
                m_cod = Value
            End Set
        End Property
        Private m_cod As Integer
    End Class
End Class
