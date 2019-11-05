# objective
understand basic patterns for resiliency

# tangent
trust but verify

# notes
* resilience
    * the capacity to recover quickly from difficulties; toughness.
        * perhaps Grit (see the book Grit by Angela Duckworth)
* why be resilient?
    * be prepared and able to clearly identify failure scenarios
    * avoid and/or contain cascading failures
    * avoid single points of failure
    * fail gracefully
    * degrade service to avoid failure
* types of resilience mechanisms
    * health check
        * reporting of the current state of the service
        * unhealthy doesn't necessarily mean non-operational
            * could indicate degraded performance
    * timeout
        * don't wait forever for something to complete
        * how do you know how long is too long?
    * retry
        * the network is not reliable
        * when a network call fails, can it be safely tried again automatically
        * good for fixing transient errors
        * be sure to log these failures though
    * circuit breaker
        * if you know something is down (too many retries, failed health check), don't keep erroring out
        * detect repetative errors over an interval of time
        * when detected prevent futher calls
    * rate limiter
        * prevent too many requests from flooding your system
        * you need to know your customer/application to select the correct rate
        * also good to detect changes in the system (e.g., a large positive jump in traffic)
    * bulkhead
        * isolate resources into pools
        * if one pool is compromised, partition it off to preserve the integrity of the service
        * "borrowed" naval term
    * correlation id
        * a specific identifier used in logging messages to trace an execution path through the system
    * compensating transation
        * from event-driven architectures and sagas
        * a transaction over the scope of multiple services
* how to implement
    * by hand
    * via a library (e.g., polly for .NET)
    * sidecar

# references
[msdn - resiliency and high availability in microservices architectures](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/resilient-high-availability-microservices)
[dzone - how to make services resilient in a microservices environment](https://dzone.com/articles/libraries-for-microservices-development)
[dzone - making your microservices resilient and fault-tolerant](https://dzone.com/articles/making-your-microservices-resilient-and-fault-tole-1)
[msdn - resiliency patterns](https://docs.microsoft.com/en-us/azure/architecture/patterns/category/resiliency)