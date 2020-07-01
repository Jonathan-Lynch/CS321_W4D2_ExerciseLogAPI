using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
	public class ActivityRepository : IActivityRepository
	{
        private readonly AppDbContext _appDbContext;

        public ActivityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Activity Add(Activity activity)
        {
            _appDbContext.Activities.Add(activity);

            _appDbContext.SaveChanges();

            return activity;
        }

        public Activity Get(int id)
        {
            return _appDbContext.Activities.Include(a => a.User).Include(a => a.ActivityType).SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _appDbContext.Activities.Include(a => a.User).Include(a => a.ActivityType).ToList();
        }

        public void Remove(Activity activity)
        {
            _appDbContext.Activities.Remove(activity);
            _appDbContext.SaveChanges();
        }

        public Activity Update(Activity updatedActivity)
        {
            var currentActivity = _appDbContext.Activities.Find(updatedActivity.Id);
            if (currentActivity == null) return null;
            _appDbContext.Entry(currentActivity).CurrentValues.SetValues(updatedActivity);
            _appDbContext.Activities.Update(currentActivity);
            _appDbContext.SaveChanges();
            return updatedActivity;
        }
    }
}
