/* 
 * Note: The QueueUtilities class is not used in the QueueCreateProject sample, 
 * because the ProjectContext.WaitForQueue method handles the queue job. 
 * This file is provided if you want to manage the queue job with more granularity.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Client;
using Microsoft.ProjectServer.Client;

namespace QueueCreateProject
{
    class QueueUtilities
    {
        const int WAIT_TIME = 1000; // Wait one second.
        private static ClientContext context;

        // Array of queue job states that are completed processing.
        private readonly JobState[] completeJobStates = new JobState[] { 
            JobState.Canceled, JobState.CorrelationBlocked, JobState.Failed, 
            JobState.FailedNotBlocking, JobState.Success };

        public QueueUtilities(ClientContext ctx)
        {
            context = ctx;
        }

        // Wait for all queue jobs to complete, for the specified project.
        internal bool WaitForQueueByProject(Project proj, int timeoutSeconds)
        {
            int waitSeconds = 0;
            proj.RefreshLoad();

            var jobs = context.LoadQuery(proj.QueueJobs);
            context.ExecuteQuery();

            if (jobs.Count() == 0)
                return true;

            while (true)
            {
                Console.Write(".");
                bool done = !jobs.Any(q => !this.completeJobStates.Any(cs => cs == q.JobState));

                foreach (var job in jobs)
                {
                    job.RefreshLoad();
                }

                context.ExecuteQuery();

                if (done)
                    return true;

                // There are still incomplete jobs; return if we timed out.
                if (waitSeconds >= timeoutSeconds)
                    return false;

                System.Threading.Thread.CurrentThread.Join(WAIT_TIME);
                ++waitSeconds;
            }
        }

        internal JobState WaitForQueue(QueueJob job, int timeoutSeconds)
        {
            int seconds = timeoutSeconds;

            while (seconds > 0 && !this.completeJobStates.Any(state => job.JobState == state))
            {
                System.Threading.Thread.CurrentThread.Join(1000);
                seconds--;
                RefreshQueueJob(job);
            }
            return job.JobState;
        }

        private void RefreshQueueJob(QueueJob job)
        {
            job.RefreshLoad();
            context.ExecuteQuery();
        }
    }
}