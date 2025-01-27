// MIT License
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;

namespace StarForge.Utils
{
    /// <summary>
    /// Provides extension methods for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Checks if a string is null or consists only of white-space characters.
        /// </summary>
        /// <param name="val">The string to check.</param>
        /// <returns>True if the string is null or white space; otherwise, false.</returns>
        public static bool IsNullOrWhiteSpace(this string val) => string.IsNullOrWhiteSpace(val);

        /// <summary>
        /// Checks if a string is null or empty.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// Checks if a string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="val">The string to check.</param>
        /// <returns>True if the string is null, empty, or white space; otherwise, false.</returns>
        public static bool IsBlank(this string val) => val.IsNullOrWhiteSpace() || val.IsNullOrEmpty();

        /// <summary>
        /// Returns an empty string if the input string is null.
        /// </summary>
        /// <param name="val">The string to check.</param>
        /// <returns>The original string if it is not null; otherwise, an empty string.</returns>
        public static string OrEmpty(this string val) => val ?? string.Empty;

        /// <summary>
        /// Shortens a string to the specified maximum length. If the string's length
        /// is less than the maxLength, the original string is returned.
        /// </summary>
        /// <param name="val">The string to shorten.</param>
        /// <param name="maxLength">The maximum length of the returned string.</param>
        /// <returns>The shortened string if its length exceeds maxLength; otherwise, the original string.</returns>
        public static string Shorten(this string val, int maxLength) {
            if (val.IsBlank()) return val;
            return val.Length <= maxLength ? val : val.Substring(0, maxLength);
        }

        /// <summary>
        /// Slices a string from the start index to the end index.
        /// </summary>
        /// <param name="val">The string to slice.</param>
        /// <param name="startIndex">The zero-based starting character position.</param>
        /// <param name="endIndex">The zero-based ending character position.</param>
        /// <returns>The sliced string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input string is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the start or end index is out of range.</exception>
        public static string Slice(this string val, int startIndex, int endIndex) {
            if (val.IsBlank()) {
                throw new ArgumentNullException(nameof(val), "Value cannot be null or empty.");
            }

            if (startIndex < 0 || startIndex > val.Length - 1) {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            // If the end index is negative, it will be counted from the end of the string.
            endIndex = endIndex < 0 ? val.Length + endIndex : endIndex;

            if (endIndex < 0 || endIndex < startIndex || endIndex > val.Length) {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            return val.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Converts the input string to an alphanumeric string, optionally allowing periods.
        /// </summary>
        /// <param name="input">The input string to be converted.</param>
        /// <param name="allowPeriods">A boolean flag indicating whether periods should be allowed in the output string.</param>
        /// <returns>
        /// A new string containing only alphanumeric characters, underscores, and optionally periods.
        /// If the input string is null or empty, an empty string is returned.
        /// </returns>
        public static string ConvertToAlphanumeric(this string input, bool allowPeriods = false) {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            List<char> filteredChars = new List<char>();
            int lastValidIndex = -1;

            // Iterate over the input string, filtering and determining valid start/end indices
            foreach (char character in input
                         .Where(character => char
                             .IsLetterOrDigit(character) || character == '_' || (allowPeriods && character == '.'))
                         .Where(character => filteredChars.Count != 0 || (!char.IsDigit(character) && character != '.'))) {

                filteredChars.Add(character);
                lastValidIndex = filteredChars.Count - 1; // Update lastValidIndex for valid characters
            }

            // Remove trailing periods
            while (lastValidIndex >= 0 && filteredChars[lastValidIndex] == '.') {
                lastValidIndex--;
            }

            // Return the filtered string
            return lastValidIndex >= 0
                ? new string(filteredChars.ToArray(), 0, lastValidIndex + 1) : string.Empty;
        }

        // Rich text formatting, for Unity UI elements that support rich text.
        /// <summary>
        /// Applies a color to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <param name="color">The color to apply.</param>
        /// <returns>The formatted text with the specified color.</returns>
        public static string RichColor(this string text, string color) => $"<color={color}>{text}</color>";

        /// <summary>
        /// Applies a size to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <param name="size">The size to apply.</param>
        /// <returns>The formatted text with the specified size.</returns>
        public static string RichSize(this string text, int size) => $"<size={size}>{text}</size>";

        /// <summary>
        /// Applies bold formatting to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <returns>The formatted text in bold.</returns>
        public static string RichBold(this string text) => $"<b>{text}</b>";

        /// <summary>
        /// Applies italic formatting to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <returns>The formatted text in italics.</returns>
        public static string RichItalic(this string text) => $"<i>{text}</i>";

        /// <summary>
        /// Applies underline formatting to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <returns>The formatted text with an underline.</returns>
        public static string RichUnderline(this string text) => $"<u>{text}</u>";

        /// <summary>
        /// Applies strikethrough formatting to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <returns>The formatted text with a strikethrough.</returns>
        public static string RichStrikethrough(this string text) => $"<s>{text}</s>";

        /// <summary>
        /// Applies a font to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <param name="font">The font to apply.</param>
        /// <returns>The formatted text with the specified font.</returns>
        public static string RichFont(this string text, string font) => $"<font={font}>{text}</font>";

        /// <summary>
        /// Applies alignment to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <param name="align">The alignment to apply.</param>
        /// <returns>The formatted text with the specified alignment.</returns>
        public static string RichAlign(this string text, string align) => $"<align={align}>{text}</align>";

        /// <summary>
        /// Applies a gradient to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <param name="color1">The first color of the gradient.</param>
        /// <param name="color2">The second color of the gradient.</param>
        /// <returns>The formatted text with the specified gradient.</returns>
        public static string RichGradient(this string text, string color1, string color2) => $"<gradient={color1},{color2}>{text}</gradient>";

        /// <summary>
        /// Applies rotation to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <param name="angle">The angle of rotation.</param>
        /// <returns>The formatted text with the specified rotation.</returns>
        public static string RichRotation(this string text, float angle) => $"<rotate={angle}>{text}</rotate>";

        /// <summary>
        /// Applies spacing to the text using rich text formatting.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <param name="space">The amount of space to apply.</param>
        /// <returns>The formatted text with the specified spacing.</returns>
        public static string RichSpace(this string text, float space) => $"<space={space}>{text}</space>";
    }
}