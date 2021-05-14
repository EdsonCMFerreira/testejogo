using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorReadDataApi.Domain
{
    public class Rodada
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Dado { get; set; }
        public string mensagem { get; set; }

    }

 

}