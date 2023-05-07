using InterestHub2.Data;
using InterestHub2.Models;
using InterestHub2.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterestHub2.Repositories
{
    internal static class UserRepository
    {
        internal async static Task<List<User>> GetUsersAsync()
        {
            using (var db = new InterestHubDbContext())
            {
                return await db.Users.ToListAsync();
            }
        }
        internal async static Task<User> GetUserByIdAsync(int userId)
        {
            using (var db = new InterestHubDbContext())
            {
                return await db.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            }
        }
        internal async static Task<List<UserInterestDTO>> GetUserAndInterestByIdAsync(int userId)
        {
            using (var db = new InterestHubDbContext())
            {
                List<UserInterestDTO> list = new List<UserInterestDTO>();

                var items = await (from u in db.Users
                             join ui in db.UserInterests on u.UserId equals ui.FK_UserId
                             join i in db.Interests on ui.FK_InterestId equals i.InterestId
                             where u.UserId == userId
                             select new
                             {
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName,
                                 Interest = i.Title,
                                 Description = i.Description,
                             }).ToListAsync();

                foreach (var item in items)
                {
                    UserInterestDTO itemDTO = new UserInterestDTO();
                    itemDTO.FirstName = item.FirstName;
                    itemDTO.LastName = item.LastName;
                    itemDTO.Interest = item.Interest;
                    itemDTO.Description = item.Description;
                    list.Add(itemDTO);
                }
                return list;
            }
        }
        internal async static Task<List<UserLinkDTO>> GetUserAndLinkByIdAsync(int userId)
        {
            using (var db = new InterestHubDbContext())
            {
                List<UserLinkDTO> list = new List<UserLinkDTO>();

                var items = await (from u in db.Users
                                   join ui in db.UserInterests on u.UserId equals ui.FK_UserId
                                   join i in db.Interests on ui.FK_InterestId equals i.InterestId
                                   join uil in db.UserInterestLinks on i.InterestId equals uil.FK_InterestId
                                   join l in db.Links on uil.FK_LinkId equals l.LinkId
                                   where u.UserId == userId && u.UserId == uil.FK_UserId
                                   select new
                                   {
                                       FirstName = u.FirstName,
                                       LastName = u.LastName,
                                       LinkTitle = l.Title,
                                       LinkUrl = l.Url,
                                   }).ToListAsync();

                foreach (var item in items)
                {
                    UserLinkDTO itemDTO = new UserLinkDTO();
                    itemDTO.FirstName = item.FirstName;
                    itemDTO.LastName = item.LastName;
                    itemDTO.LinkTitle = item.LinkTitle;
                    itemDTO.Url = item.LinkUrl;
                    list.Add(itemDTO);
                }
                return list;
            }
        }
        internal async static Task<bool> ConnectUserAndInterestAsync(UserInterest userInterest)
        {
            using (var db = new InterestHubDbContext())
            {
                try
                {
                    await db.UserInterests.AddAsync(userInterest);
                    return await db.SaveChangesAsync() <= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        internal async static Task<bool> ConnectUserLinkAsync(UserInterestLink uil)
        {
            using (var db = new InterestHubDbContext())
            {
                try
                {
                    await db.UserInterestLinks.AddAsync(uil);
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
