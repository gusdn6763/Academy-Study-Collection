var express = require('express');
var router = express.Router();
/* GET users listing. */
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});
/* 회원가입 */
router.post('/signup', function(req, res, next) {

  var username = req.body.username;
  var password = req.body.password;
  var name = req.body.password;

  var db = req.app.get('database');

   if(db == undefined)
  {
    res.json({message:'503 Server Error'});
    return;
  }

  var validate = userValidation(username,password);

  if(validate ==false)
  {
    res.json({message:'400 Bad Request'})
  }

  var usersCollection = db.collection('users');

  usersCollection.count({'username':username},function(err,result)
  {
    if(err) throw(err); 

    if(result > 0) 
    {
      res.json({message: '400 Bad Request'});
      return;
    }
    else
    {
      usersCollection.insertOne({'username':username,'password':password,'name':name},function(err,result)
      {
        if(err) throw(err);
    
        if(result.ops.length > 0)
        res.json(result.ops[0]);
    
        else 
        {
          res.json({message:'503 Server Error'})
        }
      });
    }

  });



});

var userValidation = function(username,password)
{
  if(username == '' || password =='')
  {
    return false;
  }
  if(username.length < 4 || username.length >12)
  {
    return false;
  }
  if(password.length < 4 || password.length >12)
  {
    return false;
  }
  return true;
}

/* 로그인 */
router.post('/signin', function(req, res, next) {

});

module.exports = router;