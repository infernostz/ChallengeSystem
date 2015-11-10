namespace CS.Client.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Newtonsoft.Json;

    using CS.Client.Infrastructure.Contracts;

    using CS.Common.Models.InputModels;
    using CS.Common.Models.ViewModels;
    using System.Text;

    public class ChallengesService : IChallengesService
    {
        private const string BASE_ADDRESS = "http://localhost:15476/";
        private HttpClient httpClient;

        public ChallengesService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BASE_ADDRESS);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<ChallengePartialViewModel> GetCurrentChallenges()
        {
            IEnumerable<ChallengePartialViewModel> challenges = null;

            //HttpResponseMessage response = this.httpClient.GetAsync("api/challenges/all").Result;
            HttpResponseMessage response = this.httpClient.GetAsync("api/challenges").Result;

            if (response.IsSuccessStatusCode)
            {
                challenges = JsonConvert.DeserializeObject<IEnumerable<ChallengePartialViewModel>>(response.Content.ReadAsStringAsync().Result);
            }

            return challenges;
        }

        public IEnumerable<CompletedChallengeView> GetCompletedChallenges()
        {
            IEnumerable<CompletedChallengeView> challenges = null;

            HttpResponseMessage response = this.httpClient.GetAsync("api/challenges/completed").Result;

            if (response.IsSuccessStatusCode)
            {
                challenges = JsonConvert.DeserializeObject<IEnumerable<CompletedChallengeView>>(response.Content.ReadAsStringAsync().Result);
            }

            return challenges;
        }

        public ChallengeViewModel GetChallengeDetails(int id)
        {
            ChallengeViewModel challenge = null;

            HttpResponseMessage response = this.httpClient.GetAsync("api/challenges/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                challenge = JsonConvert.DeserializeObject<ChallengeViewModel>(response.Content.ReadAsStringAsync().Result);
            }

            return challenge;
        }

        public DateTime? GetNextAvailableChallengeDate()
        {
            DateTime? datetime = null;

            HttpResponseMessage response = this.httpClient.GetAsync("api/challenges/next").Result;

            if (response.IsSuccessStatusCode)
            {
                datetime = JsonConvert.DeserializeObject<DateTime?>(response.Content.ReadAsStringAsync().Result);
            }

            return datetime;
        }

        public void PostNewChallenge(ChallengeInputModel challenge)
        {
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(challenge), Encoding.UTF8, "application/json");

            HttpResponseMessage response = this.httpClient.PostAsync("api/challenges/", contentPost).Result;
        }
    }
}