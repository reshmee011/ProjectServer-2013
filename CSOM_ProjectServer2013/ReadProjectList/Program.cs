using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.SharePoint.Client;
using Microsoft.ProjectServer.Client;

namespace ReadProjectList
{
    class Program
    {
        private const string pwaPath = "http://vm768/pwa";    // Change the path for Project Web App.
        
        // Set the Project Server client context.
        private static ProjectContext projContext;

        // For applications that access both the Project Server CSOM and the SharePoint CSOM, you could
        // use the ProjectServer object. Those statements are commented out in this application.
        // However, it is not necessary to instantiate a ProjectServer object, because the the 
        // ProjectContext object inherits from ClientContext in SharePoint.
            //private static ProjectServer projSvr;
            //private static ClientRuntimeContext context;

        static void Main(string[] args)
        {
            projContext = new ProjectContext(pwaPath); 
                //context = new ClientContext(pwaPath);
                //projSvr = new ProjectServer(context);

            // Get the list of published projects in Project Web App.
            projContext.Load(projContext.Projects);
            projContext.ExecuteQuery();
                //context.Load(projSvr.Projects);
                //context.ExecuteQuery();

            Console.WriteLine("\nProject ID : Project name : Created date");

                //foreach (PublishedProject pubProj in projSvr.Projects)
            foreach (PublishedProject pubProj in projContext.Projects)
            {
                Console.WriteLine("\n\t{0}\n\t{1} : {2}", pubProj.Id.ToString(), pubProj.Name, 
                    pubProj.CreatedDate.ToString());
            }

            Console.Write("\nPress any key to exit: ");
            Console.ReadKey(false);
        }
    }
}
