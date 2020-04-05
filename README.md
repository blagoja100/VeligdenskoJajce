# VeligdenskoJajce


GET Get Playrooms
https://localhost:44314/api/playrooms/


Example Request
Get Playrooms

curl --location --request GET 'https://localhost:44314/api/playrooms/'

GET Get Available Playrooms
https://localhost:44314/api/playrooms/all


Example Request
Get Available Playrooms

curl --location --request GET 'https://localhost:44314/api/playrooms/all' \
--data-raw ''

POST Create Playroom
https://localhost:44314/api/playrooms/createroom
BODY raw

{
	"OwnerId": 1,
	"OwnerName": "Blago",
	"OwnerPictureUrl": "http://images.com/1",
	"RoomName": "Room 3",
	"RoomPassword" : "12345"
}



Example Request
Create Playroom

curl --location --request POST 'https://localhost:44314/api/playrooms/createroom' \
--data-raw '{
	"OwnerId": 1,
	"OwnerName": "Blago",
	"OwnerPictureUrl": "http://images.com/1",
	"RoomName": "Room 3",
	"RoomPassword" : "12345"
}'

POST Join Room
https://localhost:44314/api/playrooms/joinroom
BODY raw

 {
    "RoomId": 1,
    "RoomPassword": "12345",
    "SecondUserId": 2,
    "SecondUserName": "Marti",
    "SecondUserPictureUrl": "http:image.com/2"
}



Example Request
Join Room

curl --location --request POST 'https://localhost:44314/api/playrooms/joinroom' \
--data-raw ' {
    "RoomId": 1,
    "RoomPassword": "12345",
    "SecondUserId": 2,
    "SecondUserName": "Marti",
    "SecondUserPictureUrl": "http:image.com/2"
}'

POST Game Start
https://localhost:44314/api/playrooms/gamestart
BODY raw

 {
    "RoomId": 1,
    "OwnerId": 1,
    "SecondUserId": 2
}



Example Request
Game Start

curl --location --request POST 'https://localhost:44314/api/playrooms/gamestart' \
--data-raw ' {
    "RoomId": 1,
    "OwnerId": 1,
    "SecondUserId": 2
}'
