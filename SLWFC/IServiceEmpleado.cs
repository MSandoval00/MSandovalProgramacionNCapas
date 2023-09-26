using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceEmpleado" in both code and config file together.
    [ServiceContract]
    public interface IServiceEmpleado
    {
        [OperationContract]
        SLWFC.Result Add(ML.Empleado empleado);
        [OperationContract]
        SLWFC.Result Update(ML.Empleado empleado);
        [OperationContract]
        SLWFC.Result Delete(string NumeroEmpleado);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))]
        SLWFC.Result GetAll();
        [OperationContract]
        [ServiceKnownType(typeof(ML.Empresa))]
        SLWFC.Result EmpresaGetAll();
        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))]
        SLWFC.Result GetById(string NumeroEmpleado);

    }
}
