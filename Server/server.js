const ws = require("ws");
const server = new ws.Server({ port: 8081 });

const fs = require('fs');
let dataFile = fs.readFileSync('./playerData.json');

server.on("listening", () => {
    console.log("서버가 열렸습니다!");
});

server.on("connection", client => {
    client.on("message", messages => {
        
    });

});