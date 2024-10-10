namespace BloomFilterSpace;

public class BitArray
{
    private readonly bool[] _bitArray;

    public BitArray(int size)
    {
        _bitArray = new bool[size];
    }

    public bool Get(int index)
    {
        return _bitArray[index];
    }

    public void Set(int index, bool value)
    {
        _bitArray[index] = value;
    }
}