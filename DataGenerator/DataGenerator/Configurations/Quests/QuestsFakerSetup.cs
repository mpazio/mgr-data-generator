using Bogus;
using DataGenerator.Data.Quest;

namespace DataGenerator.Configurations.Quests;

public static class QuestsFakerSetup
{
    public static Faker<Quest> SetupQuest(int? seed = null)
    {
        var questGoals = SetupQuestGoal(seed);
        var killGoals = SetupKillGoal(seed);
        var deliveryGoals = SetupDeliveryGoal(seed);

        int questIDs = 1;
        var quests = new Faker<Quest>()
                .StrictMode(true)
                .RuleFor(e => e.ID, f => questIDs++)
                .RuleFor(e => e.NameTag, f => f.Lorem.Random.String())
                .RuleFor(e => e.DescriptionTag, f => f.Lorem.Random.String())
                .RuleFor(e => e.QuestGoal, f => f.PickRandomParam<QuestGoal>(questGoals, killGoals, deliveryGoals));
        
        if(seed is not null)
        {
            quests.UseSeed(seed.Value);
        }

        return quests;
    }

    public static Faker<KillGoal> SetupKillGoal(int? seed = null)
    {
        var killGoals = new Faker<KillGoal>()
                .StrictMode(true)
                .RuleFor(e => e.EnemyID, f => f.Random.Number(0, 100000))
                .RuleFor(e => e.CurrentCounter, f => f.Random.Number(0, 10))
                .RuleFor(e => e.GoalCounter, f => f.Random.Number(10, 20))
                .RuleFor(e => e.Active, f => f.PickRandom(new bool[]{true , false}))
            ;
        
        if(seed is not null)
        {
            killGoals.UseSeed(seed.Value);
        }

        return killGoals;
    }
    
    public static Faker<DeliveryGoal> SetupDeliveryGoal(int? seed = null)
    {
        var deliveryItems = SetupItemsForDelivery(seed);
        
        var deliveryGoals = new Faker<DeliveryGoal>()
                .StrictMode(true)
                .RuleFor(e => e.ItemsForDelivery, f => deliveryItems.Generate(5).ToList())
                .RuleFor(e => e.Active, f=> f.PickRandom(new bool[]{true , false}))
            ;
        
        if(seed is not null)
        {
            deliveryGoals.UseSeed(seed.Value);
        }

        return deliveryGoals;
    }
    
    public static Faker<DeliveryItem> SetupItemsForDelivery(int? seed = null)
    {
        var deliveryItems = new Faker<DeliveryItem>()
                .StrictMode(true)
                .RuleFor(e => e.ItemID, f => f.Random.Number(0, 100000))
                .RuleFor(e => e.HowManyHasInEquipment, f=> f.Random.Number(0, 100))
                .RuleFor(e => e.GoalCounter, f=> f.Random.Number(0, 20))
            ;
            
        if(seed is not null)
        {
            deliveryItems.UseSeed(seed.Value);
        }

        return deliveryItems;
    }
    
    public static Faker<QuestGoal> SetupQuestGoal(int? seed = null)
    {
        var questGoals = new Faker<QuestGoal>()
                .StrictMode(true)
                .RuleFor(e => e.Active, f => f.PickRandom(new bool[]{true , false}))
            ;
        
        if(seed is not null)
        {
            questGoals.UseSeed(seed.Value);
        }

        return questGoals;
    }

}
