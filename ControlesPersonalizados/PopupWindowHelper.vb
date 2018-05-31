Namespace Components.Controls
#Region "Event Argument Classes"
    ''' <summary>
    ''' Contains event information for a <see cref="PopupClosed"/> event.
    ''' </summary>
    Public Class PopupClosedEventArgs
        Inherits EventArgs

        ''' <summary>
        ''' The popup form.
        ''' </summary>
        Private m_popup As Form = Nothing

        ''' <summary>
        ''' Gets the popup form which is being closed.
        ''' </summary>
        Public ReadOnly Property Popup() As Form
            Get
                Return m_popup
            End Get
        End Property

        ''' <summary>
        ''' Constructs a new instance of this class for the specified
        ''' popup form.
        ''' </summary>
        ''' <param name="popup">Popup Form which is being closed.</param>
        Public Sub New(ByVal popup As Form)
            m_popup = popup
        End Sub
    End Class

    ''' <summary>
    ''' Arguments to a <see cref="PopupCancelEvent"/>.  Provides a
    ''' reference to the popup form that is to be closed and 
    ''' allows the operation to be cancelled.
    ''' </summary>
    Public Class PopupCancelEventArgs
        Inherits EventArgs

        ''' <summary>
        ''' Whether to cancel the operation
        ''' </summary>
        Private m_cancel As Boolean = False
        ''' <summary>
        ''' Mouse down location
        ''' </summary>
        Private location As Point
        ''' <summary>
        ''' Popup form.
        ''' </summary>
        Private m_popup As Form = Nothing

        ''' <summary>
        ''' Constructs a new instance of this class.
        ''' </summary>
        ''' <param name="popup">The popup form</param>
        ''' <param name="location">The mouse location, if any, where the
        ''' mouse event that would cancel the popup occured.</param>
        Public Sub New(ByVal popup As Form, ByVal location As Point)
            m_popup = popup
            Me.location = location
            m_cancel = False
        End Sub

        ''' <summary>
        ''' Gets the popup form
        ''' </summary>
        Public ReadOnly Property Popup() As Form
            Get
                Return m_popup
            End Get
        End Property

        ''' <summary>
        ''' Gets the location that the mouse down which would cancel this 
        ''' popup occurred
        ''' </summary>
        Public ReadOnly Property CursorLocation() As Point
            Get
                Return Me.location
            End Get
        End Property

        ''' <summary>
        ''' Gets/sets whether to cancel closing the form. Set to
        ''' <c>true</c> to prevent the popup from being closed.
        ''' </summary>
        Public Property Cancel() As Boolean
            Get
                Return m_cancel
            End Get
            Set(ByVal Value As Boolean)
                m_cancel = Value
            End Set
        End Property

    End Class
#End Region

#Region "Delegates"
    ''' <summary>
    ''' Represents the method which responds to a <see cref="PopupClosed"/> event.
    ''' </summary>
    Public Delegate Sub PopupClosedEventHandler(ByVal sender As Object, ByVal e As PopupClosedEventArgs)

    ''' <summary>
    ''' Represents the method which responds to a <see cref="PopupCancel"/> event.
    ''' </summary>
    Public Delegate Sub PopupCancelEventHandler(ByVal sender As Object, ByVal e As PopupCancelEventArgs)
#End Region

#Region "GestorVentanaPopup"
    ''' <summary>
    ''' A class to assist in creating popup windows like Combo Box drop-downs and Menus.
    ''' This class includes functionality to keep the title bar of the popup owner form
    ''' active whilst the popup is displayed, and to automatically cancel the popup
    ''' whenever the user clicks outside the popup window or shifts focus to another 
    ''' application.
    ''' </summary>
    Public Class GestorVentanaPopup
        Inherits NativeWindow

