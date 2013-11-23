using System.Data;
using Repository.Data;
using Repository.Helpers;
namespace InfastructureLib.Data.Entities{
    public class DPage : InfastructureLib.Business.BPage, IDataUnit{
        public int key {
            get { return Page_ID; }
            set { Page_ID = value; }
        }

        public string dataError { get; set; }

        public void InitFromRow(DataRow parsing) {
            Name = parsing["Name"].ToStr();
            Title = parsing["Title"].ToStr();
            Url = parsing["Url"].ToStr();
            Icon_Url = parsing["Icon_Url"].ToStr();
            Page_ID = parsing["Page_ID"].ToInt();
            Parent_Page_ID = parsing["Parent_Page_ID"].ToInt();
        }

        public override bool Equivilant(Repository.Business.IBusinessUnit comparing) {
            return this.MatchingKeyAndType<DPage>(comparing);
        }

        //All string members have malicious code removed from them.
        public void Scrub() {
            Name = Name.Scrub();
            Title = Title.Scrub();
            Url = Url.Scrub();
            Icon_Url = Icon_Url.Scrub();
        }
    }
}
