using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository;
using Sitecore.Analytics.Tracking;
using Sitecore.Data;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Repository
{
    public class GoalRepository : IGoalRepository
    {
        public void RegisterOutcome(ID definitionId, List<ID> list)
        {
            throw new NotImplementedException();
        }

        public void RegisterGoal(ID goalId, string description, Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
