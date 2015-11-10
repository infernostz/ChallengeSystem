namespace CS.Client.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Mvc;

    using Newtonsoft.Json;
    
    using CS.Client.Infrastructure.Contracts;
    using CS.Client.Infrastructure.Services;

    using CS.Common.Models.InputModels;

    public class HomeController : Controller
    {
        private IChallengesService challengesService;

        public HomeController()
            : this(new ChallengesService())
        {
        }

        public HomeController(IChallengesService challengesService)
        {
            this.challengesService = challengesService;
        }

        public ActionResult GetAll()
        {
            var challenges = challengesService.GetCurrentChallenges();

            if (challenges == null || challenges.Count() == 0)
            {
                var datetime = challengesService.GetNextAvailableChallengeDate();

                return View("NoCurrentChallenges", datetime);
            }

            return View("CurrentChallenges", challenges);
        }

        public ActionResult GetById(int id)
        {
            var challenge = challengesService.GetChallengeDetails(id);

            if (challenge == null || challenge.IsCompleted)
            {
                return this.RedirectToAction("GetCompleted");
            }

            return View("ChallengeDetails", challenge);
        }
        
        public ActionResult GetCompleted()
        {
            var completedChallenges = challengesService.GetCompletedChallenges();

            return View("CompletedChallenges", completedChallenges);
        }

        [HttpGet]
        public ActionResult NewChallenge()
        {
            var model = TempData["challengeModel"] as ChallengeInputModel;

            if (model != null)
            {
                return View(model);
            }

            return View();
        }

        [HttpPost]
        public ActionResult PostNewChallenge(ChallengeInputModel challenge)
        {
            if(!ModelState.IsValid)
            {
                TempData["challengeModel"] = challenge;
                return this.RedirectToAction("NewChallenge");
            }

            this.challengesService.PostNewChallenge(challenge);

            return this.RedirectToAction("NewChallenge");
        }
    }
}