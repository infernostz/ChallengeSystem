namespace CS.Common.Models.ViewModels
{
    using System;

    public class ChallengeViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public int MinimumWordsRestriction { get; set; }

        public string Reward { get; set; }

        public bool IsCompleted { get; set; }
    }
}