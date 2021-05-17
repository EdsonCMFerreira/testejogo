using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiModeloDDD.Domain.Entitys
{
    public class Rodada
    {
        public long Id { get; set; }
        public int Dado { get; set; }
        public string Mensagem { get; set; }

    }
}
