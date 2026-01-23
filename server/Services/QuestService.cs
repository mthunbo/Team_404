using Services.IQuestService;

public class QuestService : IQuestService 
{
    private readonly List<Quest> _quests = new()
    {
        new Quest { Id = 1, Title = "Clean your room", Description = "Tidy up your room", CoinReward = 10 },
        new Quest { Id = 2, Title = "Take out trash", Description = "Take trash to the bin", CoinReward = 5 }
    };

    public Ienumerable<Quest> GetQuests()
    {
        return _quests;
    }
}
