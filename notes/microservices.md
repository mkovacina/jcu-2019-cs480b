# objective
to provide an overview of the microservices philosophy

# tangent

you dont need to be the leader to lead

DAEMON
detatch
aggressive
ego
misson
ownership
negotiation

# notes
- "an approach to developing a single application as a suite of small services, each running in its own process and communicating with lightweight mechanisms, often an HTTP resource API" [1]
- built around business capabilities
    - sounds like "service-based"
- deployed independently
- deployed via automation
    - one of the differentiators from a philosophy standpoint
- mininum of centralized management
- benefits
	- module boundaries
	- independent deployment (autonomous)
	- technology diversity:q
		- possibly easier to move along with the wave of technology evolution
	- multiple teams
	- scalability
	- agile (not Agile)
	- full stack team
	- aligns well to a domain driven design approach with respect to the single-responsibility principle
- challenges
	- technology diversity
	- full stack team
	- all the challenges (or fun) of distributed computing (the fallacies)
	- operational complexity
		- for developers, operations, etc...
	- CAP theorem
	- increased resource requirements
		- more processes, more machines, more memory
- requirements
	- stateless (again...)
	- clear domain boundaries
	- automation
		- testing
		- deployment
	- loose coupling to other services (contracts...)
		- API as a first class concept
- how do i know if my microservice is too big
	- connection diagrams
		- afferent, efferent, and total connections
- the "microservices premium"
	- upgront cost of design, hardware
- monolith first?
	- microservices are successful once you know what you are actually trying to do
	- also can be said of any technique that you 

	
# references
[1] [fowler: microservices](https://martinfowler.com/articles/microservices.html)

[2] [fowler: microservices guide](https://www.martinfowler.com/microservices/)

[3] [microservices.io](https://microservices.io


