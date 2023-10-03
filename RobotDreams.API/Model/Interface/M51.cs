namespace RobotDreams.API.Model.Interface
{
    public class M51 : GunfireWeapons, IZoomable
    {
        public string Zoom()
        {
            return "Target close";
        }
    }
}
