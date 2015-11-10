namespace CS.Common.Models.ViewModels
{
    using System;

    public class CompletedChallengeView
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Reward { get; set; }

        public string Answer { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}