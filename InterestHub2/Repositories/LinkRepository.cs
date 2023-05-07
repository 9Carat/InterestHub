using InterestHub2.Data;
using InterestHub2.Models;
using Microsoft.EntityFrameworkCore;

namespace InterestHub2.Repositories
{
    internal static class LinkRepository
    {
        internal async static Task<List<Link>> GetLinksAsync()
        {
            using (var db = new InterestHubDbContext())
            {
                return await db.Links.ToListAsync();
            }
        }
        internal async static Task<bool> AddLinkAsync(Link link)
        {
            using (var db = new InterestHubDbContext())
            {
                try
                {
                    await db.Links.AddAsync(link);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
