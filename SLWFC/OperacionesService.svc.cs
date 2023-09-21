using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OperacionesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OperacionesService.svc or OperacionesService.svc.cs at the Solution Explorer and start debugging.
    public class OperacionesService : IOperacionesService
    {
        public void DoWork()
        {
        }
        public int Suma(int a,int b)
        {
            return a+b;
        }
        public int Resta(int c,int d) { return c-d; }
        public int Multiplicar(int e, int f) { return e*f; }
        public double Divide(double g, double h) { return g/h; }
    }
}
