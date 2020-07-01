﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class ActivityMappingExtenstions
    {

        public static ActivityModel ToApiModel(this Core.Models.Activity activity)
        {
            return new ActivityModel
            {
                Id = activity.Id,
                Date = activity.Date,
                ActivityTypeId = activity.ActivityTypeId,
                ActivityType = activity.ActivityType.Name,
                Duration = activity.Duration,
                Distance = activity.Distance,
                UserId = activity.UserId,
                User = activity.User.Name,
                Notes = activity.Notes
            };
        }

        public static Core.Models.Activity ToDomainModel(this ActivityModel activityModel)
        {
            return new Core.Models.Activity
			{
                Id = activityModel.Id,
                Date = activityModel.Date,
                ActivityTypeId = activityModel.ActivityTypeId,
                Duration = activityModel.Duration,
                Distance = activityModel.Distance,
                UserId = activityModel.UserId,
                Notes = activityModel.Notes
            };
        }

        public static IEnumerable<ActivityModel> ToApiModels(this IEnumerable<Core.Models.Activity> activities)
        {
            return activities.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Core.Models.Activity> ToDomainModels(this IEnumerable<ActivityModel> activityModels)
        {
            return activityModels.Select(a => a.ToDomainModel());
        }
    }
}
