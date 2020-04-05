using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeligdenskoJajce.Model
{
    public class PlayRoom
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPictureUrl { get; set; }
        public string RoomName { get; set; }
        public string RoomPassword { get; set; }
        public int? SecondUserId { get; set; }
        public string SecondUserName { get; set; }
        public string SecondUserPictureUrl { get; set; }
        public bool IsGameStarted { get; set; }
        public bool IsOwnerWinner { get; set; }
    }
}
