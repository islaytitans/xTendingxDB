using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Analytics.Tracking;
using Sitecore.Data;

namespace JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository
{
    public interface IGoalRepository
    {
        void RegisterOutcome(ID definitionId, List<ID> list);
        void RegisterGoal(ID goalId, string description);
    }
}
