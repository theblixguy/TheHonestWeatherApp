Imports Microsoft.Phone.Tasks
Imports System.IO

Partial Public Class About
    Inherits PhoneApplicationPage

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub TextBlock1_Tap(sender As Object, e As GestureEventArgs) Handles TextBlock1.Tap
        Dim task As New Microsoft.Phone.Tasks.WebBrowserTask
        task.URL = "http://www.suyashsrijan.com"
        task.Show()
    End Sub

    Private Sub TextBlock2_Tap(sender As Object, e As GestureEventArgs) Handles TextBlock2.Tap
        Dim marketplaceReviewTask As MarketplaceReviewTask = New MarketplaceReviewTask()
        marketplaceReviewTask.Show()
    End Sub

    Private Sub TextBlock3_Tap(sender As Object, e As GestureEventArgs) Handles TextBlock3.Tap
        Dim em As New EmailComposeTask
        em.Subject = "The Honest Weather App v1 Feedback"
        em.To = "suyashsrijan@outlook.com"
        em.Show()
    End Sub
End Class
