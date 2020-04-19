using Database.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repos
{
    public class UsersPictureRepo : IPictureRepository
    {
        private readonly IGridFSBucket _bucket;
        public UsersPictureRepo(IFlayDatabase database)
        {
            _bucket = database.UsersPicture;
        }
        public ObjectId UploadFromBytes(string filename, byte[] source)
        {
            return _bucket.UploadFromBytes(filename, source);
        }

        public ObjectId UploadFromStream(string filename, Stream source)
        {
            return _bucket.UploadFromStream(filename, source);
        }

        public byte[] DownloadAsBytes(string userId)
        {
            return _bucket.DownloadAsBytesByName(userId);
        }
    }
}
