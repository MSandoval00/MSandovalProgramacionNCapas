using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceUsuario" in both code and config file together.
    [ServiceContract]
    public interface IServiceUsuario
    {
        [OperationContract]
        SLWFC.Result Add(ML.Usuario usuario);
        [OperationContract]
        SLWFC.Result Delete(int IdUsuario);
        [OperationContract]
        SLWFC.Result Update(ML.Usuario usuario);
       [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SLWFC.Result GetAll(ML.Usuario usuario);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SLWFC.Result GetById(int IdUsuario);
    }
}
