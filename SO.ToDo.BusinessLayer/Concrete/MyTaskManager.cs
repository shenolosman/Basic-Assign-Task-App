﻿using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class MyTaskManager : IMyTaskService
    {
        private readonly IMyTaskDAL _myTaskDal;

        public MyTaskManager(IMyTaskDAL myTaskDal)
        {
            _myTaskDal = myTaskDal;
        }
        public void Add(MyTask table)
        {
            _myTaskDal.Save(table);
        }

        public void Remove(MyTask table)
        {
            _myTaskDal.Delete(table);
        }

        public void Update(MyTask table)
        {
            _myTaskDal.Update(table);
        }

        public MyTask GetById(int id)
        {
            return _myTaskDal.GetById(id);
        }

        public List<MyTask> GetAll()
        {
            return _myTaskDal.GetAll();
        }
    }
}