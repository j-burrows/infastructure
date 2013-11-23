using Repository.Presentation;
using Repository.Helpers;

namespace InfastructureLib.Presentation{
    public class PPage : InfastructureLib.Base.Page, IPresentationUnit{
        public void Format() {
            Name = Name.Format();
            Title = Title.Format();
            Url = Url.Format();
            Icon_Url = Icon_Url.Format();
        }
    }
}
