using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeligdenskoJajce.Model
{
    public class GamePlay
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomPassword { get; set; }
        public int SecondUserId { get; set; }
        public string SecondUserName { get; set; }
        public string SecondUserPictureUrl { get; set; }
        public bool IsGameStarted { get; set; }
    }
}
