using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperacionesService" in both code and config file together.
    [ServiceContract]
    public interface IOperacionesService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        int Suma(int a, int b);
        [OperationContract]
        int Resta(int c, int d);
        [OperationContract]
        int Multiplicar(int e, int f);
        [OperationContract]
        double Divide(double g, double h);
    }
}
