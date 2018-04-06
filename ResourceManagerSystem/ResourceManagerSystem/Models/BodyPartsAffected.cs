namespace ResourceManagerSystem.Models
{
    public class BodyPartsAffected
    {
        public int BodyPartsAffectedID { set; get; }
        public int BodyPartID { set; get; }
        public int AccidentEffectID { set; get; }

        public BodyPart BodyPart { set; get; }
        public AccidentEffect AccidentEffect { set; get; }
    }
}