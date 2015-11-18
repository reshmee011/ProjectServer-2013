/*
 * The QueueCreateProject sample uses the Project Server CSOM to do the following:
 *     1. Creates a ProjectCreationInformation object with the basic information for a new project.
 *     2. Gets the GUID for the basic Enterprise Project type by using the name of the EPT.
 *     3. Adds the EPT to the ProjectCreationInformation object.
 *     4. Adds the new project to the published Projects collection, and 
 *        waits for the Project Server Queue Service to update the collection.
 *     5. Lists the published projects.
 *     
 * For more information, see Getting started with the Project Server CSOM and .NET
 * in the Project 2013 SDK.
 * See also the Microsoft.ProjectServer.Client.ProjectContext.Projects property 
 * and the ProjectCreationInformation class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ProjectServer.Client;

namespace QueueCreateProject
{
    class Program
    {
        private const string pwaPath = "https://radev.support.cps.co.uk/PWA";    // Change the path to your Project Web App instance.
        private static string basicEpt = "Enterprise Project";  // Basic enterprise project type.
        private static string projName = "CSOM Project" + DateTime.Now.ToShortTimeString().Replace(":", "-");
        private static int timeoutSeconds = 10;                 // The maximum wait time for a queue job, in seconds.

        private static ProjectContext projContext;

        static void Main(string[] args)
        {
            if (!ParseCommandLine(args))
            {
                Usage();
                ExitApp();
            }

            projContext = new ProjectContext(pwaPath);

            //Console.WriteLine("Published projects, before creating the {0} project:\r\n", projName);
            //ListPublishedProjects();

            if (CreateTestProject())
                ListPublishedProjects();
            else
                Console.WriteLine("\nProject creation failed: {0}", projName);

            ExitApp();
        }

        // Create a project.
        private static bool CreateTestProject()
        {
            bool projCreated = false;

            try
            {
                Console.Write("\nCreating project: {0} ...", projName);
                ProjectCreationInformation newProj = new ProjectCreationInformation();

                newProj.Id = Guid.NewGuid();
                newProj.Name = projName;
                newProj.Description = "Test creating a project with CSOM";
                newProj.Start = DateTime.Today.Date;

                // Setting the EPT GUID is optional. If no EPT is specified, Project Server uses 
                // the default EPT. 
                //newProj.EnterpriseProjectTypeId = GetEptUid(basicEpt);

                PublishedProject newPublishedProj = projContext.Projects.Add(newProj);
                QueueJob qJob = projContext.Projects.Update();

                // Calling Load and ExecuteQuery for the queue job is optional. If qJob is 
                // not initialized when you call WaitForQueue, Project Server initializes it.
                //projContext.Load(qJob);
                //projContext.ExecuteQuery();

                JobState jobState = projContext.WaitForQueue(qJob, timeoutSeconds);

                //projContext.WaitForQueueAsync(qJob, timeoutSeconds, 
                projContext.WaitForQueue(qJob, timeoutSeconds);

                if (jobState == JobState.Success)
                {
                    projCreated = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThere is a problem in the queue. Timeout is {0} seconds.",
                        timeoutSeconds);
                    Console.WriteLine("\tQueue JobState: {0}", jobState.ToString());
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: SOAP exception: {0}", ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: {0}", ex.Message);
                Console.ResetColor();
            }
            return projCreated;
        }

        // Get the GUID of the specified enterprise project type.
        private static Guid GetEptUid(string eptName)
        {
            Guid eptUid = Guid.Empty;

            try
            {
                // Get the list of EPTs that have the specified name. 
                // If the EPT name exists, the list will contain only one EPT.
                var eptList = projContext.LoadQuery(
                    projContext.EnterpriseProjectTypes.Where(
                        ept => ept.Name == eptName));
                projContext.ExecuteQuery();

                eptUid = eptList.First().Id;

                // Alternate routines to find the EPT GUID. Both (a) and (b) download the entire list of EPTs.
                // (a) Using a foreach block:
                //foreach (EnterpriseProjectType ept in projSvr.EnterpriseProjectTypes)
                //{
                //    if (ept.Name == eptName)
                //    {
                //        eptUid = ept.Id;
                //        break;
                //    }
                //}
                // (b) Querying for the EPT list, and then using a lambda expression to select the EPT:
                //var eptList = projContext.LoadQuery(projContext.EnterpriseProjectTypes);
                //projContext.ExecuteQuery();
                //eptUid = eptList.First(ept => ept.Name == eptName).Id;
            }
            catch (Exception ex)
            {
                string msg = string.Format("GetEptUid: eptName = \"{0}\"\n\n{1}",
                    eptName, ex.GetBaseException().ToString());
                throw new ArgumentException(msg);
            }
            return eptUid;
        }

        // List the published projects.
        private static void ListPublishedProjects()
        {
            // Get the list of projects on the server.
            projContext.Load(projContext.Projects);
            projContext.ExecuteQuery();

            Console.WriteLine("\nProject ID : Project name : Created date");

            foreach (PublishedProject pubProj in projContext.Projects)
            {
                Console.WriteLine("\n\t{0} :\n\t{1} : {2}", pubProj.Id.ToString(), pubProj.Name,
                    pubProj.CreatedDate.ToString());
            }
        }

        // Parse the command line. Return true if there are no errors.
        private static bool ParseCommandLine(string[] args)
        {
            bool error = false;
            int argsLen = args.Length;

            try
            {
                for (int i = 0; i < argsLen; i++)
                {
                    if (error) break;
                    if (args[i].StartsWith("-") || args[i].StartsWith("/"))
                        args[i] = "*" + args[i].Substring(1).ToLower();

                    switch (args[i])
                    {
                        case "*projname":
                        case "*n":
                            if (++i >= argsLen) return false;
                            projName = args[i];
                            break;
                        case "*timeout":
                        case "*t":
                            if (++i >= argsLen) return false;
                            timeoutSeconds = Convert.ToInt32(args[i]);
                            break;
                        case "*?":
                        default:
                            error = true;
                            break;
                    }
                }
            }
            catch (FormatException)
            {
                error = true;
            }

            if (string.IsNullOrEmpty(projName)) error = true;
            return !error;
        }

        private static void Usage()
        {
            string example = "Usage: QueueCreateProject -projName | -n \"New project name\" [-timeout | -t sec]";
            example += "\nExample: QueueCreateProject -n \"My new project\"";
            example += "\nDefault timeout seconds = " + timeoutSeconds.ToString();
            Console.WriteLine(example);
        }

        private static void ExitApp()
        {
            Console.Write("\nPress any key to exit... ");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }
}
