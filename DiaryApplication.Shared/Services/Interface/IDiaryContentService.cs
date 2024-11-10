using DiaryApplication.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApplication.Shared.Services.Interface
{
    public interface IDiaryContentService
    {
        Task<List<DiaryContent>> GetAllDiaryContent();
        Task<DiaryContent> AddContent(DiaryContent diaryContent);
        Task<DiaryContent> GetDiaryContentById(int id);
        Task<DiaryContent> EditDiaryContent(int id, DiaryContent diaryContent);
        Task<bool> DeleteDiaryContent(int id);
    }
}
