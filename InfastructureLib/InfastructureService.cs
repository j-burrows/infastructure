using System.Collections.Generic;
using InfastructureLib.Data.Entities;
using InfastructureLib.Factory;
using System.Linq;
using System.Collections.Generic;
using InfastructureLib.Data.Repositories;
using Repository.Data;
namespace InfastructureLib{
    public class InfastructureService : IInfastructureService{
        public bool IDExists(int Page_ID) {
            return Page_FromID(Page_ID) != null;
        }

        public DPage Page_FromID(int Page_ID) {
            return SqlSPageRepository.ByID(Page_ID).FirstOrDefault();
        }

        public IEnumerable<IEnumerable<DPage>> PageStructure_GetBySelected(int Page_ID) {
            List<IEnumerable<DPage>> pageStructure = new List<IEnumerable<DPage>>();
            IEnumerable<DPage> children;
            DPage i;

            DPage starting = Page_FromID(Page_ID);
            if(starting == null){
                return pageStructure;
            }

            if ((children = SqlSPageRepository.Children(starting)).Count() > 0) {
                pageStructure.Insert(0, children);
            }

            IEnumerable<DPage> currentRow = SqlSPageRepository.Siblings(starting);
            currentRow.First(x => x.Page_ID == Page_ID).inFocus = true;
            pageStructure.Insert(0, currentRow);

            //Starting from back up, parent rows are added.
            i = new DPage{Page_ID = starting.Parent_Page_ID};
            int currentPageID;
            while(true){
                IEnumerable<DPage> nextRow = SqlSPageRepository.Siblings(i);
                currentPageID = i.Page_ID;

                if(i.Page_ID == 0 || (i = nextRow.FirstOrDefault()) == null){
                    break;                  //Top of tree has been reached, no more parents.
                }
                nextRow.First(x => x.Page_ID == currentPageID).inFocus = true;

                pageStructure.Insert(0, nextRow);

                i.Page_ID = i.Parent_Page_ID;
            }
            return pageStructure;
        }

        public DPage Page_Create(DPage creating){
            IDataRepository<DPage> pages = RepositoryFactory.Instance.Construct<DPage>();
            pages.Create(creating);
            return creating;
        }

        public DPage Page_Update(DPage updating){
            IDataRepository<DPage> pages = SqlSPageRepository.ByID(updating.Page_ID);
            pages.Update(updating);
            return updating;
        }

        public void Page_Delete(DPage deleting){
            IDataRepository<DPage> pages = SqlSPageRepository.ByID(deleting.Page_ID);
            pages.Delete(deleting);    
        }
    }
}
