using System;

namespace LookingForCharsRecursion
{
    public static class CharsCounter
    {
        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <returns>The number of occurrences of all characters.</returns>
        public static int GetCharsCount(string str, char[] chars)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            return GetCharsCount(str, chars, 0, str.Length - 1);
        }

        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <returns>The number of occurrences of all characters within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            return GetCharsCount(str, chars, startIndex, endIndex, str.Length * chars.Length);
        }

        /// <summary>
        /// Searches a string for a limited number of characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <param name="limit">A maximum number of characters to search.</param>
        /// <returns>The limited number of occurrences of characters to search for within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (startIndex > str.Length || endIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "StartIndex or endIndex are greater string length.");
            }

            if (endIndex <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "EndIndex is zero or less than zero.");
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit less zero");
            }

            if (str.Length == 0 || startIndex > endIndex)
            {
                return 0;
            }

            int count = RecursSearchInCharArrayWhithLimit(str[startIndex], chars, 0, limit);
            return GetCharsCount(str, chars, startIndex + 1, endIndex, limit - count) + count;
        }

        public static int RecursSearchInCharArrayWhithLimit(char letter, char[] chars, int count, int limit)
        {
            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (chars.Length == 0 || count == limit)
            {
                return 0;
            }

            int i = 0;
            i += letter == chars[0] ? 1 : 0;
            count += i;
            return RecursSearchInCharArrayWhithLimit(letter, chars[1..], count, limit) + i;
        }
    }
}
