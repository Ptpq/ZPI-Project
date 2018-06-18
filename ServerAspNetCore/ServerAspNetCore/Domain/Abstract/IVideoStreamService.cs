using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAspNetCore.Domain.Abstract
{
    public interface IVideoStreamService
    {
      Task<Stream> GetVideoById(int id);
  }
}
