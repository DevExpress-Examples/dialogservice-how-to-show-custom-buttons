Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Text

Namespace dxDialog1.ViewModels
    Public Class MainViewModel
        Inherits ViewModelBase

        Protected ReadOnly Property DialogService() As IDialogService
            Get
                Return Me.GetService(Of IDialogService)()
            End Get
        End Property

        Private dialogViewModel As DialogViewModel = Nothing

        Public Sub New()
            ShowDialogCommand = New DelegateCommand(AddressOf ShowDialog)
            Result = "Please use the 'Choose Options' button to open a dialog window and choose options."
        End Sub

        Private privateShowDialogCommand As DelegateCommand
        Public Property ShowDialogCommand() As DelegateCommand
            Get
                Return privateShowDialogCommand
            End Get
            Private Set(ByVal value As DelegateCommand)
                privateShowDialogCommand = value
            End Set
        End Property

        Public Async Sub ShowDialog()

            If dialogViewModel Is Nothing Then
                dialogViewModel = New DialogViewModel()
            End If
            Dim viewModel As New DialogViewModel(dialogViewModel)

            Dim restoreDefaultsCommand As New UICommand() With {.Id = "cmdRestoreDefaults", .Caption = "Restore Defaults", .IsCancel = False, .IsDefault = False, .Command = New DelegateCommand(Of CancelEventArgs)(Function(x)
                x.Cancel = True
                viewModel.RestoreDefaults()
            End Function)}


            Dim saveCommand As New UICommand() With { _
                .Id = "cmdSave", _
                .Caption = "Save", _
                .IsCancel = False, _
                .IsDefault = True _
            }

            Dim cancelCommand As New UICommand() With { _
                .Id = "cmdCancel", _
                .Caption = "Cancel", _
                .IsCancel = True, _
                .IsDefault = False _
            }


            Dim result_Renamed = Await DialogService.ShowDialogAsync(New List(Of UICommand)() From {restoreDefaultsCommand, saveCommand, cancelCommand}, "Check options that you want to enable", viewModel)

            Dim builder As New StringBuilder()

            If result_Renamed IsNot cancelCommand Then
                builder = New StringBuilder("The Dialog was not canceled. The state of the options is the following:" & vbLf)
                dialogViewModel = viewModel
            Else
                builder = New StringBuilder("The Dialog was canceled. The state of the options is the following:" & vbLf)
            End If

            fillOptions(builder, dialogViewModel)
            Result = builder.ToString()
        End Sub

        Private Sub fillOptions(ByVal builder As StringBuilder, ByVal viewModel As DialogViewModel)
            builder.Append(String.Format("{0} = {1}" & vbLf, NameOf(viewModel.Option1), viewModel.Option1))
            builder.Append(String.Format("{0} = {1}" & vbLf, NameOf(viewModel.Option2), viewModel.Option2))
            builder.Append(String.Format("{0} = {1}" & vbLf, NameOf(viewModel.Option3), viewModel.Option3))
        End Sub

        Protected _Result As String
        Public Property Result() As String
            Get
                Return Me._Result
            End Get
            Set(ByVal value As String)
                Me.SetProperty(Me._Result, value, "Result")
            End Set
        End Property
    End Class
End Namespace
