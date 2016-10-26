using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using JonathanRobbins.xTendingxDB.CMS.xDB.Entities;
using JonathanRobbins.xTendingxDB.CMS.xDB.Interfaces.Repository;
using JonathanRobbins.xTendingxDB.CMS.xDB.Repository;
using Sitecore.Analytics;
using Sitecore.Data;
using Sitecore.Diagnostics;

namespace JonathanRobbins.xTendingxDB.Controllers
{
    public class TrackingController : GlassController
    {
        private IGoalRepository _goalRepository;
        private IKeyInteractionsRepository _keyInteractionsRepository;

        public TrackingController(IGoalRepository goalRepository, IKeyInteractionsRepository keyInteractionsRepository)
        {
            _goalRepository = goalRepository;
            _keyInteractionsRepository = keyInteractionsRepository;
        }

        public string Test()
        {
            return "Give me a goal";
        }

        public string AbandonSession()
        {
            Session.Abandon();
            return "Abandoned";
        }

        public JsonResult RegisterOutcome(string outcomeDefinitionIdString, string contactIdString)
        {
            if (string.IsNullOrWhiteSpace(outcomeDefinitionIdString))
            {
                throw new ArgumentNullException(nameof(outcomeDefinitionIdString));
            }
            if (string.IsNullOrWhiteSpace(contactIdString))
            {
                throw new ArgumentNullException(nameof(contactIdString));
            }

            ID definitionId;
            if (!ID.TryParse(outcomeDefinitionIdString, out definitionId))
            {
                return Json(new Tuple<bool, string>(false, outcomeDefinitionIdString + " is not a valid Sitecore Id"));
            }

            ID contactId;
            if (!ID.TryParse(contactIdString, out contactId))
            {
                return
                    Json(new Tuple<bool, string>(false,
                        "Failed to register Outcome for the Contact, the ContactId is not a valid Id - " +
                        contactIdString));
            }

            if (!Tracker.IsActive)
                Tracker.StartTracking();

            try
            {
                _goalRepository.RegisterOutcome(definitionId, new List<ID>() {contactId});
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e, this);
                return Json(new Tuple<bool, string>(false, e.Message));
            }

            return Json(new Tuple<bool, string>(true, "Successfully registered outcome"));
        }

        public JsonResult RegisterGoal(string id, string description)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            ID goalId;
            if (!ID.TryParse(id, out goalId))
            {
                return Json(new Tuple<bool, string>(false, id + " is not a valid Sitecore Id"));
            }

            if (!Tracker.IsActive)
                Tracker.StartTracking();

            try
            {
                _goalRepository.RegisterGoal(goalId, description, Tracker.Current.Session.Contact);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e, this);
                return Json(new Tuple<bool, string>(false, e.Message));
            }

            return Json(new Tuple<bool, string>(true, "Successfully registered goal"));
        }

        public JsonResult RegisterBrochureDownload(BrochureDownload brochureDownload)
        {
            if (brochureDownload == null)
            {
                Response.StatusCode = 400;
                return Json(new ArgumentNullException());
            }

            if (!Tracker.IsActive)
                Tracker.StartTracking();

            try
            {
                _keyInteractionsRepository.Set(Tracker.Current.Session.Contact, brochureDownload);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e, this);
                return Json(new Tuple<bool, string>(false, e.Message));
            }

            return Json(new Tuple<bool, string>(true, "Successfully registered goal"));
        }

        public JsonResult RegisterGalleryViewed(ImageGalleryViewed imageGalleryViewed)
        {
            if (imageGalleryViewed == null)
            {
                Response.StatusCode = 400;
                return Json(new ArgumentNullException());
            }

            if (!Tracker.IsActive)
                Tracker.StartTracking();

            try
            {
                _keyInteractionsRepository.Set(Tracker.Current.Session.Contact, imageGalleryViewed);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e, this);
                return Json(new Tuple<bool, string>(false, e.Message));
            }

            return Json(new Tuple<bool, string>(true, "Successfully registered goal"));
        }
    }
}