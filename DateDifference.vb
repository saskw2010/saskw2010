Imports Microsoft.VisualBasic
Public Class DateDifferencemosso
    ''' <summary>
    ''' defining Number of days in month; index 0=> january and 11=> December
    ''' february contain either 28 or 29 days, that's why here value is -1
    ''' which wil be calculate later.
    ''' </summary>
    Private monthDay As Integer() = New Integer(11) {31, -1, 31, 30, 31, 30, _
     31, 31, 30, 31, 30, 31}

    ''' <summary>
    ''' contain from date
    ''' </summary>
    Private fromDate As DateTime

    ''' <summary>
    ''' contain To Date
    ''' </summary>
    Private toDate As DateTime

    ''' <summary>
    ''' this three variable for output representation..
    ''' </summary>
    Private year As Integer
    Private month As Integer
    Private day As Integer

    Public Sub New(d1 As DateTime, d2 As DateTime)
        Dim increment As Integer

        If d1 > d2 Then
            Me.fromDate = d2
            Me.toDate = d1
        Else
            Me.fromDate = d1
            Me.toDate = d2
        End If

        ''' 
        ''' Day Calculation
        ''' 
        increment = 0

        If Me.fromDate.Day > Me.toDate.Day Then

            increment = Me.monthDay(Me.fromDate.Month - 1)
        End If
        ''' if it is february month
        ''' if it's to day is less then from day
        If increment = -1 Then
            If DateTime.IsLeapYear(Me.fromDate.Year) Then
                ' leap year february contain 29 days
                increment = 29
            Else
                increment = 28
            End If
        End If
        If increment <> 0 Then
            day = (Me.toDate.Day + increment) - Me.fromDate.Day
            increment = 1
        Else
            day = Me.toDate.Day - Me.fromDate.Day
        End If


        If (Me.fromDate.Month + increment) > Me.toDate.Month Then
            Me.month = (Me.toDate.Month + 12) - (Me.fromDate.Month + increment)
            increment = 1
        Else
            Me.month = (Me.toDate.Month) - (Me.fromDate.Month + increment)
            increment = 0
        End If

        '''
        ''' year calculation
        '''

        Me.year = Me.toDate.Year - (Me.fromDate.Year + increment)
    End Sub

    Public Overrides Function ToString() As String
        'return base.ToString();
        Return Me.year & " Year(s), " & Me.month & " month(s), " & Me.day & " day(s)"
    End Function

    Public ReadOnly Property Years() As Integer
        Get
            Return Me.year
        End Get
    End Property

    Public ReadOnly Property Months() As Integer
        Get
            Return Me.month
        End Get
    End Property

    Public ReadOnly Property Days() As Integer
        Get
            Return Me.day
        End Get
    End Property

End Class