#Region "Unmanaged Code"
        Private Declare Auto Function SendMessage Lib "user32" ( _
            ByVal handle As IntPtr, _
            ByVal msg As Integer, _
            ByVal wParam As Integer, _
            ByVal lParam As IntPtr) As Integer

        Private Declare Auto Function PostMessage Lib "user32" ( _
            ByVal handle As IntPtr, _
            ByVal msg As Integer, _
            ByVal wParam As Integer, _
            ByVal lParam As IntPtr) As Integer

        Private Const WM_ACTIVATE As Integer = &H6
        Private Const WM_ACTIVATEAPP As Integer = &H1C
        Private Const WM_NCACTIVATE As Integer = &H86

        Private Declare Sub keybd_event Lib "user32" ( _
            ByVal bVk As Byte, _
            ByVal bScan As Byte, _
            ByVal dwFlags As Integer, _
            ByVal dwExtraInfo As Integer)

        Private Const KEYEVENTF_KEYUP As Integer = &H2
#End Region

#Region "Member Variables"
        ''' <summary>
        ''' Message filter to detect mouse clicks anywhere in the application
        ''' whilst the popup window is being displayed.
        ''' </summary>
        Private WithEvents filter As GestorVentanaPopupMessageFilter = Nothing
        ''' <summary>
        ''' The popup form that is being shown.
        ''' </summary>
        Private WithEvents m_popup As Form = Nothing
        ''' <summary>
        ''' The owner of the popup form that is being shown:
        ''' </summary>
        Private m_owner As Form = Nothing
        ''' <summary>
        ''' Whether the popup is showing or not.
        ''' </summary>
        Private popupShowing As Boolean = False
        ''' <summary>
        ''' Whether the popup has been cancelled, notified by PopupCancel,
        ''' rather than closed.
        ''' </summary>
        Private skipClose As Boolean = False
#End Region

        ''' <summary>
        ''' Raised when the popup form is closed.
        ''' </summary>
        Public Event PopupClosed As PopupClosedEventHandler
        ''' <summary>
        ''' Raised when the Popup Window is about to be cancelled.  The
        ''' <see cref="PopupCancelEventArgs.Cancel"/> property can be
        ''' set to <c>true</c> to prevent the form from being cancelled.
        ''' </summary>
        Public Event PopupCancel As PopupCancelEventHandler

        ''' <summary>
        ''' Shows the specified Form as a popup window, keeping the
        ''' Owner's title bar active and preparing to cancel the popup
        ''' should the user click anywhere outside the popup window.
        ''' <para>Typical code to use this message is as follows:</para>
        ''' <code>
        '''    frmPopup popup = new frmPopup();
        '''    Point location = Me.PointToScreen(new Point(button1.Left, button1.Bottom));
        '''    popupHelper.ShowPopup(this, popup, location);
        ''' </code>
        ''' <para>Put as much initialisation code as possible
        ''' into the popup form's constructor, rather than the <see cref="System.Windows.Forms.Load"/>
        ''' event as this will improve visual appearance.</para>
        ''' </summary>
        ''' <param name="owner">Main form which owns the popup</param>
        ''' <param name="popup">Window to show as a popup</param>
        ''' <param name="location">Location relative to the screen to show the popup at.</param>
        Public Sub ShowPopup(ByVal owner As Form, ByVal popup As Form, ByVal location As Point)

            m_owner = owner
            m_popup = popup

            ' Start checking for the popup being cancelled
            Application.AddMessageFilter(filter)

            ' Set the location of the popup form:
            popup.StartPosition = FormStartPosition.Manual
            popup.Location = location
            ' Make it owned by the window that's displaying it:
            owner.AddOwnedForm(popup)

            ' Show the popup:
            Me.popupShowing = True
            popup.Show()
            popup.Activate()

            ' A little bit of fun.  We've shown the popup,
            ' but because we've kept the main window's
            ' title bar in focus the tab sequence isn't quite
            ' right.  This can be fixed by sending a tab,
            ' but that on its own would shift focus to the
            ' second control in the form.  So send a tab,
            ' followed by a reverse-tab.

            ' Send a Tab command:
            Dim bVk As Byte
            bVk = Keys.Tab
                keybd_event(bVk, 0, 0, 0)
            keybd_event(bVk, 0, KEYEVENTF_KEYUP, 0)

            ' Send a reverse Tab command:
        bVk = Keys.ShiftKey
            keybd_event(bVk, 0, 0, 0)
            bVk = Keys.Tab
            keybd_event(bVk, 0, 0, 0)
            keybd_event(bVk, 0, KEYEVENTF_KEYUP, 0)
            bVk = Keys.ShiftKey
            keybd_event(bVk, 0, KEYEVENTF_KEYUP, 0)


            ' Start filtering for mouse clicks outside the popup
            filter.Popup = popup

        End Sub

        ''' <summary>
        ''' Subclasses the owning form's existing Window Procedure to enables the 
        ''' title bar to remain active when a popup is show, and to detect if
        ''' the user clicks onto another application whilst the popup is visible.
        ''' </summary>
        ''' <param name="m">Window Procedure Message</param>
        Protected Overrides Sub WndProc(ByRef m As Message)

            MyBase.WndProc(m)

            If (Me.popupShowing) Then

                ' check for WM_ACTIVATE and WM_NCACTIVATE
                If (m.Msg = WM_NCACTIVATE) Then
                    ' Check if the title bar will made inactive:
                    If (m.WParam.Equals(IntPtr.Zero)) Then
                        ' If so reactivate it.
                        SendMessage(Me.Handle, WM_NCACTIVATE, 1, IntPtr.Zero)

                        ' Note it's no good to try and consume this message;
                        ' if you try to do that you'll end up with windows
                        ' that don't respond.
                    End If

                ElseIf (m.Msg = WM_ACTIVATEAPP) Then

                    ' Check if the application is being deactivated.
                    If (m.WParam.Equals(IntPtr.Zero)) Then
                        ' It is so cancel the popup:
                        ClosePopup()
                        ' And put the title bar into the inactive state:
                        PostMessage(Me.Handle, WM_NCACTIVATE, 0, IntPtr.Zero)
                    End If
                End If
            End If
        End Sub

        ''' <summary>
        ''' Called when the popup is being hidden.
        ''' </summary>
        Public Sub ClosePopup()
            If (Me.popupShowing) Then
                If Not (skipClose) Then
                    ' Raise event to owner
                    OnPopupClosed(New PopupClosedEventArgs(m_popup))
                End If
                skipClose = False

                ' Make sure the popup is closed and we've cleaned
                ' up:
                m_owner.RemoveOwnedForm(m_popup)
                popupShowing = False
                m_popup.Close()
                ' No longer need to filter for clicks outside the
                ' popup.
                Application.RemoveMessageFilter(filter)

                ' If we did something from the popup which shifted
                ' focus to a new form, like showing another popup
                ' or dialog, then Windows won't know how to bring
                ' the original owner back to the foreground, so
                ' force it here:
                m_owner.Activate()

                ' Nothing out references for GC
                m_popup = Nothing
                m_owner = Nothing

            End If
        End Sub

        ''' <summary>
        ''' Raises the <see cref="PopupClosed"/> event.
        ''' </summary>
        ''' <param name="e"><see cref="PopupClosedEventArgs"/> describing the
        ''' popup form that is being closed.</param>
        Protected Sub OnPopupClosed(ByVal e As PopupClosedEventArgs)
            RaiseEvent PopupClosed(Me, e)
        End Sub

        ''' <summary>
        ''' Raises the <see cref="PopupCancel"/> event.
        ''' </summary>
        ''' <param name="e"><see cref="PopupCancelEventArgs"/> describing the
        ''' popup form that about to be cancelled.</param>
        Protected Sub OnPopupCancel(ByVal e As PopupCancelEventArgs)
            RaiseEvent PopupCancel(Me, e)
            If Not (e.Cancel) Then
                skipClose = True
            End If
        End Sub

        ''' <summary>
        ''' Default constructor.
        ''' </summary>
        ''' <remarks>Use the <see cref="System.Windows.Forms.NativeWindow.AssignHandle"/>
        ''' method to attach this class to the form you want to show popups from.</remarks>
        Public Sub New()
            filter = New GestorVentanaPopupMessageFilter(Me)
        End Sub


        Private Sub m_popup_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_popup.Closed
            ClosePopup()
        End Sub

        Private Sub filter_PopupCancel(ByVal sender As Object, ByVal e As Components.Controls.PopupCancelEventArgs) Handles Filter.PopupCancel
            OnPopupCancel(e)
        End Sub
    End Class
