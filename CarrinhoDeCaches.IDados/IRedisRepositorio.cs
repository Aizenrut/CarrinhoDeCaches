using System.Collections.Generic;

namespace CarrinhoDeCaches.IDados
{
    public interface IRedisRepositorio
    {
        string HGet(string chave, string campo);
        IDictionary<string, string> HGetAll(string chave);
        void HSet(string chave, params KeyValuePair<string, string>[] campoValores);
        void Del(params string[] chaves);
        void HDel(string chave, params string[] campos);
    }
}
