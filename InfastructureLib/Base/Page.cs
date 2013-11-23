namespace InfastructureLib.Base{
    public class Page{
        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual string Url { get; set; }
        public virtual string Icon_Url { get; set; }
        public virtual int Page_ID{get;set;}
        public virtual int Parent_Page_ID { get; set; }
        public virtual bool inFocus { get; set; }
    }
}
