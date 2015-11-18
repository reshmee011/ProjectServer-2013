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
        

        static void Main(string[] args)
        {
            projContext = new ProjectContext(pwaPath); 
                //context = new ClientContext(pwaPath);
                //projSvr = new ProjectServer(context);
           // string userName = "reshmeeauckloo";
            //GUID for reshmee auckloo
            Guid resUID = new Guid("02C5EE34-5CE8-E411-80C1-00155D640C06");
            string customFieldName = "Staff Number";
        
            // Get the list of resources from Project Web App.
            projContext.Load(projContext.EnterpriseResources);
            projContext.Load(projContext.CustomFields);

            projContext.ExecuteQuery();
             
            Console.WriteLine("\nResource ID : Resource name ");

            int numResInCollection = projContext.EnterpriseResources.Count();
              var usrs = projContext.Web.SiteUsers;

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

    }
}
