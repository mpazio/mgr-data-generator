namespace DataGenerator.Data.Quest;

public class Quest
{
    public int ID { get; set; }
    public string NameTag { get; set; }
    public string DescriptionTag { get; set; }
    public QuestGoal QuestGoal { get; set; }
}