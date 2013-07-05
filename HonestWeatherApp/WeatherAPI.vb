Public Class WeatherAPI

    Shared Function GetWeatherMsg(Code As Integer) As String
        Dim msg As String = Nothing
        Select Case Code
            Case 200
                msg = "Some fucking thunderstorms with a bit of rain"
            Case 201
                msg = "Some fucking thunderstorms and it's pissing down"
            Case 202
                msg = "Some fucking thunderstorms with apocalyptic rain"
            Case 210
                msg = "Lame thunderstorms"
            Case 211
                msg = "A fucking thunderstorm"
            Case 212
                msg = "A big fucking thunderstorm"
            Case 221
                msg = "A fucking ragged thunderstorm"
            Case 230
                msg = "A fucking thunderstorm with light drizzle"
            Case 231
                msg = "A fucking thunderstorm with drizzle"
            Case 232
                msg = "A fucking thunderstorm with heavy drizzle"
            Case 300
                msg = "Light fucking drizzle"
            Case 301
                msg = "A fucking drizzle"
            Case 302
                msg = "Heavy fucking drizzle"
            Case 310
                msg = "It's pissing down lightly"
            Case 311
                msg = "It's pissing down"
            Case 312
                msg = "It's pissing down heavily"
            Case 321
                msg = "Pissing showers"
            Case 500
                msg = "It's pissing down lightly"
            Case 501
                msg = "It's pissing down moderately"
            Case 502
                msg = "It's fucking raining right now"
            Case 503
                msg = "It's fucking raining, monsoon style"
            Case 504
                msg = "An apocalyptic downpour. Prepare fucking boats"
            Case 511
                msg = "There's freezing fucking rain"
            Case 520
                msg = "There are light fucking showers"
            Case 521
                msg = "There are fucking showers"
            Case 522
                msg = "There are heavy fucking showers"
            Case 600
                msg = "There is fucking light snow"
            Case 601
                msg = "It's fucking snowing right now"
            Case 602
                msg = "Tons of fucking snow"
            Case 622
                msg = "Tons of fucking shower snow"
            Case 611
                msg = "Fucking sleet"
            Case 621
                msg = "Nasty fucking shower sleet"
            Case 701
                msg = "We have fucking mist"
            Case 711
                msg = "We have fucking smoke"
            Case 721
                msg = "We see fucking haze"
            Case 731
                msg = "We have fucking sand/dust whirls"
            Case 741
                msg = "Yay, fucking fog"
            Case 800
                msg = "Clear fucking skies"
            Case 801
                msg = "A few fucking clouds"
            Case 802
                msg = "Scattered fucking clouds"
            Case 803
                msg = "Broken fucking clouds"
            Case 804
                msg = "There are fucking overcast clouds"
            Case 900
                msg = "A fucking tornado is raging"
            Case 901
                msg = "A fucking tropical storm is raging"
            Case 902
                msg = "A fucking hurricane is raging"
            Case 903
                msg = "Extreme fucking cold"
            Case 904
                msg = "Extreme fucking heat"
            Case 905
                msg = "It's windy as fuck"
            Case 906
                msg = "It's fucking hailing right now"
        End Select
        Return msg
    End Function

    Shared Function GetTempMsg(AvgTemp As Integer) As String
        Dim msg1 As String = Nothing
        If (AvgTemp < -15) Then
            msg1 = "Hell is freezing over"
        ElseIf (AvgTemp > -15 And AvgTemp <= -5) Then
            msg1 = "It's cold as fuck"
        ElseIf (AvgTemp > -5 And AvgTemp <= 5) Then
            msg1 = "It's fucking chilly"
        ElseIf (AvgTemp > 5 And AvgTemp <= 18) Then
            msg1 = "It's sort of ok"
        ElseIf (AvgTemp > 18 And AvgTemp <= 25) Then
            msg1 = "It feels pretty fucking nice"
        ElseIf (AvgTemp > 25 And AvgTemp <= 35) Then
            msg1 = "It's pretty fucking hot"
        ElseIf (AvgTemp > 35) Then
            msg1 = "It's hot as fuck"
        End If
        Return msg1
    End Function
End Class
