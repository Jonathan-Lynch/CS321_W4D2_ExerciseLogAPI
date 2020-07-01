using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
	public class ActivityTypeRepository : IActivityTypeRepository
	{
        private readonly AppDbContext _appDbContext;

        public ActivityTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ActivityType Add(ActivityType activityType)
        {
            _appDbContext.ActivityTypes.Add(activityType);
            _appDbContext.SaveChanges();
            return activityType;

        }

        public ActivityType Get(int id)
        {
            return _appDbContext.ActivityTypes.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _appDbContext.ActivityTypes.ToList();
        }

        public void Remove(ActivityType activityType)
        {
            _appDbContext.ActivityTypes.Remove(activityType);
            _appDbContext.SaveChanges();
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            var currentActivityType = _appDbContext.ActivityTypes.Find(updatedActivityType.Id);
            if (currentActivityType == null) return null;
            _appDbContext.Entry(currentActivityType).CurrentValues.SetValues(updatedActivityType);
            _appDbContext.ActivityTypes.Update(currentActivityType);
            _appDbContext.SaveChanges();
            return currentActivityType;
        }
    }
}
