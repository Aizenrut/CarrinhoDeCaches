using CarrinhoDeCaches.IDados;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;

namespace CarrinhoDeCaches.Dados
{
    public class RedisRepositorio : IRedisRepositorio
    {
        private readonly IRedisClient redisClient;

        public RedisRepositorio(IRedisClient redisClient)
        {
            this.redisClient = redisClient;
        }

        public string HGet(string chave, string campo)
        {
            return redisClient.GetValueFromHash(chave, campo);
        }

        public IDictionary<string, string> HGetAll(string chave)
        {
            return redisClient.GetAllEntriesFromHash(chave);
        }

        public void HSet(string chave, params KeyValuePair<string, string>[] campoValores)
        {
            redisClient.SetRangeInHash(chave, campoValores);
        }

        public void Del(params string[] chaves)
        {
            redisClient.RemoveAll(chaves);
        }

        public void HDel(string chave, params string[] campos)
        {
            foreach (var campo in campos)
                redisClient.RemoveEntryFromHash(chave, campo);
        }

        public void Expire(string chave, TimeSpan tempo)
        {
            redisClient.ExpireEntryIn(chave, tempo);
        }
    }
}
