using CRUD.Dto;

namespace CRUD.Repository.Interfaces
{
    public interface ITasksBiz
    {
        Task<Tasks> AddTasks(Tasks task);
        Task<Tasks> UpdateTasks(Tasks task);
        Task<Tasks> DeleteTasks(Tasks task);
        List<Tasks> GetTask(int userId);
        List<Tasks> GetTasksHistory(int userId);
        List<Tasks> GetTasks(int userId, int taskId);

    }
}
