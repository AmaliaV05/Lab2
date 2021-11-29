using System.Collections.Generic;

namespace Project2.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public IList<string> UserRoles { get; set; } = new List<string>();
    }
}
