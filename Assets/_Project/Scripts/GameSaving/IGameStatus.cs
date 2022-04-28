using System.Collections.Generic;

namespace Relanima.GameSaving
{
    public interface IGameStatus
    {
        string GetPlayerName();
        int GetResources();
        List<Extension> GetBoughtExtensionsList();
    }
}