using System;

namespace HeroGameApi
{
    public class Hero
    {
        public int HeroId { get; set; }
        public string HName { get; set; }
        public int MinHit { get; set; }
        public int MaxHit { get; set; }

        public Hero(int HeroId, string HName, int MinHit, int MaxHit)
        {
            this.HeroId = HeroId;
            this.HName = HName;
            this.MinHit = MinHit;
            this.MaxHit = MaxHit;
        }
    }
}