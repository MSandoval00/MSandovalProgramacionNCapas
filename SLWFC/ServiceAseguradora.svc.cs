using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceAseguradora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceAseguradora.svc or ServiceAseguradora.svc.cs at the Solution Explorer and start debugging.
    public class ServiceAseguradora : IServiceAseguradora
    {
        public SLWFC.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Add(aseguradora);
            //SLWFC.Result resultwcf = new SLWFC.Result();
            //resultwcf.Correct = result.Correct;
            //resultwcf.ErrorMessage = result.ErrorMessage;
            //resultwcf.Ex=result.Ex;
            //resultwcf.Object=result.Object;
            //resultwcf.Objects = result.Objects;

            //return resultwcf;

            //Forma 2
            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };


        }
        public SLWFC.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Update(aseguradora);
            //SLWFC.Result resultwcf= new SLWFC.Result();
            //resultwcf.Correct=result.Correct;
            //resultwcf.ErrorMessage=result.ErrorMessage;
            //resultwcf.Ex= result.Ex;
            //resultwcf.Objects= result.Objects;
            //resultwcf.Object = result.Object;

            //return resultwcf;
            //Forma 2
            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWFC.Result Delete(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.Delete(IdAseguradora);
            //SLWFC.Result resultwcf = new SLWFC.Result();
            //resultwcf.Correct = result.Correct;
            //resultwcf.ErrorMessage=result.ErrorMessage;
            //resultwcf.Ex=result.Ex;
            //resultwcf.Objects= result.Objects;
            //resultwcf.Object = result.Object;

            //return resultwcf ;
            //Forma 2
            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };

        }
        public SLWFC.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();
            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWFC.Result GetById(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetById(IdAseguradora);
            return new SLWFC.Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
