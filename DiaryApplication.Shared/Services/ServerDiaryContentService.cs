using DiaryApplication.Shared.Data;
using DiaryApplication.Shared.Entity;
using DiaryApplication.Shared.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Shared.Services
{
    public class ServerDiaryContentService : IDiaryContentService
    {
        private readonly DiaryDbContext _context;

        public ServerDiaryContentService(DiaryDbContext context)
        {
            _context = context;
        }

        public async Task<DiaryContent> AddContent(DiaryContent diaryContent)
        {
            _context.DiaryContents.Add(diaryContent);
            await _context.SaveChangesAsync();

            return diaryContent;
        }

        public async Task<bool> DeleteDiaryContent(int id)
        {
            var dbDiaryContent = await _context.DiaryContents.FindAsync(id);
            if (dbDiaryContent != null)
            {
                _context.Remove(dbDiaryContent);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<DiaryContent> EditDiaryContent(int id, DiaryContent diaryContent)
        {
            var dbGame = await _context.DiaryContents.FindAsync(id);
            if (dbGame != null)
            {
                dbGame.Date = diaryContent.Date;
                dbGame.Content = diaryContent.Content;
                await _context.SaveChangesAsync();
                return dbGame;
            }
            throw new Exception("Game not found.");
        }

        public async Task<List<DiaryContent>> GetAllDiaryContent()
        {
            var allContent = await _context.DiaryContents
                                                .OrderByDescending(date => date.Date)
                                                .ToListAsync();
            return allContent;
        }

        public async Task<DiaryContent> GetDiaryContentById(int id)
        {
            return await _context.DiaryContents.FindAsync(id);
        }
    }
}
