using System.Globalization;
using System.Text.RegularExpressions;

namespace RobotDreams.API.Helper
{
    public static class RegExUtilities
    {
        public static bool IsValidEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsPhoneNumberCorrect(string phoneNumber)
        {
            //3087774825
            //(281)388 - 0388
            //(281)388 - 0300
            //(979) 778 - 0978
            //(281)934 - 2479
            //(281)934 - 2447
            //(979)826 - 3273
            //(979)826 - 3255
            //1334714149
            //(281)356 - 2530
            //(281)356 - 5264
            //(936)825 - 2081
            //(832)595 - 9500
            //(832)595 - 9501
            //281 - 342 - 2452
            //1334431660

            return Regex.IsMatch(phoneNumber, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
        }
    }
}
