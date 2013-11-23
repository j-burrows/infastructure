using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfastructureLib;
using InfastructureLib.Data.Entities;
using InfastructureLib.Data.Repositories;

namespace InfastructureLibDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository.Configuration.connString = "Server=localhost;Database=ApplicationData;Trusted_Connection=True;";
            IInfastructureService service = new InfastructureService();
            DPage Home = new DPage{
                Url = "http://www.jonathan-burrows.com",
                Name = "Home",
                Title = "Main page of JonathanBurrows.com"
            };
            DPage Applications = new DPage { 
                Url = "http://www.jonathan-burrows.com/projects",
                Name = "Projects",
                Title = "Newest projects/documentation",
                Parent_Page_ID = 6
            };
            DPage Mailit = new DPage { 
                Url = "http://www.jonathan-burrows.com/mailit",
                Name = "Mailit",
                Title = "Email Application",
                Parent_Page_ID = 7
            };
            DPage MailitApplication = new DPage { 
                Url = "http://www.jonathan-burrows.com/mailit-application",
                Name = "Application",
                Title = "Use the application",
                Parent_Page_ID = 9                
            };
            DPage MailitHome = new DPage{
                Url = "~/",
                Name = "Mailit Home",
                Title = "Portal page of Mailit",
                Parent_Page_ID = 21
            };
            DPage Create = new DPage{
                Url = "~/create",
                Name = "Create",
                Title = "Create a new message",
                Parent_Page_ID = 21
            };
            DPage Inbox = new DPage{
                Url = "~/inbox",
                Name = "Inbox",
                Title = "View all received messages",
                Parent_Page_ID = 21
            };
            DPage Sent = new DPage{
                Url = "~/sent",
                Name = "Sent",
                Title = "View all sent messages",
                Parent_Page_ID = 21
            };
            DPage Friends = new DPage{
                Url = "~/friends",
                Name = "Friends",
                Title = "Manage friends/blocked users.",
                Parent_Page_ID = 21
            };

            service.Page_Create(MailitApplication);
            
            //service.Page_Create(MailitHome);
            //service.Page_Create(Create);
            //service.Page_Create(Inbox);
            //service.Page_Create(Sent);
            //service.Page_Create(Friends);
            
            //DPage page = service.Page_FromUrl("Url2");
            //IEnumerable<IEnumerable<DPage>> pages = service.PageStructure_GetBySelected(page.Url);
            //Console.WriteLine(pages.Count());
        }
    }
}
