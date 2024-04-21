using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;

namespace MyScriptureJournal.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyScriptureJournalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyScriptureJournalContext>>()))
        {
            if (context == null || context.Scripture == null)
            {
                throw new ArgumentNullException("Null MyScriptureJournalContext");
            }

            // Look for any movies.
            if (context.Scripture.Any())
            {
                return;   // DB has been seeded
            }

            context.Scripture.AddRange(
                new Scriptures
                {
                    Book = "Alma",
                    Chapter = 34,
                    Verse = 16,
                    Note = "The mercy of Christ will free us from justice",
                    ReleaseDate = DateTime.Now
                },

                new Scriptures
                {
                    Book = "Moises",
                    Chapter = 1,
                    Verse = 39,
                    Note = "God's purpose for his children",
                    ReleaseDate = DateTime.Now
                },

                new Scriptures
                {
                    Book = "D&C",
                    Chapter = 50,
                    Verse = 24,
                    Note = "Everything that comes from God is Light",
                    ReleaseDate = DateTime.Now
                },

                new Scriptures
                {
                    Book = "Eter",
                    Chapter = 12,
                    Verse = 4,
                    Note = "Faith in Christ is an anchor that makes us better people",
                    ReleaseDate = DateTime.Now
                }
            );
            context.SaveChanges();
        }
    }
}


