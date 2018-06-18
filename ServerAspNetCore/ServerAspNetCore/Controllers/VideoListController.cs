using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerAspNetCore.Domain.Abstract;
using ServerAspNetCore.Domain.Entities;

namespace ServerAspNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/VideoList")]
    public class VideoListController : Controller
    {

        private IRepositoryVideo<Video> _videosRepository;

        public VideoListController(IRepositoryVideo<Video> videoRepository)
        {
            _videosRepository = videoRepository;
        }

        [HttpGet("{idC}")]
        public async Task<IActionResult> Get(int idC)
        {
            var videos = _videosRepository.GetList(x => x.IdCourse == idC).Result;
            videos.OrderBy(x => x.Order);
            return Json(videos);
        }

        [HttpGet("Video/{idVideo}")]
        public async Task<IActionResult> GetVideo(int idVideo)
        {
            var videos = await _videosRepository.GetBy(x => x.IdVideo == idVideo);
            return Json(videos);
        }


    }
}