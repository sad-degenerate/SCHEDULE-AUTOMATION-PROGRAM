namespace BL.Model
{
    public class GroupsInFlow
    {
        public int Id { get; set; }
        public int FlowId { get; set; }
        public int GroupId { get; set; }

        public GroupsInFlow() { }

        public GroupsInFlow(int flowId, int groupId)
        {
            FlowId = flowId;
            GroupId = groupId;
        }

        public override bool Equals(object obj)
        {
            if (obj is GroupsInFlow)
            {
                var another = obj as GroupsInFlow;

                if (another.FlowId == FlowId && another.GroupId == GroupId)
                    return true;
            }

            return false;
        }
    }
}