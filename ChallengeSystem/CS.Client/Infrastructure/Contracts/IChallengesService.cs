namespace CS.Client.Infrastructure.Contracts
{
    using System;
    using System.Collections.Generic;

    using CS.Common.Models.InputModels;
    using CS.Common.Models.ViewModels;

    public interface IChallengesService
    {
        IEnumerable<ChallengePartialViewModel> GetCurrentChallenges();

        IEnumerable<CompletedChallengeView> GetCompletedChallenges();

        ChallengeViewModel GetChallengeDetails(int id);

        DateTime? GetNextAvailableChallengeDate();

        void PostNewChallenge(ChallengeInputModel challenge);
    }
}