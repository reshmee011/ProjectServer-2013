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
        private const string pwaPath = "https://radev.support.cps.co.uk/PWA/";    // Change the path for Project Web App.
        
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
           // string userName = "reshmeeauckloo";
            //GUID for reshmee auckloo
            Guid resUID = new Guid("02C5EE34-5CE8-E411-80C1-00155D640C06");
            string customFieldName = "Staff Number";
            string customFieldValue = "000000";
            // Get the list of published projects in Project Web App.
            projContext.Load(projContext.EnterpriseResources);
            projContext.Load(projContext.CustomFields);

            projContext.ExecuteQuery();
                //context.Load(projSvr.Projects);
                //context.ExecuteQuery();

            Console.WriteLine("\nResource ID : Resource name ");

                //foreach (PublishedProject pubProj in projSvr.Projects)
            foreach (EnterpriseResource res in projContext.EnterpriseResources)
            {
                Console.WriteLine("\n\t{0}\n\t{1}", res.Id.ToString(), res.Name);
            }


            int numResInCollection = projContext.EnterpriseResources.Count();
              var usrs = projContext.Web.SiteUsers;
             // var usr = string.IsNullOrEmpty(userName) ? projContext.Web.CurrentUser : usrs.GetByLoginName());

            if (numResInCollection > 0)
            {
                projContext.Load(projContext.EnterpriseResources.GetByGuid(resUID));
                projContext.Load(projContext.EntityTypes.ResourceEntity);
                projContext.ExecuteQuery();

                var entRes2Edit = projContext.EnterpriseResources.GetByGuid(resUID);

                var userCustomFields = entRes2Edit.CustomFields;

                Guid ResourceEntityUID = projContext.EntityTypes.ResourceEntity.ID;

               var customfield = projContext.CustomFields.Where(x => x.Name == customFieldName);

               entRes2Edit[customfield.First().InternalName] = "3456";

                Console.WriteLine("\nEditing resource : GUID : Can Level");
                Console.WriteLine("\n{0} : {1} : {2}", entRes2Edit.Name, entRes2Edit.Id.ToString(),
                    entRes2Edit.CanLevel.ToString());

                // Toggle the CanLevel property.
                entRes2Edit.CanLevel = !entRes2Edit.CanLevel;

                // The entRes2Edit object is in the EnterpriseResources collection.
                projContext.EnterpriseResources.Update();

                // Save the change.
                projContext.ExecuteQuery();

                // Check that the change was made.
                projContext.Load(projContext.EnterpriseResources.GetByGuid(resUID));
                projContext.ExecuteQuery();

                entRes2Edit = projContext.EnterpriseResources.GetByGuid(resUID);

                Console.WriteLine("\n\nChanged resource : GUID : Can Level");
                Console.WriteLine("\n{0} : {1} : {2}", entRes2Edit.Name, entRes2Edit.Id.ToString(),
                    entRes2Edit.CanLevel.ToString());
            }

            Console.Write("\nPress any key to exit: ");
            Console.ReadKey(false);

           
        }

        private static string GetFullUserName(string userName)
        {
            return string.Format("i:0#.f|membership|{0}\\{1}", userName,"cps");
        }

    }
}
