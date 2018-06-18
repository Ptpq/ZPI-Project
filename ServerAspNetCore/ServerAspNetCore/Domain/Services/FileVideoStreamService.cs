using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServerAspNetCore.Domain.Services
{
  public class FileVideoStreamService
  {
    private readonly string _filename;

    public FileVideoStreamService(string filename, string ext)
    {

      _filename = @"~/VideoDataFile/" + filename + "." + ext;
    }

    public async void WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
    {
      try
      {
        var buffer = new byte[65536];

        using (var video = File.Open(_filename, FileMode.Open, FileAccess.Read))
        {
          int length = (int)video.Length;
          var bytesRead = 1;

          while (length > 0 && bytesRead > 0)
          {
            bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
            await outputStream.WriteAsync(buffer, 0, bytesRead);
            length -= bytesRead;
          }
        }
      }
      catch (Exception ex)
      {
        return;
      }
      finally
      {
        outputStream.Close();
      }
    }
  }
}
