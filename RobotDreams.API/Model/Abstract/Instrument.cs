namespace RobotDreams.API.Model.Abstract
{
    public abstract class Instrument
    {
        public string Name { get; set; }
        public abstract string Play();

    }
}
