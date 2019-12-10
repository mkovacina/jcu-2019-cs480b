# objective
provide an overview of serverless computing

# notes

- a.k.a. Functions as a Service (FaaS)
- a cloud programming model that eases the operations burden of deployment 
	- execute code in response to a trigger (event-based)
	- develop code on a higher-level platform 
	- run code without provisioning/managing servers
	- "FaaS is about running backend code without managing your own server systems or your own long-lived server applications" [2]
- serverless = FaaS + BaaS (backend as a service.  e.g., managed database, S3 storage)
- characteristics
	- stateless :)
		- more precisely, persisted must be stored externally
	- short execution duration
		- FaaS not equivalent to a job runner (necessarily)
- historical context
	- 2009, two large competitors
		- Amazon EC2: looked and felt like managing physical hardware
			- comfortable for existing IT people
			- more readily amenable to "lift and shift"
			- full control of the environment without needing to manage physical hardware
				- also meant that many cloud "-ilities" weren't "free"/automatic
		- Google App Engine
			- enforced a programming model that separated a stateless application layer from a stateful storage layer
			- provided for automatic scaling and high-availbility
				- driven through the opinionated development model, which mean that Google could make informed decisions about your application given initial constraints
		- the market moved towards the Amazon model, so other clouds offered similar models
			- it was a familiar model
			- open the door for "DevOps"
			- sometimes disruption takes time
	- 2015, Amazon launches AWS Lambda
		- why...
			- because the amount of work to deploy a simple app (less than 100 lines of Javascript) far outweighted the development effort
			- paying for resources to be available even if they aren't being used
- but containers...	
- Existing products
	- AWS Lambda
	- Azure Functions
	- Google Cloud Functions
- triggers
	- timer
	- message (message queue)
	- event
	- HTTP request
- Advantages
	- cost depending on the type of application being built
		- when the application has periods of underutilization
		- "pay-as-you-go"
		- when can it be cost effective
			- spikes in traffic
				- can be cheaper than throwing more (idle) hardware
			- occasional requests
	- automatic horizontal elastic scaling managed by the provider
	- more focus on building the application and not the infrastructure
	- automatic resource provisioning and allocation
	- lower operational overhead
	- possibly shorter dev cycle/time to market
- Disadvantages
	- less control and knowledge of the operational environment
	- more constrained/opinionated environment to enable vendor to meet guarantees (see Google App Engine)
	- cold starts/warm-up time
		- running a program twice takes longer than running a program that performs the computtion twice
		- cold start
			- creating a new execution environment 
			- depends on language, libraries, code size, external resources needed
			- the frequency of cold starts depends on the frequency of your execution
				- e.g., more cold starts if you only execute your function 1 per hour
					- this adds to the overall execution time/responsiveness of your function
					- this is "ok" depending on what you are doing
		- warm start: reusing an existing base execution environment
	- more constrained resource limits
		- providers need to make sure everyone plays nice
			- can't take up terabytes of RAM to model training, for example
	- difficult to debug/monitor/test
	- vendor lock-in if you are not careful
		- even if you are, it is difficult/expensive to be vendor-neutral
- like assembly versus C, or maybe C versus C++/C#

# reference
1. [Cloud Programming Simplified: A Berkeley View on Serverless Computing](https://www2.eecs.berkeley.edu/Pubs/TechRpts/2019/EECS-2019-3.pdf)
2. [Fowler, FaaS](https://martinfowler.com/articles/serverless.html#unpacking-faas)
