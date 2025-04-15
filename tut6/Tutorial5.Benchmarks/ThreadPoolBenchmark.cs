using BenchmarkDotNet.Attributes;

namespace Tutorial5.Benchmarks;

public class ThreadPoolBenchmark
{
    [Benchmark]
    public void ExampleWithoutMixMaxThreads()
    {
        Console.WriteLine("ThreadPool Example 4 started");
         
        //Try to check how uncommenting those lines will affect the result
        //ThreadPool.SetMinThreads(2, 2); 
        //ThreadPool.SetMaxThreads(2, 2); 
            
        // Get ThreadPool information
        ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
        ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);
            
        Console.WriteLine($"Default ThreadPool settings:");
        Console.WriteLine($"Min worker threads: {minWorkerThreads}, Min completion port threads: {minCompletionPortThreads}");
        Console.WriteLine($"Max worker threads: {maxWorkerThreads}, Max completion port threads: {maxCompletionPortThreads}");
            
        Console.WriteLine("Queueing multiple work items at once...");
            
        // Queue several work items
        using CountdownEvent countdown = new CountdownEvent(10);
        for (int i = 1; i <= 10; i++)
        {
            int taskNumber = i;
            ThreadPool.QueueUserWorkItem(_ => 
            {
                Console.WriteLine($"Work item {taskNumber} started on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500); // Simulate work
                Console.WriteLine($"Work item {taskNumber} completed");
                countdown.Signal();
            });
        }
        
        countdown.Wait();
        
        Console.WriteLine("ThreadPool Example 4 completed");
    }
    
    [Benchmark]
    public void ExampleWithMinMaxThreads()
    {
        Console.WriteLine("ThreadPool Example 4 started");
        
        ThreadPool.SetMinThreads(2, 2); 
        ThreadPool.SetMaxThreads(2, 2); 
            
        // Get ThreadPool information
        ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
        ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);
            
        Console.WriteLine($"Default ThreadPool settings:");
        Console.WriteLine($"Min worker threads: {minWorkerThreads}, Min completion port threads: {minCompletionPortThreads}");
        Console.WriteLine($"Max worker threads: {maxWorkerThreads}, Max completion port threads: {maxCompletionPortThreads}");
            
        Console.WriteLine("Queueing multiple work items at once...");
            
        // Queue several work items
        using CountdownEvent countdown = new CountdownEvent(10);
        for (int i = 1; i <= 10; i++)
        {
            int taskNumber = i;
            ThreadPool.QueueUserWorkItem(_ => 
            {
                Console.WriteLine($"Work item {taskNumber} started on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500); // Simulate work
                Console.WriteLine($"Work item {taskNumber} completed");
                countdown.Signal();
            });
        }

        countdown.Wait();
            
        Console.WriteLine("ThreadPool Example 4 completed");
    }
}