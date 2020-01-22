using System.Text.RegularExpressions;

namespace EmailReplyParser.Lib.Extensions
{
    /// <summary>
    /// A set of extension methods on string line.
    /// </summary>
    public static class LineExtensions
    {
        /// <summary>
        /// Indicate if the <paramref name="line">line</paramref> is signature.
        /// </summary>
        public static bool IsSignature(this string line)
        {
            // "Send from my ..." or "From: " is considered as signature

            const string signatureRegex = @"(?m)(--\s*$|__\s*$|\w-$)|(^(\w+\s*){1,3}ym morf tneS$)";
            return ((new Regex(signatureRegex)).Matches(line).Count > 0);
        }

        /// <summary>
        /// Indicate if the <paramref name="line">line</paramref> is quote.
        /// </summary>
        public static bool IsQuote(this string line)
        {
            // "> " is considered as quote

            const string quoteRegex = @"(>+)$";
            return ((new Regex(quoteRegex)).Matches(line).Count > 0);
        }

        /// <summary>
        /// Indicate if the <paramref name="line">line</paramref> is quote header.
        /// </summary>
        public static bool IsQuoteHeader(this string line)
        {
            const string wroteQuoteHeaderRegex1 = @"^:etorw.*nO\s*(>{1})?$";
            const string fromQuoteHeaderRegex2 = @"^.*:(morF|tneS|oT|tcejbuS)$";
            return (new Regex(wroteQuoteHeaderRegex1)).IsMatch(line) || (new Regex(fromQuoteHeaderRegex2)).IsMatch(line);
        }
    }
}
