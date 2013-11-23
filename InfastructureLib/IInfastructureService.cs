using System.Web.Services;
using System.ServiceModel;
using System.Collections.Generic;
using InfastructureLib.Data.Entities;
namespace InfastructureLib{
    [ServiceContract]
    public interface IInfastructureService{
        [OperationContract]
        bool IDExists(int Page_ID);

        [OperationContract]
        DPage Page_FromID(int Page_ID);

        [OperationContract]
        IEnumerable<IEnumerable<DPage>> PageStructure_GetBySelected(int Page_ID);

        [OperationContract]
        DPage Page_Create(DPage creating);

        [OperationContract]
        DPage Page_Update(DPage updating);

        [OperationContract]
        void Page_Delete(DPage deleting);
    }
}