#End Region

#Region "GestorVentanaPopupMessageFilter"
    ''' <summary>
    ''' A Message Loop filter which detect mouse events whilst the popup form is shown
    ''' and notifies the owning <see cref="GestorVentanaPopup"/> class when a mouse
    ''' click outside the popup occurs.
    ''' </summary>
    Public Class GestorVentanaPopupMessageFilter
        Implements IMessageFilter

        Private Const WM_LBUTTONDOWN As Integer = &H201
        Private Const WM_RBUTTONDOWN As Integer = &H204
        Private Const WM_MBUTTONDOWN As Integer = &H207
        Private Const WM_NCLBUTTONDOWN As Integer = &HA1
        Private Const WM_NCRBUTTONDOWN As Integer = &HA4
        Private Const WM_NCMBUTTONDOWN As Integer = &HA7

        ''' <summary>
        ''' Raised when the Popup Window is about to be cancelled.  The
        ''' <see cref="PopupCancelEventArgs.Cancel"/> property can be
        ''' set to <c>true</c> to prevent the form from being cancelled.
        ''' </summary>
        Public Event PopupCancel As PopupCancelEventHandler

        ''' <summary>
        ''' The popup form
        ''' </summary>
        Private m_popup As Form = Nothing
        ''' <summary>
        ''' The owning <see cref="GestorVentanaPopup"/> object.
        ''' </summary>
        Private owner As GestorVentanaPopup = Nothing

        ''' <summary>
        ''' Constructs a new instance of this class and sets the owning
        ''' object.
        ''' </summary>
        ''' <param name="owner">The <see cref="GestorVentanaPopup"/> object
        ''' which owns this class.</param>
        Public Sub New(ByVal owner As GestorVentanaPopup)
            Me.owner = owner
        End Sub

        ''' <summary>
        ''' Gets/sets the popup form which is being displayed.
        ''' </summary>
        Public Property Popup() As Form
            Get
                Return m_popup
            End Get
            Set(ByVal Value As Form)
                m_popup = Value
            End Set
        End Property

        ''' <summary>
        ''' Checks the message loop for mouse messages whilst the popup
        ''' window is displayed.  If one is detected the position is
        ''' checked to see if it is outside the form, and the owner
        ''' is notified if so.
        ''' </summary>
        ''' <param name="m">Windows Message about to be processed by the
        ''' message loop</param>
        ''' <returns><c>true</c> to filter the message, <c>false</c> otherwise.
        ''' This implementation always returns <c>false</c>.</returns>
        Public Function PreFilterMessage(ByRef m As Message) As Boolean _
                  Implements IMessageFilter.PreFilterMessage
            If Not (Me.Popup Is Nothing) Then
                Select Case m.Msg
                    Case WM_LBUTTONDOWN, WM_RBUTTONDOWN, WM_MBUTTONDOWN, _
                        WM_NCLBUTTONDOWN, WM_NCRBUTTONDOWN, WM_NCMBUTTONDOWN
                        OnMouseDown()
                End Select
            End If
            Return False
        End Function

        ''' <summary>
        ''' Checks the mouse location and calls the OnCancelPopup method
        ''' if the mouse is outside the popup form.		
        ''' </summary>
        Private Sub OnMouseDown()

            ' Get the cursor location
            Dim cursorPos As Point = Cursor.Position
            ' Check if it is within the popup form
            If Not (Popup.Bounds.Contains(cursorPos)) Then
                ' If not, then call to see if it should be closed
                OnCancelPopup(New PopupCancelEventArgs(Popup, cursorPos))
            End If

        End Sub

        ''' <summary>
        ''' Raises the <see cref="PopupCancel"/> event.
        ''' </summary>
        ''' <param name="e">The <see cref="PopupCancelEventArgs"/> associated 
        ''' with the cancel event.</param>
        Protected Sub OnCancelPopup(ByVal e As PopupCancelEventArgs)
            RaiseEvent PopupCancel(Me, e)
            If Not (e.Cancel) Then
                owner.ClosePopup()
                ' Clear reference for GC
                Popup = Nothing
            End If
        End Sub
    End Class
#End Region
End Namespace
