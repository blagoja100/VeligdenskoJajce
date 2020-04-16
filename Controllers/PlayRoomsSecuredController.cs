using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeligdenskoJajce.Data;
using VeligdenskoJajce.Model;

namespace VeligdenskoJajce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayRoomsSecuredController : PlayRoomsController
    {
        public PlayRoomsSecuredController(VeligdenskoJajceContext context) : base(context)
        {
        }       
    }
}
