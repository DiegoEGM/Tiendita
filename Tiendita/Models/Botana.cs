using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace Tiendita.Models
{
    [Table("botanas")]
    public class Botana
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        public string Username { get; set; }
        public int Precio { get; set; }

    }
}
