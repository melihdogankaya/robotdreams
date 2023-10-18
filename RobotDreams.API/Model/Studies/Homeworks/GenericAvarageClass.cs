namespace RobotDreams.API.Model.Studies.Homeworks
{
    public class GenericAvarageClass <T>
    {
        public T Field { get; set; }
        public int Code { get; set; }    
        public decimal StudentAvarage { get; set; }
        public string Message {  get; set; }
        

    }
}
