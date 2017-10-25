' NOTE: You can use the "Rename" command on the context menu to change the class name "MesaControl" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select MesaControl.svc or MesaControl.svc.vb at the Solution Explorer and start debugging.
Public Class MesaControl
    Implements IMesaControl
    Public db As New MCtrlEntities
    Public Sub DoWork() Implements IMesaControl.DoWork
    End Sub

End Class
