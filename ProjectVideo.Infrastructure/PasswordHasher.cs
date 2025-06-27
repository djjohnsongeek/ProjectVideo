using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

// This class is simplified version of Microsoft's own PasswordHasher
// https://github.com/dotnet/aspnetcore/blob/704f7cb1d2cea33afb00c2097731216f121c2c73/src/Identity/Extensions.Core/src/PasswordHasher.cs#L250

namespace ProjectVideo.Infrastructure
{
    public class PasswordHasher
    {
        private readonly int _iterCount;
        private readonly RandomNumberGenerator _rng;
        private int _saltSize;
        private int _bytesRequested;
        private KeyDerivationPrf _prf;

        public PasswordHasher()
        {
            _iterCount = 100_000;
            _rng = RandomNumberGenerator.Create();
            _saltSize = 128 / 8;
            _bytesRequested = 256 / 8;
            _prf = KeyDerivationPrf.HMACSHA512;
        }

        public string HashPassword(string password)
        {
            return Convert.ToBase64String(HashPasswordV3(password));
        }

        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(hashedPassword);
            ArgumentNullException.ThrowIfNullOrEmpty(password);

            byte[] hashedBytes = Convert.FromBase64String(hashedPassword);
            return VerifyHashedPasswordV3(hashedBytes, password);
        }

        private byte[] HashPasswordV3(string password)
        {
            // Produce a version 3 (see comment above) text hash.
            byte[] salt = new byte[_saltSize];
            _rng.GetBytes(salt);
            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, _prf, _iterCount, _bytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; // format marker
            WriteNetworkByteOrder(outputBytes, 1, (uint)_prf);
            WriteNetworkByteOrder(outputBytes, 5, (uint)_iterCount);
            WriteNetworkByteOrder(outputBytes, 9, (uint)_saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + _saltSize, subkey.Length);
            return outputBytes;
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }

        private bool VerifyHashedPasswordV3(byte[] hashedPassword, string password)
        {
            try
            {
                // Read header information
                int saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);

                // Read the salt: must be >= 128 bits
                if (saltLength < 128 / 8)
                {
                    return false;
                }
                byte[] salt = new byte[saltLength];
                Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);

                // Read the subkey (the rest of the payload): must be >= 128 bits
                int subkeyLength = hashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8)
                {
                    return false;
                }
                byte[] expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // Hash the incoming password and verify it
                byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, _prf, _iterCount, subkeyLength);

                return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
            }
            catch
            {
                // This should never occur except in the case of a malformed payload, where
                // we might go off the end of the array. Regardless, a malformed payload
                // implies verification failed.
                return false;
            }
        }
    }
}
