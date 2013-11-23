using Repository.Business;
using Repository.Business.Protocols;
namespace InfastructureLib.Business{
    public class BPage : InfastructureLib.Presentation.PPage, IBusinessUnit{
        public readonly ProtocolStack Name_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = false, maxLength = 16 }, "Name");
        public readonly ProtocolStack Title_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = true, maxLength = 32 }, "Title");
        public readonly ProtocolStack Url_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = false, maxLength = 1024 }, "Url");
        public readonly ProtocolStack Icon_Url_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = true, maxLength = 1024 }, "Icon_Url");


        public bool CreateValid(){
            bool isValid = true;
            isValid = Name_Rules.Create.passes(Name) && isValid;
            isValid = Title_Rules.Create.passes(Title) && isValid;
            isValid = Url_Rules.Create.passes(Url) && isValid;
            isValid = Icon_Url_Rules.Create.passes(Icon_Url) && isValid;
            return isValid;
        }

        public bool UpdateValid() {
            bool isValid = true;
            isValid = Name_Rules.Update.passes(Name) && isValid;
            isValid = Title_Rules.Update.passes(Title) && isValid;
            isValid = Url_Rules.Update.passes(Url) && isValid;
            isValid = Icon_Url_Rules.Update.passes(Icon_Url) && isValid;
            return isValid;
        }

        public bool DeleteValid() {
            return true;
        }

        public virtual bool Equivilant(IBusinessUnit comparing) {
            return false;
        }
    }
}
