# objective

# tangent

Compare and contrast (epic quote battle??)

"Perfect is the enemy of the good" -- Voltaire
-vs-
"Delay is preferable to error" -- Thomas Jefferson

# notes
## from last time
* what does dancing have to do with anything?
	* Choreography - each local transaction publishes domain events that trigger local transactions in other services
	* Orchestration - an orchestrator (object) tells the participants what local transactions to execute

* Setup test for controller

## event-based architecture
* examples
	* a restaurant kitchen 
	* IoT
	* elevators (WSJ, elevators as a service)
* can be used with SOA, SBA, microservices
* basic flow
	* event detection
	* event notification
	* event processing
* a producer-consumer pattern
	* producers of the event are decoupled from consumers of the event
	* consumers of the event are decoupled
		* not competing consumer
* compare and contrast
	* request/response
	* message-based
	* event-based
* basic components
	* event
		* "a significant change in state"
		* types: causal, spatial, temporal
	* event notification
		* a message containing information about an event that occurred
		* just enough information to be self-describing
		* may contain a link back to the source system for subsequent querying
	* source/emitter/agent
		* a system that generates events
		* does not know who is consuming the event
	* sink/consumer
		* a system that consumes events
		* does not (necessarily) know who triggered the event
	* channel
		* the medium that conveys events between sources and sinks
		* examples could be an ESB or a message queue
* two basic models
	* pub/sub
		* consumers subscribe to "topics"
		* once an event notification is consumer, subsequent subscribers will not see it
	* event stream
		* events are written to a log with strict ordering in a durable manner
		* this is a log/journal
		* consumers can walk the entire history
* consumer event processing styles
	* simple event
		* an event is detected, notified, and something responds
		* example
			* event: a new quote by Thomas Jefferson is added
			* response: send an email to everyone subscribed to Thomas Jefferson
	* event stream
		* a stream of events events are processed for notability 
		* used for pattern detection
		* stream processors may transduce data into subsequent streams
		* examples
			* fraud detection on your credit card
			* high-frequency trading
	* complex event
		* using patterns of simple events to infer that something complex has happened
		* looking for a confluence of events over varying timescales
		* 
	* online event
* dealing with distributed transactions
	* sagas
		* series of localized transactions paired with compensating transactions
		* choreographed versus orchestrated
* analysis
	* advantages
		* simplifies horizontal scaling...scale sinks proportional to event rate
		* resilient due to decoupled (and stateless...)
		* loose coupling at the deployment and concept-level
		* easy to add new functionality quickly
		* easily distributable
		* can handle high volume and high velocity of data
	* disadvantages
		* distributed transactions more complex to manage
		* guaranteed delivery can be challenging
		* exactly-once delivery is difficult
			* must be able to handle seeing an event twice



# references
[Event-Driven Architecture Overview](http://elementallinks.com/el-reports/EventDrivenArchitectureOverview_ElementalLinks_Feb2011.pdf)
[MSDN - Event-driven architecture style](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/event-driven)
[ACM - Online Event Processing](https://queue.acm.org/detail.cfm?id=3321612)
[Fowler - What do you mean by 'Event-Driven'](https://martinfowler.com/articles/201701-event-driven.html)
[Apache Kafka](https://www.confluent.io/blog/apache-kafka-for-service-architectures/)
[WSJ - Elevators as a service](https://www.wsj.com/articles/going-up-the-elevator-as-a-service-business-11570440600)