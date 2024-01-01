using CRUD.Dal;
using CRUD.Dto;
using CRUD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repository.Biz
{
    public class TasksBiz : ITasksBiz
    {
        private readonly CRUDDalBase _db;
        public TasksBiz(CRUDDalBase db)
        {
            _db = db;
        }
        public async Task<Tasks> AddTasks(Tasks task)
        {
            task.TaskCreTime = DateTime.Now;
            task.TaskIsActive = 1;
            await _db.Tasks.AddAsync(task);
            await _db.SaveChangesAsync();
            return task;
        }
        public async Task<Tasks> UpdateTasks(Tasks task)
        {
            task.TaskCreTime = DateTime.Now;
            task.TaskIsActive = 1;
            _db.Entry(task).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task<Tasks> DeleteTasks(Tasks task)
        {
            task.TaskIsActive = 0;
            task.TaskCreTime = DateTime.Now;
            _db.Entry(task).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            //_db.Tasks.Remove(task);
            //await _db.SaveChangesAsync();
            return task;
        }

        public List<Tasks> GetTask(int userId)
        {
            var list = _db.Tasks.Where(x=> x.TaskUserId == userId && x.TaskIsActive == 1).ToList();
            return list;
        }
        public List<Tasks> GetTasks(int userId, int taskId)
        {
            var list = _db.Tasks.Where(x => x.TaskId == taskId && x.TaskUserId == userId).ToList();
            return list;
        }

        public List<Tasks> GetTasksHistory(int userId)
        {
            var list = _db.Tasks.Where(x => x.TaskIsActive == 0 && x.TaskUserId == userId).ToList();
            return list;
        }
    }
}
