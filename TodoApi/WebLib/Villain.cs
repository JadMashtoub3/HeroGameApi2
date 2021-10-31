using System;

namespace HeroGameApi
{
    public class Villain
    {
        public int VillainId { get; set; }
        public string VillainName { get; set; }
        public int VHealth { get; set; }
          public Villain(int VillainId, string VillainName, int VHealth)
        {
            this.VillainId = VillainId;
            this.VillainName = VillainName;
            this.VHealth = VHealth;
        }
    }
}