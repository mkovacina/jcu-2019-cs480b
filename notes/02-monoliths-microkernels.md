# objectives

# notes

* > organizations which design systems … are constrained to produce designs which are copies of  the communication structures of these organizations
    -- Melvin E. Conway

* Having a clear understanding of the "what" makes the "how" much easier
    * seems obvious and easy
        * guess what....

## one view of the development lifecycle
* macro: the time to develop the product
* meso: proof of concept, prototype, production
    * proof of concept
        * quick and dirty, PDQ (program done quickly)
        * minimal tests
        * doesn't cover all edge cases
        * shows that the concept works
        * performance, security, etc. are lesser priority
        * code MUST be thrown out
        * mostly internal; customers probably wont' see this
    * prototype
        * built more methodically
        * major details and some minor details covered
        * not to many "sharp edges"
        * performance and security details come into focus
        * automated testing should be in place
        * code MAY be thrown out
        * internal and external
        * minimal documentation
    * production
        * no sharp edges
        * full-breadth of automated tests
        * full documentation
        * all hardening happens here (security, performance, etc.)
* micro: iterations/agile
* individual: work days

## monoliths
 * > Monolithic architecture describes buildings which are carved, cast or excavated from a single piece of material, historically from rock
 * built as a single unit
 * ball of mud
 * a larger system can have monolithic components
    * client, server, database
        * 3-tier architecture built from 2.5 monoliths
* > using the phrase "anti-pattern" is an "anti-pattern"
* benefits of a monolith
    * simple to deploy
    * quick to get started with
    * easy to scale for more transaction volume
    * easy to test when small
* disadvantages of a monolith
    * complexity increases over time
        * progressively difficult to add new features
        * progressively difficult to fix bugs
        * progressively difficult to test
            * startup gets slow as it gets bigger
        * initial development speed falls as size increases
            * longer to pull the code
            * longer to build the code
            * longer to find all the places that touch your code
            * tooling might get bogged down/crash
            * greater chance of conflict on merge
            * difficult but not impossible to have multiple teams own different parts
                * requires coordination, and talking is the most difficult of all technical problems
    * expensive to scale
        * needs resources for the whole application
    * difficult to scale
        * one module is CPU intensive, one GPU, and one memory
    * a lot of work to deploy a small fix
    * one part crashes, the whole thing comes crashing down ("blast radius")
    * limitations on developer choice
        * all developers in the monolith mostly likely will be forced to used the same
            * language/runtime 
                * move to new VS for C++
                * can't get to latest C#
            * source control repository
            * versions of libraries
            * communication protocols
    * slow to onboard new developers ("intimidating")
* how and when to build a monolith
    * Fowler
    * good for proofs of concept
    * good for prototypes and even initial production
    * shipping ok software is better than never shipping perfect software
        * agile...
        * "no plan survives contact with the enemy" 
            * Helmuth Karl Bernhard Graf von Moltke
            * the customer is not the enemy, but...
        * making a decision (shipping when it is good enough) is better than not making a decision at all (not shipping until every detail is complete)
            * another goldilocks problem
    * use the initial development speed to make progress
        * but speed is not an excuse to be sloppy
        * think about your layers
        * think about what success is going to look like
        * make decisions that are oriented in the general direction of where you want to go
    * options once you are established
        * break it apart
        * peel it apart
        * sacrifice it

## modular monoliths
* two ways to view this
    * the next step after a monolith
    * an alternative to microservices
* back to the layers again...sort of
* less about object-orient and more about domain-oriented
    * think about the interaction between concepts, not objects
    * add new/refactor old with API design in mind
        * APIs aren't just REST
        * the public classes/properties on your assembly are an API
    * coupling to the interface and not the implementation
* differences between monoliths and modular monoliths
    * clear intent to separate between layers and domains
* the same advantages and disadvantages of a monolith apply
* whereas monoliths tend to evolve, modular monoliths tend to have more "design"
* the module separation can happen in different ways
    * trust (all in the same repo/project)
    * same repo, different libraries linked together
    * plug-in model
        * same or separate repo
        * DIY or use an existing plug-in framework
        * starting to get into dependency conflicts
        * might be able to isolate module crashes 
        * starting to get faster builds
        * teams might have more autonomy over process if not tools
        * testing might get more manageable
        * now you need a team to own the plug-in framework
    * submodules, etc., etc.
* it's never too late to try to make things better
    * the longer you wait the more retrofitting you will have to do
    * often times you will need intermediary ("transition") states
        * scaffolding...necessary but temporary
    * like walking through a large town
        * the new and the old stand in stark contrast
    * "gradually" versus "boil the ocean"

## microkernel
* more than just for operating systems
* similarities to the "command pattern" from design patterns
* can be seen as an evolutionary step from a modular monolith
* the microkernel provides "just enough" for others to build upon
* this is one method of implementing a plug-in model
* two components
    * microkernel/core system
        * provides common functionality, such as...
        * responsible for loading the plugins
            * hard linked
            * blind reflection
            * manifest/registry
        * dictates how the core talks to modules
            * this is another API/contract
            * just because this is a microkernel doesn't mean you can't use the network
            * methods include
                * direct reference
                * shared memory
                * network
                    * tcp/ip, web service, messages, etc.
                * as always, you must know what you are trying to do
        * the microkernel is the orchestrator
    * plugins
        * should be independent
        * provide a specific piece of functionality
        * be a good neighbor
        * should have an adapter layer that separates the business logic from the plugin contract bits
            * what if the contract changes?
            * what if you want to use the business logic somewhere else?
            * what if you want to test your business logic? (gasp)
* avoid modules depending on each other
    * it can be done but then you get into dependency problems 
        * see Eclipse
    * if you see a module that everyone depends on, consider bringing it into the microkernel
* advantages of a microkernel
    * isolation (domain, product, team, ...)
    * quickly add new functionality
    * easy to deploy
    * quick to add new features
    * teams have more levels of autonomy
    * plugin teams can have less to worry about (deployment, etc.)
* disadvantages of a microkernel
    * can be difficult to scale (similar to monoliths)
    * plugin contract versioning can be a headache
    * deployment can be difficult if too flexible
        * e.g., java beans and xml files
        * this is a pro/con double edged sword
        * i.e., people make their own problems
    * conflicting dependencies between plugins
            

 # references
 [Wikipedia: monolithic architecture](https://en.wikipedia.org/wiki/Monolithic_architecture)
 [microservices-v-monoliths](https://www.mulesoft.com/resources/api/microservices-vs-monolithic)
 [mesocycles](https://academy.sportlyzer.com/wiki/mesocycle/)
 [monolithic vs. microservices architecture](https://articles.microservices.com/monolithic-vs-microservices-architecture-5c4848858f59)
 [microservices.io: monolithic architecture pattern](https://microservices.io/patterns/monolithic.html)
 [fowler: monolith first](https://martinfowler.com/bliki/MonolithFirst.html)
 [modular-monolith-microservices](https://mozaicworks.com/blog/modular-monolith-microservices/)
 [o'reilly: microkernel architecture](https://www.oreilly.com/library/view/software-architecture-patterns/9781491971437/ch03.html)