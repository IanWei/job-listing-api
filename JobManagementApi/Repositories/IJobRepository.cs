using JobManagementApi.Models;

namespace JobManagementApi.Repositories;

public interface IJobRepository
{
    Task<List<Job>> GetAllJobsAsync();
    Task<Job> GetJobByIdAsync(string jobId);
    Task AddJobAsync(Job job);
}