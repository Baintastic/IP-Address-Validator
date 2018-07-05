using System;

namespace StringCalculator
{
    public class IPAddressValidator
    {
        public bool ValidateIpv4Address(string ipv4Address)
        {
            var valid = true;
            if (string.IsNullOrWhiteSpace(ipv4Address) || hasLetter(ipv4Address))
            {
                return !valid;
            }

            var splitAddress = Split(ipv4Address);
            if (splitAddress.Length != 4 || InvalidHostAddress(splitAddress))
            {
                return !valid;
            }
            return valid;
        }

        private static bool InvalidHostAddress(string[] splitAddress)
        {
            return splitAddress[3] == "0" || splitAddress[3] == "255";
        }

        private bool hasLetter(string ipv4Address)
        {
            foreach (char c in ipv4Address)
            {
                if (char.IsLetter(c))
                    return true;
            }
            return false; ;
        }

        private static string[] Split(string ipv4Address)
        {
            return ipv4Address.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
