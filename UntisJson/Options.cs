using System;

namespace UntisJson
{
    /// <summary>
    /// Options for JSON export
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Flag whether to minify JSON output.
        /// </summary>
        public bool MinifyJson { get; set; } = true;

        /// <summary>
        /// Exclude all items with UntisID 0.
        /// </summary>
        public bool ExcludeUntisIdZero { get; set; } = false;

        /// <summary>
        /// Only include items newer or equal to this DateTimeOffset.
        /// </summary>
        public DateTimeOffset? DateThreshold { get; set; } = null;
    }
}
