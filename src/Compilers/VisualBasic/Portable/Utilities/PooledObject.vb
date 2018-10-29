Namespace Microsoft.CodeAnalysis.PooledObjects

    Public Class Pool(Of T As Class)
        Friend _pool As ObjectPool(Of T)
        Friend _clear As Action(Of T)

        Private Sub New(f As ObjectPool(Of T).Factory, size As Integer, clear As Action(Of T))
            _pool = New ObjectPool(Of T)(f, size)
            _clear = clear
        End Sub
        Public Shared Function Make(f As Func(Of T), Optional size As Integer = 32, Optional clear As Action(Of T) = Nothing) As Pool(Of T)
            Return New Pool(Of T)(New ObjectPool(Of T).Factory(Function() f()), size, clear)
        End Function

        Public Function GetInstance() As PooledObject(Of T)
            Return New PooledObject(Of T)(Me, _pool.Allocate)
        End Function

    End Class

    Public Class PooledObject(Of T As Class)
        Private _Pool As Pool(Of T)
        Private _Value As T

        Public ReadOnly Property Value As T
            Get
                Return _Value
            End Get
        End Property


        Friend Sub New(Pool As Pool(Of T), Value As T)
            _Pool = Pool
            _Value = Value
        End Sub

        Public Sub Free()
            _Pool?._clear(_Value)
            _Pool._pool.Free(_Value)
            _Value = Nothing
            _Pool = Nothing
        End Sub

    End Class

    Public Module Pools
        Private f0 As Func(Of HashSet(Of VisualBasic.Symbol)) = Function() New HashSet(Of VisualBasic.Symbol)()
        Friend ReadOnly Property SymbolPool As Pool(Of HashSet(Of VisualBasic.Symbol)) =
            Pool(Of HashSet(Of VisualBasic.Symbol)).Make(f0, 64, Sub(v) v.Clear())
        Private f1 As Func(Of HashSet(Of VisualBasic.BoundNode)) = Function() New HashSet(Of VisualBasic.BoundNode)(ReferenceEqualityComparer.Instance)

        Friend ReadOnly Property BoundNodePool As Pool(Of HashSet(Of VisualBasic.BoundNode)) =
            Pool(Of HashSet(Of VisualBasic.BoundNode)).Make(f1, 64, Sub(v) v.Clear())
    End Module

End Namespace
