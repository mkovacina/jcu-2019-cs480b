`docker`

this is the basic docker command.
running it will show you the standard usage text


`docker ps`

displays all the running containers


`docker images`

displays a list of images that are in the cache


`docker pull hello-world`

this pulls the docker image for hello-world into the local cache
this is the url: `https://hub.docker.com/_/hello-world`


`docker run hello-world`

launches a container with a hello world program
if the container has not been downloaded it will download it
if the latest is not in the cache it will download the latest first


`docker run busybox echo "hello from busybox"`

launch the busybox container and echo a string


`docker run -it ubuntu bash`
`docker run -i -t ubuntu bash`
`docker run --interactive --tty ubuntu bash`

launches a container with ubuntu then launches bash


`docker help container`

list all the commands that can be run against a container


`docker system prune -a`

clears out all of your local cache
