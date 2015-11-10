namespace CS.Common.Models.ViewModels
{    
    using System.ComponentModel.DataAnnotations;

    public class ChallengePartialViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}