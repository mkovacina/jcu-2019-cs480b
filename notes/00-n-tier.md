# notes
* class overview
	* class contents
		* this is an overview of many topics
		* many of these topics could be classes themselves
		* breakdown of class time to 8-hour work day
	* Tuesday/Thursday "theory and practice" split
	* When there is homework, it will be Thursday to Thursday
	* Final exam:
	* Wikipedia, Stack Overflow, MSDN, etc.
* layered architectures
	* layer on top depends on layer below (for support)
	* think of it like a layer cake
		* right sized cake for the right event
		* taller the cake, the larger the base...otherwise it crashes...be careful of adding too many layers
			* the first instance of Goldilocks
			* "granularity" -- this is the skill, knowing the right level of coarseness
	* laying provides separation
		* layers can be separated logically (interfaces) or physically (APIs, network)
			* business layer using a data layer abstraction
			* presentation layer calling to a canonical HTTP-based API
		* layers can provide logical separation
		* layers can provide physical separation
			* prevent a client from having an ODBC connection to the database
* 3-tier architecture
	* presentation layer
		* manages user interaction with the system
		* input validation, presentation logic
		* all can talk to the same business logic layer
			* pro: avoiding duplication of logic
			* con: too much/not enough data 
		* multiple presentation layers (web, mobile)
	* business logic layer (domain)
		* provides the core business processes and logic
		* can be called the application server
		* exposes service interfaces
	* data layer
		* database system, etc.
		* exposes data stored in the system 
		* may expose external data through service interfaces
* 1-tier architecture
	* monolithic application (fat client)
	* all installed on the same machine
	* data stored separately though
	* examples
		* notepad
* 2-tier architecture
	* alternate name is client/server architecture
	* client and server are separated
	* client tier is the presentation layer
	* server tier is the business and data layer
	* the fat can be split between the two layers in any proportion
		* leaning towards the back is better 
* n-tier architecture
	* presentation, application/service, business, data, logging, reporting
		* draw this out with physical/logical separations
	* identifying logical components
		* object-oriented at a different level
	* communication between levels
		* different protocols and why
			* tcp/ip
			* http
			* synchronous versus asynchronous
* benefits of a n-tier architecture
	* independent layers
		* individual security
		* individual scaling
		* ability to load balance
		* this is all easier management (at least between layers)
	* component lifecycle independent of other components
		* as long as you don't break
	* possibly a faster/more responsive application due to parallelism
	* update or replace one part of the system without impacting other parts
	* allows for the potential of code reuse
	* business reasons
		* increased speed of development and deployment
			* easier to add new features -> money
		* reduced cost 
			* more efficient use of hardware (only scale what's needed)
			* more uptime
	* trading one type of complexity for another though
		* each service/layer is simpler
		* complexity of deployment and management overall increases
	* all this individuality comes at a cost
		* more management
		* more complexity
		* more complication
	* be aware of coupling level
		* it isn't "bad"
		* too much is "not good"
		* look at number of incoming/outgoing connections
	* initial startup time/cost might be higher with n-tier
		* agile
		* iterative
		* good OO/design
		* "debt"
* guidelines
		* lower layers should not depend on upper layers
			* keep it a tree, not a graph
		* upper layer (physical) should only interact with the layer below it
			* no end-arounds
			* keeps clear separation and dependencies
			* since the layer below only impacts the layer above, the system is more understandable
			* strict adherence to this rule may introduce unnecessary complexity/strive
				* but so will lack of paying attention to this rule
		* upper layer may interact with other more that the layer below it
			* can improve performance
			* increases complexity and coupling
			* more applicability to layers in the same logical tier
			* harder to reason about the impact to a change in layer/service
		* the key is the abstraction/interface between the layers
			* this is what allows for the "loose coupling"
			* without this you can't change dependent components without changing code
			* interface, base class, contract, API
* SOLID as applied to n-tier
	* Single responsibility
		* a service should have a single, well-defined responsibility
		* "encapsulation"
	* Open-closed
		* less directly applicable, but teams own their own
	* Liskov substitution principle
		* design by contract
		* components should be replicable with instances following the same contract
	* Interface segregation
		* many specific interfaces better than one general
		* there is no silver bullet
		* balance with DRY
	* Dependency inversion
		* depend up abstractions....depend upon API
		* "loose coupling"
* CAP Theorem
	* definition
		* Consistency: every read receives the most recent data
		* Availability: every request receives a response (errors don't count)
		* Partition tolerance: system operates with arbitrary number of messages being dropped
	* network failures are going to happen, so decide between consistency and availability
		* with a perfect network, you can have all 3
	* further decisions between latency and consistency
		* this is more real-world
		* a variation on availability
		* high-availability versus replication
* Fallacies of distributed computing
	* The network is reliable
	* Latency is zero
	* Bandwidth is infinite
	* The network is secure
	* Topology doesn't change
	* There is one administrator
	* Transport cost is zero
	* The network is homogeneous



# References
0. [MSDN: N-tier Data Applications Overview](https://docs.microsoft.com/en-us/visualstudio/data-tools/n-tier-data-applications-overview?view=vs-2019)
0. [Wikipedia: Multitier Architecture](https://en.wikipedia.org/wiki/Multitier_architecture)
0. [MSDN: Layered Applications](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff650258%28v%3dpandp.10%29)
0. [Wikipedia: SOLID](https://en.wikipedia.org/wiki/SOLID)
0. [LinuxJournal: 3-tier architecture](https://www.linuxjournal.com/article/3508)
0. [MSDN: Design Fundamental](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ee658116(v=pandp.10))