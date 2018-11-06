Imports DevExpress.Mvvm

Namespace dxDialog1.ViewModels
    Public Class DialogViewModel
        Inherits ViewModelBase

        Public Sub New()
        End Sub
        Public Sub New(ByVal viewModel As DialogViewModel)
            Option1 = viewModel.Option1
            Option2 = viewModel.Option2
            Option3 = viewModel.Option3
        End Sub

        Protected _Option1 As Boolean
        Public Property Option1() As Boolean
            Get
                Return Me._Option1
            End Get
            Set(ByVal value As Boolean)
                Me.SetProperty(Me._Option1, value, "Option1")
            End Set
        End Property


        Protected _Option2 As Boolean
        Public Property Option2() As Boolean
            Get
                Return Me._Option2
            End Get
            Set(ByVal value As Boolean)
                Me.SetProperty(Me._Option2, value, "Option2")
            End Set
        End Property


        Protected _Option3 As Boolean
        Public Property Option3() As Boolean
            Get
                Return Me._Option3
            End Get
            Set(ByVal value As Boolean)
                Me.SetProperty(Me._Option3, value, "Option3")
            End Set
        End Property
        Public Sub RestoreDefaults()
            Me.Option1 = True
            Me.Option2 = False
            Me.Option3 = True

        End Sub
    End Class
End Namespace
