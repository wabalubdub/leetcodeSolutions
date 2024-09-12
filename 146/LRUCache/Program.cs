using lru;

LRUCache cache = new LRUCache(1);
Console.WriteLine(cache.Get(6));
Console.WriteLine(cache.Get(8));

cache.Put(12,1);
Console.WriteLine(cache.Get(2));
cache.Put(15,11);
cache.Put(5,2);
cache.Put(1,15);
cache.Put(4,2);
Console.WriteLine(cache.Get(4));
Console.WriteLine(cache.Get(2));

cache.Put(15,15);
Console.WriteLine(cache.Get(2));