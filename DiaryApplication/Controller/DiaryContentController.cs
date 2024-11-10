using DiaryApplication.Shared.Data;
using DiaryApplication.Shared.Entity;
using DiaryApplication.Shared.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryContentController : ControllerBase
    {
        private readonly IDiaryContentService _diaryContentService;

        public DiaryContentController(IDiaryContentService contentService)
        {
            _diaryContentService = contentService;
        }

        [HttpPost]
        public async Task<ActionResult<DiaryContent>> AddDiaryContent(DiaryContent diary)
        {
            try
            {
                var addedContent = await _diaryContentService.AddContent(diary);
                return Ok(addedContent);
            }
            catch (Exception ex)
            {
                // Log the exception (to console, file, or a logging service)
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiaryContent>> GetDiaryContentById(int id)
        {
            var content = await _diaryContentService.GetDiaryContentById(id);
            if (content == null)
                return NotFound();

            return Ok(content);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DiaryContent>> UpdateDiaryContent(int id, DiaryContent diaryContent)
        {
            try
            {
                var result = await _diaryContentService.EditDiaryContent(id, diaryContent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error editing diary content: {ex.Message}");
            }
        }
    }
}
