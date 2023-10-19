namespace RobotDreams.API.Model.EntityFrameworkExample
{
    public class UserModel
    {
        public bool Authenticate { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
