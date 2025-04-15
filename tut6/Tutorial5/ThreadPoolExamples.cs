namespace Tutorial5;

 /// <summary>
    /// Examples using ThreadPool for concurrency
    /// </summary>
    public static class ThreadPoolExamples
    {
        /// <summary>
        /// Basic ThreadPool usage
        /// Question: What will be the order of the output?
        /// </summary>
        public static void Example1()
        {
            Console.WriteLine("ThreadPool Example 1 started");
            
            Console.WriteLine("Main thread: Queueing work items");
            
            ThreadPool.QueueUserWorkItem(_ => 
            {
                Console.WriteLine("ThreadPool work item 1 executed");
            });
            
            ThreadPool.QueueUserWorkItem(_ => 
            {
                Console.WriteLine("ThreadPool work item 2 executed");
            });
            
            Console.WriteLine("Main thread: Work items queued");
            
            // Give the ThreadPool time to process the work items
            Thread.Sleep(500);
            
            Console.WriteLine("ThreadPool Example 1 completed");
        }

        /// <summary>
        /// ThreadPool with simple wait handle synchronization
        /// Question: What will be the order of the output?
        /// </summary>
        public static void Example2()
        {
            Console.WriteLine("ThreadPool Example 2 started");
            
            // Create a manual reset event to signal when the work is done
            using (ManualResetEvent resetEvent = new ManualResetEvent(false))
            {
                ThreadPool.QueueUserWorkItem(_ => 
                {
                    Console.WriteLine("ThreadPool: Starting work");
                    Thread.Sleep(1000); // Simulate work
                    Console.WriteLine("ThreadPool: Work completed");
                    
                    // Signal that work is complete
                    resetEvent.Set();
                });
                
                Console.WriteLine("Main thread: Waiting for work to complete");
                
                // Wait for the work to complete
                resetEvent.WaitOne();
                
                Console.WriteLine("Main thread: Received completion signal");
            }
            
            Console.WriteLine("ThreadPool Example 2 completed");
        }

        /// <summary>
        /// Multiple work items with state
        /// Question: What will be the order of the output?
        /// </summary>
        public static void Example3()
        {
            Console.WriteLine("ThreadPool Example 3 started");
            
            // A countdown event to wait for all work items to complete
            using (CountdownEvent countdown = new CountdownEvent(3))
            {
                for (int i = 1; i <= 3; i++)
                {
                    int taskNumber = i; // Capture the loop variable
                    
                    ThreadPool.QueueUserWorkItem(_ => 
                    {
                        Console.WriteLine($"Task {taskNumber} started");
                        Thread.Sleep(taskNumber * 200); // Different delays
                        Console.WriteLine($"Task {taskNumber} completed");
                        
                        // Signal that this task is done
                        countdown.Signal();
                    });
                }
                
                Console.WriteLine("Main thread: Waiting for all tasks");
                
                // Wait for all work items to complete
                countdown.Wait();
                
                Console.WriteLine("Main thread: All tasks completed");
            }
            
            Console.WriteLine("ThreadPool Example 3 completed");
        }
        
        /// <summary>
        /// Compare immediate vs. delayed work items
        /// Question: Will the delayed items always execute after immediate ones?
        /// </summary>
        public static void Example4()
        {
            Console.WriteLine("ThreadPool Example 4 started");
            
            // Queue immediate work items
            Console.WriteLine("Queueing immediate work items");
            for (int i = 1; i <= 3; i++)
            {
                int taskNumber = i;
                ThreadPool.QueueUserWorkItem(_ => 
                {
                    Console.WriteLine($"Immediate work item {taskNumber} executing");
                });
            }
            
            // Small delay to let ThreadPool start processing
            Thread.Sleep(100);
            
            // Queue more work items with a small delay
            Console.WriteLine("Queueing delayed work items");
            for (int i = 1; i <= 3; i++)
            {
                int taskNumber = i;
                ThreadPool.QueueUserWorkItem(_ => 
                {
                    Console.WriteLine($"Delayed work item {taskNumber} executing");
                });
            }
            
            // Give time for ThreadPool to process items
            Thread.Sleep(1000);
            
            Console.WriteLine("ThreadPool Example 5 completed");
        }
    }