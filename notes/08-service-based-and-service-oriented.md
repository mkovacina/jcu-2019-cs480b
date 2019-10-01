# objective
* to understand the difference between service-based and service oriented architectures

# tangent to ponder
"If you want to change the world, start off by making your bed."
- Admiral William H. McRaven

# notes
## service-oriented
* commonly referred to as SOA
* application is structured into multiple independent services
* HTTP is a common for communication
* based on a request/reply pattern
* synchronous and asynchronous
* >A service has four properties according to one of many definitions of SOA
    a. It logically represents a business activity with a specified outcome.
    b. It is self-contained.
    c. It is a black box for its consumers.
    d. It may consist of other underlying services.[4]
* business logic modularized into services
    * think of the "yellow pages" and how you can lookup services you need
    * thus services are broken into layers
* one can think "are we a" when building services for SOA
    * say there is a ticketing service being discussed
        * that service might not make sense if you can't answer in the affirmative "are we a 'ticketing' company'?
    * similar to "is a" from object-oriented
* platform-agnostic so you can pick the language that best suits the problem
* common components
    * central (message) broker
        * eliminates direct service-to-service coupling
        * eliminates the need for service A to speak the protocol of service B
        * eliminates some of the need for service A to know about some of the message format changes to service B
        * a message broker can deal with needed multiple communication protocols and can provide message transformation capabilities
            * the downside of message transformation capabilities is that the logic for a service is now effectively spread across multiple platform components
    * enterprise service bus
        * >a set of rules and principles for integrating numerous applications together over a bus-like infrastructure [7]
        *  components can communicate without dependency on or knowledge of other systems
        * eliminates the brittleness of point-to-point integrations
    * central orchestrators
    * service registry
        * identity of the dependent service is determined at runtime
        * can be simple such as by name
        * can be more complex to account for factors such as cost, functionality and performance
        * provides the ability to swap/upgrade a service
            * as long as the message contract hasn't changed
    * WSDL/SOAP/Web Services
* benefits
    * service re-use
    * loose coupling via messaging and service discovery
    * monitoring since message based
        * performance
        * troubleshooting
        * auditing and security
    * message transform if using a broker/bus
    * protocol management if using a broker/bus
    * increased agility via composition of existing services into new applications and the ability to quickly add new services
    * independent services make localized troubleshooting easy
    * scalability, reliability, availability
        * assuming you do things right
* disadvantages
    * language sprawl
    * can generate many messages
    * testing due to message transformation logic, overall complexity, ...
    * complex management
# service-based
* break services apart by domain
    * focus on the concept of a bounded context
    * changes to a component stay in the bounded context
    * with SOA, a component change will have to be managed across multiple layers
* when to use it
    * migrating away from a monolithic application

# refences
1. https://www.javaworld.com/article/2071889/what-is-service-oriented-architecture.html
2. https://docs.microsoft.com/en-us/dotnet/architecture/microservices/architect-microservice-container-applications/service-oriented-architecture
3. http://www.opengroup.org/soa/source-book/soa/p4.htm
4. https://en.wikipedia.org/wiki/Service-oriented_architecture
5. https://www.geeksforgeeks.org/service-oriented-architecture/
6. https://www.infoq.com/news/2016/10/service-based-architecture/
7. https://www.mulesoft.com/resources/esb/what-esb