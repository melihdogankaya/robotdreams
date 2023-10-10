namespace RobotDreams.API.Model.Studies.Abst
{
    public abstract class Drawing
    {
        public string @System { get; set; }
        public string Description { get; set; }
        public string HowToDraw { get; set; } 

        public abstract string Draw();

    }
}
