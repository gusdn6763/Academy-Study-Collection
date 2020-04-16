var app = require('express')();
var http = require('http').createServer(app);
var io = require('socket.io')(http);
var uuidv4 = require('uuid/v4');

//방 여러개 생성
var rooms = [];

io.on('connection', function(socket) {


    //서버 접속시
    socket.emit('res_connect', { clientId: socket.id });
    var roomNumber = 0;
    //유니티에서 이러한 스트링을 전달시
    socket.on('req_joinroom', function(data) {
        //매칭 기능 구현
        var roomIndex = FindRoom();
        if (roomIndex != -1) {
            socket.join(rooms[roomIndex].roomId, function() {
                var client = { clientId: socket.id, ready: false }
                rooms[roomIndex].clients.push(client);

                socket.to(rooms[roomIndex].roomId).emit('res_otherjoinroom', {
                    roomId: rooms[roomIndex].roomId, 
                    otherClientId: socket.id, 
                    clientsNumber: clientsNumber });
                    
            });
        } else {
            //방 만들기 
            var roomId = uuidv4();
            socket.join(roomId, function() {
                var room = { roomId: roomId, clients: [{ clientId: socket.id, ready: false }]};
                rooms.push(room);
                //roomNumber = rooms.cnt;
                socket.emit('res_createroom', { roomId: roomId,roomNumber: roomNumber });
                
            });
        }
    });

        var FindRoom = function() {
            if (rooms.length > 0) {
                for (var i = 0; i < rooms.length; i++) {
                    if (rooms[i].clients.length < 6) {
                        return i;
                    } 
                }
            }
            return -1;
        }


        //방 나가기
    socket.on('req_unjoinroom', function(data) {
        if (!data) return;
        socket.leave(data.roomId, function(result) {
            var room = rooms.find(room => room.roomId == data.roomId);
            if (room) {
                var clients = room.clients;
                for (var i = 0; i < clients.length; i++) {
                    if (clients[i].clientId === data.clientId) {
                        clients.splice(i, 1);
                        socket.emit('res_unjoinroom', { roomId: room.roomId });

                        if (clients.length == 0) {
                            var roomIndex = rooms.indexOf(room);
                            rooms.splice(roomIndex, 1);
                        } else {
                            //나갔다고 정보 전달
                            socket.to(room.roomId).emit('res_otherunjoinroom', { otherClientId: socket.id });
                        }
                    }
                }
            }
        });
    });

    //유니티에서 준비 버튼 입력시 실행
    socket.on('req_ready', function(data) {
        if (!data) return;
        var room = rooms.find(room => room.roomId === data.roomId);

        if (room) {
            var clients = room.clients;
            var client = data.clientId;
            if (client) {
                client.ready = true;
                socket.emit('res_ready');
                socket.to(room.roomId).emit('res_otherready', { otherClientId: socket.id });
            }
            if (clients.length > 1) {
                var cnt = 0;
                for (var i = 0; i < clients.length; i++) {
                    if (clients[i].ready == true) {
                        cnt++;
                    }
                }
                if (clients.length == cnt) {
                    // 모두가 True인 상황
                    io.in(room.roomId).emit('res_play');
                }
            }
        }
    });

    socket.on('req_unready', function(data) {
        if (!data) return;

        var room = rooms.find(room => room.roomId == data.roomId);

        if (room) {
            var clients = room.clients;
            var client = clients.find(client => client.clientId == data.clientId);
            if (client) {
                client.ready = false;
                socket.emit('res_unready');
                socket.to(room.roomId).emit('res_otherunready', { otherClientId: socket.id });
            }
        }
    });

    socket.on('req_createtank', function(data) {
        if (!data) return;

        var clientId = data.clientId;
        var roomId = data.roomId;
        var position = data.position;

        if (roomId) {
            socket.to(roomId).emit('res_othercreatetank', { clientId: clientId, position: position });
        }
    });

    socket.on('req_movetank', function(data) {
        if (!data) return;

        var position = data.position;
        var roomId = data.roomId;
        var clientId = data.clientId;

        if (roomId) {
            socket.to(roomId).emit('res_othermovetank', { clientId: clientId, position: position });
        }
    });

    socket.on('disconnect', function(reason) {
        console.log('Disconnect');

        var room = rooms.find(room => room.clients.find(client => client.clientId === socket.id));
        
        if (room) {
            socket.leave(room.roomId, function() {
                var clients = room.clients;
                var client = clients.find(client => client.clientId === socket.id);
                clients.splice(clients.indexOf(client), 1);
        
                if (clients.length == 0) {
                    rooms.splice(rooms.indexOf(room), 1);
                } else {
                    socket.to(room.roomId).emit('res_otherunjoinroom', { otherClientId: socket.id });
                }
            });
        }
    });
});

http.listen(3000, function() {
    console.log('listening on *:3000');
});