using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.Data.Items;
using Sitecore.Analytics.Exceptions;
using Sitecore.Analytics.Tracking;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Exceptions;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Repository
{
    public class GoalRepository : IGoalRepository
    {
        public void RegisterOutcome(ID definitionId, List<ID> list)
        {
            throw new NotImplementedException();
        }

        public void RegisterGoal(ID goalId, string description)
        {
            if (!Tracker.IsActive)
                Tracker.StartTracking();

            if (!Tracker.IsActive)
            {
                throw new TrackerNotActiveException();
            }

            Item eventItem = Sitecore.Context.Database.GetItem(goalId);
            if (eventItem == null)
            {
                throw new ItemNotFoundException(goalId.ToString());
            }
            if (eventItem.TemplateID != Core.SitecoreConfig.ItemIds.Templates.GoalId)
            {
                throw new Exception("Item is not a goal " + eventItem.ID);
            }

            var goal = new PageEventItem(eventItem);

            Sitecore.Analytics.Model.PageEventData eventData = Tracker.Current.Interaction.PreviousPage.Register(goal);
            eventData.Data = goal["Description"] + " " + description;
        }
    }
}
