using System;
using System.Security.Cryptography;
using System.Text;

namespace BloomFilterSpace;

public class BloomFilter
{
    private readonly int _size;
    private readonly BitArray _bitArray;
    private readonly int _hashCount;

    public BloomFilter(int size, int hashCount)
    {
        _size = size;
        _bitArray = new BitArray(size);
        _hashCount = hashCount;
    }

    private int[] GetHashes(string item)
    {
        var result = new int[_hashCount];
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var hash1 = BitConverter.ToInt32(sha256.ComputeHash(Encoding.UTF8.GetBytes(item)), 0);
            var hash2 = BitConverter.ToInt32(sha256.ComputeHash(Encoding.UTF8.GetBytes(item)), 4);

            for (int i = 0; i < _hashCount; i++)
            {
                var combinedHash = hash1 + (i * hash2);
                result[i] = Math.Abs(combinedHash % _size);
            }
        }

        return result;
    }

    public void Add(string item)
    {
        var hashes = GetHashes(item);
        foreach (var hash in hashes)
        {
            _bitArray.Set(hash, true);
        }
    }

    public bool MightContain(string item)
    {
        var hashes = GetHashes(item);
        foreach (var hash in hashes)
        {
            if (!_bitArray.Get(hash))
            {
                return false;
            }
        }

        return true;
    }
}

