using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ServerAspNetCore.Domain.Abstract;
using ServerAspNetCore.Domain.Entities;

namespace ServerAspNetCore.Domain.Services
{
    public class VideoStreamService : IVideoStreamService
    {
        private HttpClient _client;
        private IRepository<Video> _videoRepository;


        public VideoStreamService(IRepository<Video> videoRepository)
        {
            _client = new HttpClient();
            _videoRepository = videoRepository;

        }

        public async Task<Stream> GetVideoById(int videoId)
        {

            Video video = await _videoRepository.Get(videoId);

            var urlBlob = string.Empty;
            urlBlob = video.Directory;


            return await _client.GetStreamAsync(urlBlob);
        }

        ~VideoStreamService()
        {
            if (_client != null)
                _client.Dispose();
        }
    }
}
