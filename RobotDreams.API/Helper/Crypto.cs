using System.Security.Cryptography;
using System.Text;

namespace RobotDreams.API.Helper
{
    public static class Crypto
    {
        public static string EncryptPassword(string password)
        {
            return Algorithms.RijndaelEncrypt(password);
        }

        public static string DecryptPassword(string password)
        {
            return Algorithms.RijndaelDecrypt(password);
        }

        public static string GenerateRandomInt(int length = 2)
        {
            return Algorithms.GenerateRandomInt(length, length);
        }

        public static string GenerateRandomString(int length = 8)
        {
            return GenerateRandomString(length, length);
        }

        public static string GenerateRandomString(int minLength = 8, int maxLength = 8)
        {
            return Algorithms.GenerateRandomString(minLength, maxLength);
        }

        public static int RandomNumber(int min, int max)
        {
            var rnd = new Random();
            return rnd.Next(min, max);
        }

        public static class Algorithms
        {
            private const string PasswordCharsLcase = "abcdefgijkmnopqrstwxyz";
            private const string PasswordCharsUcase = "ABCDEFGHJKLMNPQRSTWXYZ";
            private const string PasswordCharsNumeric = "0123456789";

            public static string GenerateRandomString(int minLength, int maxLength)
            {
                if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
                    return null;

                var charGroups = new[]
                             {
            PasswordCharsLcase.ToCharArray(),
            PasswordCharsUcase.ToCharArray(),
            PasswordCharsNumeric.ToCharArray()
        };

                var charsLeftInGroup = new int[charGroups.Length];
                for (var i = 0; i < charsLeftInGroup.Length; i++) charsLeftInGroup[i] = charGroups[i].Length;
                var leftGroupsOrder = new int[charGroups.Length];
                for (var i = 0; i < leftGroupsOrder.Length; i++) leftGroupsOrder[i] = i;
                var randomBytes = new byte[4];
                var rng = new RNGCryptoServiceProvider();
                rng.GetBytes(randomBytes);
                var seed = (randomBytes[0] & 0x7f) << 24 | randomBytes[1] << 16 | randomBytes[2] << 8 | randomBytes[3];
                var random = new Random(seed);
                var password = minLength < maxLength ? new char[random.Next(minLength, maxLength + 1)] : new char[minLength];
                var lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                for (var i = 0; i < password.Length; i++)
                {
                    var nextLeftGroupsOrderIdx = lastLeftGroupsOrderIdx == 0 ? 0 : random.Next(0, lastLeftGroupsOrderIdx);
                    var nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];
                    var lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;
                    var nextCharIdx = lastCharIdx == 0 ? 0 : random.Next(0, lastCharIdx + 1);
                    password[i] = charGroups[nextGroupIdx][nextCharIdx];
                    if (lastCharIdx == 0)
                        charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
                    else
                    {
                        if (lastCharIdx != nextCharIdx)
                        {
                            var temp = charGroups[nextGroupIdx][lastCharIdx];
                            charGroups[nextGroupIdx][lastCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
                            charGroups[nextGroupIdx][nextCharIdx] = temp;
                        }
                        charsLeftInGroup[nextGroupIdx]--;
                    }

                    if (lastLeftGroupsOrderIdx == 0)
                        lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                    else
                    {
                        if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                        {
                            var temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                            leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
                            leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                        }
                        lastLeftGroupsOrderIdx--;
                    }
                }
                return new string(password);
            }

            public static string GenerateRandomInt(int minLength, int maxLength)
            {
                if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
                    return null;

                var charGroups = new[]
                             {
                    PasswordCharsNumeric.ToCharArray()
                };

                var charsLeftInGroup = new int[charGroups.Length];
                for (var i = 0; i < charsLeftInGroup.Length; i++) charsLeftInGroup[i] = charGroups[i].Length;
                var leftGroupsOrder = new int[charGroups.Length];
                for (var i = 0; i < leftGroupsOrder.Length; i++) leftGroupsOrder[i] = i;
                var randomBytes = new byte[4];
                var rng = new RNGCryptoServiceProvider();
                rng.GetBytes(randomBytes);
                var seed = (randomBytes[0] & 0x7f) << 24 | randomBytes[1] << 16 | randomBytes[2] << 8 | randomBytes[3];
                var random = new Random(seed);
                var password = minLength < maxLength ? new char[random.Next(minLength, maxLength + 1)] : new char[minLength];
                var lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                for (var i = 0; i < password.Length; i++)
                {
                    var nextLeftGroupsOrderIdx = lastLeftGroupsOrderIdx == 0 ? 0 : random.Next(0, lastLeftGroupsOrderIdx);
                    var nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];
                    var lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;
                    var nextCharIdx = lastCharIdx == 0 ? 0 : random.Next(0, lastCharIdx + 1);
                    password[i] = charGroups[nextGroupIdx][nextCharIdx];
                    if (lastCharIdx == 0)
                        charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
                    else
                    {
                        if (lastCharIdx != nextCharIdx)
                        {
                            var temp = charGroups[nextGroupIdx][lastCharIdx];
                            charGroups[nextGroupIdx][lastCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
                            charGroups[nextGroupIdx][nextCharIdx] = temp;
                        }
                        charsLeftInGroup[nextGroupIdx]--;
                    }

                    if (lastLeftGroupsOrderIdx == 0)
                        lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                    else
                    {
                        if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                        {
                            var temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                            leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
                            leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                        }
                        lastLeftGroupsOrderIdx--;
                    }
                }
                return new string(password);
            }
            public static string RijndaelEncrypt(string text)
            {
                return RijndaelEncrypt(text, new Guid("6042386F-0228-4188-830B-8AEAFA25FEB3"), new Guid("6BE33EFC-1CA1-46C0-BD35-99172499B143"));
            }

            public static string RijndaelEncrypt(string text, Guid key, Guid iv)
            {
                var value = new UTF8Encoding(false).GetBytes(text);

                using (var stm = new MemoryStream())
                {
                    var rij = Rijndael.Create();
                    rij.Key = key.ToByteArray();
                    rij.IV = iv.ToByteArray();
                    using (var cs = new CryptoStream(stm, rij.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(value, 0, value.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    return Convert.ToBase64String(stm.ToArray());
                }
            }

            public static string RijndaelDecrypt(string text)
            {
                return RijndaelDecrypt(text, new Guid("6042386F-0228-4188-830B-8AEAFA25FEB3"), new Guid("6BE33EFC-1CA1-46C0-BD35-99172499B143"));
            }

            public static string RijndaelDecrypt(string text, Guid key, Guid iv)
            {
                try
                {
                    var value = Convert.FromBase64String(text);

                    using (var stm = new MemoryStream())
                    {
                        var rij = Rijndael.Create();
                        rij.Key = key.ToByteArray();
                        rij.IV = iv.ToByteArray();
                        using (var cs = new CryptoStream(stm, rij.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(value, 0, value.Length);
                            cs.Flush();
                            cs.Close();
                        }
                        var byResult = stm.ToArray();
                        return new UTF8Encoding(false).GetString(byResult, 0, byResult.Length);
                    }
                }
                catch (Exception ex)
                {
                    return "";
                }
            }

            public static string HexEncode(IEnumerable<byte> value)
            {
                const string hex = "0123456789abcdef";
                var sb = new StringBuilder();
                foreach (byte t in value)
                {
                    sb.Append(hex[(t & 0xf0) >> 4]);
                    sb.Append(hex[t & 0x0f]);
                }
                return sb.ToString();
            }

        }
    }
}
