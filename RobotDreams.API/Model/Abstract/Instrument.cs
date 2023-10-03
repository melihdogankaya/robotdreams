namespace RobotDreams.API.Model.Abstract
{
    public abstract class Instrument
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract string Play();
    }
}
