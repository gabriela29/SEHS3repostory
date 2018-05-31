Namespace Components.Controls

    ''' <summary>
    ''' An version of a <see cref="System.Windows.Forms.Control"/> 
    ''' which can be shown floating, like a tooltip.  If you
    ''' want to use Me control in conjunction with mouse events
    ''' then you must ensure that the mouse is never in any part of the 
    ''' control when it is shown (like a tooltip). Otherwise, 
    ''' <see cref="System.Windows.Forms.MouseEnter"/> and 
    ''' <see cref="System.Windows.Forms.MouseLeave"/> events
    ''' are broken, and the Forms Message Filter
    ''' goes into a continuous loop when attempting to show
    ''' the control.
    ''' </summary>
    Public Class FloatControl
        Inherits Control


        Private Declare Function SetParent Lib "user32" ( _
            ByVal hWndChild As IntPtr, _
            ByVal hWndNewParent As IntPtr) As Integer

        Private Declare Function ShowWindow Lib "user32" ( _
            ByVal hWnd As IntPtr, _
            ByVal nCmdShow As Integer) As Integer

        Private Const WS_EX_TOOLWINDOW As Integer = &H80
        Private Const WS_EX_NOACTIVATE As Integer = &H8000000
        Private Const WS_EX_TOPMOST As Integer = &H8

        Private Const WM_NCHITTEST As Integer = &H84
        Private Const HTTRANSPARENT As System.Int32 = (-1)


        ''' <summary>
        ''' Shows the control as a floating Window child 
        ''' of the desktop.  To hide the control again,
        ''' use the <see cref="Visible"/> property.
        ''' </summary>
        Public Sub ShowFloating()
            If (Me.Handle.Equals(IntPtr.Zero)) Then
                MyBase.CreateControl()
            End If
            SetParent(MyBase.Handle, IntPtr.Zero)
            ShowWindow(MyBase.Handle, 1)
        End Sub

        ''' <summary>
        ''' Get the <see cref="System.Windows.Forms.CreateParams"/>
        ''' used to create the control.  Me override adds the
        ''' <code>WS_EX_NOACTIVATE</code>, <code>WS_EX_TOOLWINDOW</code>
        ''' and <code>WS_EX_TOPMOST</code> extended styles to make
        ''' the Window float on top.
        ''' </summary>
        Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
            Get
                Dim p As CreateParams = MyBase.CreateParams
                p.ExStyle = p.ExStyle Or (WS_EX_NOACTIVATE Or WS_EX_TOOLWINDOW Or WS_EX_TOPMOST)
                p.Parent = IntPtr.Zero
                Return p
            End Get
        End Property


        ''' <summary>
        ''' Overrides the standard Window Procedure to ensure the
        ''' window is transparent to all mouse events.
        ''' </summary>
        ''' <param name="m">Windows message to process.</param>
        Protected Overrides Sub WndProc(ByRef m As Message)
            If (m.Msg = WM_NCHITTEST) Then
                m.Result = New IntPtr(HTTRANSPARENT)
            Else
                MyBase.WndProc(m)
            End If
        End Sub


        ''' <summary>
        ''' Overrides the standard painting procedure to render
        ''' the text associated with the control.
        ''' </summary>
        ''' <param name="e">PaintEvent Arguments</param>
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            If (MyBase.Text.Length > 0) Then
                Dim br As Brush = New SolidBrush(Me.ForeColor)
                e.Graphics.DrawString(MyBase.Text, Me.Font, br, New PointF(1.0F, 1.0F))
                br.Dispose()
            End If
            e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, _
                0, 0, Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - 1)
        End Sub

        ''' <summary>
        ''' Constructs a new instance of Me control.
        ''' </summary>
        Public Sub New()
            ' intentionally blank
        End Sub

    End Class

End Namespace
