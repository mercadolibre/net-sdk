var express = require('express');
var fs = require('fs');

var app = express.createServer();

app.configure(function(){
    app.use(express.methodOverride());
    app.use(express.bodyParser());
});

app.post('/oauth/token', function(req, res) {
    if(req.query["grant_type"]=="authorization_code") {
        if(req.query["code"]=="bad code") {
            res.send({"message":"Error validando el parámetro code","error":"invalid_grant","status":400,"cause":[]}, 400);
        } else if(req.query["code"]=="valid code without refresh token") {
            res.send({
                   "access_token" : "valid token",
                   "token_type" : "bearer",
                   "expires_in" : 10800,
                   "scope" : "write read"
            });
        } else if(req.query["code"]=="valid code with refresh token") {
            res.send({
                   "access_token" : "valid token",
                   "token_type" : "bearer",
                   "expires_in" : 10800,
                   "refresh_token" : "valid refresh token",
                   "scope" : "write read"
            });
        } else {
            res.send(404);
        }
    } else if(req.query['grant_type']=='refresh_token') {
        if(req.query['refresh_token']=='valid refresh token') {
            res.send({
                   "access_token" : "valid token",
                   "token_type" : "bearer",
                   "expires_in" : 10800,
                   "scope" : "write read"
            });
        }
    }
});

app.get('/sites', function(req, res) {
    res.send([{"id":"MLA","name":"Argentina"},{"id":"MLB","name":"Brasil"},{"id":"MCO","name":"Colombia"},{"id":"MCR","name":"Costa Rica"},{"id":"MEC","name":"Ecuador"},{"id":"MLC","name":"Chile"},{"id":"MLM","name":"Mexico"},{"id":"MLU","name":"Uruguay"},{"id":"MLV","name":"Venezuela"},{"id":"MPA","name":"Panamá"},{"id":"MPE","name":"Perú"},{"id":"MPT","name":"Portugal"},{"id":"MRD","name":"Dominicana"}]);
});


app.get('/users/me', function(req, res) {
    if(req.query['access_token']=='valid token') {
        res.send({"id":123456,"nickname":"foobar"});
    } else if(req.query['access_token']=='expired token') {
        res.send(404);
    } else {
        res.send({"message":"The User ID must match the consultant's","error":"forbidden","status":403,"cause":[]}, 403);
    }
});


app.post('/items', function(req, res) {
    if(req.query['access_token']=='valid token') {
        if(req.body && req.body.foo == "bar") {
            res.send(201);
        } else {
            res.send(400);
        }
    } else if(req.query['access_token']=='expired token') {
        res.send(404);
    } else {
        res.send(403);
    }
});


app.put('/items/123', function(req, res) {
    if(req.query['access_token']=='valid token') {
        if(req.body && req.body.foo == "bar") {
            res.send(200);
        } else {
            res.send(400);
        }
    } else if(req.query['access_token']=='expired token') {
        res.send(404);
    } else {
        res.send(403);
    }
});

app.delete('/items/123', function(req, res) {
    if(req.query['access_token']=='valid token') {
        res.send(200);
    } else if(req.query['access_token']=='expired token') {
        res.send(404);
    } else {
        res.send(403);
    }
});

app.get('/echo/user_agent',function(req,res) {
    if (req.headers['user-agent'].match(/MELI-NET-SDK-.*/))
        res.send(200);
    else 
        res.send({"message":"The user agent didn't match the expected string " + req.headers['user-agent'],"error":"user-agent-mismatch","status":400,"cause":[]}, 400);
        
});

app.listen(3000);

fs.writeFileSync('/tmp/mockapi.pid', process.pid);
