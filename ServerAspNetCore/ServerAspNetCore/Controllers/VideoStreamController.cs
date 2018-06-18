using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerAspNetCore.Domain.Abstract;

namespace ServerAspNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/VideoStream")]
    public class VideoStreamController : Controller
    {

    private IVideoStreamService _streamingService;

    public VideoStreamController(IVideoStreamService streamingService)
    {
      _streamingService = streamingService;
    }

    [HttpGet("{name}")]
    public async Task<FileStreamResult> Get(int id)
    {
      var stream = await _streamingService.GetVideoById(id);
      return new FileStreamResult(stream, "video/mp4");
      /*string ext = "mp4";
      var video = new VideoStream(filename, ext);

      var response = Request.CreateResponse();
      response.Content = new PushStreamContent(video.WriteToStream, new MediaTypeHeaderValue("video/" + ext));

      return response;*/
    }



  }
}
