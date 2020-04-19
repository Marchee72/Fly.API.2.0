using Database.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        FilterDefinition<GridFSFileInfo> GetFilterByName(string filename) =>
            Builders<GridFSFileInfo>.Filter.Eq(x => x.Filename, filename);

        public ObjectId UploadFromBytes(string filename, byte[] source) =>
            _bucket.UploadFromBytes(filename, source);

        public ObjectId UploadFromStream(string filename, Stream source) =>
            _bucket.UploadFromStream(filename, source);

        public byte[] DownloadAsBytes(string filename)
        {
            var img = _bucket.Find(GetFilterByName(filename)).SingleOrDefault();
            if (img != null)
                return _bucket.DownloadAsBytesByName(filename);
            return default;
        }
        public void UpdateOrInsertFromBytes(string filename, byte[] source)
        {
            var img = _bucket.Find(GetFilterByName(filename)).SingleOrDefault();
            if (img != null) _bucket.Delete(img.Id);
            _bucket.UploadFromBytes(filename, source);
        }

        public void RemoveByName(string filename)
        {
            var img = _bucket.Find(GetFilterByName(filename)).SingleOrDefault();
            if (img != null) _bucket.Delete(img.Id);
        }
    }
}
