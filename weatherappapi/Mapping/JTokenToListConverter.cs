
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json.Linq;
using weatherappapi.models;
using System.Linq;

namespace weatherappapi.mapping {
    public class JTokenToListConverter<T> : ITypeConverter<JToken, List<T>> where T : new()
    {
        public List<T> Convert(JToken source, List<T> destination, ResolutionContext context)
        {             
            var userList = new List<T>();
            var tokenCountItems = source.Count();
            for (int i = 0; i < tokenCountItems; i++)
                {
                    var token = source.ElementAt(i);
                    var result = new T();

                    if (token != null)
                    {
                        result = context.Mapper.Map<JToken, T>(token);
                    }
                    userList.Add(result);
                }
                
            return userList;
        }
    }
}