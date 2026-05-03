using System;

public sealed class Logger {
    // private static Logger obj = new Logger();        // Creates object immediately
    private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());      // Better performance and thread safe

    // public static Logger Instance => _instance.Value;
    // SIMILARLY
    public static Logger Instance{
        get {return _instance.Value;}
    }

    private Logger() {
        Console.WriteLine("Logger Created Once");
    }

    public void Log(string message) {
        Console.WriteLine($"[LOG]: {message}");
    }
}

class Singleton {
    static void Main(){
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;

        logger1.Log("Application Started");

        Console.WriteLine(ReferenceEquals(logger1, logger2) ? "Same Instance" : "Different Instance");
    }
}