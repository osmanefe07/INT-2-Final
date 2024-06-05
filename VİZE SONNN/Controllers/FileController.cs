using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vize.Dtos;
using vize.Models;

namespace vize.Controllers
{
    [Route("api/File[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public FileController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<FileDto> GetList()
        {
            var file = _context.Files.ToList();
            var fileDtos = _mapper.Map<List<FileDto>>(file);
            return fileDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public FileDto Get(int id)
        {
            var file = _context.Files.Where(s => s.Id == id).SingleOrDefault();
            var fileDto = _mapper.Map<FileDto>(file);
            return fileDto;
        }

        [HttpPost]
        public ResultDto Post(FileDto dto)
        {
            if (_context.Files.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen file Kayıtlıdır!";
                return result;
            }
            var file = _mapper.Map<Models.File>(dto);
            file.Updated = DateTime.Now;
            file.Created = DateTime.Now;
            _context.Files.Add(file);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "file Eklendi";
            return result;
        }


        [HttpPut]
        [Authorize (Roles = "Admin")]
        public ResultDto Put(FileDto dto)
        {
            var file = _context.Files.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (file == null)
            {
                result.Status = false;
                result.Message = "file Bulunamadı!";
                return result;
            }
            file.Name = dto.Name;
            file.IsActive = dto.IsActive;
            file.Size = dto.Size;
            file.Updated = DateTime.Now;
            file.Description = dto.Description;
            file.CategoryId = dto.CategoryId;
            _context.Files.Update(file);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "file Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var file = _context.Files.Where(s => s.Id == id).SingleOrDefault();
            if (file == null)
            {
                result.Status = false;
                result.Message = "file Bulunamadı!";
                return result;
            }
            _context.Files.Remove(file);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "file Silindi";
            return result;
        }
    }
}
