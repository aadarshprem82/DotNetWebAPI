using System;

class temp{
    static bool isEven(int number){
        return number % 2 == 0;
    }

    static void GetValues(out int a, out int b){
        a = 10;
        b = 20;
    }

    static async Task<int> GetAsync(){
        return 10;
    }

    static int Root(int x) => x * 2;

    static async Task Main(){
        

        // List <int> numbers = new List<int> {1,2,3,4,5};
        // var evenSquare = numbers.Where(x => x%2 == 0).Select(x => x * x).ToList();
        // Console.WriteLine($"{string.Join(',', numbers)} = {string.Join(',', evenSquare)}");

        // var value = Root(16);
        // Console.WriteLine($"Value: {value}");

        // var value = await GetAsync();
        // // var value = GetAsync().Result;       // without task main return type and await
        // Console.WriteLine($"Value: {value}");
        
        // var number = 100123;
        // Console.WriteLine($"{number} is {(isEven(number) ? "even" : "odd")}.");

        // int a, b;
        // GetValues(out a, out b);
        // Console.WriteLine($"Value of a={a}\tb={b}");
    }

}
