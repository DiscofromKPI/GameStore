using System.Collections.Generic;

namespace GameStore.ViewModels.User
{
    public class UserRegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}