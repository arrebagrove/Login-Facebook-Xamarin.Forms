using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginFacebook.Model
{
    /// <summary>
    ///  Usuário
    /// </summary>
    public class Usuario
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

    }
}
