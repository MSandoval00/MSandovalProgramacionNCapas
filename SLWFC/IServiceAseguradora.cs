using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceAseguradora" in both code and config file together.
    [ServiceContract]
    public interface IServiceAseguradora
    {
        [OperationContract]
        SLWFC.Result Add(ML.Aseguradora aseguradora);
        [OperationContract]
        SLWFC.Result Update(ML.Aseguradora aseguradora);
        [OperationContract]
        SLWFC.Result Delete(int IdAseguradora);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SLWFC.Result GetAll();
        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SLWFC.Result UsuarioGetAll(ML.Usuario usuario);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SLWFC.Result GetById(int IdAseguradora);
    }
}
