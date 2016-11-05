using System.Diagnostics;

namespace TennisScoring.Core.Domain
{
    // Bit pointless but would imagine a player would have a name, some stats etc
    [DebuggerDisplay("{FirstName}")]
    public class Player
    {
        public string FirstName { get; set; }
    }
}
