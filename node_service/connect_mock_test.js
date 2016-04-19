var connect = require('connect');
var http = require('http');
var mocker = require('connect-api-mocker-adv-v2');

console.log("1");

var cors = require('cors'); 
var app = connect();

console.log("2");

app.use(cors());

 var   options = {
      urlRoot: '/api',
      pathRoot: 'mocks',
      ignoreQuery: false
    };
    
console.log("3");	
    
app.use(mocker(options));

console.log("4");	

//create node.js http server and listen on port
http.createServer(app).listen(3000, "0.0.0.0");

console.log("5");	
