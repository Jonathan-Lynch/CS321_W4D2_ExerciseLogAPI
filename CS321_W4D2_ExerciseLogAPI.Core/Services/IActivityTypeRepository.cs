using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
	public interface IActivityTypeRepository
	{
        ActivityType Add(ActivityType activityType);
        // Read
        ActivityType Get(int id);
        // Update
        ActivityType Update(ActivityType activityType);
        // Delete
        void Remove(ActivityType activityType);
        // List
        IEnumerable<ActivityType> GetAll();
    }
}
