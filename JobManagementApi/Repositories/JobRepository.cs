using JobManagementApi.Models;

namespace JobManagementApi.Repositories;

public class JobRepository : IJobRepository
{
    private readonly List<Job> _jobs;

    public JobRepository()
    {
        _jobs = new List<Job>
        {
            new Job
            {
                Id = "1",
                Title = "Software Development",
                Description = "Developing new features for the platform",
                SubItems = new List<SubItem>
                {
                    new SubItem { ItemId = "1", Title = "Design UI", Description = "Design the user interface", Status = "In Progress" },
                    new SubItem { ItemId = "2", Title = "Write Code", Description = "Develop backend services", Status = "Pending" }
                }
            },
            new Job
            {
                Id = "2",
                Title = "Database Migration",
                Description = "Migrating legacy data to the new system",
                SubItems = new List<SubItem>
                {
                    new SubItem { ItemId = "1", Title = "Data Cleanup", Description = "Clean up old records", Status = "Completed" },
                    new SubItem { ItemId = "2", Title = "Migration", Description = "Migrate the data to the new system", Status = "Pending" }
                }
            }
        };
    }

    public async Task<List<Job>> GetAllJobsAsync()
    {
        return await Task.FromResult(_jobs);
    }

    public async Task<Job> GetJobByIdAsync(string jobId)
    {
        return await Task.FromResult(_jobs.FirstOrDefault(j => j.Id == jobId));
    }

    public async Task AddJobAsync(Job job)
    {
        _jobs.Add(job);
        await Task.CompletedTask;
    }
}