using System.ComponentModel.DataAnnotations;
using CoVoyageurCore.Models;

namespace CoVoyageurView.Helpers
{
    sealed public class PasswordIsEqual : ValidationAttribute
    {
        public User User { get; set; }
        public PasswordIsEqual(User user)
        {

            User = user;
        }
        public override bool IsValid(object? value)
        {
            if (value != User.Password)
                return false;
            return true;
        }
    }
}
