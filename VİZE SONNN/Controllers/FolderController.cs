using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vize.Dtos;
using vize.Models;

namespace vize.Controllers
{
    [Route("api/Folder[action]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public FolderController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<FolderDto> GetList()
        {
            var klasor = _context.Folders.ToList();
            var KlasorDtos = _mapper.Map<List<FolderDto>>(klasor);
            return KlasorDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public FolderDto Get(int id)
        {
            var klasor = _context.Folders.Where(s => s.Id == id).SingleOrDefault();
            var KlasorDto = _mapper.Map<FolderDto>(klasor);
            return KlasorDto;
        }

        [HttpPost]
        public ResultDto Post(FolderDto dto)
        {
            if (_context.Folders.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Klasör Kayıtlıdır!";
                return result;
            }
            var klasor = _mapper.Map<Folder>(dto);
            klasor.Updated = DateTime.Now;
            klasor.Created = DateTime.Now;
            _context.Folders.Add(klasor);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Klasör Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(FolderDto dto)
        {
            var klasor = _context.Folders.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (klasor == null)
            {
                result.Status = false;
                result.Message = "Klasör Bulunamadı!";
                return result;
            }
            klasor.Name = dto.Name;
            klasor.IsActive = dto.IsActive;
            klasor.Updated = DateTime.Now;
            klasor.Description = dto.Description;
            _context.Folders.Update(klasor);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Klasör Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var klasor = _context.Folders.Where(s => s.Id == id).SingleOrDefault();
            if (klasor == null)
            {
                result.Status = false;
                result.Message = "Klasör Bulunamadı!";
                return result;
            }
            _context.Folders.Remove(klasor);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Klasör Silindi";
            return result;
        }
    }
}

