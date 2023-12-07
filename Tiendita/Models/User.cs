using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Tiendita.Models
{
    [Table("cuentas")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
