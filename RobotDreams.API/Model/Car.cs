namespace RobotDreams.API.Model
{
    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int EnginePowerCc { get;set; }
        public bool Hatchback { get; set; }

        public bool IsHatchback(string brand)
        {
            var a = "aaaaaa";
            var c = Convert.ToInt32(a);

            if (brand == "Ferrari")
            {
                return false;
            }
            else
            {
                c = Convert.ToInt32(a);
                return true;
            }
           
        }
        
    }
}
