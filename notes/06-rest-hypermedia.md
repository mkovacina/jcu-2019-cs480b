# objective

To have a conversational understanding of REST

# tangent to consider

"You determine your own level of involvement" -- Tyler Durden

# notes

1. REST stands for Representational State Transfer
1. Developed in 94-95 
1. Roy Fielding dissertation published in 2000, "Architecture Styles and the Design of Network-based Software Architectures"
    * a model for how the web should work
    * > motivated by the desire to understand and evaluate the architectural design of network-based application software through principled use of architectural constraints, thereby obtaining the functional, performance, and social properties desired of an architecture.
    * > REST emphasizes scalability of component interactions, generality of interfaces, independent deployment of components, and intermediary components to reduce interaction latency, enforce security, and encapsulate legacy systems.
1. REST is an architectural style
    * it is not bound to HTTP, HTML, TCP/IP, etc
    * it is derived through the application of constraints
1. REST is about resources, not objects
    * the original model of the web was about documents
    * documents were "realized"; they existed or they didn't
    * resources are conceptual (almost philosophical)
        * separation of form from reality
            * think about media types
            * think about interfaces (and contracts)
            * build on the concept/interface not the implementation
    * separate resources can reference the same object
        * (static) the employee is another employees manager
        * (dynamic) the employee is the employee of the week 
1. REST is about the passing the state of interaction
1. Deriving REST
    * two patterns for architecture
        * bottom-up
            * start with nothing and keep adding until requirements are met
            * more emergent and open
        * top-down
            * start with the unconstrained whole system then incrementally apply constraints
    * the bottom-up, "start with nothing" approach is used by Fielding
    1. Start with the Null Style
        * the Null pattern is useful
            * the null set in math
            * the null object patter (i.e., NullFactory)
            * the concept of zero
        * no constraints but no functionality
        * all components are the same
    1. Apply "client-server" constraint
        * separation of concerns
        * separate UI/client from backend
            * the terminology is sometimes illustrative of the thought process being (implicitly) browser centric as opposed to API-oriented
                * note, I'm not saying that Fielding was only thinking about browsers, but REST as an API design mechanism wasn't the primary theme
        * allows for the components to evolve independently
        * allows for the client to be portable
            * i.e., not tied to a specific server/backend
        * allows for simpler server components thus more scalable
    1. Apply "stateless" constraint
        * yup, stateless again
        * each request contains all information necessary to understand the request
            * no stored context on the server
                * thus session state lives with the client
                * what about a database on the backend 
                    * not specifically called out
                    * given the state of the web at the time this might not have been a realistic option
                    * still poses a scalability bottleneck
                        * compare/contrast with the how much extra data must be sent over the network to "keep state"
        * "inducing the -ilities"
            * visibility
                * a single request gives a monitoring system insight
                * a monitoring system does not necessarily need access to the servers
            * reliability
                * recover from partial failures
            * scalability
            * parallelizability
        * reduced server control over application behavior since it is dependent upon the client
    1. Apply "cache" constraint
        * improve network efficiency
        * implicit/explicit marking of data for caching or not
        * can eliminate the need for network calls since the local cache can satisfy the request
        * improved -ilities
            * efficiency(ility)
            * scalability
            * perceived performance
        * must account for dealing with potentially stale data
    1. Apply "uniform constraint" interface
        * uniform interface between components
        * separate out implementation from the service itself (contracts)
            * allows for independent evolvability
        * the four interface constraints of REST
            * identification of resources
            * manipulation of resources through representations
                * data plus metadata
                * remember the discussion about media types
                * this goes back to the difference between the WWW as modeled via documents as opposed to more abstract resources
            * self-descriptive messages
            * hypermedia as the engine of application state (HatEoAS)
                * > an application's state is therefore defined by its pending requests, the topology of connected components, the active requests on those connectors, the data flow of representations in response to those requests, and the processing of those representations as they are received by the user agent
    1. Apply "layered system" constraint
        * allows for system composability
        * encapsulates each layer such that a layer is only aware of its immediate inputs and outputs
        * the inherently limits system complexity (good thing)
        * layers can be used for
            * caching
            * encapsulating legacy systems and services
                * one more step down the road to deprecation
            * enforcing policy (security, resource, etc)
        * disadvantages
            * can add latency
            * management overhead
    1. Apply "code-on-demand" constraint (optional)
        * download and run code to go with the data
        * applets, scripts, javascript
        * security is an issue

    
    
