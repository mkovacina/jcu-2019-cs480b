Reference
https://docs.docker.com/get-started/part2/

Setup
Be sure you are in the `.\node-bulletin-board\bulletin-board-app\` directory

`docker image build -t bulletinboard:1.0 .`

creates the image for the application 

`docker container run --publish 8000:8080 --detach --name bb bulletinboard:1.0`

runs the container
forwards port 8000 in the container to port 8000 on the machine

`docker container rm --force bb`

removes the container


