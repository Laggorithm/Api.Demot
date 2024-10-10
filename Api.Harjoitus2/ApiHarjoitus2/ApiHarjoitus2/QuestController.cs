using ApiHarjoitus2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("quests")]
public class QuestsController : ControllerBase
{
    private readonly QuestDbContext _context;

    public QuestsController(QuestDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quest>>> GetAllQuests()
    {
        return await _context.Quests.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Quest>> GetQuest(int id)
    {
        var quest = await _context.Quests.FindAsync(id);
        if (quest == null)
        {
            return NotFound();
        }

        return quest;
    }

    [HttpPost]
    public async Task<ActionResult<Quest>> CreateQuest(Quest quest)
    {
        _context.Quests.Add(quest);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetQuest), new { id = quest.Id }, quest);
    }
}
