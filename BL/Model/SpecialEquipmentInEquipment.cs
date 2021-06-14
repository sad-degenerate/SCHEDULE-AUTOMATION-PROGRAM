namespace BL.Model
{
    public class SpecialEquipmentInEquipment
    {
        public int Id { get; set; }
        public int SpecialEquipmentId { get; set; }
        public int EquipmentId { get; set; }

        public SpecialEquipmentInEquipment() { }

        public SpecialEquipmentInEquipment(int specialEquipmentId, int equipmentId)
        {
            SpecialEquipmentId = specialEquipmentId;
            EquipmentId = equipmentId;
        }

        public override bool Equals(object obj)
        {
            if (obj is SpecialEquipmentInEquipment)
            {
                var another = obj as SpecialEquipmentInEquipment;

                if (another.EquipmentId == EquipmentId && another.SpecialEquipmentId == SpecialEquipmentId)
                    return true;
            }

            return false;
        }
    }
}