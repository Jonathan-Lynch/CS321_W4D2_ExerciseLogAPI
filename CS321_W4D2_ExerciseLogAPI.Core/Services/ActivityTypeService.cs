using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
	public class ActivityTypeService : IActivityTypeService
	{
		private IActivityTypeRepository _activityTypeRepo;

		public ActivityTypeService(IActivityTypeRepository activityTypeRepo)
		{
			_activityTypeRepo = activityTypeRepo;
		}

		public ActivityType add(ActivityType activityType)
		{
			_activityTypeRepo.Add(activityType);
			return activityType;
		}

		public ActivityType Get(int id)
		{
			return _activityTypeRepo.Get(id);
		}

		public IEnumerable<ActivityType> GetAll()
		{
			return _activityTypeRepo.GetAll();
		}

		public ActivityType Update(ActivityType updateActivityType)
		{
			var activityType = _activityTypeRepo.Update(updateActivityType);
			return activityType;
		}

		public void remove(ActivityType activityType)
		{
			_activityTypeRepo.Remove(activityType);
		}
	}
}
