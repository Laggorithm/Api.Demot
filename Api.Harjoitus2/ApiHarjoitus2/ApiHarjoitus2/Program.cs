var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory quest storage
var quests = new List<Quest>
{
    new Quest { Id = 1, Name = "Tuhoa rotat", Description = "Tapa 3 rottaa ja tuo nahat minulle.", Reward = 50 },
    new Quest { Id = 2, Name = "Etsi Viljo", Description = "Onkos Viljoo näkyny.", Reward = 100 }
};

// GET: /quests - Get all quests
app.MapGet("/quests", () =>
{
    return Results.Ok(quests);
});

// GET: /quests/{id} - Get a quest by ID
app.MapGet("/quests/{id}", (int id) =>
{
    var quest = quests.FirstOrDefault(q => q.Id == id);
    return quest is not null ? Results.Ok(quest) : Results.NotFound();
});

// POST: /quests - Create a new quest
app.MapPost("/quests", (Quest quest) =>
{
    // Assign a new ID to the quest (based on the last quest's ID)
    var newId = quests.Count > 0 ? quests.Max(q => q.Id) + 1 : 1;
    quest.Id = newId;

    // Add the new quest to the list
    quests.Add(quest);
    return Results.Created($"/quests/{quest.Id}", quest);
});
 
 
app.Run();
