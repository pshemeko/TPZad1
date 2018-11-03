using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zad1
{
    public enum Rodzaj : byte
    {
        [XmlEnum(Name = "kryminal")]
        kryminal = 0,
        [XmlEnum(Name = "romans")]
        romans,
        [XmlEnum(Name = "popularno_naukowy")]
        popularno_naukowy,
        [XmlEnum(Name = "powiesc")]
        powiesc,
        [XmlEnum(Name = "fantastyka")]
        fantastyka

    };
  
}

