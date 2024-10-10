using BloomFilterSpace;

 var bloomFilter = new BloomFilter(10000, 3);
        bloomFilter.Add("apple");
        bloomFilter.Add("banana");
        bloomFilter.Add("orange");

        Console.WriteLine(bloomFilter.MightContain("apple"));   // True
        Console.WriteLine(bloomFilter.MightContain("banana"));  // True
        Console.WriteLine(bloomFilter.MightContain("grape"));   // False