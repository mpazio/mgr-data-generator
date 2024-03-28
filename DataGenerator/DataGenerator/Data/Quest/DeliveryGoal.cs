namespace DataGenerator.Data.Quest;

public class DeliveryGoal : QuestGoal
{
    public IEnumerable<DeliveryItem> ItemsForDelivery { get; set; }
}

public class DeliveryItem
{
    public int ItemID { get; set; }
    public int HowManyHasInEquipment { get; set; }
    public int GoalCounter { get; set; }
}