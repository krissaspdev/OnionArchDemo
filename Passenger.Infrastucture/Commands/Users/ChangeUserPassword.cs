namespace Passenger.Infrastucture.Commands.Users
{
    public class ChangeUserPassword : ICommand
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}