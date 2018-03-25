using Asset.Cache.Interfaces;
using Asset.Model;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis.Generic;
namespace Asset.Cache
{
    public class GenericCacheRepository<T> : IGenericCacheRepository<T> where T : BaseEntity
    {
        private readonly string _cacheKey;

        public GenericCacheRepository(string cacheKey)
        {
            _cacheKey = cacheKey;
        }

        public bool Exists()
        {
            using (var redisClient = new RedisClient())
            {
                return redisClient.ContainsKey("asa." + _cacheKey + ".all");
            }
        }

        public void Add(List<T> entities)
        {
            using (var redisClient = new RedisClient())
            {
                IRedisTypedClient<T> redis = redisClient.As<T>();
                IRedisList<T> list = redis.Lists["asa." + _cacheKey + ".all"];
                list.AddRange(entities);
            }
        }

        public void Delete()
        {
            using (var redisClient = new RedisClient())
            {
                redisClient.Remove("asa." + _cacheKey + ".all");
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var redisClient = new RedisClient())
            {
                IRedisTypedClient<T> redis = redisClient.As<T>();
                IRedisList<T> list = redis.Lists["asa." + _cacheKey + ".all"];
                return list;
            }
        }
    }
}
