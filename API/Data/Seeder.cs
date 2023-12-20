using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Controllers.Entities;
using ChatMicroservice.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seeder
    {
        public static async Task SeedData(DataContext dataContext)
{
    if (await dataContext.Questions.AnyAsync()) 
        return; // If the database is already populated, don't populate again

    var jsonData = await File.ReadAllTextAsync("Data/questionsData.json");
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var questions = JsonSerializer.Deserialize<List<Question>>(jsonData, options);

    foreach (var question in questions)
    {
        foreach (var choice in question.Choices)
        {
            if (!await dataContext.Choices.AnyAsync(c => c.Id == choice.Id))
            {
                await dataContext.Choices.AddAsync(choice);
            }
        }
    }

    await dataContext.Questions.AddRangeAsync(questions.Where(q => !dataContext.Questions.Any(q2 => q2.Id == q.Id)));

    await dataContext.SaveChangesAsync();
}

    }
}
