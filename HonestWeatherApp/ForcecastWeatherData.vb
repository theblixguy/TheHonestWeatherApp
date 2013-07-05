Public Class ForcecastWeatherData

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

    Public Class City
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
        Public Property coord() As Coord
            Get
                Return m_coord
            End Get
            Set(value As Coord)
                m_coord = Value
            End Set
        End Property
        Private m_coord As Coord
        Public Property country() As String
            Get
                Return m_country
            End Get
            Set(value As String)
                m_country = Value
            End Set
        End Property
        Private m_country As String
        Public Property population() As Integer
            Get
                Return m_population
            End Get
            Set(value As Integer)
                m_population = Value
            End Set
        End Property
        Private m_population As Integer
    End Class

    Public Class Temp
        Public Property day() As Double
            Get
                Return m_day
            End Get
            Set(value As Double)
                m_day = Value
            End Set
        End Property
        Private m_day As Double
        Public Property min() As Double
            Get
                Return m_min
            End Get
            Set(value As Double)
                m_min = Value
            End Set
        End Property
        Private m_min As Double
        Public Property max() As Double
            Get
                Return m_max
            End Get
            Set(value As Double)
                m_max = Value
            End Set
        End Property
        Private m_max As Double
        Public Property night() As Double
            Get
                Return m_night
            End Get
            Set(value As Double)
                m_night = Value
            End Set
        End Property
        Private m_night As Double
        Public Property eve() As Double
            Get
                Return m_eve
            End Get
            Set(value As Double)
                m_eve = Value
            End Set
        End Property
        Private m_eve As Double
        Public Property morn() As Double
            Get
                Return m_morn
            End Get
            Set(value As Double)
                m_morn = Value
            End Set
        End Property
        Private m_morn As Double
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

    Public Class List
        Public Property dt() As Integer
            Get
                Return m_dt
            End Get
            Set(value As Integer)
                m_dt = Value
            End Set
        End Property
        Private m_dt As Integer
        Public Property temp() As Temp
            Get
                Return m_temp
            End Get
            Set(value As Temp)
                m_temp = Value
            End Set
        End Property
        Private m_temp As Temp
        Public Property pressure() As Double
            Get
                Return m_pressure
            End Get
            Set(value As Double)
                m_pressure = Value
            End Set
        End Property
        Private m_pressure As Double
        Public Property humidity() As Integer
            Get
                Return m_humidity
            End Get
            Set(value As Integer)
                m_humidity = Value
            End Set
        End Property
        Private m_humidity As Integer
        Public Property weather() As List(Of Weather)
            Get
                Return m_weather
            End Get
            Set(value As List(Of Weather))
                m_weather = Value
            End Set
        End Property
        Private m_weather As List(Of Weather)
        Public Property speed() As Double
            Get
                Return m_speed
            End Get
            Set(value As Double)
                m_speed = Value
            End Set
        End Property
        Private m_speed As Double
        Public Property deg() As Integer
            Get
                Return m_deg
            End Get
            Set(value As Integer)
                m_deg = Value
            End Set
        End Property
        Private m_deg As Integer
        Public Property clouds() As Integer
            Get
                Return m_clouds
            End Get
            Set(value As Integer)
                m_clouds = Value
            End Set
        End Property
        Private m_clouds As Integer
        Public Property rain() As Double
            Get
                Return m_rain
            End Get
            Set(value As Double)
                m_rain = Value
            End Set
        End Property
        Private m_rain As Double
    End Class

    Public Class ForecastRootObject
        Public Property cod() As String
            Get
                Return m_cod
            End Get
            Set(value As String)
                m_cod = value
            End Set
        End Property
        Private m_cod As String
        Public Property message() As Double
            Get
                Return m_message
            End Get
            Set(value As Double)
                m_message = value
            End Set
        End Property
        Private m_message As Double
        Public Property city() As City
            Get
                Return m_city
            End Get
            Set(value As City)
                m_city = value
            End Set
        End Property
        Private m_city As City
        Public Property cnt() As Integer
            Get
                Return m_cnt
            End Get
            Set(value As Integer)
                m_cnt = value
            End Set
        End Property
        Private m_cnt As Integer
        Public Property list() As List(Of List)
            Get
                Return m_list
            End Get
            Set(value As List(Of List))
                m_list = value
            End Set
        End Property
        Private m_list As List(Of List)
    End Class
End Class
