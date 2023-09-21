using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceEmpleado" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceEmpleado.svc or ServiceEmpleado.svc.cs at the Solution Explorer and start debugging.
    public class ServiceEmpleado : IServiceEmpleado
    {
        public SLWFC.Result Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            SLWFC.Result resultwcf = new SLWFC.Result();
            resultwcf.Correct = result.Correct;
            resultwcf.Object = result.Object;
            resultwcf.ErrorMessage = result.ErrorMessage;
            resultwcf.Ex = result.Ex;
            resultwcf.Objects = result.Objects;
            return resultwcf;
        } 
        public SLWFC.Result Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            SLWFC.Result resultwcf = new SLWFC.Result();
            resultwcf.Correct = result.Correct;
            resultwcf.Object = result.Object;
            resultwcf.ErrorMessage = result.ErrorMessage;
            resultwcf.Ex = result.Ex;
            resultwcf.Objects = result.Objects;
            return resultwcf;
        }
        public SLWFC.Result Delete(string NumeroEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(NumeroEmpleado);
            SLWFC.Result resultwcf = new SLWFC.Result();
            resultwcf.Correct = result.Correct;
            resultwcf.Object = result.Object;
            resultwcf.ErrorMessage = result.ErrorMessage;
            resultwcf.Ex = result.Ex;
            resultwcf.Objects = result.Objects;
            return resultwcf;
        }

    }
}
