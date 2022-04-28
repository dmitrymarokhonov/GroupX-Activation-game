using System.Collections.Generic;

namespace Relanima.GameSaving
{
    [System.Serializable]
    public class GameData
    {
        public int resources;
        public List<Extension> boughtExtensions;

        public GameData(int resources, List<Extension> boughtExtensions)
        {
            this.resources = resources;
            this.boughtExtensions = boughtExtensions;
        }
    }
}