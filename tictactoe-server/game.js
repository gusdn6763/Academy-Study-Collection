const uuidv4 = require('uuid/v4');


module.exports = function(server) {

    var rooms = [];
    var io = require('socket.io')(server, {
        transports:['websocket'],
    });

    io.on('connection', function(socket) {
        console.log("Connection");

        //1. 빈방 확인
        //2. 없으면 만듬
        //3. 있으면 할당
        //4. 2유저가 존재하면 게임시작
        //5. 누가 접속 해제시 그 유저의 방은 게임 종료

        //방 만들기
        var createRoom  = function() {
            var roomId = uuidv4();
            socket.join(roomId, function() {
                var room = { roomId: roomId, clients: [{clientId: socket.id,ready:false}]};
                rooms.push(room);
            });
        }

        //유효한 방 찾기
        var getAvailableRoomId = function() {
            if(rooms.length>0) {
                for(var i = 0;i<rooms.length;i++) {
                    if(rooms[i].clients.length < 2) {
                        return i; 
                    }
                }
            }
            return -1;
        }

        //빈방 찾기
        var roomIndex = getAvailableRoomId();
        if(roomIndex > -1) {
            //접속한 유저 보냄
            socket.join(rooms[roomIndex].roomId, function() {
                var client = {clientId: socket.id,ready:false}
                rooms[roomIndex].clients.push(client);
            });
        } else {
            createRoom();
        }

        socket.on('disconnect',function(reason) {
            console.log("Disconnection");
        });
    });
};