
using SingletonThreadSafeLazy;

var s1 = Singleton.Instance;
var s2 = Singleton.Instance;

Console.WriteLine(ReferenceEquals(s1, s2)
    ? "Same instance"
    : "Different instances");

s1.DoWork();

Console.WriteLine("Press any key to exit...");
Console.ReadLine();