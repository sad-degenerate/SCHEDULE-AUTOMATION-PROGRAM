namespace BL.Model
{
    public class SubgroupsInGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubgroupId { get; set; }

        public SubgroupsInGroup() { }

        public SubgroupsInGroup(int groupId, int subgroupId)
        {
            GroupId = groupId;
            SubgroupId = subgroupId;
        }

        public override bool Equals(object obj)
        {
            if (obj is SubgroupsInGroup)
            {
                var another = obj as SubgroupsInGroup;

                if (another.GroupId == GroupId && another.SubgroupId == SubgroupId)
                    return true;
            }

            return false;
        }
    }
}