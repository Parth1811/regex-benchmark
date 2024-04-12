﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

class Benchmark
{
    static void Main(string[] args)
    {
        if (args.Length <= 1)
        {
            Console.WriteLine("Usage: benchmark <filename> regex1 [regex2 ...]");
            Environment.Exit(1);
        }

        StreamReader reader = new System.IO.StreamReader(args[0]);
        string data = reader.ReadToEnd();

        for (int i = 1; i < args.Length; i++)
        {
            Benchmark.Measure(data, args[i]);
        }
        // // Email
        // Benchmark.Measure(data, @"[\w\.+-]+@[\w\.-]+\.[\w\.-]+");

        // // URI
        // Benchmark.Measure(data, @"[\w]+://[^/\s?#]+[^\s?#]+(?:\?[^\s#]*)?(?:#[^\s]*)?");

        // // IP
        // Benchmark.Measure(data, @"(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9])\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9])");
    }

    static void Measure(string data, string pattern)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        MatchCollection matches = Regex.Matches(data, pattern);
        int count = matches.Count;

        stopwatch.Stop();

        Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds.ToString("G", System.Globalization.CultureInfo.InvariantCulture) + " - " + count);
    }
}
