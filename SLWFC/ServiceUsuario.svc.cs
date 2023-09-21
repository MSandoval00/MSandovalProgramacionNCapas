using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceUsuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceUsuario.svc or ServiceUsuario.svc.cs at the Solution Explorer and start debugging.
    public class ServiceUsuario : IServiceUsuario
    {
        public SLWFC.Result Add(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);
            SLWFC.Result resultwcf =new SLWFC.Result();
            resultwcf.Correct = result.Correct;
            resultwcf.Object = result.Object;
            resultwcf.ErrorMessage = result.ErrorMessage;
            resultwcf.Ex=result.Ex;
            resultwcf.Objects=result.Objects;

            return resultwcf;
        }
    }
}
