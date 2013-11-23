using System.Collections.Generic;
using System.Data.SqlClient;
using InfastructureLib.Data.Entities;
using Repository.Data;
using Repository.Helpers;
namespace InfastructureLib.Data.Repositories{
    internal class SqlSPageRepository : SqlSRepository<DPage>{
        public SqlSPageRepository() : base(){ }

        public static SqlSPageRepository ByID(int Page_ID) {
            //Collection is filled with the targeted page (if exists).
            SqlSPageRepository constructing = new SqlSPageRepository();
            string query = string.Format(@"
                EXEC Page_GetByID @Page_ID = '{0}';",
                Page_ID
            );
            constructing.FillRepository(query);
            return constructing;
        }

        public static SqlSPageRepository ByUrl(string url) {
            //Collection is filled with pages with matching url.
            SqlSPageRepository constructing = new SqlSPageRepository();
            string query = string.Format(@"
                EXEC Page_GetByUrl @Url='{0}';",
                url
            );
            constructing.FillRepository(query);
            return constructing;
        }

        public static SqlSPageRepository Children(DPage parent) {
            //Collection is filled with pages belonging to given parent.
            SqlSPageRepository constructing = new SqlSPageRepository();
            string query = string.Format(@"
                EXEC Page_GetChildren @Page_ID='{0}';",
                parent.Page_ID
            );
            constructing.FillRepository(query);
            return constructing;
        }

        public static SqlSPageRepository Siblings(DPage sibling) {
            //Collection if filled who are children of given page.
            SqlSPageRepository constructing = new SqlSPageRepository();
            string query = string.Format(
                @"EXEC Page_GetSiblings @Page_ID='{0}';",
                sibling.Page_ID
            );
            constructing.FillRepository(query);
            return constructing;
        }

        protected override void CreateEval(DPage creating) {
            //Entry is added in database via command.
            SqlCommand command = new SqlCommand("Page_Create");
            command.AddParams(
                new Param("Name", creating.Name),
                new Param("Title", creating.Title),
                new Param("Url", creating.Url),
                new Param("Icon_Url", creating.Icon_Url)
            );
            if(creating.Parent_Page_ID != 0){
                command.AddParam("Parent_Page_ID", creating.Parent_Page_ID);
            }
            creating.key = ExecStoredProcedure(command);

            base.CreateEval(creating);      //Entry is created in main memory collection.
        }

        protected override void UpdateEval(DPage updating) {
            //Entry is updated in database via command.
            SqlCommand command = new SqlCommand("Page_Update");
            command.AddParams( 
                new Param("Name", updating.Name),
                new Param("Title", updating.Title),
                new Param("Url", updating.Url),
                new Param("Icon_Url", updating.Icon_Url),
                new Param("Page_ID", updating.Page_ID)
            );
            ExecNonReader(command);

            base.UpdateEval(updating);      //Entry is updated in main memory collection.
        }

        protected override void DeleteEval(DPage deleting) {
            //Entry is deleted from database via command.
            SqlCommand command = new SqlCommand("Page_Delete");
            command.AddParam("Page_ID", deleting.Page_ID);
            ExecNonReader(command);

            base.DeleteEval(deleting);      //Entry is deleted from main memory collection.
        }
    }
}
