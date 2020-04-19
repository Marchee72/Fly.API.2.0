using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repos.Interfaces
{
    public interface IPictureRepository
    {
        ObjectId UploadFromBytes(string filename, byte[] source);
        ObjectId UploadFromStream(string filename, Stream source);
        byte[] DownloadAsBytes(string filename);
    }
}
