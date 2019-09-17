# objective
* to provide a basic understanding of HTTP

# tangent to ponder
* "the beatings will continue until morale improves"

# notes
## http
* http = hypertext transfer protocol
* origin at CERN with Tim Berners-Lee in 1989
* versions
    * 1.0 was the original
    * 1.1 is widely used
    * 2.0 is out there now and server are supporting it
    * 3.0 is being proposed
* text-based, line-oriented stateless client/server protocol at the application layer
* HTTP only presumes a reliable transport
    * TCP/IP isn't the only way
* designed for building distributed, collaborative, hypermedia information systems
* basic terms
    * connection
    * message
    * request
    * response
    * URI/URL
    * resource
        * A network data object or service which can be identified by a
       URI 
    * user-agent
	* header
	* cookie
* media types
    * aka MIME types
    * this is how browsers identify the type of content, not through file extensions
    * format: *type*/*subtype*  with no whitespace
        * two types
            * discrete
                * single file
                * examples
                    * application
                    * image
                    * video
                    * text
            * multipart
                * content broken into pieces
                * examples
                    * message
                        * think email
                    * multipart
                        * think container format like zip
                        * multiple different types of content within
    
    * Internet Assigned Numbers Authority (IANA) responsible for the official list of media types
    * examples
        * text/plain
        * application/octet-stream
        * image/jpeg
* caching
* authentication
    * basic
        * base64 encoding of the username/password 
        * only secure when used with TLS
    * digest access
        * hashing of the username/password
* the verbs
    * GET
        * requests a resource
    * HEAD
        * similar to GET but without the body of the response
        * useful for getting metadata about a resource
    * POST
        * create a new resource
    * PUT
        * full update of a resource
    * PATCH
        * partial update of a resource
    * DELETE
        * delete a resource
    * OPTIONS
        * checks what operations are supported by a specific resource
    * TRACE
        * echoes the requests
        * useful for troubleshooting to see if anything is has been changed by intermediate servers
    * CONNECT
        * for tunneling
    * Safe methods
        * GET, OPTIONS, HEAD, TRACE    
        * intended for information retrieval only
        * should not change the state of the system
        * this is by convention only
    * Idempotent methods
        * PUT, DELETE, GET, OPTIONS, HEAD, TRACE
        * multiple requests should have the same effect as a single request
* status codes
    * 1xx
        * Informational
    * 2xx
        * Success
    * 3xx
        * Redirection
    * 4xx
        * Client error
    * 5xx
        * Server error
## rpc
* remote procedure call
* a form of interprocess communication
* synchronous
* spans the transport and application layer
* request-response pattern
* similar to a normal procedure call, but the execution is in a different memory space
    * might be on a different machine
* overall process
    * [client] calls the stub
    * [client] the stub marshals the parameters
    * [client] send the message to the remote machine
    * [remote] receive the message
    * [remote] unmarshall the message
    * [remote] execute the procedure with the parameters
    * [remote] reverse the process to return the response
* benefits
    * feels like you are just calling another function
    * stub libraries provided for you (sometimes)
    * useful when a REST philosophy doesn't fit
    * philosophically good for designing functional services
* drawbacks
    * seems like you are just calling another function
        * see the fallacies of distributed computing
    * update the stub when the service is updated
        * coordination is hard
* examples of RPC protocols
    * gRPC
    * CORBA
    * COM/DCOM
    * .NET Remoting
    * Java Remoting

# references
[RFC2616](https://www.w3.org/Protocols/rfc2616/rfc2616.html)

[Wikipedia: http](https://en.wikipedia.org/wiki/Hypertext_Transfer_Protocol)

[Wikipedia: http status codes](https://en.wikipedia.org/wiki/List_of_HTTP_status_codes)

[Wikipedia: rpc](https://en.wikipedia.org/wiki/Remote_procedure_call)

