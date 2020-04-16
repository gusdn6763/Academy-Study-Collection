var express = require('express');
var router = express.Router();
var mongodb = require('mongodb');

/* 클라이언트가 서버에게 채팅 메시지 전송 */
router.post('/add', function(req, res, next) {
    var message = req.body.message;  
    var db = req.app.get('database');

    var userId = req.session.user_id;

    if (userId) {
        // 1. 유저 이름 찾기
        var usersCollection = db.collection('users');
        usersCollection.findOne({_id:mongodb.ObjectID(req.session.user_id)}, 
            {projection:{_id:false, name:true}},
            function(err, usersResult) {
                if (err) throw(err);

                // 2. 메시지의 Seq. 찾기
                var countersCollection = db.collection('counters');
                countersCollection.findOneAndUpdate({_id:"chatcounter"}, {$inc:{seq:1}}, {returnOriginal:false}, function(err, result) {
                    if (err) throw(err);
                    console.log(result);

                    // 3. chat collection에 메시지 추가하기
                    var chatCollection = db.collection('chat');
                    chatCollection.insertOne({_id:result.value.seq, 
                        message: message, name: usersResult.name, date: Date()}, 
                        function(err, result) {
                            if (err) throw(err);
                            res.status(200).json({message:"Ok"});
                    });
                });
            });    
    } else {
        res.status(401).send('로그인이 필요합니다');
    }
});

/* 서버에서 클라이언트로 메시지 전송 */
router.get('/:seq', function(req, res, next) {
    var db = req.app.get('database');
    var chatCollection = db.collection('chat');

    var seq = Number(req.params.seq);

    if (seq == 0) {
        chatCollection.find().sort({_id:-1}).limit(1).toArray(function(err, result) {
            if (err) throw(err);
            var resultStr = JSON.stringify({objects: result});
            res.status(200).json({message: resultStr});
        });
    } else {
        chatCollection.find({_id:{'$gt':seq}}).sort({_id:-1}).toArray(function(err, result) {
            if (err) throw(err);
            var resultStr = JSON.stringify({objects: result});
            res.status(200).json({message: resultStr});
        });
    }
});

module.exports = router;
