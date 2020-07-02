using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Keezag.HHSurge.Application.Model
{
    public class UserModel
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }

        [JsonIgnore]
        public string Type { get; set; }
    }
}
