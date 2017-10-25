Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IMesaControl" in both code and config file together.
<ServiceContract()>
Public Interface IMesaControl

    <OperationContract()>
    Sub DoWork()

End Interface
