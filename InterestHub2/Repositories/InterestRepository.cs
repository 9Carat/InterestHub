using InterestHub2.Data;
using InterestHub2.Models;
using Microsoft.EntityFrameworkCore;

namespace InterestHub2.Repositories
{
    internal static class InterestRepository
    {
        internal async static Task<List<Interest>> GetInterestsAsync()
        {
            using (var db = new InterestHubDbContext())
            {
                return await db.Interests.ToListAsync();
            }
        }
    }
}
