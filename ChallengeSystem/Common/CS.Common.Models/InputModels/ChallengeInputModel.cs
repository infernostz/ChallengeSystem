namespace CS.Common.Models.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ChallengeInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public int MinimumWordsRestriction { get; set; }

        [Required]
        public string Reward { get; set; }
    }
}